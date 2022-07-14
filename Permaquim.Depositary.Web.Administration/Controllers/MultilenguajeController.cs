namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class MultilenguajeController
    {
        public static string ObtenerTextoPorClave(string pClave, List<Entities.TextoLenguaje> pDataTextos)
        {
            string resultado = "";
            if (pDataTextos != null)
            {
                var registro = pDataTextos.FirstOrDefault(x => x.Clave == pClave);
                if (registro != null)
                    resultado = registro.Texto;
                else
                    resultado = pDataTextos.FirstOrDefault(x => x.Clave == "GENERIC").Texto;
            }
            else
                resultado = "**";

            return resultado;
        }

        public static List<Entities.TextoLenguaje> ObtenerTextosLenguaje(Int64 pUsuarioId)
        {
            List<Entities.TextoLenguaje> resultado = new();

            if (pUsuarioId == -1)
            {
                DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje oLenguaje = new();
                oLenguaje.Where.Add(DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oLenguaje.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.EsDefault, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                oLenguaje.Items();

                if (oLenguaje.Result.Count > 0)
                {
                    foreach (var lenguajeitem in oLenguaje.Result.FirstOrDefault().ListOf_LenguajeItem_LenguajeId.Where(x => x.Habilitado == true))
                    {
                        Entities.TextoLenguaje textoLenguaje = new();
                        textoLenguaje.LenguajeId = lenguajeitem._LenguajeId;
                        textoLenguaje.Lenguaje = oLenguaje.Result.FirstOrDefault().Nombre;
                        textoLenguaje.Texto = lenguajeitem.Texto;
                        textoLenguaje.LenguajeItemId = lenguajeitem.Id;
                        textoLenguaje.Clave = lenguajeitem.Clave;
                        textoLenguaje.Cultura = oLenguaje.Result.FirstOrDefault().Cultura;
                        resultado.Add(textoLenguaje);
                    }
                }

            }
            else
            {
                DepositarioAdminWeb.Business.Relations.Seguridad.Usuario oUsuario = new();
                oUsuario.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oUsuario.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsuarioId);

                oUsuario.Items();

                if (oUsuario.Result.Count > 0)
                {
                    var lenguaje = oUsuario.Result.FirstOrDefault().LenguajeId;
                    foreach (var lenguajeitem in oUsuario.Result.FirstOrDefault().LenguajeId.ListOf_LenguajeItem_LenguajeId.Where(x => x.Habilitado == true))
                    {
                        Entities.TextoLenguaje textoLenguaje = new();
                        textoLenguaje.LenguajeId = lenguajeitem._LenguajeId;
                        textoLenguaje.Lenguaje = lenguaje.Nombre;
                        textoLenguaje.Texto = lenguajeitem.Texto;
                        textoLenguaje.LenguajeItemId = lenguajeitem.Id;
                        textoLenguaje.Clave = lenguajeitem.Clave;
                        textoLenguaje.Cultura = lenguaje.Cultura;
                        resultado.Add(textoLenguaje);
                    }
                }
            }

            //agregamos el texto generico
            Entities.TextoLenguaje genericoLenguaje = new();
            genericoLenguaje.LenguajeId = -1;
            genericoLenguaje.Lenguaje = "GENERIC";
            genericoLenguaje.Texto = "**";
            genericoLenguaje.LenguajeItemId = -1;
            genericoLenguaje.Clave = "GENERIC";
            genericoLenguaje.Cultura = "ES-ar";
            resultado.Add(genericoLenguaje);

            return resultado;
        }
    }
}
