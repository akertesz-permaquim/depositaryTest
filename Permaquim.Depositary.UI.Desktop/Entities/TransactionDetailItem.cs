using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TransactionDetailItem
    {
        public long Id { get; set; }
        public string Denominacion { get; set; }
        public decimal Unidades { get; set; }
        public Int64 DenominacionId { get; set; }
        public long CantidadUnidades { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
