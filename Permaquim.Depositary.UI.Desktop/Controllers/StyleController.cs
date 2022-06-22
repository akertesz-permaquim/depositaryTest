using Permaquim.Depositary.UI.Desktop.Helpers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static  class StyleController
    {

        private static Permaquim.Depositario.Entities.Relations.Estilo.Esquema _selectedSchema = new();
        public static Image GetLogo()
        {
            return GetImageResource("Logo");
        }
        public static Image GetLogin()
        {
            return GetImageResource("Login");
        }
        public static Image GetImageResource(string resourceName)
        {
            Image resultImage = null;

            Permaquim.Depositario.Business.Relations.Estilo.EsquemaDetalle entities = new();
            entities.Where.Add(Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId,
              Depositario.sqlEnum.OperandEnum.Equal,
              DatabaseController.CurrentDepositary.SectorId.SucursalId.EmpresaId.EstiloEsquemaId.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, resourceName);

            entities.Items();
            if (entities.Result.Count > 0)
                resultImage = ImageFromBase64Helper.GetImageFromBase64String(entities.Result.FirstOrDefault().Valor);

            return resultImage;
        }

        public static System.Drawing.Color GetColor(ColorNameEnum colorName)
        {
            System.Drawing.Color returnValue = Color.White;

            Permaquim.Depositario.Business.Relations.Estilo.EsquemaDetalle entities = new();

            entities.Where.Add(Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId,
            Depositario.sqlEnum.OperandEnum.Equal,
            DatabaseController.CurrentDepositary.SectorId.SucursalId.EmpresaId.EstiloEsquemaId.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(typeof(ColorNameEnum), colorName));

            entities.Items();
            if (entities.Result.Count > 0)
            {
                string value = entities.Result.FirstOrDefault().Valor;
                value = value.Replace("rgb", "").Replace("(", "").Replace(")", "");
                Int32 red = Int32.Parse(value.Split(',')[0]);
                Int32 green = Int32.Parse(value.Split(',')[1]);
                Int32 blue = Int32.Parse(value.Split(',')[2]);

                returnValue = Color.FromArgb(red, green, blue);
            }

            return returnValue;
        }
    }
}
