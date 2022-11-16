using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static  class StyleController
    {

        private static Permaquim.Depositario.Entities.Relations.Estilo.Esquema _selectedSchema = new();
        private static List<Permaquim.Depositario.Entities.Relations.Estilo.EsquemaDetalle> _selectedSchemaDetail = new();
        public static void ResetSchema()
        {
            _selectedSchemaDetail.Clear();
        }
        public static Image GetLogo()
        {
            return GetImageResource("Logo");
        }
        public static Image GetLogin()
        {
            return GetImageResource("Login");
        }

        public static Image GetDeviceImage()
        {
            return ImageFromBase64Helper.
                GetImageFromBase64String(DatabaseController.CurrentDepositary.ModeloId.Imagen);

        }

        public static Image GetPresentation()
        {
            return GetImageResource("Presentacion");
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

        public static Image GetImageResourceFromfile(string fileResourceName)
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + fileResourceName)) 
                return  Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + fileResourceName);
            else
                return null;
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
                    entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.Habilitado,
                    Depositario.sqlEnum.OperandEnum.Equal, true);
 
                    _selectedSchemaDetail = entities.Items();
                }

                return _selectedSchemaDetail;
            }
        }

        public static System.Drawing.Color GetColor(ColorNameEnum colorName) 
        {
            System.Drawing.Color retValue = Color.White;

            var ret = StyleItems.FirstOrDefault(s => s.Nombre.Equals(Enum.GetName(colorName)));
            if (ret != null)
            {
                string value = ret.Valor;
                string valueType = ret.Valor.Substring(0, ret.Valor.IndexOf('('));
                value = value.Replace(valueType, "").Replace("(", "").Replace(")", "");

                Int32 red = Int32.Parse(value.Split(',')[0]);
                Int32 green = Int32.Parse(value.Split(',')[1]);
                Int32 blue = Int32.Parse(value.Split(',')[2]);
                if (value.Split(',').Length == 4)
                {
                    int transparency = Convert.ToInt32(Decimal.Parse(value.Split(',')[3].Trim()) * 100);
                    retValue = Color.FromArgb(transparency, red, green, blue);
                }
                else
                {
                    retValue = Color.FromArgb(red, green, blue);
                }
            }

            return  retValue;
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

        public static void SetControlStyle(DataGridView grid)
        {

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            grid.ColumnHeadersDefaultCellStyle.BackColor =
                   StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            grid.BackgroundColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.FondoGrilla);
            grid.DefaultCellStyle.BackColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.FondoFilasGrilla);
            grid.DefaultCellStyle.ForeColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.TextoFilasGrilla);
            

        }

        public static void SetControlFooterStyle(DataGridView grid) {
            {
                if (grid.Rows.Count > 0)
                {
                    grid.Rows[grid.Rows.Count - 1].DefaultCellStyle.BackColor =
                        StyleController.GetColor(Enumerations.ColorNameEnum.PieGrilla);
                    grid.Rows[grid.Rows.Count - 1].DefaultCellStyle.ForeColor =
                        StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    grid.Rows[grid.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);

                    SetControlHeight(grid);
                }
            }
        }
        public static void SetControlHeight(DataGridView grid)
        {
            grid.Height = grid.RowTemplate.Height * grid.Rows.Count +
            grid.ColumnHeadersHeight;
        }

        public static DataGridViewCellStyle GetFullDateColumnStyle()
        {
            DataGridViewCellStyle dateColumnStyle = new()
            {
                Format = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA)
            };
            return dateColumnStyle;

        }
        public static DataGridViewCellStyle GetShortDateColumnStyle()
        {
            DataGridViewCellStyle dateColumnStyle = new()
            {
                Format = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA)
            };
            return dateColumnStyle;

        }
    }
}
