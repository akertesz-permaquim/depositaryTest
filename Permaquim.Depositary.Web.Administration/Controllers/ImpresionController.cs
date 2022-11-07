namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class ImpresionController
    {
        public static bool GenerarRegistrosTicketEmpresa(Int64 pEmpresaId)
        {
            bool resultado = false;

            //Obtenemos la empresa default
            Depositary.Business.Tables.Directorio.Empresa oEmpresa = new();

            oEmpresa.Where.Add(Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.EsDefault, Depositary.sqlEnum.OperandEnum.Equal, true);
            oEmpresa.Where.Add(sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oEmpresa.Items();

            if (oEmpresa.Result.Count > 0)
            {
                Depositary.Business.Tables.Impresion.Ticket oTicket = new();
                oTicket.Where.Add(Depositary.Business.Tables.Impresion.Ticket.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, oEmpresa.Result.FirstOrDefault().Id);

                oTicket.Items();

                if (oTicket.Result.Count > 0)
                {
                    oTicket.BeginTransaction();
                    foreach (var registroTicket in oTicket.Result)
                    {
                        registroTicket.EmpresaId = pEmpresaId;
                        registroTicket.FechaModificacion = null;
                        registroTicket.UsuarioModificacion = null;
                        registroTicket.FechaCreacion = DateTime.Now;
                        try
                        {
                            oTicket.Add(registroTicket, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                        }
                        catch (Exception ex)
                        {
                            AuditController.Log(ex);
                            oTicket.EndTransaction(false);
                            return false;
                        }
                    }
                    oTicket.EndTransaction(true);

                }

            }
            resultado = true;

            return resultado;
        }
    }
}
