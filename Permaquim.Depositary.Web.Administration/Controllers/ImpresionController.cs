namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class ImpresionController
    {
        public static bool GenerarRegistrosTicketEmpresa(Int64 pEmpresaId)
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
                    Depositary.Business.Tables.Impresion.Ticket oTicket = new();

                    oTicket.Where.Add(Depositary.Business.Tables.Impresion.Ticket.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, bTablesEmpresa.Result.FirstOrDefault().Id);

                    oTicket.Items();

                    if (oTicket.Result.Count > 0)
                    {
                        Depositary.Business.Tables.Impresion.Ticket btTicket = new();

                        btTicket.BeginTransaction();
                        foreach (var registroTicket in oTicket.Result)
                        {
                            registroTicket.EmpresaId = pEmpresaId;
                            registroTicket.FechaModificacion = null;
                            registroTicket.UsuarioModificacion = null;
                            registroTicket.FechaCreacion = DateTime.Now;
                            try
                            {
                                btTicket.Add(registroTicket, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                            }
                            catch (Exception ex)
                            {
                                AuditController.Log(ex);
                                btTicket.EndTransaction(false);
                                return false;
                            }
                        }
                        btTicket.EndTransaction(true);

                    }
                }

            }
            resultado = true;

            return resultado;
        }
    }
}
