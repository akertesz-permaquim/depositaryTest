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
        public WorkerTaskTypeEnum WorkerTaskType { get; set; }


    }
}
