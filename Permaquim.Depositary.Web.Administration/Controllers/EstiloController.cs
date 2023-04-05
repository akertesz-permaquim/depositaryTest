namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class EstiloController
    {
        private static Depositary.Entities.Tables.Estilo.EsquemaDetalle _eTablesEsquemaDetalle = new();

        public static List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEsquemaDetalles(Int64 pUsuarioId)
        {
            List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> resultado = new();
            using (Depositary.Business.Tables.Estilo.EsquemaDetalle bTablesEsquemaDetalle = new())
            {
                //Primero valoro que usuario se esta recibiendo como parametro, si es -1 traemos los estilos de la empresa default o la primera que se encuentre.
                if (pUsuarioId == -1)
                {
                    using (Depositary.Business.Relations.Directorio.Empresa bRelationsEmpresa = new())
                    {

                        bRelationsEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.EsDefault, Depositary.sqlEnum.OperandEnum.Equal, true);
                        bRelationsEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);


                        if (bRelationsEmpresa.Items().Count == 0)
                        {
                            bRelationsEmpresa.Where.Clear();
                            bTablesEsquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, bRelationsEmpresa.Items().FirstOrDefault().EstiloEsquemaId.Id);
                        }
                        else
                            bTablesEsquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, bRelationsEmpresa.Result.FirstOrDefault().EstiloEsquemaId.Id);
                    }

                    bTablesEsquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    bTablesEsquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);
                    bTablesEsquemaDetalle.Items();
                }
                else
                {
                    using (Depositary.Business.Relations.Seguridad.Usuario bRelationsUsuario = new())
                    {

                        bRelationsUsuario.Where.Add(Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        bRelationsUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pUsuarioId);

                        bRelationsUsuario.Items();

                        var estiloEsquemaId = bRelationsUsuario.Result.FirstOrDefault().EmpresaId._EstiloEsquemaId;

                        bTablesEsquemaDetalle.Where.Add(Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Depositary.sqlEnum.OperandEnum.Equal, estiloEsquemaId);
                        bTablesEsquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        bTablesEsquemaDetalle.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);
                    }

                    resultado = bTablesEsquemaDetalle.Items();
                }
                resultado = bTablesEsquemaDetalle.Result;
            }
            return resultado;
        }

        public static string ObtenerItemEstilo(List<Depositary.Entities.Tables.Estilo.EsquemaDetalle> dataEsquemaDetalles, string pNombre, bool obtenerSoloValor = false)
        {
            string resultado = "";

            if (dataEsquemaDetalles.Where(x => x.Nombre == pNombre).Count() > 0)
            {
                _eTablesEsquemaDetalle = dataEsquemaDetalles.Where(x => x.Nombre == pNombre).FirstOrDefault();
                if (!obtenerSoloValor)
                {
                    switch (_eTablesEsquemaDetalle.TipoEsquemaDetalleId)
                    {
                        case 1:
                            resultado = "background-color:" + _eTablesEsquemaDetalle.Valor;
                            break;
                        case 2:
                            resultado = "font-family:" + _eTablesEsquemaDetalle.Valor;
                            break;
                        case 3:
                            resultado = _eTablesEsquemaDetalle.Valor;
                            break;
                    }
                }
                else
                    resultado = _eTablesEsquemaDetalle.Valor;
            }
            return resultado;
        }

    }
}
