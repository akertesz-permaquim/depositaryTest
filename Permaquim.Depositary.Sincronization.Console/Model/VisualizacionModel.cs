using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class VisualizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Visualizacion.Perfil> Perfiles { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilItem> PerfilesItems { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilTipo> Tipos { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfil = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Visualizacion_Perfil);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Visualizacion_Perfil).Replace("_", "."), fechaSincroPerfil);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfilItem = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Visualizacion_PerfilItem);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Visualizacion_PerfilItem).Replace("_", "."), fechaSincroPerfilItem);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfilTipo = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo).Replace("_", "."), fechaSincroPerfilTipo);
        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (Tipos.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.PerfilTipo perfilTipo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Tipos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo, item.Id);
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
                                    perfilTipo.Update(item);
                                }
                                else
                                {
                                    perfilTipo.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Perfiles.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.Perfil perfil = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_Perfil, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? perfilTipoIdOrigen;
                        foreach (var item in Perfiles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_Perfil, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            perfilTipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo, item.PerfilTipoId);

                            if (perfilTipoIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PerfilTipoId = perfilTipoIdOrigen.Value;
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
                                    perfil.Update(item);
                                }
                                else
                                {
                                    perfil.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (PerfilesItems.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.PerfilItem perfilItem = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_PerfilItem, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? perfilIdOrigen;
                        foreach (var item in PerfilesItems)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_PerfilItem, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_Perfil, item.PerfilId);

                            if (perfilIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PerfilId = perfilIdOrigen.Value;
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
                                    perfilItem.Update(item);
                                }
                                else
                                {
                                    perfilItem.Add(item);
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
