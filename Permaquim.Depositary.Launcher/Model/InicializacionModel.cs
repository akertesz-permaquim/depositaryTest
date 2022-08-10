namespace Permaquim.Depositary.Launcher.Model
{
    public class InicializacionModel
    {
        public string CodigoExternoDepositario { get; set; }

        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> AplicacionConfiguracion { get; set; } = new();
        public List<Depositario.Entities.Tables.Auditoria.Log> AuditoriaLog { get; set; } = new();
        public List<Depositario.Entities.Tables.Auditoria.TipoLog> AuditoriaTipoLog { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Banco> BancaBanco { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Cuenta> BancaCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.TipoCuenta> BancaTipoCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.UsuarioCuenta> BancaUsuarioCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Biometria.HuellaDactilar> BiometriaHuellaDactilar { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Empresa> DirectorioEmpresa { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Grupo> DirectorioGrupo { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.IdentificadorUsuario> DirectorioIdentificadorUsuario { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.RelacionMonedaSucursal> DirectorioRelacionMonedaSucursal { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sector> DirectorioSector { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sucursal> DirectorioSucursal { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoIdentificador> DirectorioTipoIdentificador { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoContadora> DispositivoComandoContadora { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoPlaca> DispositivoComandoPlaca { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> DispositivoConfiguracionDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Depositario> DispositivoDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioContadora> DispositivoDepositarioContadora { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioEstado> DispositivoDepositarioEstado { get; set; } = new();
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
        public List<Depositario.Entities.Tables.Operacion.CierreDiario> OperacionCierreDiario { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Contenedor> OperacionContenedor { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Evento> OperacionEvento { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Sesion> OperacionSesion { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoContenedor> OperacionTipoContenedor { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoEvento> OperacionTipoEvento { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TipoTransaccion> OperacionTipoTransaccion { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Transaccion> OperacionTransaccion { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> OperacionTransaccionDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobre> OperacionTransaccionSobre { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> OperacionTransaccionSobreDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Turno> OperacionTurno { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TurnoUsuario> OperacionTurnoUsuario { get; set; } = new();
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
        public List<Depositario.Entities.Tables.Sincronizacion.EntidadCabecera> SincronizacionEntidadCabecera { get; set; } = new();
        public List<Depositario.Entities.Tables.Sincronizacion.EntidadDetalle> SincronizacionEntidadDetalle { get; set; } = new();
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
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionEmpresa { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMoneda> PlantillaMoneda { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> PlantillaMonedaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.OrigenValor> OrigenValor { get; set; } = new();

        public void Persist()
        {

            Depositario.Business.Tables.Sincronizacion.EntidadDetalle entitiesSincronizacionEntidadDetalle = new();
            foreach (var item in SincronizacionEntidadDetalle)
            {
                entitiesSincronizacionEntidadDetalle.Add(item);
            }
            Depositario.Business.Tables.Turno.AgendaTurno entitiesTurnoAgendaTurno = new();
            foreach (var item in TurnoAgendaTurno)
            {
                entitiesTurnoAgendaTurno.Add(item);
            }
            Depositario.Business.Tables.Seguridad.Aplicacion entitiesSeguridadAplicacion = new();
            foreach (var item in SeguridadAplicacion)
            {
                entitiesSeguridadAplicacion.Add(item);
            }
            Depositario.Business.Tables.Seguridad.AplicacionParametro entitiesSeguridadAplicacionParametro = new();
            foreach (var item in SeguridadAplicacionParametro)
            {
                entitiesSeguridadAplicacionParametro.Add(item);
            }
            Depositario.Business.Tables.Seguridad.AplicacionParametroValor entitiesSeguridadAplicacionParametroValor = new();
            foreach (var item in SeguridadAplicacionParametroValor)
            {
                entitiesSeguridadAplicacionParametroValor.Add(item);
            }
            Depositario.Business.Tables.Banca.Banco entitiesBancaBanco = new();
            foreach (var item in BancaBanco)
            {
                entitiesBancaBanco.Add(item);
            }
            Depositario.Business.Tables.Operacion.CierreDiario entitiesOperacionCierreDiario = new();
            foreach (var item in OperacionCierreDiario)
            {
                entitiesOperacionCierreDiario.Add(item);
            }
            Depositario.Business.Tables.Geografia.Ciudad entitiesGeografiaCiudad = new();
            foreach (var item in GeografiaCiudad)
            {
                entitiesGeografiaCiudad.Add(item);
            }
            Depositario.Business.Tables.Geografia.CodigoPostal entitiesGeografiaCodigoPostal = new();
            foreach (var item in GeografiaCodigoPostal)
            {
                entitiesGeografiaCodigoPostal.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.ComandoContadora entitiesDispositivoComandoContadora = new();
            foreach (var item in DispositivoComandoContadora)
            {
                entitiesDispositivoComandoContadora.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.ComandoPlaca entitiesDispositivoComandoPlaca = new();
            foreach (var item in DispositivoComandoPlaca)
            {
                entitiesDispositivoComandoPlaca.Add(item);
            }
            Depositario.Business.Tables.Aplicacion.Configuracion entitiesAplicacionConfiguracion = new();
            foreach (var item in AplicacionConfiguracion)
            {
                entitiesAplicacionConfiguracion.Add(item);
            }
            Depositario.Business.Tables.Sincronizacion.Configuracion entitiesSincronizacionConfiguracion = new();
            foreach (var item in SincronizacionConfiguracion)
            {
                entitiesSincronizacionConfiguracion.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entitiesDispositivoConfiguracionDepositario = new();
            foreach (var item in DispositivoConfiguracionDepositario)
            {
                entitiesDispositivoConfiguracionDepositario.Add(item);
            }
            Depositario.Business.Tables.Operacion.Contenedor entitiesOperacionContenedor = new();
            foreach (var item in OperacionContenedor)
            {
                entitiesOperacionContenedor.Add(item);
            }
            Depositario.Business.Tables.Banca.Cuenta entitiesBancaCuenta = new();
            foreach (var item in BancaCuenta)
            {
                entitiesBancaCuenta.Add(item);
            }
            Depositario.Business.Tables.Valor.Denominacion entitiesValorDenominacion = new();
            foreach (var item in ValorDenominacion)
            {
                entitiesValorDenominacion.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.Depositario entitiesDispositivoDepositario = new();
            foreach (var item in DispositivoDepositario)
            {
                entitiesDispositivoDepositario.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.DepositarioContadora entitiesDispositivoDepositarioContadora = new();
            foreach (var item in DispositivoDepositarioContadora)
            {
                entitiesDispositivoDepositarioContadora.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.DepositarioEstado entitiesDispositivoDepositarioEstado = new();
            foreach (var item in DispositivoDepositarioEstado)
            {
                entitiesDispositivoDepositarioEstado.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.DepositarioMoneda entitiesDispositivoDepositarioMoneda = new();
            foreach (var item in DispositivoDepositarioMoneda)
            {
                entitiesDispositivoDepositarioMoneda.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.DepositarioPlaca entitiesDispositivoDepositarioPlaca = new();
            foreach (var item in DispositivoDepositarioPlaca)
            {
                entitiesDispositivoDepositarioPlaca.Add(item);
            }
            Depositario.Business.Tables.Directorio.Empresa entitiesDirectorioEmpresa = new();
            foreach (var item in DirectorioEmpresa)
            {
                entitiesDirectorioEmpresa.Add(item);
            }
            Depositario.Business.Tables.Sincronizacion.Entidad entitiesSincronizacionEntidad = new();
            foreach (var item in SincronizacionEntidad)
            {
                entitiesSincronizacionEntidad.Add(item);
            }
            Depositario.Business.Tables.Sincronizacion.EntidadCabecera entitiesSincronizacionEntidadCabecera = new();
            foreach (var item in SincronizacionEntidadCabecera)
            {
                entitiesSincronizacionEntidadCabecera.Add(item);
            }
            Depositario.Business.Tables.Estilo.Esquema entitiesEstiloEsquema = new();
            foreach (var item in EstiloEsquema)
            {
                entitiesEstiloEsquema.Add(item);
            }
            Depositario.Business.Tables.Estilo.EsquemaDetalle entitiesEstiloEsquemaDetalle = new();
            foreach (var item in EstiloEsquemaDetalle)
            {
                entitiesEstiloEsquemaDetalle.Add(item);
            }
            Depositario.Business.Tables.Turno.EsquemaDetalleTurno entitiesTurnoEsquemaDetalleTurno = new();
            foreach (var item in TurnoEsquemaDetalleTurno)
            {
                entitiesTurnoEsquemaDetalleTurno.Add(item);
            }
            Depositario.Business.Tables.Turno.EsquemaTurno entitiesTurnoEsquemaTurno = new();
            foreach (var item in TurnoEsquemaTurno)
            {
                entitiesTurnoEsquemaTurno.Add(item);
            }
            Depositario.Business.Tables.Operacion.Evento entitiesOperacionEvento = new();
            foreach (var item in OperacionEvento)
            {
                entitiesOperacionEvento.Add(item);
            }
            Depositario.Business.Tables.Seguridad.Funcion entitiesSeguridadFuncion = new();
            foreach (var item in SeguridadFuncion)
            {
                entitiesSeguridadFuncion.Add(item);
            }
            Depositario.Business.Tables.Directorio.Grupo entitiesDirectorioGrupo = new();
            foreach (var item in DirectorioGrupo)
            {
                entitiesDirectorioGrupo.Add(item);
            }
            Depositario.Business.Tables.Biometria.HuellaDactilar entitiesBiometriaHuellaDactilar = new();
            foreach (var item in BiometriaHuellaDactilar)
            {
                entitiesBiometriaHuellaDactilar.Add(item);
            }
            Depositario.Business.Tables.Seguridad.IdentificadorUsuario entitiesDirectorioIdentificadorUsuario = new();
            foreach (var item in DirectorioIdentificadorUsuario)
            {
                entitiesDirectorioIdentificadorUsuario.Add(item);
            }
            Depositario.Business.Tables.Regionalizacion.Lenguaje entitiesRegionalizacionLenguaje = new();
            foreach (var item in RegionalizacionLenguaje)
            {
                entitiesRegionalizacionLenguaje.Add(item);
            }
            Depositario.Business.Tables.Regionalizacion.LenguajeItem entitiesRegionalizacionLenguajeItem = new();
            foreach (var item in RegionalizacionLenguajeItem)
            {
                entitiesRegionalizacionLenguajeItem.Add(item);
            }
            Depositario.Business.Tables.Auditoria.Log entitiesAuditoriaLog = new();
            foreach (var item in AuditoriaLog)
            {
                entitiesAuditoriaLog.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.Marca entitiesDispositivoMarca = new();
            foreach (var item in DispositivoMarca)
            {
                entitiesDispositivoMarca.Add(item);
            }
            Depositario.Business.Tables.Seguridad.Menu entitiesSeguridadMenu = new();
            foreach (var item in SeguridadMenu)
            {
                entitiesSeguridadMenu.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.Modelo entitiesDispositivoModelo = new();
            foreach (var item in DispositivoModelo)
            {
                entitiesDispositivoModelo.Add(item);
            }
            Depositario.Business.Tables.Valor.Moneda entitiesValorMoneda = new();
            foreach (var item in ValorMoneda)
            {
                entitiesValorMoneda.Add(item);
            }
            Depositario.Business.Tables.Geografia.Pais entitiesGeografiaPais = new();
            foreach (var item in GeografiaPais)
            {
                entitiesGeografiaPais.Add(item);
            }
            Depositario.Business.Tables.Visualizacion.Perfil entitiesVisualizacionPerfil = new();
            foreach (var item in VisualizacionPerfil)
            {
                entitiesVisualizacionPerfil.Add(item);
            }
            Depositario.Business.Tables.Visualizacion.PerfilItem entitiesVisualizacionPerfilItem = new();
            foreach (var item in VisualizacionPerfilItem)
            {
                entitiesVisualizacionPerfilItem.Add(item);
            }
            Depositario.Business.Tables.Visualizacion.PerfilTipo entitiesVisualizacionPerfilTipo = new();
            foreach (var item in VisualizacionPerfilTipo)
            {
                entitiesVisualizacionPerfilTipo.Add(item);
            }
            Depositario.Business.Tables.Geografia.Provincia entitiesGeografiaProvincia = new();
            foreach (var item in GeografiaProvincia)
            {
                entitiesGeografiaProvincia.Add(item);
            }
            Depositario.Business.Tables.Directorio.RelacionMonedaSucursal entitiesDirectorioRelacionMonedaSucursal = new();
            foreach (var item in DirectorioRelacionMonedaSucursal)
            {
                entitiesDirectorioRelacionMonedaSucursal.Add(item);
            }
            Depositario.Business.Tables.Valor.RelacionMonedaTipoValor entitiesValorRelacionMonedaTipoValor = new();
            foreach (var item in ValorRelacionMonedaTipoValor)
            {
                entitiesValorRelacionMonedaTipoValor.Add(item);
            }
            Depositario.Business.Tables.Seguridad.Rol entitiesSeguridadRol = new();
            foreach (var item in SeguridadRol)
            {
                entitiesSeguridadRol.Add(item);
            }
            Depositario.Business.Tables.Seguridad.RolFuncion entitiesSeguridadRolFuncion = new();
            foreach (var item in SeguridadRolFuncion)
            {
                entitiesSeguridadRolFuncion.Add(item);
            }
            Depositario.Business.Tables.Directorio.Sector entitiesDirectorioSector = new();
            foreach (var item in DirectorioSector)
            {
                entitiesDirectorioSector.Add(item);
            }
            Depositario.Business.Tables.Operacion.Sesion entitiesOperacionSesion = new();
            foreach (var item in OperacionSesion)
            {
                entitiesOperacionSesion.Add(item);
            }
            Depositario.Business.Tables.Directorio.Sucursal entitiesDirectorioSucursal = new();
            foreach (var item in DirectorioSucursal)
            {
                entitiesDirectorioSucursal.Add(item);
            }
            Depositario.Business.Tables.Valor.Tipo entitiesValorTipo = new();
            foreach (var item in ValorTipo)
            {
                entitiesValorTipo.Add(item);
            }
            Depositario.Business.Tables.Seguridad.TipoAplicacion entitiesSeguridadTipoAplicacion = new();
            foreach (var item in SeguridadTipoAplicacion)
            {
                entitiesSeguridadTipoAplicacion.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario entitiesDispositivoTipoConfiguracionDepositario = new();
            foreach (var item in DispositivoTipoConfiguracionDepositario)
            {
                entitiesDispositivoTipoConfiguracionDepositario.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.TipoContadora entitiesDispositivoTipoContadora = new();
            foreach (var item in DispositivoTipoContadora)
            {
                entitiesDispositivoTipoContadora.Add(item);
            }
            Depositario.Business.Tables.Operacion.TipoContenedor entitiesOperacionTipoContenedor = new();
            foreach (var item in OperacionTipoContenedor)
            {
                entitiesOperacionTipoContenedor.Add(item);
            }
            Depositario.Business.Tables.Banca.TipoCuenta entitiesBancaTipoCuenta = new();
            foreach (var item in BancaTipoCuenta)
            {
                entitiesBancaTipoCuenta.Add(item);
            }
            Depositario.Business.Tables.Estilo.TipoEsquemaDetalle entitiesEstiloTipoEsquemaDetalle = new();
            foreach (var item in EstiloTipoEsquemaDetalle)
            {
                entitiesEstiloTipoEsquemaDetalle.Add(item);
            }
            Depositario.Business.Tables.Operacion.TipoEvento entitiesOperacionTipoEvento = new();
            foreach (var item in OperacionTipoEvento)
            {
                entitiesOperacionTipoEvento.Add(item);
            }
            Depositario.Business.Tables.Seguridad.TipoFuncion entitiesSeguridadTipoFuncion = new();
            foreach (var item in SeguridadTipoFuncion)
            {
                entitiesSeguridadTipoFuncion.Add(item);
            }
            Depositario.Business.Tables.Seguridad.TipoIdentificador entitiesDirectorioTipoIdentificador = new();
            foreach (var item in DirectorioTipoIdentificador)
            {
                entitiesDirectorioTipoIdentificador.Add(item);
            }
            Depositario.Business.Tables.Auditoria.TipoLog entitiesAuditoriaTipoLog = new();
            foreach (var item in AuditoriaTipoLog)
            {
                entitiesAuditoriaTipoLog.Add(item);
            }
            Depositario.Business.Tables.Seguridad.TipoMenu entitiesSeguridadTipoMenu = new();
            foreach (var item in SeguridadTipoMenu)
            {
                entitiesSeguridadTipoMenu.Add(item);
            }
            Depositario.Business.Tables.Dispositivo.TipoPlaca entitiesDispositivoTipoPlaca = new();
            foreach (var item in DispositivoTipoPlaca)
            {
                entitiesDispositivoTipoPlaca.Add(item);
            }
            Depositario.Business.Tables.Operacion.TipoTransaccion entitiesOperacionTipoTransaccion = new();
            foreach (var item in OperacionTipoTransaccion)
            {
                entitiesOperacionTipoTransaccion.Add(item);
            }
            Depositario.Business.Tables.Operacion.Transaccion entitiesOperacionTransaccion = new();
            foreach (var item in OperacionTransaccion)
            {
                entitiesOperacionTransaccion.Add(item);
            }
            Depositario.Business.Tables.Operacion.TransaccionDetalle entitiesOperacionTransaccionDetalle = new();
            foreach (var item in OperacionTransaccionDetalle)
            {
                entitiesOperacionTransaccionDetalle.Add(item);
            }
            Depositario.Business.Tables.Operacion.TransaccionSobre entitiesOperacionTransaccionSobre = new();
            foreach (var item in OperacionTransaccionSobre)
            {
                entitiesOperacionTransaccionSobre.Add(item);
            }
            Depositario.Business.Tables.Operacion.TransaccionSobreDetalle entitiesOperacionTransaccionSobreDetalle = new();
            foreach (var item in OperacionTransaccionSobreDetalle)
            {
                entitiesOperacionTransaccionSobreDetalle.Add(item);
            }
            Depositario.Business.Tables.Operacion.Turno entitiesOperacionTurno = new();
            foreach (var item in OperacionTurno)
            {
                entitiesOperacionTurno.Add(item);
            }
            Depositario.Business.Tables.Operacion.TurnoUsuario entitiesOperacionTurnoUsuario = new();
            foreach (var item in OperacionTurnoUsuario)
            {
                entitiesOperacionTurnoUsuario.Add(item);
            }
            Depositario.Business.Tables.Seguridad.Usuario entitiesSeguridadUsuario = new();
            foreach (var item in SeguridadUsuario)
            {
                entitiesSeguridadUsuario.Add(item);
            }
            Depositario.Business.Tables.Banca.UsuarioCuenta entitiesBancaUsuarioCuenta = new();
            foreach (var item in BancaUsuarioCuenta)
            {
                entitiesBancaUsuarioCuenta.Add(item);
            }
            Depositario.Business.Tables.Seguridad.UsuarioRol entitiesSeguridadUsuarioRol = new();
            foreach (var item in SeguridadUsuarioRol)
            {
                entitiesSeguridadUsuarioRol.Add(item);
            }
            Depositario.Business.Tables.Seguridad.UsuarioSector entitiesSeguridadUsuarioSector = new();
            foreach (var item in SeguridadUsuarioSector)
            {
                entitiesSeguridadUsuarioSector.Add(item);
            }
            Depositario.Business.Tables.Geografia.Zona entitiesGeografiaZona = new();
            foreach (var item in GeografiaZona)
            {
                entitiesGeografiaZona.Add(item);
            }

            Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entitiesConfiguracionEmpresa = new();
            foreach (var item in ConfiguracionEmpresa)
            {
                entitiesConfiguracionEmpresa.Add(item);
            }

            Depositario.Business.Tables.Dispositivo.PlantillaMoneda entitiesPlantillaMoneda = new();
            foreach (var item in PlantillaMoneda)
            {
                entitiesPlantillaMoneda.Add(item);
            }

            Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle entitiesPlantillaMonedaDetalle = new();
            foreach (var item in PlantillaMonedaDetalle)
            {
                entitiesPlantillaMonedaDetalle.Add(item);
            }

            Depositario.Business.Tables.Valor.OrigenValor entitiesOrigenValor = new();
            foreach (var item in OrigenValor)
            {
                entitiesOrigenValor.Add(item);
            }
        }

    }
    
}
