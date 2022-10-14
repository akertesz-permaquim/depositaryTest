namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class EstiloController
    {
        public static List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEsquemaDetalles(Int64 pUsuarioId)
        {
            List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> resultado = new();
            Depositary.Business.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();

            //Primero valoro que usuario se esta recibiendo como parametro, si es -1 traemos los estilos de la empresa default o la primera que se encuentre.
            if (pUsuarioId == -1)
            {
                Depositary.Business.Relations.Directorio.Empresa empresa = new Depositary.Business.Relations.Directorio.Empresa();
                empresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.EsDefault, Depositary.sqlEnum.OperandEnum.Equal, true);
                empresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);


                if (empresa.Items().Count == 0)
                {
                    empresa.Where.Clear();
                    esquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, empresa.Items().FirstOrDefault().EstiloEsquemaId.Id);
                }
                else
                    esquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, empresa.Result.FirstOrDefault().EstiloEsquemaId.Id);

                esquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                esquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);
                esquemaDetalle.Items();
            }
            else
            {
                Depositary.Business.Relations.Seguridad.Usuario usuario = new();
                usuario.Where.Add(Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                usuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pUsuarioId);

                usuario.Items();

                var estiloEsquemaId = usuario.Result.FirstOrDefault().EmpresaId._EstiloEsquemaId;

                esquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, estiloEsquemaId);
                esquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                esquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);

                resultado = esquemaDetalle.Items();
            }
            resultado = esquemaDetalle.Result;
            return resultado;
        }

        public static string ObtenerItemEstilo(List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> dataEsquemaDetalles, string pNombre, bool obtenerSoloValor = false)
        {
            string resultado = "";
            Depositary.Entities.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();

            if (dataEsquemaDetalles.Where(x => x.Nombre == pNombre).Count() > 0)
            {
                esquemaDetalle = dataEsquemaDetalles.Where(x => x.Nombre == pNombre).FirstOrDefault();
                if (!obtenerSoloValor)
                {
                    switch (esquemaDetalle.TipoEsquemaDetalleId)
                    {
                        case 1:
                            resultado = "background-color:" + esquemaDetalle.Valor;
                            break;
                        case 2:
                            resultado = "font-family:" + esquemaDetalle.Valor;
                            break;
                        case 3:
                            resultado = esquemaDetalle.Valor;
                            break;
                    }
                }
                else
                    resultado = esquemaDetalle.Valor;
            }
            return resultado;
        }

        public static int ObtenerPaginadoDefault(Int64 pEmpresaId)
        {
            int paginado = 10; //Por defecto el paginado es de 10 registros

            int paginadoConversion=0;

            string paginadoSinConvertir = "";

            paginadoSinConvertir = AplicacionController.ObtenerConfiguracionEmpresa("PAGINADO_DEFAULT", pEmpresaId);

            if (int.TryParse(paginadoSinConvertir, out paginadoConversion))
                paginado = paginadoConversion;

            return paginado;
        }
    }
}
