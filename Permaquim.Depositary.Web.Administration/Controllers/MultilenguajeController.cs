namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class MultilenguajeController
    {
        private static List<Entities.TextoLenguaje> _textosLenguaje = new();

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
            _textosLenguaje.Clear();

            if (pUsuarioId == -1)
            {
                using (Depositary.Business.Relations.Regionalizacion.Lenguaje bRelationsLenguaje = new())
                {
                    bRelationsLenguaje.Where.Add(Depositary.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    bRelationsLenguaje.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.EsDefault, Depositary.sqlEnum.OperandEnum.Equal, true);

                    bRelationsLenguaje.Items();

                    if (bRelationsLenguaje.Result.Count > 0)
                    {
                        foreach (var lenguajeitem in bRelationsLenguaje.Result.FirstOrDefault().ListOf_LenguajeItem_LenguajeId.Where(x => x.Habilitado == true))
                        {
                            Entities.TextoLenguaje textoLenguaje = new();
                            textoLenguaje.LenguajeId = lenguajeitem._LenguajeId;
                            textoLenguaje.Lenguaje = bRelationsLenguaje.Result.FirstOrDefault().Nombre;
                            textoLenguaje.Texto = lenguajeitem.Texto;
                            textoLenguaje.LenguajeItemId = lenguajeitem.Id;
                            textoLenguaje.Clave = lenguajeitem.Clave;
                            textoLenguaje.Cultura = bRelationsLenguaje.Result.FirstOrDefault().Cultura;
                            _textosLenguaje.Add(textoLenguaje);
                        }
                    }
                }

            }
            else
            {
                using (Depositary.Business.Relations.Seguridad.Usuario bRelationsUsuario = new())
                {
                    bRelationsUsuario.Where.Add(Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    bRelationsUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pUsuarioId);

                    bRelationsUsuario.Items();

                    if (bRelationsUsuario.Result.Count > 0)
                    {
                        var lenguaje = bRelationsUsuario.Result.FirstOrDefault().LenguajeId;
                        foreach (var lenguajeitem in bRelationsUsuario.Result.FirstOrDefault().LenguajeId.ListOf_LenguajeItem_LenguajeId.Where(x => x.Habilitado == true))
                        {
                            Entities.TextoLenguaje textoLenguaje = new();
                            textoLenguaje.LenguajeId = lenguajeitem._LenguajeId;
                            textoLenguaje.Lenguaje = lenguaje.Nombre;
                            textoLenguaje.Texto = lenguajeitem.Texto;
                            textoLenguaje.LenguajeItemId = lenguajeitem.Id;
                            textoLenguaje.Clave = lenguajeitem.Clave;
                            textoLenguaje.Cultura = lenguaje.Cultura;
                            _textosLenguaje.Add(textoLenguaje);
                        }
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
            _textosLenguaje.Add(genericoLenguaje);

            return _textosLenguaje;
        }
    }
}
