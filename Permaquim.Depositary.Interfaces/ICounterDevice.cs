namespace Permaquim.Depositary.Interfaces
{
    public interface ICounterDevice
    {
        public string DeviceName { get; set; }
        // Counter
        public byte[] DeviceReset { get; set; }
        public byte[] RemoteCancel { get; set; }

        // Escrow
        public byte[] OpenEscrow { get; set; } 
        public byte[] CloseEscrow { get; set; } 

        // Mode Specification
        public byte[] DepositMode { get; set; } 
        public byte[] ManualDepositMode { get; set; } 
        public byte[] NormalErrorRecoveryMode { get; set; } 
        public byte[] StoringErrorRecoveryMode { get; set; } 
        public byte[] CollectMode { get; set; } 
        public byte[] StopCounting { get; set; } 
        public byte[] StoringStart { get; set; } 
        public byte[] BatchDataTransmission { get; set; } 
        public byte[] Sense { get; set; }
        public byte[] CountingDataRequest { get; set; } 

    }
}