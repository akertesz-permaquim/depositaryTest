using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.CustomExceptions
{
    internal class CommPortException : Exception
    {
        public string PortName { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
