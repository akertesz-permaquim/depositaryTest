using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class AplicacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionTipoDato> TiposDatos { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> ValidacionesDatos { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> Configuraciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionesEmpresas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;
        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionTipoDato = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato).Replace("_", "."), fechaSincroConfiguracionTipoDato);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionValidacionDato = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato).Replace("_", "."), fechaSincroConfiguracionValidacionDato);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Aplicacion_Configuracion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Aplicacion_Configuracion).Replace("_", "."), fechaSincroConfiguracion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionEmpresa = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionEmpresa);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionEmpresa).Replace("_", "."), fechaSincroConfiguracionEmpresa);
        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposDatos.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionTipoDato configuracionTipoDato = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposDatos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato, item.Id);
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
                                    configuracionTipoDato.Update(item);
                                }
                                else
                                {
                                    configuracionTipoDato.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (ValidacionesDatos.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionValidacionDato configuracionValidacionDato = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoDatoIdOrigen;
                        foreach (var item in ValidacionesDatos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.Id);
                            tipoDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato, item.TipoDatoId);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (tipoDatoIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoDatoId = tipoDatoIdOrigen.Value;
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
                                    configuracionValidacionDato.Update(item);
                                }
                                else
                                {
                                    configuracionValidacionDato.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Configuraciones.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.Configuracion configuracion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_Configuracion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? validacionDatoIdOrigen;
                        foreach (var item in Configuraciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_Configuracion, item.Id);

                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (aplicacionIdOrigen.HasValue && validacionDatoIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;
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
                                    configuracion.Update(item);
                                }
                                else
                                {
                                    configuracion.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (ConfiguracionesEmpresas.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa configuracionEmpresa = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionEmpresa, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? validacionDatoIdOrigen;
                        Int64? empresaIdOrigen;
                        foreach (var item in ConfiguracionesEmpresas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionEmpresa, item.Id);
                            validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (empresaIdOrigen.HasValue && validacionDatoIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;
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
                                    configuracionEmpresa.Update(item);
                                }
                                else
                                {
                                    configuracionEmpresa.Add(item);
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
