using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class AuditoriaModel : IModel
    {
        public List<Depositario.Entities.Tables.Auditoria.TipoLog> TiposLogs { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoLog = SynchronizationController.obtenerFechaUltimaSincronizacion("Auditoria.TipoLog");

            SincroDates.Add("Auditoria.TipoLog", fechaSincroTipoLog);
        }

        public void Persist()
        {
            try
            {
                if (TiposLogs.Count > 0)
                {
                    Depositario.Business.Tables.Sincronizacion.Entidad entidad = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Auditoria.TipoLog");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposLogs)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Auditoria.TipoLog", item.Id);
                            Int64? usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if(usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    Int64? usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    entidad.Update(item);
                                }
                                else
                                {
                                    entidad.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
