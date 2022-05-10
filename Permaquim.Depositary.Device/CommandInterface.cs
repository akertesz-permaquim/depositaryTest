using Permaquim.Depositary.Interfaces;
namespace Permaquim.Depositary.Device
{
    public partial class CommandInterface : ICounterDevice, IIOBoard
    {
        public string DeviceName { get; set; }  = "DE50";

        // Counter
        public byte[] DeviceReset { get; set; } = new byte[7];
        public byte[] RemoteCancel { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)55, (byte)3, (byte)0 };

        // Escrow
        public byte[] OpenEscrow { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)53, (byte)3, (byte)0 };
        public byte[] CloseEscrow { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)54, (byte)3, (byte)0 };

        // Mode Specification
        public byte[] DepositMode { get; set; } = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)48, (byte)3, (byte)0 };
        public byte[] ManualDepositMode { get; set; } = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)49, (byte)3, (byte)0 };
        public byte[] NormalErrorRecoveryMode { get; set; } = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)50, (byte)3, (byte)0 };
        public byte[] StoringErrorRecoveryMode { get; set; } = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)51, (byte)3, (byte)0 };
        public byte[] CollectMode { get; set; } = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)52, (byte)3, (byte)0 };
        public byte[] StopCounting { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)51, (byte)3, (byte)0 };
        public byte[] StoringStart { get; set; } = new byte[10] { (byte)2, (byte)48, (byte)48, (byte)52, (byte)52, (byte)48, (byte)48, (byte)49, (byte)3, (byte)0 };
        public byte[] BatchDataTransmission { get; set; } = new byte[103]{(byte) 2,(byte) 48,(byte) 57,(byte) 55,(byte) 50,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte)48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            (byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 3,(byte) 0};

        public byte[] Sense { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)64, (byte)3, (byte)0 };
        public byte[] CountingDataRequest { get; set; } = new byte[7] { (byte)2, (byte)48, (byte)48, (byte)49, (byte)65, (byte)3, (byte)0 };

        //IO board commands
        public string Open { get; set; } = "O";
        public string Close { get; set; } = "C";
        public string UnLock { get; set; } = "U";
        public string Status { get; set; } = "S";
        public string Empty { get; set; } = "E";
        public string Approve { get; set; } = "A";
        /// <summary>
        /// Counter port definition
        /// </summary>
        public CommunicationPort CounterComPort { get; set; } = new CommunicationPort()
        {
            PortName = "COM1",
            Parity = 2,
            DataBits = 7,
            ReadBufferSize = 9600,
            StopBits = 1,
            ReadTimeout = 2000,
            RtsEnable = false,
            Handshake = 0,
            BaudRate = 9600
        };
        /// <summary>
        /// IOboard port definition
        /// </summary>
        public CommunicationPort IOboardComPort { get; set; } = new CommunicationPort()
        {
            PortName = "COM1",
            Parity = 2,
            DataBits = 7,
            ReadBufferSize = 9600,
            StopBits = 1,
            ReadTimeout = 2000,
            RtsEnable = false,
            Handshake = 0,
            BaudRate = 38400
        };
    }
}
