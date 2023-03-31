using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
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
        private FileInfo _file;

        public Worker(ILogger<Worker> logger, IConfiguration configuration) 
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                string str = AppDomain.CurrentDomain.BaseDirectory + "\\" + this._configuration.GetSection("LogFile").Get<string>();
                this.Log("Starting Service ..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(((object)ex).ToString());
            }
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                this._workerTasks = AppConfiguration.GetWorkerTasks(this._configuration.GetSection("TaskJson").Get<string>());
                this._threads = new Dictionary<WorkerTask, Thread>();
                this.CreateThreads();
                int taskDelay = this._configuration.GetSection("TaskDelay").Get<int>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    this.CheckThreads();
                    await Task.Delay(taskDelay, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                this.Log(((object)ex).ToString());
            }
        }

        private void CreateThreads()
        {
            foreach (WorkerTask workerTask in this._workerTasks)
            {
                Thread thread = this.CreateThread(workerTask);
                this._threads.Add(workerTask, thread);
            }
        }

        private Thread CreateThread(WorkerTask workerTask)
        {
            Thread thread = new(()=>WorkerTaskRun(workerTask));
            thread.Name = workerTask.ProcessName;
            return thread;
        }

        private void CheckThreads()
        {
            foreach (WorkerTask key in this._threads.Keys)
            {
                System.Threading.ThreadState threadState = this._threads[key].ThreadState;
                if (threadState != System.Threading.ThreadState.Unstarted)
                {
                    if (threadState == System.Threading.ThreadState.Stopped || threadState == System.Threading.ThreadState.Aborted)
                    {
                        this._threads[key] = this.CreateThread(key);
                        this._threads[key].Start();
                    }
                }
                else
                    this._threads[key].Start();
            }
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            this.client.Dispose();
            this._logger.LogInformation("The service has been stopped...");
            return StopAsync(cancellationToken);
        }

        private void Log(string log) {
            Console.WriteLine(log);
            var sw = File.AppendText("LogFile.txt");
            sw.WriteLine(log);
            sw.Close();

        }

        private void WorkerTaskRun(WorkerTask task)
        {
            while (true)
            {
                if (!this.IsRunning(task))
                {
                    if (task.Process != null)
                    {
                        int downtimeOfProcess = this.GetDowntimeOfProcess(task.Process);
                        if (downtimeOfProcess < task.SleepTime)
                        {
                            int num = task.SleepTime - downtimeOfProcess;
                            this.Log(string.Concat((string[])new string[5]
                            {
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
                                    Thread.Sleep(num);
                                }
                                catch (Exception ex)
                                {
                                    this.Log(ex.Message + " / " + ex.StackTrace);
                                }
                            }
                            else
                                Thread.Sleep(task.SleepTime - 1000);
                        }
                    }
                    this.LaunchApplication(task);
                }
                Thread.Sleep(1000);
            }
        }

        private int GetDowntimeOfProcess(Process process) => (int)(DateTime.Now - process.ExitTime).TotalMilliseconds;

        private bool IsRunning(WorkerTask task)
        {
            bool flag = true;
            try
            {
                if (task.ProcessId > 0)
                {
                    if (Process.GetProcessById(task.ProcessId).HasExited)
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
        }

        private void LaunchApplication(WorkerTask task)
        {
            switch (task.WorkerTaskType)
            {
                case WorkerTask.WorkerTaskTypeEnum.Executable:
                    task.ProcessId = Process.Start(task.Target).Id;
                    break;
                case WorkerTask.WorkerTaskTypeEnum.UIExecutable:
                    task.ProcessId = NativeMethods.LaunchProcess(task.Target);
                    break;
            }
            if (task.ProcessId <= 0)
                return;
            task.Process = Process.GetProcessById(task.ProcessId);
            task.ProcessHandle = task.Process.SafeHandle;
        }
    }
}
