using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Interfaces
{
    public interface IIOBoard
    {
        public string Open { get; set; }
        public string Close { get; set; } 
        public string UnLock { get; set; }
        public string Status { get; set; }
        public string Empty  { get; set; }
        public string Approve  { get; set; } 
    }
}
