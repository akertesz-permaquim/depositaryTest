

using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class InicializacionModel
    {
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;
        public string CodigoExternoDepositario { get; set; } = ConfigurationController.GetCurrentDepositaryCode();

        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionTipoDato> AplicacionConfiguracionTipoDato { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> AplicacionConfiguracionValidacionDato { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> AplicacionConfiguracion { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionEmpresa> AplicacionConfiguracionEmpresa { get; set; } = new();
        public List<Depositario.Entities.Tables.Auditoria.TipoLog> AuditoriaTipoLog { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Banco> BancaBanco { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Cuenta> BancaCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.TipoCuenta> BancaTipoCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.UsuarioCuenta> BancaUsuarioCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Biometria.HuellaDactilar> BiometriaHuellaDactilar { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Empresa> DirectorioEmpresa { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Grupo> DirectorioGrupo { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.IdentificadorUsuario> SeguridadIdentificadorUsuario { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.RelacionMonedaSucursal> DirectorioRelacionMonedaSucursal { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sector> DirectorioSector { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sucursal> DirectorioSucursal { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoIdentificador> SeguridadTipoIdentificador { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoContadora> DispositivoComandoContadora { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoPlaca> DispositivoComandoPlaca { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> DispositivoConfiguracionDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Depositario> DispositivoDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioContadora> DispositivoDepositarioContadora { get; set; } = new();
        //public List<Depositario.Entities.Tables.Dispositivo.DepositarioEstado> DispositivoDepositarioEstado { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> DispositivoDepositarioMoneda { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioPlaca> DispositivoDepositarioPlaca { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Marca> DispositivoMarca { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Modelo> DispositivoModelo { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> DispositivoTipoConfiguracionDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoContadora> DispositivoTipoContadora { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoPlaca> DispositivoTipoPlaca { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.Esquema> EstiloEsquema { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.EsquemaDetalle> EstiloEsquemaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.TipoEsquemaDetalle> EstiloTipoEsquemaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Ciudad> GeografiaCiudad { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.CodigoPostal> GeografiaCodigoPostal { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Pais> GeografiaPais { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Provincia> GeografiaProvincia { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Zona> GeografiaZona { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoContenedor> OperacionTipoContenedor { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoEvento> OperacionTipoEvento { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoTransaccion> OperacionTipoTransaccion { get; set; } = new();
        public List<Depositario.Entities.Tables.Regionalizacion.Lenguaje> RegionalizacionLenguaje { get; set; } = new();
        public List<Depositario.Entities.Tables.Regionalizacion.LenguajeItem> RegionalizacionLenguajeItem { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Aplicacion> SeguridadAplicacion { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametro> SeguridadAplicacionParametro { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametroValor> SeguridadAplicacionParametroValor { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Funcion> SeguridadFuncion { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Menu> SeguridadMenu { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Rol> SeguridadRol { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.RolFuncion> SeguridadRolFuncion { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoAplicacion> SeguridadTipoAplicacion { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoFuncion> SeguridadTipoFuncion { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoMenu> SeguridadTipoMenu { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Usuario> SeguridadUsuario { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioRol> SeguridadUsuarioRol { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioSector> SeguridadUsuarioSector { get; set; } = new();
        public List<Depositario.Entities.Tables.Sincronizacion.Configuracion> SincronizacionConfiguracion { get; set; } = new();
        public List<Depositario.Entities.Tables.Sincronizacion.Entidad> SincronizacionEntidad { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.AgendaTurno> TurnoAgendaTurno { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.EsquemaDetalleTurno> TurnoEsquemaDetalleTurno { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.EsquemaTurno> TurnoEsquemaTurno { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Denominacion> ValorDenominacion { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Moneda> ValorMoneda { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.RelacionMonedaTipoValor> ValorRelacionMonedaTipoValor { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Tipo> ValorTipo { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.Perfil> VisualizacionPerfil { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilItem> VisualizacionPerfilItem { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilTipo> VisualizacionPerfilTipo { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMoneda> PlantillaMoneda { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> PlantillaMonedaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.OrigenValor> OrigenValor { get; set; } = new();
        public List<Depositario.Entities.Tables.Impresion.TipoTicket> TipoTicket { get; set; } = new();
        public List<Depositario.Entities.Tables.Impresion.Ticket> Ticket { get; set; } = new();

        public bool Persist()
        {
            bool resultado = false;

            Depositario.Business.Tables.Sincronizacion.Entidad entitiesSincronizacionEntidad = new();

            entitiesSincronizacionEntidad.BeginTransaction();

            Depositario.Business.Tables.Sincronizacion.Configuracion entitiesSincronizacionConfiguracion = new(entitiesSincronizacionEntidad);
            try
            {
                #region Sincronizacion

                if (SincronizacionEntidad.Count > 0)
                {
                    foreach (var item in SincronizacionEntidad)
                    {
                        var newEntitieSincronizacionEntidad = entitiesSincronizacionEntidad.Add(item);
                        var sincronizacionConfiguracionEntities = SincronizacionConfiguracion.Where(x => x.EntidadId == item.Id);
                        if (sincronizacionConfiguracionEntities != null)
                        {
                            Int64? sincronizacionCabeceraId = null;

                            sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Sincronizacion_Configuracion, DateTime.Now);

                            if (sincronizacionCabeceraId != null)
                            {
                                foreach (var subItem in sincronizacionConfiguracionEntities)
                                {
                                    subItem.EntidadId = newEntitieSincronizacionEntidad.Id;

                                    Int64 origenId = subItem.Id;

                                    subItem.UsuarioCreacion = 0;
                                    subItem.UsuarioModificacion = subItem.UsuarioModificacion.HasValue ? 0 : null;

                                    var newEntitieSincronizacionConfiguracion = entitiesSincronizacionConfiguracion.Add(subItem);

                                    SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSincronizacionConfiguracion.Id);
                                }

                                SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                            }
                        }
                    }
                }

                #endregion

                #region Geografia

                Depositario.Business.Tables.Geografia.Pais entitiesGeografiaPais = new(entitiesSincronizacionEntidad);
                if (GeografiaPais.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Geografia_Pais, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in GeografiaPais)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieGeografiaPais = entitiesGeografiaPais.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaPais.Id);
                        }

                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Geografia.Provincia entitiesGeografiaProvincia = new(entitiesSincronizacionEntidad);
                if (GeografiaProvincia.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Geografia_Provincia, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in GeografiaProvincia)
                        {
                            Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Pais, item.PaisId);

                            if (paisIdOrigen.HasValue)
                            {
                                item.PaisId = paisIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieGeografiaProvincia = entitiesGeografiaProvincia.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaProvincia.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Geografia.Ciudad entitiesGeografiaCiudad = new(entitiesSincronizacionEntidad);
                if (GeografiaCiudad.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Geografia_Ciudad, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in GeografiaCiudad)
                        {
                            Int64? provinciaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Provincia, item.ProvinciaId);

                            if (provinciaIdOrigen.HasValue)
                            {
                                item.ProvinciaId = provinciaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieGeografiaCiudad = entitiesGeografiaCiudad.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaCiudad.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Geografia.CodigoPostal entitiesGeografiaCodigoPostal = new(entitiesSincronizacionEntidad);

                if (GeografiaCodigoPostal.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Geografia_CodigoPostal, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in GeografiaCodigoPostal)
                        {
                            Int64? ciudadIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Ciudad, item.CiudadId);

                            if (ciudadIdOrigen.HasValue)
                            {
                                item.CiudadId = ciudadIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieGeografiaCodigoPostal = entitiesGeografiaCodigoPostal.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaCodigoPostal.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);

                    }
                }

                Depositario.Business.Tables.Geografia.Zona entitiesGeografiaZona = new(entitiesSincronizacionEntidad);

                if (GeografiaZona.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Geografia_Zona, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in GeografiaZona)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieGeografiaZona = entitiesGeografiaZona.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaZona.Id);
                        }

                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Auditoria

                Depositario.Business.Tables.Auditoria.TipoLog entitiesAuditoriaTipoLog = new(entitiesSincronizacionEntidad);

                if (AuditoriaTipoLog.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Auditoria_TipoLog, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {

                        foreach (var item in AuditoriaTipoLog)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieAuditoriaTipoLog = entitiesAuditoriaTipoLog.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieAuditoriaTipoLog.Id);
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Regionalizacion

                Depositario.Business.Tables.Regionalizacion.Lenguaje entitiesRegionalizacionLenguaje = new(entitiesSincronizacionEntidad);

                if (RegionalizacionLenguaje.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in RegionalizacionLenguaje)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieAuditoriaRegionalizacionLenguaje = entitiesRegionalizacionLenguaje.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieAuditoriaRegionalizacionLenguaje.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Regionalizacion.LenguajeItem entitiesRegionalizacionLenguajeItem = new(entitiesSincronizacionEntidad);

                if (RegionalizacionLenguajeItem.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Regionalizacion_LenguajeItem, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {

                        foreach (var item in RegionalizacionLenguajeItem)
                        {
                            Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);

                            if (lenguajeIdOrigen.HasValue)
                            {
                                item.LenguajeId = lenguajeIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieRegionalizacionLenguajeItem = entitiesRegionalizacionLenguajeItem.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieRegionalizacionLenguajeItem.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Visualizacion

                Depositario.Business.Tables.Visualizacion.PerfilTipo entitiesVisualizacionPerfilTipo = new(entitiesSincronizacionEntidad);

                if (VisualizacionPerfilTipo.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {

                        foreach (var item in VisualizacionPerfilTipo)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieVisualizacionPerfilTipo = entitiesVisualizacionPerfilTipo.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfilTipo.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Visualizacion.Perfil entitiesVisualizacionPerfil = new(entitiesSincronizacionEntidad);

                if (VisualizacionPerfil.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_Perfil, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in VisualizacionPerfil)
                        {
                            Int64? perfilTipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Visualizacion_PerfilTipo, item.PerfilTipoId);

                            if (perfilTipoIdOrigen.HasValue)
                            {
                                item.PerfilTipoId = perfilTipoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieVisualizacionPerfil = entitiesVisualizacionPerfil.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfil.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Visualizacion.PerfilItem entitiesVisualizacionPerfilItem = new(entitiesSincronizacionEntidad);

                if (VisualizacionPerfilItem.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Visualizacion_PerfilItem, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in VisualizacionPerfilItem)
                        {
                            Int64? perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Visualizacion_Perfil, item.PerfilId);

                            if (perfilIdOrigen.HasValue)
                            {
                                item.PerfilId = perfilIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieVisualizacionPerfilItem = entitiesVisualizacionPerfilItem.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfilItem.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Biometria

                Depositario.Business.Tables.Biometria.HuellaDactilar entitiesBiometriaHuellaDactilar = new(entitiesSincronizacionEntidad);

                if (BiometriaHuellaDactilar.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Biometria_HuellaDactilar, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in BiometriaHuellaDactilar)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieBiometriaHuellaDactilar = entitiesBiometriaHuellaDactilar.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieBiometriaHuellaDactilar.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Seguridad.Aplicacion

                Depositario.Business.Tables.Seguridad.TipoAplicacion entitiesSeguridadTipoAplicacion = new(entitiesSincronizacionEntidad);

                if (SeguridadTipoAplicacion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {

                        foreach (var item in SeguridadTipoAplicacion)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieSeguridadTipoAplicacion = entitiesSeguridadTipoAplicacion.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoAplicacion.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.Aplicacion entitiesSeguridadAplicacion = new(entitiesSincronizacionEntidad);

                if (SeguridadAplicacion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Aplicacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadAplicacion)
                        {
                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion, item.TipoId);

                            if (tipoIdOrigen.HasValue)
                            {
                                item.TipoId = tipoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadAplicacion = entitiesSeguridadAplicacion.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacion.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.AplicacionParametro entitiesSeguridadAplicacionParametro = new(entitiesSincronizacionEntidad);

                if (SeguridadAplicacionParametro.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadAplicacionParametro)
                        {
                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue)
                            {
                                item.AplicacionId = aplicacionIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadAplicacionParametro = entitiesSeguridadAplicacionParametro.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacionParametro.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.AplicacionParametroValor entitiesSeguridadAplicacionParametroValor = new(entitiesSincronizacionEntidad);

                if (SeguridadAplicacionParametroValor.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_AplicacionParametroValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadAplicacionParametroValor)
                        {
                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            Int64? aplicacionParametroIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro, item.ParametroId);

                            if (aplicacionIdOrigen.HasValue && aplicacionParametroIdOrigen.HasValue)
                            {
                                item.AplicacionId = aplicacionIdOrigen.Value;

                                item.ParametroId = aplicacionParametroIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadAplicacionParametroValor = entitiesSeguridadAplicacionParametroValor.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacionParametroValor.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Valor

                Depositario.Business.Tables.Valor.Tipo entitiesValorTipo = new(entitiesSincronizacionEntidad);

                if (ValorTipo.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Tipo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ValorTipo)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieValorTipo = entitiesValorTipo.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieValorTipo.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Valor.Moneda entitiesValorMoneda = new(entitiesSincronizacionEntidad);
                if (ValorMoneda.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Moneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ValorMoneda)
                        {
                            Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Pais, item.PaisId);

                            if (paisIdOrigen.HasValue)
                            {
                                item.PaisId = paisIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieValorMoneda = entitiesValorMoneda.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieValorMoneda.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Valor.Denominacion entitiesValorDenominacion = new(entitiesSincronizacionEntidad);

                if (ValorDenominacion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Denominacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ValorDenominacion)
                        {
                            Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Tipo, item.TipoValorId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (monedaIdOrigen.HasValue && tipoValorIdOrigen.HasValue)
                            {
                                item.MonedaId = monedaIdOrigen.Value;

                                item.TipoValorId = tipoValorIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieValorDenominacion = entitiesValorDenominacion.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieValorDenominacion.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Valor.RelacionMonedaTipoValor entitiesValorRelacionMonedaTipoValor = new(entitiesSincronizacionEntidad);

                if (ValorRelacionMonedaTipoValor.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ValorRelacionMonedaTipoValor)
                        {
                            Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Tipo, item.TipoValorId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (monedaIdOrigen.HasValue && tipoValorIdOrigen.HasValue)
                            {
                                item.MonedaId = monedaIdOrigen.Value;

                                item.TipoValorId = tipoValorIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieValorRelacionMonedaTipoValor = entitiesValorRelacionMonedaTipoValor.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieValorRelacionMonedaTipoValor.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Estilo

                Depositario.Business.Tables.Estilo.TipoEsquemaDetalle entitiesEstiloTipoEsquemaDetalle = new(entitiesSincronizacionEntidad);

                if (EstiloTipoEsquemaDetalle.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Estilo_TipoEsquemaDetalle, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EstiloTipoEsquemaDetalle)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieEstiloTipoEsquemaDetalle = entitiesEstiloTipoEsquemaDetalle.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloTipoEsquemaDetalle.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Estilo.Esquema entitiesEstiloEsquema = new(entitiesSincronizacionEntidad);

                if (EstiloEsquema.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Estilo_Esquema, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EstiloEsquema)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieEstiloEsquema = entitiesEstiloEsquema.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloEsquema.Id);
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Estilo.EsquemaDetalle entitiesEstiloEsquemaDetalle = new(entitiesSincronizacionEntidad);
                if (EstiloEsquemaDetalle.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Estilo_EsquemaDetalle, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EstiloEsquemaDetalle)
                        {
                            Int64? esquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Estilo_Esquema, item.EsquemaId);
                            Int64? tipoEsquemaDetalleIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Estilo_TipoEsquemaDetalle, item.TipoEsquemaDetalleId);

                            if (esquemaIdOrigen.HasValue && tipoEsquemaDetalleIdOrigen.HasValue)
                            {
                                item.EsquemaId = esquemaIdOrigen.Value;

                                item.TipoEsquemaDetalleId = tipoEsquemaDetalleIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieEstiloEsquemaDetalle = entitiesEstiloEsquemaDetalle.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloEsquemaDetalle.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Directorio

                Depositario.Business.Tables.Directorio.Grupo entitiesDirectorioGrupo = new(entitiesSincronizacionEntidad);

                if (DirectorioGrupo.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Grupo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DirectorioGrupo)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieDirectorioGrupo = entitiesDirectorioGrupo.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioGrupo.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Directorio.Empresa entitiesDirectorioEmpresa = new(entitiesSincronizacionEntidad);

                if (DirectorioEmpresa.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Empresa, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DirectorioEmpresa)
                        {
                            Int64? grupoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Grupo, item.GrupoId);
                            Int64? estiloEsquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Estilo_Esquema, item.EstiloEsquemaId);
                            Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);
                            Int64? codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_CodigoPostal, item.CodigoPostalId);

                            if (grupoIdOrigen.HasValue && estiloEsquemaIdOrigen.HasValue && lenguajeIdOrigen.HasValue && codigoPostalIdOrigen.HasValue)
                            {
                                item.GrupoId = grupoIdOrigen.Value;

                                item.EstiloEsquemaId = estiloEsquemaIdOrigen.Value;

                                item.CodigoPostalId = codigoPostalIdOrigen.Value;

                                item.LenguajeId = lenguajeIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDirectorioEmpresa = entitiesDirectorioEmpresa.Add(item);
                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioEmpresa.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Directorio.Sucursal entitiesDirectorioSucursal = new(entitiesSincronizacionEntidad);

                if (DirectorioSucursal.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Sucursal, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DirectorioSucursal)
                        {
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            Int64? codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_CodigoPostal, item.CodigoPostalId);
                            Int64? zonaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Zona, item.ZonaId);

                            if (empresaIdOrigen.HasValue && codigoPostalIdOrigen.HasValue && zonaIdOrigen.HasValue)
                            {
                                item.EmpresaId = empresaIdOrigen.Value;

                                item.CodigoPostalId = codigoPostalIdOrigen.Value;

                                item.ZonaId = zonaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDirectorioSucursal = entitiesDirectorioSucursal.Add(item);
                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioSucursal.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Directorio.Sector entitiesDirectorioSector = new(entitiesSincronizacionEntidad);

                if (DirectorioSector.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Sector, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DirectorioSector)
                        {
                            Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Sucursal, item.SucursalId);

                            if (sucursalIdOrigen.HasValue)
                            {
                                item.SucursalId = sucursalIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDirectorioSector = entitiesDirectorioSector.Add(item);
                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioSector.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Directorio.RelacionMonedaSucursal entitiesDirectorioRelacionMonedaSucursal = new(entitiesSincronizacionEntidad);

                if (DirectorioRelacionMonedaSucursal.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_RelacionMonedaSucursal, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DirectorioRelacionMonedaSucursal)
                        {
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);
                            Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Sucursal, item.SucursalId);

                            if (monedaIdOrigen.HasValue && sucursalIdOrigen.HasValue)
                            {
                                item.MonedaId = monedaIdOrigen.Value;

                                item.SucursalId = sucursalIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDirectorioRelacionMonedaSucursal = entitiesDirectorioRelacionMonedaSucursal.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioRelacionMonedaSucursal.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Valor.OrigenValor

                Depositario.Business.Tables.Valor.OrigenValor entitiesOrigenValor = new(entitiesSincronizacionEntidad);

                if (OrigenValor.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_OrigenValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in OrigenValor)
                        {
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);

                            if (empresaIdOrigen.HasValue)
                            {
                                item.EmpresaId = empresaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieValorOrigenValor = entitiesOrigenValor.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieValorOrigenValor.Id);
                            }

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Seguridad

                Depositario.Business.Tables.Seguridad.TipoFuncion entitiesSeguridadTipoFuncion = new(entitiesSincronizacionEntidad);

                if (SeguridadTipoFuncion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoFuncion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadTipoFuncion)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieSeguridadTipoFuncion = entitiesSeguridadTipoFuncion.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoFuncion.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.TipoIdentificador entitiesSeguridadTipoIdentificador = new(entitiesSincronizacionEntidad);

                if (SeguridadTipoIdentificador.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadTipoIdentificador)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieSeguridadTipoIdentificador = entitiesSeguridadTipoIdentificador.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoIdentificador.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.TipoMenu entitiesSeguridadTipoMenu = new(entitiesSincronizacionEntidad);

                if (SeguridadTipoMenu.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoMenu, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadTipoMenu)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieSeguridadTipoMenu = entitiesSeguridadTipoMenu.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoMenu.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.Usuario entitiesSeguridadUsuario = new(entitiesSincronizacionEntidad);

                if (SeguridadUsuario.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Usuario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadUsuario)
                        {
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            Int64? lenguajelIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);
                            Int64? perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Visualizacion_Perfil, item.PerfilId);

                            if (empresaIdOrigen.HasValue && lenguajelIdOrigen.HasValue && perfilIdOrigen.HasValue)
                            {
                                item.EmpresaId = empresaIdOrigen.Value;

                                item.LenguajeId = lenguajelIdOrigen.Value;

                                item.PerfilId = perfilIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadUsuario = entitiesSeguridadUsuario.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuario.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.Funcion entitiesSeguridadFuncion = new(entitiesSincronizacionEntidad);

                if (SeguridadFuncion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Funcion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadFuncion)
                        {
                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            Int64? tipoFuncionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_TipoFuncion, item.TipoId);

                            if (aplicacionIdOrigen.HasValue && tipoFuncionIdOrigen.HasValue)
                            {
                                item.AplicacionId = aplicacionIdOrigen.Value;

                                item.TipoId = tipoFuncionIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadFuncion = entitiesSeguridadFuncion.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadFuncion.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.IdentificadorUsuario entitiesSeguridadIdentificadorUsuario = new(entitiesSincronizacionEntidad);

                if (SeguridadIdentificadorUsuario.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_IdentificadorUsuario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadIdentificadorUsuario)
                        {
                            Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            Int64? tipoIdentificadorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador, item.TipoId);

                            if (usuarioIdOrigen.HasValue && tipoIdentificadorIdOrigen.HasValue)
                            {
                                item.UsuarioId = usuarioIdOrigen.Value;

                                item.TipoId = tipoIdentificadorIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadIdentificadorUsuario = entitiesSeguridadIdentificadorUsuario.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadIdentificadorUsuario.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.Rol entitiesSeguridadRol = new(entitiesSincronizacionEntidad);
                if (SeguridadRol.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Rol, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadRol.OrderBy(x => x.DependeDe))
                        {
                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue)
                            {
                                if (item.DependeDe.HasValue)
                                {
                                    Int64? dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Rol, item.DependeDe.Value);
                                    item.DependeDe = dependeDeOrigen;
                                }

                                item.AplicacionId = aplicacionIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadRol = entitiesSeguridadRol.Add(item);
                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadRol.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.UsuarioRol entitiesSeguridadUsuarioRol = new(entitiesSincronizacionEntidad);

                if (SeguridadUsuarioRol.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_UsuarioRol, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadUsuarioRol)
                        {
                            Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            Int64? rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Rol, item.RolId);

                            if (usuarioIdOrigen.HasValue && rolIdOrigen.HasValue)
                            {
                                item.UsuarioId = usuarioIdOrigen.Value;

                                item.RolId = rolIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadUsuarioRol = entitiesSeguridadUsuarioRol.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuarioRol.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.UsuarioSector entitiesSeguridadUsuarioSector = new(entitiesSincronizacionEntidad);
                if (SeguridadUsuarioSector.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_UsuarioSector, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadUsuarioSector)
                        {
                            Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);

                            if (usuarioIdOrigen.HasValue && usuarioIdOrigen.HasValue)
                            {
                                item.SectorId = sectorIdOrigen.Value;

                                item.UsuarioId = usuarioIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadUsuarioSector = entitiesSeguridadUsuarioSector.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuarioSector.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.Menu entitiesSeguridadMenu = new(entitiesSincronizacionEntidad);
                if (SeguridadMenu.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Menu, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadMenu.OrderBy(x => x.DependeDe))
                        {
                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_TipoMenu, item.TipoId);
                            Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId);

                            if (tipoIdOrigen.HasValue && funcionIdOrigen.HasValue)
                            {
                                item.TipoId = tipoIdOrigen.Value;

                                item.FuncionId = funcionIdOrigen.Value;

                                if (item.DependeDe.HasValue)
                                {
                                    Int64? dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Menu, item.DependeDe.Value);
                                    item.DependeDe = dependeDeOrigen;
                                }

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadMenu = entitiesSeguridadMenu.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadMenu.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Seguridad.RolFuncion entitiesSeguridadRolFuncion = new(entitiesSincronizacionEntidad);

                if (SeguridadRolFuncion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_RolFuncion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in SeguridadRolFuncion)
                        {
                            Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId);
                            Int64? rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Rol, item.RolId);

                            if (funcionIdOrigen.HasValue && rolIdOrigen.HasValue)
                            {
                                item.FuncionId = funcionIdOrigen.Value;

                                item.RolId = rolIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieSeguridadRolFuncion = entitiesSeguridadRolFuncion.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadRolFuncion.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Banca

                Depositario.Business.Tables.Banca.Banco entitiesBancaBanco = new(entitiesSincronizacionEntidad);

                if (BancaBanco.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_Banco, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in BancaBanco)
                        {
                            Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Geografia_Pais, item.PaisId);

                            if (paisIdOrigen.HasValue)
                            {
                                item.PaisId = paisIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieBancaBanco = entitiesBancaBanco.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieBancaBanco.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Banca.TipoCuenta entitiesBancaTipoCuenta = new(entitiesSincronizacionEntidad);

                if (BancaTipoCuenta.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_TipoCuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in BancaTipoCuenta)
                        {
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (monedaIdOrigen.HasValue)
                            {
                                Int64 origenId = item.Id;

                                item.MonedaId = monedaIdOrigen.Value;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieBancaTipoCuenta = entitiesBancaTipoCuenta.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieBancaTipoCuenta.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Banca.Cuenta entitiesBancaCuenta = new(entitiesSincronizacionEntidad);
                if (BancaCuenta.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_Cuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in BancaCuenta)
                        {
                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Banca_TipoCuenta, item.TipoId);
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            Int64? bancoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Banca_Banco, item.BancoId);

                            if (tipoIdOrigen.HasValue && empresaIdOrigen.HasValue && bancoIdOrigen.HasValue)
                            {
                                item.TipoId = tipoIdOrigen.Value;

                                item.EmpresaId = empresaIdOrigen.Value;

                                item.BancoId = bancoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieBancaCuenta = entitiesBancaCuenta.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieBancaCuenta.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Banca.UsuarioCuenta entitiesBancaUsuarioCuenta = new(entitiesSincronizacionEntidad);
                if (BancaUsuarioCuenta.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_UsuarioCuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in BancaUsuarioCuenta)
                        {
                            Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            Int64? cuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Banca_Cuenta, item.CuentaId);

                            if (usuarioIdOrigen.HasValue && cuentaIdOrigen.HasValue)
                            {
                                item.UsuarioId = usuarioIdOrigen.Value;

                                item.CuentaId = cuentaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieBancaUsuarioCuenta = entitiesBancaUsuarioCuenta.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieBancaUsuarioCuenta.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Aplicacion

                Depositario.Business.Tables.Aplicacion.ConfiguracionTipoDato entitiesAplicacionConfiguracionTipoDato = new(entitiesSincronizacionEntidad);

                if (AplicacionConfiguracionTipoDato.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in AplicacionConfiguracionTipoDato)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieAplicacionConfiguracionTipoDato = entitiesAplicacionConfiguracionTipoDato.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracionTipoDato.Id);
                        }

                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Aplicacion.ConfiguracionValidacionDato entitiesAplicacionConfiguracionValidacionDato = new(entitiesSincronizacionEntidad);

                if (AplicacionConfiguracionValidacionDato.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in AplicacionConfiguracionValidacionDato)
                        {
                            Int64? tipoDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionTipoDato, item.TipoDatoId);

                            if (tipoDatoIdOrigen.HasValue)
                            {
                                item.TipoDatoId = tipoDatoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieAplicacionConfiguracionValidacionDato = entitiesAplicacionConfiguracionValidacionDato.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracionValidacionDato.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Aplicacion.Configuracion entitiesAplicacionConfiguracion = new(entitiesSincronizacionEntidad);

                if (AplicacionConfiguracion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_Configuracion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in AplicacionConfiguracion)
                        {
                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);

                            if (aplicacionIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                            {
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieAplicacionConfiguracion = entitiesAplicacionConfiguracion.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracion.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entitiesConfiguracionEmpresa = new(entitiesSincronizacionEntidad);

                if (AplicacionConfiguracionEmpresa.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionEmpresa, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in AplicacionConfiguracionEmpresa)
                        {
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);

                            if (empresaIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                            {
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieConfiguracionEmpresa = entitiesConfiguracionEmpresa.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieConfiguracionEmpresa.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Operacion

                Depositario.Business.Tables.Operacion.TipoContenedor entitiesOperacionTipoContenedor = new(entitiesSincronizacionEntidad);

                if (OperacionTipoContenedor.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoContenedor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in OperacionTipoContenedor)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieOperacionTipoContenedor = entitiesOperacionTipoContenedor.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoContenedor.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Operacion.TipoEvento entitiesOperacionTipoEvento = new(entitiesSincronizacionEntidad);

                if (OperacionTipoEvento.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoEvento, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in OperacionTipoEvento)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieOperacionTipoEvento = entitiesOperacionTipoEvento.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoEvento.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Operacion.TipoTransaccion entitiesOperacionTipoTransaccion = new(entitiesSincronizacionEntidad);

                if (OperacionTipoTransaccion.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_TipoTransaccion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in OperacionTipoTransaccion)
                        {
                            if (item.FuncionId.HasValue)
                            {
                                Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId.Value);

                                if (funcionIdOrigen.HasValue)
                                    item.FuncionId = funcionIdOrigen.Value;
                            }

                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieOperacionTipoTransaccion = entitiesOperacionTipoTransaccion.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoTransaccion.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Dispositivo

                Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario entitiesDispositivoTipoConfiguracionDepositario = new(entitiesSincronizacionEntidad);

                if (DispositivoTipoConfiguracionDepositario.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoTipoConfiguracionDepositario)
                        {
                            Int64 origenId = item.Id;
                            Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);

                            if (validacionDatoIdOrigen.HasValue)
                            {
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoTipoConfiguracionDepositario = entitiesDispositivoTipoConfiguracionDepositario.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoConfiguracionDepositario.Id);
                            }

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.Marca entitiesDispositivoMarca = new(entitiesSincronizacionEntidad);

                if (DispositivoMarca.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Marca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoMarca)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieDispositivoMarca = entitiesDispositivoMarca.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoMarca.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.PlantillaMoneda entitiesPlantillaMoneda = new(entitiesSincronizacionEntidad);

                if (DispositivoMarca.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlantillaMoneda)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitiePlantillaMoneda = entitiesPlantillaMoneda.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitiePlantillaMoneda.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle entitiesPlantillaMonedaDetalle = new(entitiesSincronizacionEntidad);

                if (PlantillaMonedaDetalle.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_PlantillaMonedaDetalle, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlantillaMonedaDetalle)
                        {
                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, item.PlantillaMonedaId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (plantillaMonedaIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;

                                item.MonedaId = monedaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitiePlantillaMonedaDetalle = entitiesPlantillaMonedaDetalle.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitiePlantillaMonedaDetalle.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.Modelo entitiesDispositivoModelo = new(entitiesSincronizacionEntidad);

                if (DispositivoModelo.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Modelo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoModelo)
                        {
                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, item.PlantillaMonedaId);
                            Int64? marcaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Marca, item.MarcaId);

                            if (plantillaMonedaIdOrigen.HasValue && marcaIdOrigen.HasValue)
                            {
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;

                                item.MarcaId = marcaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoModelo = entitiesDispositivoModelo.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoModelo.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.TipoContadora entitiesDispositivoTipoContadora = new(entitiesSincronizacionEntidad);

                if (DispositivoTipoContadora.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoTipoContadora)
                        {
                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);

                            if (plantillaMonedaIdOrigen.HasValue)
                            {
                                item.ModeloId = plantillaMonedaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoTipoContadora = entitiesDispositivoTipoContadora.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoContadora.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.TipoPlaca entitiesDispositivoTipoPlaca = new(entitiesSincronizacionEntidad);

                if (DispositivoTipoPlaca.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoTipoPlaca)
                        {
                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);

                            if (plantillaMonedaIdOrigen.HasValue)
                            {
                                item.ModeloId = plantillaMonedaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoTipoPlaca = entitiesDispositivoTipoPlaca.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoPlaca.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.Depositario entitiesDispositivoDepositario = new(entitiesSincronizacionEntidad);

                if (DispositivoDepositario.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Depositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoDepositario)
                        {
                            Int64? modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);
                            Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);
                            Int64? tipoContenedorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Operacion_TipoContenedor, item.TipoContenedorId);

                            if (modeloIdOrigen.HasValue && sectorIdOrigen.HasValue && tipoContenedorIdOrigen.HasValue)
                            {
                                item.ModeloId = modeloIdOrigen.Value;

                                item.SectorId = sectorIdOrigen.Value;

                                item.TipoContenedorId = tipoContenedorIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoDepositario = entitiesDispositivoDepositario.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositario.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.DepositarioContadora entitiesDispositivoDepositarioContadora = new(entitiesSincronizacionEntidad);

                if (DispositivoDepositarioContadora.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoDepositarioContadora)
                        {
                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, item.TipoContadoraId);

                            if (depositarioIdOrigen.HasValue && tipoContadoraIdOrigen.HasValue)
                            {
                                item.DepositarioId = depositarioIdOrigen.Value;

                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoDepositarioContadora = entitiesDispositivoDepositarioContadora.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioContadora.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.DepositarioMoneda entitiesDispositivoDepositarioMoneda = new(entitiesSincronizacionEntidad);

                if (DispositivoDepositarioMoneda.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioMoneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoDepositarioMoneda)
                        {
                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (depositarioIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                item.DepositarioId = depositarioIdOrigen.Value;

                                item.MonedaId = monedaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoDepositarioMoneda = entitiesDispositivoDepositarioMoneda.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioMoneda.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.DepositarioPlaca entitiesDispositivoDepositarioPlaca = new(entitiesSincronizacionEntidad);

                if (DispositivoDepositarioPlaca.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoDepositarioPlaca)
                        {
                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, item.TipoPlacaId);

                            if (depositarioIdOrigen.HasValue && tipoPlacaIdOrigen.HasValue)
                            {
                                item.DepositarioId = depositarioIdOrigen.Value;

                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoDepositarioPlaca = entitiesDispositivoDepositarioPlaca.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioPlaca.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.ComandoContadora entitiesDispositivoComandoContadora = new(entitiesSincronizacionEntidad);

                if (DispositivoComandoContadora.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ComandoContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoComandoContadora)
                        {
                            Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, item.TipoContadoraId);

                            if (tipoContadoraIdOrigen.HasValue)
                            {
                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoComandoContadora = entitiesDispositivoComandoContadora.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoComandoContadora.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.ComandoPlaca entitiesDispositivoComandoPlaca = new(entitiesSincronizacionEntidad);

                if (DispositivoComandoPlaca.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ComandoPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoComandoPlaca)
                        {
                            Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, item.TipoPlacaId);

                            if (tipoPlacaIdOrigen.HasValue)
                            {
                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoComandoPlaca = entitiesDispositivoComandoPlaca.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoComandoPlaca.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entitiesDispositivoConfiguracionDepositario = new(entitiesSincronizacionEntidad);

                if (DispositivoConfiguracionDepositario.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ConfiguracionDepositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in DispositivoConfiguracionDepositario)
                        {
                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario, item.TipoId);

                            if (depositarioIdOrigen.HasValue)
                            {
                                item.DepositarioId = depositarioIdOrigen.Value;

                                item.TipoId = tipoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieDispositivoConfiguracionDepositario = entitiesDispositivoConfiguracionDepositario.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoConfiguracionDepositario.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Turno

                Depositario.Business.Tables.Turno.EsquemaTurno entitiesTurnoEsquemaTurno = new(entitiesSincronizacionEntidad);

                if (TurnoEsquemaTurno.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_EsquemaTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TurnoEsquemaTurno)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieTurnoEsquemaTurno = entitiesTurnoEsquemaTurno.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoEsquemaTurno.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Turno.EsquemaDetalleTurno entitiesTurnoEsquemaDetalleTurno = new(entitiesSincronizacionEntidad);

                if (TurnoEsquemaDetalleTurno.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TurnoEsquemaDetalleTurno)
                        {
                            Int64? esquemaTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Turno_EsquemaTurno, item.EsquemaTurnoId);

                            if (esquemaTurnoIdOrigen.HasValue)
                            {
                                item.EsquemaTurnoId = esquemaTurnoIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieTurnoEsquemaDetalleTurno = entitiesTurnoEsquemaDetalleTurno.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoEsquemaDetalleTurno.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Turno.AgendaTurno entitiesTurnoAgendaTurno = new(entitiesSincronizacionEntidad);

                if (TurnoAgendaTurno.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_AgendaTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TurnoAgendaTurno)
                        {
                            Int64? esquemaDetalleTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno, item.EsquemaDetalleTurnoId);
                            Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);

                            if (esquemaDetalleTurnoIdOrigen.HasValue && sectorIdOrigen.HasValue)
                            {
                                item.EsquemaDetalleTurnoId = esquemaDetalleTurnoIdOrigen.Value;

                                item.SectorId = sectorIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieTurnoAgendaTurno = entitiesTurnoAgendaTurno.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoAgendaTurno.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                #region Impresion

                Depositario.Business.Tables.Impresion.TipoTicket entitiesImpresionTipoTicket = new(entitiesSincronizacionEntidad);

                if (TipoTicket.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Impresion_TipoTicket, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TipoTicket)
                        {
                            Int64 origenId = item.Id;
                            item.UsuarioCreacion = 0;
                            item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                            var newEntitieImpresionTipoTicket = entitiesImpresionTipoTicket.Add(item);

                            SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieImpresionTipoTicket.Id);

                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                Depositario.Business.Tables.Impresion.Ticket entitiesImpresionTicket = new(entitiesSincronizacionEntidad);

                if (Ticket.Count > 0)
                {
                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Impresion_Ticket, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Ticket)
                        {
                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Impresion_TipoTicket, item.TipoId);
                            Int64? depositarioModeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.DepositarioModeloId);
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);

                            if (tipoIdOrigen.HasValue && depositarioModeloIdOrigen.HasValue && empresaIdOrigen.HasValue)
                            {
                                item.TipoId = tipoIdOrigen.Value;
                                item.DepositarioModeloId = depositarioModeloIdOrigen.Value;
                                item.EmpresaId = empresaIdOrigen.Value;

                                Int64 origenId = item.Id;
                                item.UsuarioCreacion = 0;
                                item.UsuarioModificacion = item.UsuarioModificacion.HasValue ? 0 : null;

                                var newEntitieImpresionTicket = entitiesImpresionTicket.Add(item);

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, newEntitieImpresionTicket.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                #endregion

                entitiesSincronizacionEntidad.EndTransaction(true);

                resultado = true;
            }
            catch (Exception ex)
            {
                //Se loguea en archivo porque se sobreentiende que la tabla de log no esta lista.
                AuditController.LogToFile(ex);
                entitiesSincronizacionEntidad.EndTransaction(false);
            }

            return resultado;

        }

    }

}
