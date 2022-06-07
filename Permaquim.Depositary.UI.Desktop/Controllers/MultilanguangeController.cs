using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class MultilanguangeController
    {
        private static readonly List<Permaquim.Depositario.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> _languageItems = new();

        public static List<Permaquim.Depositario.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> LanguageItems
        {
            get
            {
                if (_languageItems.Count == 0)
                {
                    Permaquim.Depositario.Business.Procedures.Regionalizacion.ObtenerTextosLenguaje entities = new();
                    
                    entities.Items(DatabaseController.CurrentUser != null ? DatabaseController.CurrentUser.Id : -1);

                    return entities.MappedResultSet.Resultado;
                }

                return _languageItems;
            }

        }
        public static string GetText(string key)
        {
            var ret = LanguageItems.FirstOrDefault(s => s.Clave.Equals(key));

            return ret == null ? "***" : ret.Texto;
        }
    }
}
