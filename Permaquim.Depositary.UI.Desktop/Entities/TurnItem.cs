using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TurnItem
    {
        string Turn { get; set; }
        DateTime CreationDate { get; set; }
        DateTime closingDate { get; set; }

        string Observations { get; set; }   
    }
}
