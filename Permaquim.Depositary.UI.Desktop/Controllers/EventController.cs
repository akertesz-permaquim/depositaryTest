using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class EventController
    {
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _normal = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _cambio_de_Contenedor = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _alarma_de_Contenedor_Mal_Ubicado = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _alarma_De_Exclusa = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _estado_Fuera_De_Servicio = new() { Fecha = DateTime.Now};
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _error_De_Comunicacion = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _apertura_de_Puerta = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _cambio_de_Contenedor_Sin_usuario = new() { Fecha = DateTime.Now };
        private static Permaquim.Depositario.Entities.Tables.Operacion.Evento _cassette_full = new() { Fecha = DateTime.Now };

        private static int _eventTime  = ParameterController.EventEvaluationSeconds;

        private static Permaquim.Depositario.Business.Tables.Operacion.Evento _entities = new();

        public static void CreateEvent(EventTypeEnum eventTypeEnum, string message, string value)
        {


            switch (eventTypeEnum)
            {
                case EventTypeEnum.Normal:
                    if (DateTime.Now.Subtract(_normal.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _normal.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Cambio_de_Contenedor:
                    if (DateTime.Now.Subtract(_cambio_de_Contenedor.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _cambio_de_Contenedor.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Alarma_de_Contenedor_Mal_Ubicado:
                    if (DateTime.Now.Subtract(_alarma_de_Contenedor_Mal_Ubicado.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _alarma_de_Contenedor_Mal_Ubicado.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Alarma_De_Exclusa:
                    if (DateTime.Now.Subtract(_alarma_De_Exclusa.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _alarma_De_Exclusa.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Estado_Fuera_De_Servicio:
                    if (DateTime.Now.Subtract(_estado_Fuera_De_Servicio.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _estado_Fuera_De_Servicio.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Error_De_Comunicacion:
                    if (DateTime.Now.Subtract(_error_De_Comunicacion.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _error_De_Comunicacion.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Apertura_de_Puerta:
                    if (DateTime.Now.Subtract(_apertura_de_Puerta.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _apertura_de_Puerta.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Cambio_de_Contenedor_Sin_usuario:
                    if (DateTime.Now.Subtract(_cambio_de_Contenedor_Sin_usuario.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _cambio_de_Contenedor_Sin_usuario.Fecha = DateTime.Now;
                    }
                    break;
                case EventTypeEnum.Cassette_Full:
                    if (DateTime.Now.Subtract(_cassette_full.Fecha).TotalSeconds <= _eventTime)
                    {
                        return;
                    }
                    else
                    {
                        _cassette_full.Fecha = DateTime.Now;
                    }
                    break;
                default:
                        return;
            }

          
            _entities.Add(new Depositario.Entities.Tables.Operacion.Evento()
            {
                DepositarioId = DatabaseController.CurrentDepositary.Id,
                Fecha = DateTime.Now,
                Mensaje = message,
                SesionId = DatabaseController.CurrentSession == null ? 0 : DatabaseController.CurrentSession.Id,
                TipoId = (long)eventTypeEnum,
                Valor = value

            });
        }
    }
}

