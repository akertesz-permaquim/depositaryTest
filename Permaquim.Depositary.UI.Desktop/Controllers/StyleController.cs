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
        public enum ColorNameEnum
        {
            Ninguno =0,
            Cabecera = 1,
            Contenido = 2,
            Pie=3,
            FuentePrincipal =4,
            FuenteContraste = 5,
            BotonEstandar = 6,
            BotonAceptar = 7,
            BotonCancelar = 8,
            BotonContinuar = 9,
            BotonAlerta = 10,
            BotonSalir = 11,
            BotonAlternativo = 12,
            TextoInformacion = 13,
            TextoAlerta =14,
            TextoError  =15

        }

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
