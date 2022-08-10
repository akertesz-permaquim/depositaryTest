using System.Diagnostics;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class AuditController
    {
        public static void Log(LogTypeEnum logType, string description, string detail)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(); //Para obtener el nombre del metodo que lo llamo

                Depositario.Business.Tables.Auditoria.Log entities = new();
                Depositario.Entities.Tables.Auditoria.Log entity = new()
                {
                    AplicacionId = Global.Constants.APPLICATION_ID,
                    Fecha = DateTime.Now,
                    Metodo = stackTrace.GetFrame(1).GetMethod().Name,
                    Modulo = stackTrace.GetFrame(1).GetMethod().Module.Name,
                    TipoId = (long)logType,
                    Descripcion = description,
                    Detalle = detail,
                    UsuarioId = 
                        DatabaseController.CurrentUser == null ? -1: 
                        DatabaseController.CurrentUser.Id,

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
