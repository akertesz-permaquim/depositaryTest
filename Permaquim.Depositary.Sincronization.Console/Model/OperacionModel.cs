using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class OperacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Operacion.TipoContenedor> TiposContenedores { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoEvento> TiposEventos { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoTransaccion> TiposTransacciones { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoTransaccion = SynchronizationController.obtenerFechaUltimaSincronizacion("Operacion.TipoTransaccion");

            SincroDates.Add("Operacion.TipoTransaccion", fechaSincroTipoTransaccion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoEvento = SynchronizationController.obtenerFechaUltimaSincronizacion("Operacion.TipoEvento");

            SincroDates.Add("Operacion.TipoEvento", fechaSincroTipoEvento);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoContenedor = SynchronizationController.obtenerFechaUltimaSincronizacion("Operacion.TipoContenedor");

            SincroDates.Add("Operacion.TipoContenedor", fechaSincroTipoContenedor);

        }

        public void Persist()
        {
            try
            {

                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposEventos.Count > 0)
                {
                    Depositario.Business.Tables.Operacion.TipoEvento tipoEvento = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Operacion.TipoEvento");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposEventos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Operacion.TipoEvento", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    tipoEvento.Update(item);
                                }
                                else
                                {
                                    tipoEvento.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposContenedores.Count > 0)
                {
                    Depositario.Business.Tables.Operacion.TipoContenedor tipoContenedor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Operacion.TipoContenedor");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposContenedores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Operacion.TipoContenedor", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    tipoContenedor.Update(item);
                                }
                                else
                                {
                                    tipoContenedor.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposTransacciones.Count > 0)
                {
                    Depositario.Business.Tables.Operacion.TipoTransaccion tipoTransaccion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Operacion.TipoTransaccion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? funcionIdOrigen;
                        foreach (var item in TiposTransacciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Operacion.TipoTransaccion", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {

                                if (item.FuncionId.HasValue)
                                {
                                    funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Funcion", item.FuncionId.Value);
                                    item.FuncionId = funcionIdOrigen;
                                }

                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    tipoTransaccion.Update(item);
                                }
                                else
                                {
                                    tipoTransaccion.Add(item);
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
