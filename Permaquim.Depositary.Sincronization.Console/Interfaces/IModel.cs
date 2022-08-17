using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Sincronization.Console.Interfaces
{
    internal interface IModel 
    {
        public void Process();
        public DateTime? SincroDate { get; set; } 
        public void Persist();
  
    }
}
