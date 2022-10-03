using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TurnSearcher
    {
        public Int64 TurnoEsquemaDetalleId { get; set; }
        public string NombreEsquema { get; set; }
        public string NombreEsquemaDetalle { get; set; }
        public string Nombre
        {
            get
            {
                return NombreEsquema + " - " + NombreEsquemaDetalle;
            }
        }
    }
}
