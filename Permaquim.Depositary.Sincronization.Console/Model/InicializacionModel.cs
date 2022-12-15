

using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class InicializacionModel
    {
        public string CodigoExternoDepositario { get; set; }
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

        public void Persist()
        {
            #region Sincronizacion

            Depositario.Business.Tables.Sincronizacion.Entidad entitiesSincronizacionEntidad = new();

            if (SincronizacionEntidad.Count > 0)
            {
                foreach (var item in SincronizacionEntidad)
                {
                    var newEntitieSincronizacionEntidad = entitiesSincronizacionEntidad.Add(item);
                    var sincronizacionConfiguracionEntities = SincronizacionConfiguracion.Where(x => x.EntidadId == item.Id);
                    if (sincronizacionConfiguracionEntities != null)
                    {
                        Depositario.Business.Tables.Sincronizacion.Configuracion entitiesSincronizacionConfiguracion = new();

                        Int64? sincronizacionCabeceraId = null;

                        sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Sincronizacion.Configuracion");

                        if (sincronizacionCabeceraId != null)
                        {
                            foreach (var subItem in sincronizacionConfiguracionEntities)
                            {
                                subItem.EntidadId = newEntitieSincronizacionEntidad.Id;

                                Int64 origenId = subItem.Id;

                                var newEntitieSincronizacionConfiguracion = entitiesSincronizacionConfiguracion.Add(subItem);

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSincronizacionConfiguracion.Id);
                            }

                            SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                        }
                    }
                }
            }

            #endregion

            #region Geografia

            Depositario.Business.Tables.Geografia.Pais entitiesGeografiaPais = new();
            if (GeografiaPais.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Geografia.Pais");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in GeografiaPais)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieGeografiaPais = entitiesGeografiaPais.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaPais.Id);
                    }

                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Geografia.Provincia entitiesGeografiaProvincia = new();
            if (GeografiaProvincia.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Geografia.Provincia");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in GeografiaProvincia)
                    {
                        Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Pais", item.PaisId);

                        if (paisIdOrigen.HasValue)
                        {
                            item.PaisId = paisIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieGeografiaProvincia = entitiesGeografiaProvincia.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaProvincia.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Geografia.Ciudad entitiesGeografiaCiudad = new();
            if (GeografiaCiudad.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Geografia.Ciudad");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in GeografiaCiudad)
                    {
                        Int64? provinciaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Provincia", item.ProvinciaId);

                        if (provinciaIdOrigen.HasValue)
                        {
                            item.ProvinciaId = provinciaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieGeografiaCiudad = entitiesGeografiaCiudad.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaCiudad.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Geografia.CodigoPostal entitiesGeografiaCodigoPostal = new();

            if (GeografiaCodigoPostal.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Geografia.CodigoPostal");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in GeografiaCodigoPostal)
                    {
                        Int64? ciudadIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Ciudad", item.CiudadId);

                        if (ciudadIdOrigen.HasValue)
                        {
                            item.CiudadId = ciudadIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieGeografiaCodigoPostal = entitiesGeografiaCodigoPostal.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaCodigoPostal.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);

                }
            }

            Depositario.Business.Tables.Geografia.Zona entitiesGeografiaZona = new();

            if (GeografiaZona.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Geografia.Zona");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in GeografiaZona)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieGeografiaZona = entitiesGeografiaZona.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieGeografiaZona.Id);
                    }

                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Auditoria

            Depositario.Business.Tables.Auditoria.TipoLog entitiesAuditoriaTipoLog = new();

            if (AuditoriaTipoLog.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Auditoria.TipoLog");

                if (sincronizacionCabeceraId.HasValue)
                {

                    foreach (var item in AuditoriaTipoLog)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieAuditoriaTipoLog = entitiesAuditoriaTipoLog.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieAuditoriaTipoLog.Id);
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Regionalizacion

            Depositario.Business.Tables.Regionalizacion.Lenguaje entitiesRegionalizacionLenguaje = new();

            if (RegionalizacionLenguaje.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Regionalizacion.Lenguaje");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in RegionalizacionLenguaje)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieAuditoriaRegionalizacionLenguaje = entitiesRegionalizacionLenguaje.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieAuditoriaRegionalizacionLenguaje.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Regionalizacion.LenguajeItem entitiesRegionalizacionLenguajeItem = new();

            if (RegionalizacionLenguajeItem.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Regionalizacion.LenguajeItem");

                if (sincronizacionCabeceraId.HasValue)
                {

                    foreach (var item in RegionalizacionLenguajeItem)
                    {
                        Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Regionalizacion.Lenguaje", item.LenguajeId);

                        if (lenguajeIdOrigen.HasValue)
                        {
                            item.LenguajeId = lenguajeIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieRegionalizacionLenguajeItem = entitiesRegionalizacionLenguajeItem.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieRegionalizacionLenguajeItem.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Visualizacion

            Depositario.Business.Tables.Visualizacion.PerfilTipo entitiesVisualizacionPerfilTipo = new();

            if (VisualizacionPerfilTipo.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Visualizacion.PerfilTipo");

                if (sincronizacionCabeceraId.HasValue)
                {

                    foreach (var item in VisualizacionPerfilTipo)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieVisualizacionPerfilTipo = entitiesVisualizacionPerfilTipo.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfilTipo.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Visualizacion.Perfil entitiesVisualizacionPerfil = new();

            if (VisualizacionPerfil.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Visualizacion.Perfil");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in VisualizacionPerfil)
                    {
                        Int64? perfilTipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Visualizacion.PerfilTipo", item.PerfilTipoId);

                        if (perfilTipoIdOrigen.HasValue)
                        {
                            item.PerfilTipoId = perfilTipoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieVisualizacionPerfil = entitiesVisualizacionPerfil.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfil.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Visualizacion.PerfilItem entitiesVisualizacionPerfilItem = new();

            if (VisualizacionPerfilItem.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Visualizacion.PerfilItem");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in VisualizacionPerfilItem)
                    {
                        Int64? perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Visualizacion.Perfil", item.PerfilId);

                        if (perfilIdOrigen.HasValue)
                        {
                            item.PerfilId = perfilIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieVisualizacionPerfilItem = entitiesVisualizacionPerfilItem.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieVisualizacionPerfilItem.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Biometria

            Depositario.Business.Tables.Biometria.HuellaDactilar entitiesBiometriaHuellaDactilar = new();

            if (BiometriaHuellaDactilar.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Biometria.HuellaDactilar");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in BiometriaHuellaDactilar)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieBiometriaHuellaDactilar = entitiesBiometriaHuellaDactilar.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieBiometriaHuellaDactilar.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Seguridad.Aplicacion

            Depositario.Business.Tables.Seguridad.TipoAplicacion entitiesSeguridadTipoAplicacion = new();

            if (SeguridadTipoAplicacion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.TipoAplicacion");

                if (sincronizacionCabeceraId.HasValue)
                {

                    foreach (var item in SeguridadTipoAplicacion)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieSeguridadTipoAplicacion = entitiesSeguridadTipoAplicacion.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoAplicacion.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.Aplicacion entitiesSeguridadAplicacion = new();

            if (SeguridadAplicacion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.Aplicacion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadAplicacion)
                    {
                        Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.TipoAplicacion", item.TipoId);

                        if (tipoIdOrigen.HasValue)
                        {
                            item.TipoId = tipoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadAplicacion = entitiesSeguridadAplicacion.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacion.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.AplicacionParametro entitiesSeguridadAplicacionParametro = new();

            if (SeguridadAplicacionParametro.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.AplicacionParametro");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadAplicacionParametro)
                    {
                        Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Aplicacion", item.AplicacionId);

                        if (aplicacionIdOrigen.HasValue)
                        {
                            item.AplicacionId = aplicacionIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadAplicacionParametro = entitiesSeguridadAplicacionParametro.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacionParametro.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.AplicacionParametroValor entitiesSeguridadAplicacionParametroValor = new();

            if (SeguridadAplicacionParametroValor.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.AplicacionParametroValor");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadAplicacionParametroValor)
                    {
                        Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Aplicacion", item.AplicacionId);
                        Int64? aplicacionParametroIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.AplicacionParametro", item.ParametroId);

                        if (aplicacionIdOrigen.HasValue && aplicacionParametroIdOrigen.HasValue)
                        {
                            item.AplicacionId = aplicacionIdOrigen.Value;

                            item.ParametroId = aplicacionParametroIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadAplicacionParametroValor = entitiesSeguridadAplicacionParametroValor.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadAplicacionParametroValor.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Valor

            Depositario.Business.Tables.Valor.Tipo entitiesValorTipo = new();

            if (ValorTipo.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Valor.Tipo");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in ValorTipo)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieValorTipo = entitiesValorTipo.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieValorTipo.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Valor.Moneda entitiesValorMoneda = new();
            if (ValorMoneda.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Valor.Moneda");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in ValorMoneda)
                    {
                        Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Pais", item.PaisId);

                        if (paisIdOrigen.HasValue)
                        {
                            item.PaisId = paisIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieValorMoneda = entitiesValorMoneda.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieValorMoneda.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Valor.Denominacion entitiesValorDenominacion = new();

            if (ValorDenominacion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Valor.Denominacion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in ValorDenominacion)
                    {
                        Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Tipo", item.TipoValorId);
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);

                        if (monedaIdOrigen.HasValue && tipoValorIdOrigen.HasValue)
                        {
                            item.MonedaId = monedaIdOrigen.Value;

                            item.TipoValorId = tipoValorIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieValorDenominacion = entitiesValorDenominacion.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieValorDenominacion.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Valor.RelacionMonedaTipoValor entitiesValorRelacionMonedaTipoValor = new();

            if (ValorRelacionMonedaTipoValor.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Valor.RelacionMonedaTipoValor");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in ValorRelacionMonedaTipoValor)
                    {
                        Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Tipo", item.TipoValorId);
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);

                        if (monedaIdOrigen.HasValue && tipoValorIdOrigen.HasValue)
                        {
                            item.MonedaId = monedaIdOrigen.Value;

                            item.TipoValorId = tipoValorIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieValorRelacionMonedaTipoValor = entitiesValorRelacionMonedaTipoValor.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieValorRelacionMonedaTipoValor.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Estilo

            Depositario.Business.Tables.Estilo.TipoEsquemaDetalle entitiesEstiloTipoEsquemaDetalle = new();

            if (EstiloTipoEsquemaDetalle.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Estilo.TipoEsquemaDetalle");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in EstiloTipoEsquemaDetalle)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieEstiloTipoEsquemaDetalle = entitiesEstiloTipoEsquemaDetalle.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloTipoEsquemaDetalle.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Estilo.Esquema entitiesEstiloEsquema = new();

            if (EstiloEsquema.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Estilo.Esquema");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in EstiloEsquema)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieEstiloEsquema = entitiesEstiloEsquema.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloEsquema.Id);
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Estilo.EsquemaDetalle entitiesEstiloEsquemaDetalle = new();
            if (EstiloEsquemaDetalle.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Estilo.EsquemaDetalle");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in EstiloEsquemaDetalle)
                    {
                        Int64? esquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Estilo.Esquema", item.EsquemaId);
                        Int64? tipoEsquemaDetalleIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Estilo.TipoEsquemaDetalle", item.TipoEsquemaDetalleId);

                        if (esquemaIdOrigen.HasValue && tipoEsquemaDetalleIdOrigen.HasValue)
                        {
                            item.EsquemaId = esquemaIdOrigen.Value;

                            item.TipoEsquemaDetalleId = tipoEsquemaDetalleIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieEstiloEsquemaDetalle = entitiesEstiloEsquemaDetalle.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieEstiloEsquemaDetalle.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Directorio

            Depositario.Business.Tables.Directorio.Grupo entitiesDirectorioGrupo = new();

            if (DirectorioGrupo.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Directorio.Grupo");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DirectorioGrupo)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieDirectorioGrupo = entitiesDirectorioGrupo.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioGrupo.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Directorio.Empresa entitiesDirectorioEmpresa = new();

            if (DirectorioEmpresa.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Directorio.Empresa");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DirectorioEmpresa)
                    {
                        Int64? grupoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Grupo", item.GrupoId);
                        Int64? estiloEsquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Estilo.Esquema", item.EstiloEsquemaId);
                        Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Regionalizacion.Lenguaje", item.LenguajeId);

                        if (grupoIdOrigen.HasValue && estiloEsquemaIdOrigen.HasValue && lenguajeIdOrigen.HasValue)
                        {
                            item.GrupoId = grupoIdOrigen.Value;

                            item.EstiloEsquemaId = estiloEsquemaIdOrigen.Value;

                            item.LenguajeId = lenguajeIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDirectorioEmpresa = entitiesDirectorioEmpresa.Add(item);
                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioEmpresa.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Directorio.Sucursal entitiesDirectorioSucursal = new();

            if (DirectorioSucursal.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Directorio.Sucursal");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DirectorioSucursal)
                    {
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);
                        Int64? codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.CodigoPostal", item.CodigoPostalId);
                        Int64? zonaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Zona", item.ZonaId);

                        if (empresaIdOrigen.HasValue && codigoPostalIdOrigen.HasValue && zonaIdOrigen.HasValue)
                        {
                            item.EmpresaId = empresaIdOrigen.Value;

                            item.CodigoPostalId = codigoPostalIdOrigen.Value;

                            item.ZonaId = zonaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDirectorioSucursal = entitiesDirectorioSucursal.Add(item);
                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioSucursal.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Directorio.Sector entitiesDirectorioSector = new();

            if (DirectorioSector.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Directorio.Sector");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DirectorioSector)
                    {
                        Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Sucursal", item.SucursalId);

                        if (sucursalIdOrigen.HasValue)
                        {
                            item.SucursalId = sucursalIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDirectorioSector = entitiesDirectorioSector.Add(item);
                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioSector.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Directorio.RelacionMonedaSucursal entitiesDirectorioRelacionMonedaSucursal = new();

            if (DirectorioRelacionMonedaSucursal.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Directorio.RelacionMonedaSucursal");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DirectorioRelacionMonedaSucursal)
                    {
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);
                        Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Sucursal", item.SucursalId);

                        if (monedaIdOrigen.HasValue && sucursalIdOrigen.HasValue)
                        {
                            item.MonedaId = monedaIdOrigen.Value;

                            item.SucursalId = sucursalIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDirectorioRelacionMonedaSucursal = entitiesDirectorioRelacionMonedaSucursal.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDirectorioRelacionMonedaSucursal.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Valor.OrigenValor

            Depositario.Business.Tables.Valor.OrigenValor entitiesOrigenValor = new();

            if (OrigenValor.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Valor.OrigenValor");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in OrigenValor)
                    {
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);

                        if (empresaIdOrigen.HasValue)
                        {
                            item.EmpresaId = empresaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieValorOrigenValor = entitiesOrigenValor.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieValorOrigenValor.Id);
                        }

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Seguridad

            Depositario.Business.Tables.Seguridad.TipoFuncion entitiesSeguridadTipoFuncion = new();

            if (SeguridadTipoFuncion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.TipoFuncion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadTipoFuncion)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieSeguridadTipoFuncion = entitiesSeguridadTipoFuncion.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoFuncion.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.TipoIdentificador entitiesSeguridadTipoIdentificador = new();

            if (SeguridadTipoIdentificador.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.TipoIdentificador");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadTipoIdentificador)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieSeguridadTipoIdentificador = entitiesSeguridadTipoIdentificador.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoIdentificador.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.TipoMenu entitiesSeguridadTipoMenu = new();

            if (SeguridadTipoMenu.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.TipoMenu");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadTipoMenu)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieSeguridadTipoMenu = entitiesSeguridadTipoMenu.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadTipoMenu.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.Usuario entitiesSeguridadUsuario = new();

            if (SeguridadUsuario.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.Usuario");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadUsuario)
                    {
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);
                        Int64? lenguajelIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Regionalizacion.Lenguaje", item.LenguajeId);
                        Int64? perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Visualizacion.Perfil", item.PerfilId);

                        if (empresaIdOrigen.HasValue && lenguajelIdOrigen.HasValue && perfilIdOrigen.HasValue)
                        {
                            item.EmpresaId = empresaIdOrigen.Value;

                            item.LenguajeId = lenguajelIdOrigen.Value;

                            item.PerfilId = perfilIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadUsuario = entitiesSeguridadUsuario.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuario.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.Funcion entitiesSeguridadFuncion = new();

            if (SeguridadFuncion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.Funcion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadFuncion)
                    {
                        Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Aplicacion", item.AplicacionId);
                        Int64? tipoFuncionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.TipoFuncion", item.TipoId);

                        if (aplicacionIdOrigen.HasValue && tipoFuncionIdOrigen.HasValue)
                        {
                            item.AplicacionId = aplicacionIdOrigen.Value;

                            item.TipoId = tipoFuncionIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadFuncion = entitiesSeguridadFuncion.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadFuncion.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.IdentificadorUsuario entitiesSeguridadIdentificadorUsuario = new();

            if (SeguridadIdentificadorUsuario.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.IdentificadorUsuario");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadIdentificadorUsuario)
                    {
                        Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Usuario", item.UsuarioId);
                        Int64? tipoIdentificadorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.TipoIdentificador", item.TipoId);

                        if (usuarioIdOrigen.HasValue && tipoIdentificadorIdOrigen.HasValue)
                        {
                            item.UsuarioId = usuarioIdOrigen.Value;

                            item.TipoId = tipoIdentificadorIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadIdentificadorUsuario = entitiesSeguridadIdentificadorUsuario.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadIdentificadorUsuario.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.Rol entitiesSeguridadRol = new();
            if (SeguridadRol.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.Rol");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadRol.OrderBy(x => x.DependeDe))
                    {
                        Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Aplicacion", item.AplicacionId);

                        if (aplicacionIdOrigen.HasValue)
                        {
                            if (item.DependeDe.HasValue)
                            {
                                Int64? dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Rol", item.DependeDe.Value);
                                item.DependeDe = dependeDeOrigen;
                            }

                            item.AplicacionId = aplicacionIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadRol = entitiesSeguridadRol.Add(item);
                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadRol.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.UsuarioRol entitiesSeguridadUsuarioRol = new();

            if (SeguridadUsuarioRol.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.UsuarioRol");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadUsuarioRol)
                    {
                        Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Usuario", item.UsuarioId);
                        Int64? rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Rol", item.RolId);

                        if (usuarioIdOrigen.HasValue && rolIdOrigen.HasValue)
                        {
                            item.UsuarioId = usuarioIdOrigen.Value;

                            item.RolId = rolIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadUsuarioRol = entitiesSeguridadUsuarioRol.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuarioRol.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.UsuarioSector entitiesSeguridadUsuarioSector = new();
            if (SeguridadUsuarioSector.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.UsuarioSector");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadUsuarioSector)
                    {
                        Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Usuario", item.UsuarioId);
                        Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Sector", item.SectorId);

                        if (usuarioIdOrigen.HasValue && usuarioIdOrigen.HasValue)
                        {
                            item.SectorId = sectorIdOrigen.Value;

                            item.UsuarioId = usuarioIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadUsuarioSector = entitiesSeguridadUsuarioSector.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadUsuarioSector.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.Menu entitiesSeguridadMenu = new();
            if (SeguridadMenu.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.Menu");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadMenu.OrderBy(x => x.DependeDe))
                    {
                        Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.TipoMenu", item.TipoId);
                        Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Funcion", item.FuncionId);

                        if (tipoIdOrigen.HasValue && funcionIdOrigen.HasValue)
                        {
                            item.TipoId = tipoIdOrigen.Value;

                            item.FuncionId = funcionIdOrigen.Value;

                            if (item.DependeDe.HasValue)
                            {
                                Int64? dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Menu", item.DependeDe.Value);
                                item.DependeDe = dependeDeOrigen;
                            }

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadMenu = entitiesSeguridadMenu.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadMenu.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Seguridad.RolFuncion entitiesSeguridadRolFuncion = new();

            if (SeguridadRolFuncion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Seguridad.RolFuncion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in SeguridadRolFuncion)
                    {
                        Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Funcion", item.FuncionId);
                        Int64? rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Rol", item.RolId);

                        if (funcionIdOrigen.HasValue && rolIdOrigen.HasValue)
                        {
                            item.FuncionId = funcionIdOrigen.Value;

                            item.RolId = rolIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieSeguridadRolFuncion = entitiesSeguridadRolFuncion.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieSeguridadRolFuncion.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Banca

            Depositario.Business.Tables.Banca.Banco entitiesBancaBanco = new();

            if (BancaBanco.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Banca.Banco");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in BancaBanco)
                    {
                        Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Geografia.Pais", item.PaisId);

                        if (paisIdOrigen.HasValue)
                        {
                            item.PaisId = paisIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieBancaBanco = entitiesBancaBanco.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieBancaBanco.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Banca.TipoCuenta entitiesBancaTipoCuenta = new();

            if (BancaTipoCuenta.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Banca.TipoCuenta");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in BancaTipoCuenta)
                    {
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);

                        if (monedaIdOrigen.HasValue)
                        {
                            Int64 origenId = item.Id;

                            item.MonedaId = monedaIdOrigen.Value;

                            var newEntitieBancaTipoCuenta = entitiesBancaTipoCuenta.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieBancaTipoCuenta.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Banca.Cuenta entitiesBancaCuenta = new();
            if (BancaCuenta.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Banca.Cuenta");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in BancaCuenta)
                    {
                        Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Banca.TipoCuenta", item.TipoId);
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);
                        Int64? bancoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Banca.Banco", item.BancoId);

                        if (tipoIdOrigen.HasValue && empresaIdOrigen.HasValue && bancoIdOrigen.HasValue)
                        {
                            item.TipoId = tipoIdOrigen.Value;

                            item.EmpresaId = empresaIdOrigen.Value;

                            item.BancoId = bancoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieBancaCuenta = entitiesBancaCuenta.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieBancaCuenta.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Banca.UsuarioCuenta entitiesBancaUsuarioCuenta = new();
            if (BancaUsuarioCuenta.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Banca.UsuarioCuenta");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in BancaUsuarioCuenta)
                    {
                        Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Usuario", item.UsuarioId);
                        Int64? cuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Banca.Cuenta", item.CuentaId);

                        if (usuarioIdOrigen.HasValue && cuentaIdOrigen.HasValue)
                        {
                            item.UsuarioId = usuarioIdOrigen.Value;

                            item.CuentaId = cuentaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieBancaUsuarioCuenta = entitiesBancaUsuarioCuenta.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieBancaUsuarioCuenta.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Aplicacion

            Depositario.Business.Tables.Aplicacion.ConfiguracionTipoDato entitiesAplicacionConfiguracionTipoDato = new();

            if (AplicacionConfiguracionTipoDato.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Aplicacion.ConfiguracionTipoDato");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in AplicacionConfiguracionTipoDato)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieAplicacionConfiguracionTipoDato = entitiesAplicacionConfiguracionTipoDato.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracionTipoDato.Id);
                    }

                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Aplicacion.ConfiguracionValidacionDato entitiesAplicacionConfiguracionValidacionDato = new();

            if (AplicacionConfiguracionValidacionDato.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Aplicacion.ConfiguracionValidacionDato");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in AplicacionConfiguracionValidacionDato)
                    {
                        Int64? tipoDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Aplicacion.ConfiguracionTipoDato", item.TipoDatoId);

                        if (tipoDatoIdOrigen.HasValue)
                        {
                            item.TipoDatoId = tipoDatoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieAplicacionConfiguracionValidacionDato = entitiesAplicacionConfiguracionValidacionDato.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracionValidacionDato.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Aplicacion.Configuracion entitiesAplicacionConfiguracion = new();

            if (AplicacionConfiguracion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Aplicacion.Configuracion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in AplicacionConfiguracion)
                    {
                        Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Aplicacion", item.AplicacionId);
                        Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Aplicacion.ConfiguracionValidacionDato", item.ValidacionDatoId);

                        if (aplicacionIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                        {
                            item.AplicacionId = aplicacionIdOrigen.Value;
                            item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieAplicacionConfiguracion = entitiesAplicacionConfiguracion.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieAplicacionConfiguracion.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entitiesConfiguracionEmpresa = new();

            if (AplicacionConfiguracionEmpresa.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Aplicacion.ConfiguracionEmpresa");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in AplicacionConfiguracionEmpresa)
                    {
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);
                        Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Aplicacion.ConfiguracionValidacionDato", item.ValidacionDatoId);

                        if (empresaIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                        {
                            item.EmpresaId = empresaIdOrigen.Value;
                            item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieConfiguracionEmpresa = entitiesConfiguracionEmpresa.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieConfiguracionEmpresa.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Operacion

            Depositario.Business.Tables.Operacion.TipoContenedor entitiesOperacionTipoContenedor = new();

            if (OperacionTipoContenedor.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Operacion.TipoContenedor");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in OperacionTipoContenedor)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieOperacionTipoContenedor = entitiesOperacionTipoContenedor.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoContenedor.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Operacion.TipoEvento entitiesOperacionTipoEvento = new();

            if (OperacionTipoEvento.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Operacion.TipoEvento");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in OperacionTipoEvento)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieOperacionTipoEvento = entitiesOperacionTipoEvento.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoEvento.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Operacion.TipoTransaccion entitiesOperacionTipoTransaccion = new();

            if (OperacionTipoTransaccion.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Operacion.TipoTransaccion");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in OperacionTipoTransaccion)
                    {
                        if (item.FuncionId.HasValue)
                        {
                            Int64? funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Seguridad.Funcion", item.FuncionId.Value);

                            if (funcionIdOrigen.HasValue)
                                item.FuncionId = funcionIdOrigen.Value;
                        }

                        Int64 origenId = item.Id;

                        var newEntitieOperacionTipoTransaccion = entitiesOperacionTipoTransaccion.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieOperacionTipoTransaccion.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Dispositivo

            Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario entitiesDispositivoTipoConfiguracionDepositario = new();

            if (DispositivoTipoConfiguracionDepositario.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.TipoConfiguracionDepositario");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoTipoConfiguracionDepositario)
                    {
                        Int64 origenId = item.Id;
                        Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Aplicacion.ConfiguracionValidacionDato", item.ValidacionDatoId);

                        if (validacionDatoIdOrigen.HasValue)
                        {
                            item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                            var newEntitieDispositivoTipoConfiguracionDepositario = entitiesDispositivoTipoConfiguracionDepositario.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoConfiguracionDepositario.Id);
                        }

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.Marca entitiesDispositivoMarca = new();

            if (DispositivoMarca.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.Marca");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoMarca)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieDispositivoMarca = entitiesDispositivoMarca.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoMarca.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.PlantillaMoneda entitiesPlantillaMoneda = new();

            if (DispositivoMarca.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.PlantillaMoneda");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in PlantillaMoneda)
                    {
                        Int64 origenId = item.Id;

                        var newEntitiePlantillaMoneda = entitiesPlantillaMoneda.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitiePlantillaMoneda.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle entitiesPlantillaMonedaDetalle = new();

            if (PlantillaMonedaDetalle.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.PlantillaMonedaDetalle");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in PlantillaMonedaDetalle)
                    {
                        Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.PlantillaMoneda", item.PlantillaMonedaId);
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);

                        if (plantillaMonedaIdOrigen.HasValue && monedaIdOrigen.HasValue)
                        {
                            item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;

                            item.MonedaId = monedaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitiePlantillaMonedaDetalle = entitiesPlantillaMonedaDetalle.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitiePlantillaMonedaDetalle.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.Modelo entitiesDispositivoModelo = new();

            if (DispositivoModelo.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.Modelo");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoModelo)
                    {
                        Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.PlantillaMoneda", item.PlantillaMonedaId);
                        Int64? marcaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Marca", item.MarcaId);

                        if (plantillaMonedaIdOrigen.HasValue && marcaIdOrigen.HasValue)
                        {
                            item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;

                            item.MarcaId = marcaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoModelo = entitiesDispositivoModelo.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoModelo.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.TipoContadora entitiesDispositivoTipoContadora = new();

            if (DispositivoTipoContadora.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.TipoContadora");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoTipoContadora)
                    {
                        Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Modelo", item.ModeloId);

                        if (plantillaMonedaIdOrigen.HasValue)
                        {
                            item.ModeloId = plantillaMonedaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoTipoContadora = entitiesDispositivoTipoContadora.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoContadora.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.TipoPlaca entitiesDispositivoTipoPlaca = new();

            if (DispositivoTipoPlaca.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.TipoPlaca");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoTipoPlaca)
                    {
                        Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Modelo", item.ModeloId);

                        if (plantillaMonedaIdOrigen.HasValue)
                        {
                            item.ModeloId = plantillaMonedaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoTipoPlaca = entitiesDispositivoTipoPlaca.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoTipoPlaca.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.Depositario entitiesDispositivoDepositario = new();

            if (DispositivoDepositario.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.Depositario");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoDepositario)
                    {
                        Int64? modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Modelo", item.ModeloId);
                        Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Sector", item.SectorId);
                        Int64? tipoContenedorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Operacion.TipoContenedor", item.TipoContenedorId);

                        if (modeloIdOrigen.HasValue && sectorIdOrigen.HasValue && tipoContenedorIdOrigen.HasValue)
                        {
                            item.ModeloId = modeloIdOrigen.Value;

                            item.SectorId = sectorIdOrigen.Value;

                            item.TipoContenedorId = tipoContenedorIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoDepositario = entitiesDispositivoDepositario.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositario.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.DepositarioContadora entitiesDispositivoDepositarioContadora = new();

            if (DispositivoDepositarioContadora.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.DepositarioContadora");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoDepositarioContadora)
                    {
                        Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Depositario", item.DepositarioId);
                        Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.TipoContadora", item.TipoContadoraId);

                        if (depositarioIdOrigen.HasValue && tipoContadoraIdOrigen.HasValue)
                        {
                            item.DepositarioId = depositarioIdOrigen.Value;

                            item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoDepositarioContadora = entitiesDispositivoDepositarioContadora.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioContadora.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            //Depositario.Business.Tables.Dispositivo.DepositarioEstado entitiesDispositivoDepositarioEstado = new();

            //if (DispositivoDepositarioEstado.Count > 0)
            //{
            //    Int64? sincronizacionCabeceraId = null;

            //    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.DepositarioEstado");

            //    if (sincronizacionCabeceraId.HasValue)
            //    {
            //        foreach (var item in DispositivoDepositarioEstado)
            //        {
            //            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Depositario", item.DepositarioId);

            //            if (depositarioIdOrigen.HasValue)
            //            {
            //                item.DepositarioId = depositarioIdOrigen.Value;

            //                Int64 origenId = item.Id;

            //                var newEntitieDispositivoDepositarioEstado = entitiesDispositivoDepositarioEstado.Add(item);

            //                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioEstado.Id);
            //            }
            //        }
            //        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
            //    }
            //}

            Depositario.Business.Tables.Dispositivo.DepositarioMoneda entitiesDispositivoDepositarioMoneda = new();

            if (DispositivoDepositarioMoneda.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.DepositarioMoneda");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoDepositarioMoneda)
                    {
                        Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Depositario", item.DepositarioId);
                        Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Valor.Moneda", item.MonedaId);

                        if (depositarioIdOrigen.HasValue && monedaIdOrigen.HasValue)
                        {
                            item.DepositarioId = depositarioIdOrigen.Value;

                            item.MonedaId = monedaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoDepositarioMoneda = entitiesDispositivoDepositarioMoneda.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioMoneda.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.DepositarioPlaca entitiesDispositivoDepositarioPlaca = new();

            if (DispositivoDepositarioPlaca.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.DepositarioPlaca");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoDepositarioPlaca)
                    {
                        Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Depositario", item.DepositarioId);
                        Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.TipoPlaca", item.TipoPlacaId);

                        if (depositarioIdOrigen.HasValue && tipoPlacaIdOrigen.HasValue)
                        {
                            item.DepositarioId = depositarioIdOrigen.Value;

                            item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoDepositarioPlaca = entitiesDispositivoDepositarioPlaca.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoDepositarioPlaca.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.ComandoContadora entitiesDispositivoComandoContadora = new();

            if (DispositivoComandoContadora.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.ComandoContadora");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoComandoContadora)
                    {
                        Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.TipoContadora", item.TipoContadoraId);

                        if (tipoContadoraIdOrigen.HasValue)
                        {
                            item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoComandoContadora = entitiesDispositivoComandoContadora.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoComandoContadora.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.ComandoPlaca entitiesDispositivoComandoPlaca = new();

            if (DispositivoComandoPlaca.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.ComandoPlaca");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoComandoPlaca)
                    {
                        Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.TipoPlaca", item.TipoPlacaId);

                        if (tipoPlacaIdOrigen.HasValue)
                        {
                            item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoComandoPlaca = entitiesDispositivoComandoPlaca.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoComandoPlaca.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entitiesDispositivoConfiguracionDepositario = new();

            if (DispositivoConfiguracionDepositario.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Dispositivo.ConfiguracionDepositario");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in DispositivoConfiguracionDepositario)
                    {
                        Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Depositario", item.DepositarioId);
                        Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.TipoConfiguracionDepositario", item.TipoId);

                        if (depositarioIdOrigen.HasValue)
                        {
                            item.DepositarioId = depositarioIdOrigen.Value;

                            item.TipoId = tipoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieDispositivoConfiguracionDepositario = entitiesDispositivoConfiguracionDepositario.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieDispositivoConfiguracionDepositario.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Turno

            Depositario.Business.Tables.Turno.EsquemaTurno entitiesTurnoEsquemaTurno = new();

            if (TurnoEsquemaTurno.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Turno.EsquemaTurno");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in TurnoEsquemaTurno)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieTurnoEsquemaTurno = entitiesTurnoEsquemaTurno.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoEsquemaTurno.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Turno.EsquemaDetalleTurno entitiesTurnoEsquemaDetalleTurno = new();

            if (TurnoEsquemaDetalleTurno.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Turno.EsquemaDetalleTurno");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in TurnoEsquemaDetalleTurno)
                    {
                        Int64? esquemaTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Turno.EsquemaTurno", item.EsquemaTurnoId);

                        if (esquemaTurnoIdOrigen.HasValue)
                        {
                            item.EsquemaTurnoId = esquemaTurnoIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieTurnoEsquemaDetalleTurno = entitiesTurnoEsquemaDetalleTurno.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoEsquemaDetalleTurno.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Turno.AgendaTurno entitiesTurnoAgendaTurno = new();

            if (TurnoAgendaTurno.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Turno.AgendaTurno");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in TurnoAgendaTurno)
                    {
                        Int64? esquemaDetalleTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Turno.EsquemaDetalleTurno", item.EsquemaDetalleTurnoId);
                        Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Sector", item.SectorId);

                        if (esquemaDetalleTurnoIdOrigen.HasValue && sectorIdOrigen.HasValue)
                        {
                            item.EsquemaDetalleTurnoId = esquemaDetalleTurnoIdOrigen.Value;

                            item.SectorId = sectorIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieTurnoAgendaTurno = entitiesTurnoAgendaTurno.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieTurnoAgendaTurno.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion

            #region Impresion

            Depositario.Business.Tables.Impresion.TipoTicket entitiesImpresionTipoTicket = new();

            if (TipoTicket.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Impresion.TipoTicket");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in TipoTicket)
                    {
                        Int64 origenId = item.Id;

                        var newEntitieImpresionTipoTicket = entitiesImpresionTipoTicket.Add(item);

                        SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieImpresionTipoTicket.Id);

                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            Depositario.Business.Tables.Impresion.Ticket entitiesImpresionTicket = new();

            if (Ticket.Count > 0)
            {
                Int64? sincronizacionCabeceraId = null;

                sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacionInicial("Impresion.Ticket");

                if (sincronizacionCabeceraId.HasValue)
                {
                    foreach (var item in Ticket)
                    {
                        Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Impresion.TipoTicket", item.TipoId);
                        Int64? depositarioModeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Dispositivo.Modelo", item.DepositarioModeloId);
                        Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacionInicial("Directorio.Empresa", item.EmpresaId);

                        if (tipoIdOrigen.HasValue && depositarioModeloIdOrigen.HasValue && empresaIdOrigen.HasValue)
                        {
                            item.TipoId = tipoIdOrigen.Value;
                            item.DepositarioModeloId = depositarioModeloIdOrigen.Value;
                            item.EmpresaId = empresaIdOrigen.Value;

                            Int64 origenId = item.Id;

                            var newEntitieImpresionTicket = entitiesImpresionTicket.Add(item);

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, newEntitieImpresionTicket.Id);
                        }
                    }
                    SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                }
            }

            #endregion
        }

    }

}
