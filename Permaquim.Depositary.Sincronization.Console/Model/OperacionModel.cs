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

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoTransaccion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TipoTransaccion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Operacion_TipoTransaccion).Replace("_", "."), fechaSincroTipoTransaccion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoEvento = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TipoEvento);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Operacion_TipoEvento).Replace("_", "."), fechaSincroTipoEvento);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoContenedor = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TipoContenedor);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Operacion_TipoContenedor).Replace("_", "."), fechaSincroTipoContenedor);

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

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoEvento, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposEventos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoEvento, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposContenedores.Count > 0)
                {
                    Depositario.Business.Tables.Operacion.TipoContenedor tipoContenedor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoContenedor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposContenedores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoContenedor, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposTransacciones.Count > 0)
                {
                    Depositario.Business.Tables.Operacion.TipoTransaccion tipoTransaccion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoTransaccion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? funcionIdOrigen;
                        foreach (var item in TiposTransacciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoTransaccion, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {

                                if (item.FuncionId.HasValue)
                                {
                                    funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId.Value);
                                    item.FuncionId = funcionIdOrigen;
                                }

                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
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
