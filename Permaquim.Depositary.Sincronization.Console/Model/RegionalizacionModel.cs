using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class RegionalizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Regionalizacion.Lenguaje> Lenguajes { get; set; } = new();
        public List<Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;


        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroLenguaje = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje).Replace("_", "."), fechaSincroLenguaje);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroLenguajeItem = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Regionalizacion_LenguajeItem);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Regionalizacion_LenguajeItem).Replace("_", "."), fechaSincroLenguajeItem);
        }
        public void Persist()
        {
            try
            {

                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (Lenguajes.Count > 0)
                {
                    Depositario.Business.Tables.Regionalizacion.Lenguaje lenguaje = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Lenguajes)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.Id);
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
                                    lenguaje.Update(item);
                                }
                                else
                                {
                                    lenguaje.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }


                if (LenguajeItems.Count > 0)
                {
                    Depositario.Business.Tables.Regionalizacion.LenguajeItem lenguajeItem = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Regionalizacion_LenguajeItem, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? lenguajeIdOrigen;
                        foreach (var item in LenguajeItems)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Regionalizacion_LenguajeItem, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);

                            if (lenguajeIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.LenguajeId = lenguajeIdOrigen.Value;
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
                                    lenguajeItem.Update(item);
                                }
                                else
                                {
                                    lenguajeItem.Add(item);
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
