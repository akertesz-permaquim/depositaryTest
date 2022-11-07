using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TurnItem
    {
        public Int64 Id { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string Usuario { get; set; }
        public int Secuencia { get; set; }
        public string Turno { get; set; }
        public string CierreDiario { get; set; }
        public int CantidadTransacciones { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }

    }

    internal class TurnItemElement
    {
        public long Value { get; set; }
        public string Text { get; set; }
    }
}
