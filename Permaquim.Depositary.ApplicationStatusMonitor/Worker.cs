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
                                
                                var process = Process.GetProcessById(item.ProcessId);
                                if (item.ProcessId == 0 || process.HasExited)
                                {
                                    var startInfo = new ProcessStartInfo();
                                    startInfo.WorkingDirectory = Path.GetDirectoryName(item.Target);
                                    startInfo.UserName = "PERMAQUIM\\Akertesz";
                                    startInfo.FileName = item.Target;
                                    item.ProcessId = Process.Start("CMD.exe","/C "+item.Target).Id;
                                    Log("Detected Process " + item.ProcessName + " NO LONGER RUNNING, STARTING...");
                                }
                                break;

                            default:
                                break;
                        }

                        await Task.Delay(_configuration.GetSection("TaskDelay").Get<int>(), stoppingToken);
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