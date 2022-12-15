using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Security;

namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private HttpClient client = new();
        private List<WorkerTask> _workerTasks = new();
        private FileInfo _file;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _file = new FileInfo(_configuration.GetSection("LogFile").Get<string>());
                _file.Create().Close();
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

                                try
                                {
                                    if (item.ProcessId != 0)
                                    {

                                        var process = Process.GetProcessById(item.ProcessId);
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

                                    NativeMethods.LaunchProcess(@"C:\Windows\notepad.exe");

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
                        }

                        await Task.Delay(500, stoppingToken);
                    }
                }
            }catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }

        private void Log(string log)
        {
            var fs = File.AppendText(_file.FullName);
            fs.WriteLine(log);
            Console.WriteLine(log);
            fs.Close();
            
        }
    }
}