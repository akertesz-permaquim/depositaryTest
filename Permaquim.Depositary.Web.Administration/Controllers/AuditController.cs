using Permaquim.Depositary.Web.Administration.Entities;
using Permaquim.Depositary.Web.Administration.Managers;
using System.Diagnostics;
using static Permaquim.Depositary.Web.Administration.Entities.AuditEntities;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class AuditController
    {
        public static void Log(LogTypeEnum logType, string description, string detail)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(); //Para obtener el nombre del metodo que lo llamo

                Permaquim.Depositary.Business.Tables.Auditoria.Log entities = new();
                Permaquim.Depositary.Entities.Tables.Auditoria.Log entity = new()
                {
                    AplicacionId = AuditEntities.APPLICATION_ID,
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
