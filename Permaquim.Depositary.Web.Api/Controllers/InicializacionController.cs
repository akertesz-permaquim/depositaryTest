using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicializacionController : ControllerBase
    {
        #region GetEndpoints

        [HttpGet]
        [Route("ObtenerDatosIniciales")]
        [Authorize]
        public async Task<IActionResult> ObtenerDatosIniciales()
        {
            InicializacionModel model = new();
            model.AplicacionConfiguracion = ObtenerAplicacionConfiguracion();
            model.AuditoriaLog = ObtenerAuditoriaLog();
            model.AuditoriaTipoLog = ObtenerAuditoriaTipoLog();
            model.BancaBanco = ObtenerBancaBanco();
            model.BancaCuenta = ObtenerBancaCuenta();
            model.BancaTipoCuenta = ObtenerBancaTipoCuenta();
            model.BancaUsuarioCuenta = ObtenerBancaUsuarioCuenta();
            model.BiometriaHuellaDactilar = ObtenerBiometriaHuellaDactilar();
            model.DirectorioEmpresa = ObtenerDirectorioEmpresa();
            model.DirectorioGrupo = ObtenerDirectorioGrupo();
            model.DirectorioIdentificadorUsuario = ObtenerDirectorioIdentificadorUsuario();
            model.DirectorioRelacionMonedaSucursal = ObtenerDirectorioRelacionMonedaSucursal();
            model.DirectorioSector = ObtenerDirectorioSector();
            model.DirectorioSucursal = ObtenerDirectorioSucursal();
            model.DirectorioTipoIdentificador = ObtenerDirectorioTipoIdentificador();
            model.DispositivoComandoContadora = ObtenerDispositivoComandoContadora();
            model.DispositivoComandoPlaca = ObtenerDispositivoComandoPlaca();
            model.DispositivoConfiguracionDepositario = ObtenerDispositivoConfiguracionDepositario();
            model.DispositivoDepositario = ObtenerDispositivoDepositario();
            model.DispositivoDepositarioContadora = ObtenerDispositivoDepositarioContadora();
            model.DispositivoDepositarioEstado = ObtenerDispositivoDepositarioEstado();
            model.DispositivoDepositarioMoneda = ObtenerDispositivoDepositarioMoneda();
            model.DispositivoDepositarioPlaca = ObtenerDispositivoDepositarioPlaca();
            model.DispositivoMarca = ObtenerDispositivoMarca();
            model.DispositivoModelo = ObtenerDispositivoModelo();
            model.DispositivoTipoConfiguracionDepositario = ObtenerDispositivoTipoConfiguracionDepositario();
            model.DispositivoTipoContadora = ObtenerDispositivoTipoContadora();
            model.DispositivoTipoPlaca = ObtenerDispositivoTipoPlaca();
            model.EstiloEsquema = ObtenerEstiloEsquema();
            model.EstiloEsquemaDetalle = ObtenerEstiloEsquemaDetalle();
            model.EstiloTipoEsquemaDetalle = ObtenerEstiloTipoEsquemaDetalle();
            model.GeografiaCiudad = ObtenerGeografiaCiudad();
            model.GeografiaCodigoPostal = ObtenerGeografiaCodigoPostal();
            model.GeografiaPais = ObtenerGeografiaPais();
            model.GeografiaProvincia = ObtenerGeografiaProvincia();
            model.GeografiaZona = ObtenerGeografiaZona();
            model.OperacionCierreDiario = ObtenerOperacionCierreDiario();
            model.OperacionContenedor = ObtenerOperacionContenedor();
            model.OperacionEvento = ObtenerOperacionEvento();
            model.OperacionSesion = ObtenerOperacionSesion();
            model.OperacionTipoContenedor = ObtenerOperacionTipoContenedor();
            model.OperacionTipoEvento = ObtenerOperacionTipoEvento();
            model.OperacionTipoTransaccion = ObtenerOperacionTipoTransaccion();
            model.OperacionTransaccion = ObtenerOperacionTransaccion();
            model.OperacionTransaccionDetalle = ObtenerOperacionTransaccionDetalle();
            model.OperacionTransaccionSobre = ObtenerOperacionTransaccionSobre();
            model.OperacionTransaccionSobreDetalle = ObtenerOperacionTransaccionSobreDetalle();
            model.OperacionTurno = ObtenerOperacionTurno();
            model.OperacionTurnoUsuario = ObtenerOperacionTurnoUsuario();
            model.RegionalizacionLenguaje = ObtenerRegionalizacionLenguaje();
            model.RegionalizacionLenguajeItem = ObtenerRegionalizacionLenguajeItem();
            model.SeguridadAplicacion = ObtenerSeguridadAplicacion();
            model.SeguridadAplicacionParametro = ObtenerSeguridadAplicacionParametro();
            model.SeguridadAplicacionParametroValor = ObtenerSeguridadAplicacionParametroValor();
            model.SeguridadFuncion = ObtenerSeguridadFuncion();
            model.SeguridadMenu = ObtenerSeguridadMenu();
            model.SeguridadRol = ObtenerSeguridadRol();
            model.SeguridadRolFuncion = ObtenerSeguridadRolFuncion();
            model.SeguridadTipoAplicacion = ObtenerSeguridadTipoAplicacion();
            model.SeguridadTipoFuncion = ObtenerSeguridadTipoFuncion();
            model.SeguridadTipoMenu = ObtenerSeguridadTipoMenu();
            model.SeguridadUsuario = ObtenerSeguridadUsuario();
            model.SeguridadUsuarioRol = ObtenerSeguridadUsuarioRol();
            model.SeguridadUsuarioSector = ObtenerSeguridadUsuarioSector();
            model.SincronizacionConfiguracion = ObtenerSincronizacionConfiguracion();
            model.SincronizacionEntidad = ObtenerSincronizacionEntidad();
            model.SincronizacionEntidadCabecera = ObtenerSincronizacionEntidadCabecera();
            model.SincronizacionEntidadDetalle = ObtenerSincronizacionEntidadDetalle();
            model.TurnoAgendaTurno = ObtenerTurnoAgendaTurno();
            model.TurnoEsquemaDetalleTurno = ObtenerTurnoEsquemaDetalleTurno();
            model.TurnoEsquemaTurno = ObtenerTurnoEsquemaTurno();
            model.ValorDenominacion = ObtenerValorDenominacion();
            model.ValorMoneda = ObtenerValorMoneda();
            model.ValorRelacionMonedaTipoValor = ObtenerValorRelacionMonedaTipoValor();
            model.ValorTipo = ObtenerValorTipo();
            model.VisualizacionPerfil = ObtenerVisualizacionPerfil();
            model.VisualizacionPerfilItem = ObtenerVisualizacionPerfilItem();
            model.VisualizacionPerfilTipo = ObtenerVisualizacionPerfilTipo();

            return Ok(model);
        }
        #endregion

        #region DB
        private List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ObtenerAplicacionConfiguracion()
        {
            DepositaryWebApi.Business.Tables.Aplicacion.Configuracion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Auditoria.Log> ObtenerAuditoriaLog()
        {
            DepositaryWebApi.Business.Tables.Auditoria.Log entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> ObtenerAuditoriaTipoLog()
        {
            DepositaryWebApi.Business.Tables.Auditoria.TipoLog entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Banca.Banco> ObtenerBancaBanco()
        {
            DepositaryWebApi.Business.Tables.Banca.Banco entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> ObtenerBancaCuenta()
        {
            DepositaryWebApi.Business.Tables.Banca.Cuenta entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> ObtenerBancaTipoCuenta()
        {
            DepositaryWebApi.Business.Tables.Banca.TipoCuenta entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> ObtenerBancaUsuarioCuenta()
        {
            DepositaryWebApi.Business.Tables.Banca.UsuarioCuenta entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> ObtenerBiometriaHuellaDactilar()
        {
            DepositaryWebApi.Business.Tables.Biometria.HuellaDactilar entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> ObtenerDirectorioEmpresa()
        {
            DepositaryWebApi.Business.Tables.Directorio.Empresa entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> ObtenerDirectorioGrupo()
        {
            DepositaryWebApi.Business.Tables.Directorio.Grupo entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.IdentificadorUsuario> ObtenerDirectorioIdentificadorUsuario()
        {
            DepositaryWebApi.Business.Tables.Directorio.IdentificadorUsuario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> ObtenerDirectorioRelacionMonedaSucursal()
        {
            DepositaryWebApi.Business.Tables.Directorio.RelacionMonedaSucursal entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.Sector> ObtenerDirectorioSector()
        {
            DepositaryWebApi.Business.Tables.Directorio.Sector entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> ObtenerDirectorioSucursal()
        {
            DepositaryWebApi.Business.Tables.Directorio.Sucursal entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Directorio.TipoIdentificador> ObtenerDirectorioTipoIdentificador()
        {
            DepositaryWebApi.Business.Tables.Directorio.TipoIdentificador entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> ObtenerDispositivoComandoContadora()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoContadora entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> ObtenerDispositivoComandoPlaca()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoPlaca entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ObtenerDispositivoConfiguracionDepositario()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> ObtenerDispositivoDepositario()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> ObtenerDispositivoDepositarioContadora()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioContadora entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> ObtenerDispositivoDepositarioEstado()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> ObtenerDispositivoDepositarioMoneda()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioMoneda entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> ObtenerDispositivoDepositarioPlaca()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioPlaca entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> ObtenerDispositivoMarca()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Marca entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> ObtenerDispositivoModelo()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Modelo entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> ObtenerDispositivoTipoConfiguracionDepositario()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.TipoConfiguracionDepositario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> ObtenerDispositivoTipoContadora()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.TipoContadora entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> ObtenerDispositivoTipoPlaca()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.TipoPlaca entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> ObtenerEstiloEsquema()
        {
            DepositaryWebApi.Business.Tables.Estilo.Esquema entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEstiloEsquemaDetalle()
        {
            DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> ObtenerEstiloTipoEsquemaDetalle()
        {
            DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> ObtenerGeografiaCiudad()
        {
            DepositaryWebApi.Business.Tables.Geografia.Ciudad entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> ObtenerGeografiaCodigoPostal()
        {
            DepositaryWebApi.Business.Tables.Geografia.CodigoPostal entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Geografia.Pais> ObtenerGeografiaPais()
        {
            DepositaryWebApi.Business.Tables.Geografia.Pais entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> ObtenerGeografiaProvincia()
        {
            DepositaryWebApi.Business.Tables.Geografia.Provincia entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Geografia.Zona> ObtenerGeografiaZona()
        {
            DepositaryWebApi.Business.Tables.Geografia.Zona entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.CierreDiario> ObtenerOperacionCierreDiario()
        {
            DepositaryWebApi.Business.Tables.Operacion.CierreDiario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.Contenedor> ObtenerOperacionContenedor()
        {
            DepositaryWebApi.Business.Tables.Operacion.Contenedor entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.Evento> ObtenerOperacionEvento()
        {
            DepositaryWebApi.Business.Tables.Operacion.Evento entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.Sesion> ObtenerOperacionSesion()
        {
            DepositaryWebApi.Business.Tables.Operacion.Sesion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> ObtenerOperacionTipoContenedor()
        {
            DepositaryWebApi.Business.Tables.Operacion.TipoContenedor entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> ObtenerOperacionTipoEvento()
        {
            DepositaryWebApi.Business.Tables.Operacion.TipoEvento entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> ObtenerOperacionTipoTransaccion()
        {
            DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.Transaccion> ObtenerOperacionTransaccion()
        {
            DepositaryWebApi.Business.Tables.Operacion.Transaccion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle> ObtenerOperacionTransaccionDetalle()
        {
            DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobre> ObtenerOperacionTransaccionSobre()
        {
            DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> ObtenerOperacionTransaccionSobreDetalle()
        {
            DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.Turno> ObtenerOperacionTurno()
        {
            DepositaryWebApi.Business.Tables.Operacion.Turno entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Operacion.TurnoUsuario> ObtenerOperacionTurnoUsuario()
        {
            DepositaryWebApi.Business.Tables.Operacion.TurnoUsuario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> ObtenerRegionalizacionLenguaje()
        {
            DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> ObtenerRegionalizacionLenguajeItem()
        {
            DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> ObtenerSeguridadAplicacion()
        {
            DepositaryWebApi.Business.Tables.Seguridad.Aplicacion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> ObtenerSeguridadAplicacionParametro()
        {
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametro entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> ObtenerSeguridadAplicacionParametroValor()
        {
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametroValor entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> ObtenerSeguridadFuncion()
        {
            DepositaryWebApi.Business.Tables.Seguridad.Funcion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> ObtenerSeguridadMenu()
        {
            DepositaryWebApi.Business.Tables.Seguridad.Menu entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> ObtenerSeguridadRol()
        {
            DepositaryWebApi.Business.Tables.Seguridad.Rol entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> ObtenerSeguridadRolFuncion()
        {
            DepositaryWebApi.Business.Tables.Seguridad.RolFuncion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> ObtenerSeguridadTipoAplicacion()
        {
            DepositaryWebApi.Business.Tables.Seguridad.TipoAplicacion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> ObtenerSeguridadTipoFuncion()
        {
            DepositaryWebApi.Business.Tables.Seguridad.TipoFuncion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> ObtenerSeguridadTipoMenu()
        {
            DepositaryWebApi.Business.Tables.Seguridad.TipoMenu entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> ObtenerSeguridadUsuario()
        {
            DepositaryWebApi.Business.Tables.Seguridad.Usuario entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> ObtenerSeguridadUsuarioRol()
        {
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioRol entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> ObtenerSeguridadUsuarioSector()
        {
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioSector entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Sincronizacion.Configuracion> ObtenerSincronizacionConfiguracion()
        {
            DepositaryWebApi.Business.Tables.Sincronizacion.Configuracion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> ObtenerSincronizacionEntidad()
        {
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera> ObtenerSincronizacionEntidadCabecera()
        {
            DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle> ObtenerSincronizacionEntidadDetalle()
        {
            DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> ObtenerTurnoAgendaTurno()
        {
            DepositaryWebApi.Business.Tables.Turno.AgendaTurno entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> ObtenerTurnoEsquemaDetalleTurno()
        {
            DepositaryWebApi.Business.Tables.Turno.EsquemaDetalleTurno entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> ObtenerTurnoEsquemaTurno()
        {
            DepositaryWebApi.Business.Tables.Turno.EsquemaTurno entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> ObtenerValorDenominacion()
        {
            DepositaryWebApi.Business.Tables.Valor.Denominacion entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Valor.Moneda> ObtenerValorMoneda()
        {
            DepositaryWebApi.Business.Tables.Valor.Moneda entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> ObtenerValorRelacionMonedaTipoValor()
        {
            DepositaryWebApi.Business.Tables.Valor.RelacionMonedaTipoValor entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Valor.Tipo> ObtenerValorTipo()
        {
            DepositaryWebApi.Business.Tables.Valor.Tipo entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> ObtenerVisualizacionPerfil()
        {
            DepositaryWebApi.Business.Tables.Visualizacion.Perfil entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> ObtenerVisualizacionPerfilItem()
        {
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilItem entities = new();
            return entities.Items();
        }

        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> ObtenerVisualizacionPerfilTipo()
        {
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilTipo entities = new();
            return entities.Items();
        }


        #endregion
    }
}
