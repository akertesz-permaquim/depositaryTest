namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    internal class WorkerTask
    {
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
