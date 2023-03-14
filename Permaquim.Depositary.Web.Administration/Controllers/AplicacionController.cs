namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class AplicacionController
    {

        public static string ObtenerConfiguracionGeneral(string pClave)
        {
            string resultado = "";

            //Obtengo la aplicacion
            using (Depositary.Business.Tables.Seguridad.Aplicacion bTablesAplicacion = new())
            {

                bTablesAplicacion.Where.Add(Depositary.Business.Tables.Seguridad.Aplicacion.ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, SeguridadEntities.TipoAplicacion.Web);
                bTablesAplicacion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Aplicacion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                bTablesAplicacion.Items();

                if (bTablesAplicacion.Result.Count > 0)
                {
                    using (Depositary.Business.Tables.Aplicacion.Configuracion bTablesConfiguracion = new())
                    {
                        bTablesConfiguracion.Where.Add(Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.AplicacionId, Depositary.sqlEnum.OperandEnum.Equal, bTablesAplicacion.Result.FirstOrDefault().Id);
                        bTablesConfiguracion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        bTablesConfiguracion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, pClave);

                        bTablesConfiguracion.Items();

                        if (bTablesConfiguracion.Result.Count > 0)
                        {
                            resultado = bTablesConfiguracion.Result.FirstOrDefault().Valor;
                        }
                    }
                }
            }

            return resultado;
        }

        public static string ObtenerConfiguracionEmpresa(string pClave, Int64 pEmpresaId)
        {
            string resultado = "";

            Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa bTablesConfiguracionEmpresa = new();

            bTablesConfiguracionEmpresa.Where.Clear();
            bTablesConfiguracionEmpresa.Where.Add(Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, pEmpresaId);
            bTablesConfiguracionEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            bTablesConfiguracionEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, pClave);

            bTablesConfiguracionEmpresa.Items();

            if (bTablesConfiguracionEmpresa.Result.Count > 0)
            {
                resultado = bTablesConfiguracionEmpresa.Result.FirstOrDefault().Valor;
            }

            return resultado;
        }

        public static bool GenerarRegistrosConfiguracionEmpresa(Int64 pEmpresaId)
        {
            bool resultado = false;

            //Obtenemos la empresa default
            using (Depositary.Business.Tables.Directorio.Empresa bTablesEmpresa = new())
            {

                bTablesEmpresa.Where.Add(Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.EsDefault, Depositary.sqlEnum.OperandEnum.Equal, true);
                bTablesEmpresa.Where.Add(sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                bTablesEmpresa.Items();

                if (bTablesEmpresa.Result.Count > 0)
                {
                    Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa oConfiguracionEmpresa = new();

                    oConfiguracionEmpresa.Where.Add(Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, bTablesEmpresa.Result.FirstOrDefault().Id);

                    oConfiguracionEmpresa.Items();

                    if (oConfiguracionEmpresa.Result.Count > 0)
                    {
                        Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa btConfiguracionEmpresa = new();

                        btConfiguracionEmpresa.BeginTransaction();

                        foreach (var registroConfiguracion in oConfiguracionEmpresa.Result)
                        {
                            registroConfiguracion.EmpresaId = pEmpresaId;
                            registroConfiguracion.FechaModificacion = null;
                            registroConfiguracion.UsuarioModificacion = null;
                            registroConfiguracion.FechaCreacion = DateTime.Now;

                            try
                            {
                                btConfiguracionEmpresa.Add(registroConfiguracion, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                            }
                            catch (Exception ex)
                            {
                                AuditController.Log(ex);
                                btConfiguracionEmpresa.EndTransaction(false);
                                return false;
                            }
                        }
                        btConfiguracionEmpresa.EndTransaction(true);

                    }
                }
            }
            resultado = true;

            return resultado;
        }
    }
}
