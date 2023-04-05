using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.IO;


#nullable enable
namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    internal class WorkerTask
    {
        public SafeProcessHandle ProcessHandle { private get; set; }

        public Process Process { get; set; }

        public int ExecutionOrder { get; set; }

        public string Target { get; set; }

        public int SleepTime { get; set; }

        public int ProcessId { get; set; }

        public string ProcessName
        {
            get
            {
                try
                {
                    return Path.GetFileName(this.Target);
                }
                catch
                {
                    return this.Target;
                }
            }
        }

        public WorkerTask.WorkerTaskTypeEnum WorkerTaskType { get; set; }

        public enum WorkerTaskTypeEnum
        {
            None,
            Executable,
            UIExecutable,
            Url,
        }
    }
}

