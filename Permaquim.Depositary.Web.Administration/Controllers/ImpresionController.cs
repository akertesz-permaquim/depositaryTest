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
                    using (Depositary.Business.Tables.Impresion.Ticket bTablesTicket = new())
                    {

                        bTablesTicket.Where.Add(Depositary.Business.Tables.Impresion.Ticket.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, bTablesEmpresa.Result.FirstOrDefault().Id);

                        bTablesTicket.Items();

                        if (bTablesTicket.Result.Count > 0)
                        {
                            bTablesTicket.BeginTransaction();
                            foreach (var registroTicket in bTablesTicket.Result)
                            {
                                registroTicket.EmpresaId = pEmpresaId;
                                registroTicket.FechaModificacion = null;
                                registroTicket.UsuarioModificacion = null;
                                registroTicket.FechaCreacion = DateTime.Now;
                                try
                                {
                                    bTablesTicket.Add(registroTicket, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                                }
                                catch (Exception ex)
                                {
                                    AuditController.Log(ex);
                                    bTablesTicket.EndTransaction(false);
                                    return false;
                                }
                            }
                            bTablesTicket.EndTransaction(true);

                        }
                    }

                }

            }
            resultado = true;

            return resultado;
        }
    }
}
