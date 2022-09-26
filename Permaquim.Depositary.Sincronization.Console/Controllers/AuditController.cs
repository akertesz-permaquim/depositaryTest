using System.Diagnostics;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class AuditController
    {
        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }

        public const long APPLICATION_ID = 1;

        public static void Log(LogTypeEnum logType, string description, string detail)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(); //Para obtener el nombre del metodo que lo llamo

                Depositario.Business.Tables.Auditoria.Log entities = new();
                Depositario.Entities.Tables.Auditoria.Log entity = new()
                {
                    AplicacionId = APPLICATION_ID,
                    Fecha = DateTime.Now,
                    Metodo = stackTrace.GetFrame(1).GetMethod().Name,
                    Modulo = stackTrace.GetFrame(1).GetMethod().Module.Name,
                    TipoId = (long)logType,
                    Descripcion = description,
                    Detalle = detail,
                    UsuarioId = -1 

                };

                entities.Add(entity);
            }
            catch
            {
                return;
            }
        }

        public static void Log(Exception exception)
        {
            Log(LogTypeEnum.Exception, exception.Message, exception.StackTrace);
        }

    }
}
