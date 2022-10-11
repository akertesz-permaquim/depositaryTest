using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class BillDepositDetail
    {
        public string DenominacionNombre { get; set; }
        public string MonedaCodigo { get; set; }
        public Int64 CantidadUnidades { get; set; }
        public decimal Unidades { get; set; }
        public Int64 DenominacionId { get; set; }
    }
}
