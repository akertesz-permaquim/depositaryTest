using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class DailyClosingHeader
    {
        public Int64 Id { get; set; }
        public string CodigoCierre { get; set; }
        public DateTime? Fecha { get; set; }
        public string Usuario { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }

        public string Moneda { get; set; }

    }
}
