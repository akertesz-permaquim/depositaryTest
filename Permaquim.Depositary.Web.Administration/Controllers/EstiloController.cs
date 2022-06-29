namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class EstiloController
    {
        public static List<DepositarioAdminWeb.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEsquemaDetalles(Int64 pUsuarioId)
        {
            List<DepositarioAdminWeb.Entities.Tables.Estilo.EsquemaDetalle> resultado = new();
            DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();

            //Primero valoro que usuario se esta recibiendo como parametro, si es -1 traemos los estilos de la empresa default o la primera que se encuentre.
            if (pUsuarioId == -1)
            {
                DepositarioAdminWeb.Business.Relations.Directorio.Empresa empresa = new DepositarioAdminWeb.Business.Relations.Directorio.Empresa();
                empresa.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.EsDefault, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                empresa.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);


                if (empresa.Items().Count == 0)
                {
                    empresa.Where.Clear();
                    esquemaDetalle.Where.Add(DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, empresa.Items().FirstOrDefault().EstiloEsquemaId.Id);
                }
                else
                    esquemaDetalle.Where.Add(DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, empresa.Result.FirstOrDefault().EstiloEsquemaId.Id);

                esquemaDetalle.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                esquemaDetalle.Items();
            }
            else
            {
                DepositarioAdminWeb.Business.Relations.Seguridad.Usuario usuario = new();
                usuario.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                usuario.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsuarioId);

                usuario.Items();

                esquemaDetalle.Where.Add(DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, usuario.Result.FirstOrDefault().EmpresaId.EstiloEsquemaId.Id);
                esquemaDetalle.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                resultado = esquemaDetalle.Items();
            }
            resultado = esquemaDetalle.Result;
            return resultado;
        }

        public static string ObtenerItemEstilo(List<DepositarioAdminWeb.Entities.Tables.Estilo.EsquemaDetalle> dataEsquemaDetalles, string pNombre, bool obtenerSoloValor = false)
        {
            string resultado = "";
            DepositarioAdminWeb.Entities.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();

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
    }
}
