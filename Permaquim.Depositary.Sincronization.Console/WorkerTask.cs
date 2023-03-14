namespace Permaquim.Depositary.Sincronization.Console
{
    internal class WorkerTask
    {
        public enum WorkerTaskTypeEnum
        {
            None,
            GetToken,
            Send,
            Receive,
            SendAndReceive,
            HandleExecution
        }
        public int ExecutionOrder { get; set; }
        public string Endpoint { get; set; }
        public WorkerTaskTypeEnum WorkerTaskType { get; set; }

        public string Entity { get; set; }

        public bool SendsDate { get; set; }

        public bool Log { get; set; }

    }
}
