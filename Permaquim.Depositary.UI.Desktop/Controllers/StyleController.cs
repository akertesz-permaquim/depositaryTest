using Permaquim.Depositary.UI.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static  class StyleController
    {
        private static Permaquim.Depositario.Entities.Relations.Estilo.Esquema _selectedSchema = new();
        public static Image GetLogo()
        {

            //var e = DatabaseController.CurrentUser.EmpresaId.EstiloEsquemaId;

            Permaquim.Depositario.Business.Relations.Estilo.EsquemaDetalleValor entities = new();
            entities.Where.Add(Depositario.Business.Relations.Estilo.EsquemaDetalleValor.ColumnEnum.EsquemaDetalleId,
              Depositario.sqlEnum.OperandEnum.Equal, 1);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Estilo.EsquemaDetalleValor.ColumnEnum.EsquemaDetalleId,
                Depositario.sqlEnum.OperandEnum.Equal, 1);

            entities.Items();

            return ImageFromBase64Helper.GetImageFromBase64String(entities.Result.FirstOrDefault().Valor);
        }
        public static Image GetLogin()
        {
            Permaquim.Depositario.Business.Relations.Estilo.EsquemaDetalleValor entities = new();
            entities.Where.Add(Depositario.Business.Relations.Estilo.EsquemaDetalleValor.ColumnEnum.EsquemaDetalleId,
                Depositario.sqlEnum.OperandEnum.Equal, 4);

            entities.Items();

            return ImageFromBase64Helper.GetImageFromBase64String(entities.Result.FirstOrDefault().Valor);
        }
    }
}
