using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class DailyClosingItem
    {
        public string Moneda { get; set; }
        public long CantidadOperaciones { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }
        public double Total { get; set; }


    }
}
