using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Interfaces
{
    public  interface IComunicationPort
    {
        public string PortName { get; set; }
        public int Parity { get; set; }
        public int DataBits { get; set; }
        public int ReadBufferSize { get; set; }
        public int StopBits { get; set; }
        public int ReadTimeout { get; set; }
        public bool RtsEnable { get; set; }
        public int Handshake { get; set; }
        public int BaudRate { get; set; }
    }
}
