using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static  class StyleController
    {

        private static Permaquim.Depositario.Entities.Relations.Estilo.Esquema _selectedSchema = new();
        private static List<Permaquim.Depositario.Entities.Relations.Estilo.EsquemaDetalle> _selectedSchemaDetail = new();

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

        public static List<Permaquim.Depositario.Entities.Relations.Estilo.EsquemaDetalle> StyleItems
        {
            get {
                if (_selectedSchemaDetail.Count == 0)
                {
                    Permaquim.Depositario.Business.Relations.Estilo.EsquemaDetalle entities = new();

                    entities.Where.Add(Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId,
                    Depositario.sqlEnum.OperandEnum.Equal,
                    DatabaseController.CurrentDepositary.SectorId.SucursalId.EmpresaId.EstiloEsquemaId.Id);

                    _selectedSchemaDetail = entities.Items();

                }
                return _selectedSchemaDetail;
            }
        }

        public static System.Drawing.Color GetColor(ColorNameEnum colorName) 
        {
            System.Drawing.Color retValue = Color.White;

            string stringColorName = Enum.GetName(colorName);
            var ret = StyleItems.FirstOrDefault(s => s.Nombre.Equals(stringColorName));

            string value = ret.Valor;
            string valueType = ret.Valor.Substring(0, ret.Valor.IndexOf('('));
            value = value.Replace(valueType, "").Replace("(", "").Replace(")", "");
 
            Int32 red = Int32.Parse(value.Split(',')[0]);
            Int32 green = Int32.Parse(value.Split(',')[1]);
            Int32 blue = Int32.Parse(value.Split(',')[2]);
            if (value.Split(',').Length == 4)
            {
                int opacity = Convert.ToInt32(Decimal.Parse(value.Split(',')[3].Trim()) * 100);
                retValue = Color.FromArgb(opacity,red, green, blue);
            }
            else
            {
                retValue = Color.FromArgb(red, green, blue);
            }

            return ret == null ? Color.White : retValue;
        }
        public static Bitmap GetCellStyleBitmap()
        {
            var bitmap = new Bitmap(640, 480);

            var color = StyleController.GetColor(Enumerations.ColorNameEnum.PieGrilla);

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }
    }
}
