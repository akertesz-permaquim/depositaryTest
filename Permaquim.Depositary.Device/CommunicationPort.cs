using Permaquim.Depositary.Interfaces;
namespace Permaquim.Depositary.Device
{
    public class CommunicationPort : IComunicationPort
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
