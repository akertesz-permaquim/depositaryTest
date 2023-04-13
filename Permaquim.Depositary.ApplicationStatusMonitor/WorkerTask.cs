namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    internal class WorkerTask
    {
<<<<<<< Updated upstream
=======
        public bool Failing { get; set; }
        private bool _fileCheck = false;
        public bool FileExistCheck { get
            {
                if (!_fileCheck)
                {
                    _fileCheck = true;
                    return false;
                }
                return _fileCheck;
            }
        }
        public bool FileExists => !string.IsNullOrEmpty(Target) && File.Exists(Target);
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

>>>>>>> Stashed changes
        public enum WorkerTaskTypeEnum
        {
            None,
            Executable,
            Url
        }
        public int ExecutionOrder { get; set; }
        public string Target { get; set; }

        public int ProcessId { get; set; }

        public string ProcessName
        { get { try { return Path.GetFileName(Target); } catch { return Target; } } }
        public WorkerTaskTypeEnum WorkerTaskType { get; set; }


    }
}
