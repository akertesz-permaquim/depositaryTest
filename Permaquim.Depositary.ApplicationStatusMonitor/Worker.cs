using System.Diagnostics;

namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    public class Worker : BackgroundService
    {
        private const int POLL_TIME = 1000;
        private Dictionary<WorkerTask, Thread> _threads;
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private HttpClient client = new HttpClient();
        private List<WorkerTask> _workerTasks = new List<WorkerTask>();

        public Worker(ILogger<Worker> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Log("Starting Service "+_configuration.GetSection("TaskDelay").Get<int>());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

          
            try
            {

                _workerTasks = AppConfiguration.GetWorkerTasks(_configuration.GetSection("TaskJson").Get<string>());
                
                while (!stoppingToken.IsCancellationRequested)
                {

                    NativeMethods.LaunchProcess(@"C:\Windows\notepad.exe");

                    foreach (var item in _workerTasks)
                    {
                        switch (item.WorkerTaskType)
                        {
                            case WorkerTask.WorkerTaskTypeEnum.Url:
                                var result = await client.GetAsync(item.Target);

                                if (result.IsSuccessStatusCode)
                                {
                                    _logger.LogInformation("The website is up. Status code {StatusCode}", result.StatusCode);
                                }
                                else
                                {
                                    _logger.LogError("The website is down. Status code {StatusCode}", result.StatusCode);
                                }
                                break;

                            case WorkerTask.WorkerTaskTypeEnum.Executable:

                                bool isUp = true;


                this._workerTasks = AppConfiguration.GetWorkerTasks(this._configuration.GetSection("TaskJson").Get<string>());
                this._threads = new Dictionary<WorkerTask, Thread>();
                this.CreateThreads(stoppingToken);
                int taskDelay = this._configuration.GetSection("TaskDelay").Get<int>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    this.CheckThreads(stoppingToken);
                    await Task.Delay(taskDelay, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                this.Log(((object)ex).ToString());
            }
        }

        private void CreateThreads(CancellationToken ct)
        {
            foreach (WorkerTask workerTask in this._workerTasks)
            {
                if(!workerTask.FileExists) {
                    if(!workerTask.FileExistCheck)
                    {
                        Log($"{workerTask.ProcessName} has an invalid path. Path: {workerTask.Target}");
                    }
                    continue;
                
                }
                Thread thread = this.CreateThread(workerTask,ct);
                this._threads.Add(workerTask, thread);
            }
        }

        private Thread CreateThread(WorkerTask workerTask,CancellationToken ct)
        {
            Thread thread = new(()=>WorkerTaskRun(workerTask,ct));
            thread.Name = workerTask.ProcessName;
            return thread;
        }
        
        private void CheckThreads(CancellationToken ct)
        {
            foreach (WorkerTask key in this._threads.Keys)
            {
                System.Threading.ThreadState threadState = this._threads[key].ThreadState;
                if (threadState != System.Threading.ThreadState.Unstarted)
                {
                    if (threadState == System.Threading.ThreadState.Stopped || threadState == System.Threading.ThreadState.Aborted)
                    {
                        this._threads[key] = this.CreateThread(key,ct);
                        this._threads[key].Start();
                    }
                }
                else
                    this._threads[key].Start();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken) 
        {
            this.client.Dispose();
            this._logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }

        private void Log(string log) {
            Console.WriteLine(log);
            var sw = File.AppendText("LogFile.txt");
            sw.WriteLine(log);
            sw.Close();

        }

        private void WorkerTaskRun(WorkerTask task, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                if (!this.IsRunning(task))
                {
                    if (task.Process != null)
                    {
                        if(!task.Process.Responding)
                        {
                            task.Process.Kill();
                        }
                        int downtimeOfProcess = this.GetDowntimeOfProcess(task.Process);
                        if (downtimeOfProcess < task.SleepTime)
                        {
                            int num = task.SleepTime - downtimeOfProcess;
                            this.Log(string.Concat((string[])new string[6]
                            {
                                $"{task.ProcessName} down:",
                                (string) "Dt Difference: ",
                                (string) num.ToString(),
                                (string) Environment.NewLine,
                                (string) "Downtime: ",
                                (string) downtimeOfProcess.ToString()
                            }));
                            if (num > 0)
                            {
                                try
                                {
                                    if (task.ProcessId != 0)
                                    {

                                        var process = Process.GetProcessById(task.ProcessId);
                                        if (process.HasExited) isUp = false;
                                    }
                                    else
                                    {
                                        isUp = false;
                                    }
                                }
                                catch (ArgumentException argex)
                                {
                                    isUp = false;
                                }

                                if (!isUp)
                                {

                                    NativeMethods.LaunchProcess(item.Target);

                                    //Thread.Sleep(_configuration.GetSection("TaskDelay").Get<int>());
                                    if (item.ProcessId == 0) Log("Starting process " + item.ProcessName + "...");
                                    //item.ProcessId = Process.Start(item.Target).Id;

                                    //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                                    //System.Security.SecureString ssPwd = new System.Security.SecureString();
                                    //proc.StartInfo.UseShellExecute = true;
                                    //proc.StartInfo.FileName = item.Target;
                                    //proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(item.Target);
                                    //proc.StartInfo.UserName = "SB1015-I5";
                                    //string password = "admin";
                                    //for (int x = 0; x < password.Length; x++)
                                    //{
                                    //    ssPwd.AppendChar(password[x]);
                                    //}
                                    //password = "";
                                    //proc.StartInfo.Password = ssPwd;
                                    //proc.Start();
                                    //item.ProcessId = proc.Id;

                                }
                                break;

                            default:
                                break;
=======
                            }
                            else
                                Thread.Sleep(task.SleepTime - POLL_TIME);
                        }
                    }
                    if (!ct.IsCancellationRequested)
                    {
                        try
                        {
                            this.LaunchApplication(task);
                            task.Failing = false;
                        }catch(Exception ex) {
                            if (!task.Failing)
                            {
                                task.Failing = true;
                                Log(ex.ToString());
                            }
>>>>>>> Stashed changes
                        }

                        await Task.Delay(500, stoppingToken);
                    }
                }
<<<<<<< Updated upstream
            }catch (Exception ex)
            {
                Log(ex.ToString());
=======
                Thread.Sleep(POLL_TIME);
>>>>>>> Stashed changes
            }
        }
private bool IsRunning(WorkerTask task)
        {
            throw new NotImplementedException();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
<<<<<<< Updated upstream
            client.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
=======
            bool flag = true;
            try
            {
                if (task.ProcessId > 0)
                {
                    var process = Process.GetProcessById(task.ProcessId);
                    if (process.HasExited || !process.Responding)
                        flag = false;
                }
                else
                    flag = false;
            }
            catch (ArgumentException ex)
            {
                flag = false;
            }
            return flag;
>>>>>>> Stashed changes
        }

    }
}