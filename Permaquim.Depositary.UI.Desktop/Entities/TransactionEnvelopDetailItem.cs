using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TransactionEnvelopDetailItem
    {
        public string Sobre { get; set; }
        public string TipoValor { get; set; }
        public long CantidadDeclarada { get; set; }
        public DateTime Fecha { get; set; }
    }
}
