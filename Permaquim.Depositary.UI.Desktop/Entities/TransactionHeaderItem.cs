using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class TransactionHeaderItem
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public long TipoId { get; set; }
        public string Moneda { get; set; }
        public string Usuario { get; set; }
        public string UsuarioCuenta { get; set; }
        public string Contenedor { get; set; }
        public string Turno { get; set; }
        public string Cierrediario { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }
        public DateTime Fecha { get; set; }
        public bool Finalizada { get; set; }
        public bool EsDepositoAutomatico { get; set; }
        public  String Origen { get; set; }

    }
}
