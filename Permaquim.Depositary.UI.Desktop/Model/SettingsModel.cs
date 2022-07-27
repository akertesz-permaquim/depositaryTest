using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Model
{
    [Serializable()]
    public class SettingsModel
    {
        [Description("Url de la Web Api de la cual debe obtener la información.")]
        [Category("Comunicación")]
        [DisplayName("Web Api Url")]
        public string WebApiUrl { get; set; }

        [Description("Código externo del depositario local.")]
        [Category("Identificación")]
        [DisplayName("Codigo del Depositario")]
        public string CodigoDepositario { get; set; }

        [Description("Clave del depositario local.")]
        [Category("Identificación")]
        [DisplayName("Clave del Depositario")]
        public string ClaveDepositario { get; set; }
    }
}
