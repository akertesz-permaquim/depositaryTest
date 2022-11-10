using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class BagContentItem
    {
        public string Moneda { get; set; }
        public string Denominacion { get; set; }
        public long Cantidad { get; set; }
        public decimal Total { get; set; }

        public string FormattedTotal { get; set; }

    }

    internal class BillContentResumeItem
    {
        public string Moneda { get; set; }
        public long MonedaId { get; set; }
        public string Denominacion { get; set; }
        public long DenominacionId { get; set; }
        public decimal UnidadesDenominacion { get; set; }
        public long Cantidad { get; set; }
        public decimal Total { get; set; }

    }

    internal class BagBillContentResume
    {
        public long MonedaId { get; set; }
        public string Moneda { get; set; }
        public decimal Total { get; set; }

        public string FormattedTotal { get; set; }

        public long CantidadBilletes { get; set; }

    }

    internal class BagEnvelope
    {
        public long MonedaId { get; set; }
        public string Moneda { get; set; }
        public decimal Total { get; set; }

    }
}