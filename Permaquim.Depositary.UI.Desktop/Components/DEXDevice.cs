using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Components
{
    public class DEXDevice
    {
        public string DeviceName { get => "DE50"; }

        // Counter
        public byte[] DeviceReset = new byte[7]; //{ (byte) 2,(byte) 48,(byte) 48,(byte) 49,(byte) 56,(byte) 3,(byte) 0};

        public byte[] RemoteCancel = new byte[7]; // { (byte)2, (byte)48, (byte)48, (byte)49, (byte)55, (byte)3, (byte)0 };


        // Escrow
        public byte[] OpenEscrow = new byte[7]; // { (byte)2, (byte)48, (byte)48, (byte)49, (byte)53, (byte)3, (byte)0 };
        public byte[] CloseEscrow = new byte[7]; // { (byte)2, (byte)48, (byte)48, (byte)49, (byte)54, (byte)3, (byte)0 };

        // Mode Specification
        public byte[] DepositMode = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)48, (byte)3, (byte)0 };
        public byte[] ManualDepositMode = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)49, (byte)3, (byte)0 };
        public byte[] NormalErrorRecoveryMode = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)50, (byte)3, (byte)0 };
        public byte[] StoringErrorRecoveryMode = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)51, (byte)3, (byte)0 };
        public byte[] CollectMode = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)49, (byte)52, (byte)3, (byte)0 };

        public byte[] StopCounting = new byte[7]; // { (byte)2, (byte)48, (byte)48, (byte)49, (byte)51, (byte)3, (byte)0 };
        public byte[] StoringStart = new byte[10]; // { (byte)2, (byte)48, (byte)48, (byte)52, (byte)52, (byte)48, (byte)48, (byte)49, (byte)3, (byte)0 };
        public byte[] BatchDataTransmission = new byte[103]; //{(byte) 2,(byte) 48,(byte) 57,(byte) 55,(byte) 50,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte)48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,
            //(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 48,(byte) 3,(byte) 0};

        public byte[] Sense = new byte[7]; //{(byte) 2,(byte) 48,(byte) 48,(byte) 49,(byte) 64,(byte) 3,(byte) 0};
        public byte[] CountingDataRequest = new byte[7]; //{(byte) 2,(byte) 48,(byte) 48,(byte) 49,(byte) 65,(byte) 3,(byte) 0};
        public byte[] DenominationDataRequest = new byte[7];// { (byte)2, (byte)48, (byte)48, (byte)49, (byte)68, (byte)3, (byte)0 };

        // Currency
        public byte[] SwitchCurrency = new byte[8]; // { (byte)2, (byte)48, (byte)48, (byte)50, (byte)57, (byte)48, (byte)3, (byte)0 };

                                     //new byte[8] { (byte)2, (byte)30, (byte)30, (byte)32, (byte)39, (byte)0, (byte)3, (byte)0 };

        //IO board commands

        public string Open; //= "O";
        public string Close; // = "C";
        public string UnLock; // = "U";
        public string Status; // = "S";
        public string Empty; // = "E";
        public string Approve; // = "A";

        public CommunicationPort CounterComPort { get; set; } = new CommunicationPort();

        public CommunicationPort IOboardComPort { get; set; } = new CommunicationPort();

        public class CommunicationPort
        {
            public string PortName { get; set; }
            public int Parity  { get; set; }
            public int DataBits { get; set; }
            public int ReadBufferSize { get; set; } 
            public int StopBits { get; set; } 
            public int ReadTimeout { get; set; }
            public bool RtsEnable { get; set; } 
            public int Handshake { get; set; } 
            public int BaudRate { get; set; } 
        }
    }
}
