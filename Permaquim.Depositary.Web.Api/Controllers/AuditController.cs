using System.Diagnostics;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class AuditController
    {
        private static DepositaryWebApi.Business.Tables.Auditoria.Log _bTablesLog = new();
        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }

        public static void Log(LogTypeEnum logType, string description, string detail, Int64 userId = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(); //Para obtener el nombre del metodo que lo llamo

                DepositaryWebApi.Entities.Tables.Auditoria.Log entity = new()
                {
                    AplicacionId = (Int64)Entities.Aplicacion.Webapi,
                    Fecha = DateTime.Now,
                    Metodo = stackTrace.GetFrame(1).GetMethod().Name,
                    Modulo = stackTrace.GetFrame(1).GetMethod().Module.Name,
                    TipoId = (long)logType,
                    Descripcion = description,
                    Detalle = detail,
                    UsuarioId = userId,

                };

                _bTablesLog.Add(entity);
            }
            catch
            {
                return;
            }
        }

        public static void Log(Exception exception, Int64 userId = 0)
        {
            Log(LogTypeEnum.Exception, exception.Message, exception.StackTrace, userId);
        }
    }
}
