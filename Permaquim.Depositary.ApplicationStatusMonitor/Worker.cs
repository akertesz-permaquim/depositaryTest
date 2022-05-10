using System.Diagnostics;

namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client = new();
        private List<WorkerTask> _workerTasks = new();
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _workerTasks = AppConfiguration.GetWorkerTasks();
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
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
                            var runningProcessByName = Process.GetProcessesByName(item.Target);
                            if (runningProcessByName.Length == 0)
                            {
                                Process.Start(item.Target);
                            }
                            break;

                        default:
                            break;
                    }
 
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }
    }
}