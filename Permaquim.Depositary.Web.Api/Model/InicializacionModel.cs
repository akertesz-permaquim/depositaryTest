﻿namespace Permaquim.Depositary.Web.Api.Model
{
    public class InicializacionModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionTipoDato> AplicacionConfiguracionTipoDato { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> AplicacionConfiguracionValidacionDato { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> AplicacionConfiguracion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa> AplicacionConfiguracionEmpresa { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> AuditoriaTipoLog { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.Banco> BancaBanco { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> BancaCuenta { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> BancaTipoCuenta { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> BancaUsuarioCuenta { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> BiometriaHuellaDactilar { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> DirectorioEmpresa { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> DirectorioGrupo { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> SeguridadIdentificadorUsuario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> DirectorioRelacionMonedaSucursal { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sector> DirectorioSector { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> DirectorioSucursal { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> SeguridadTipoIdentificador { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> DispositivoComandoContadora { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> DispositivoComandoPlaca { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> DispositivoConfiguracionDepositario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> DispositivoDepositario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> DispositivoDepositarioContadora { get; set; } = new();
        //public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositaryWebApiEstado> DispositivoDepositaryWebApiEstado { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> DispositivoDepositarioMoneda { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> DispositivoDepositarioPlaca { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> DispositivoMarca { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> DispositivoModelo { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> DispositivoTipoConfiguracionDepositario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> DispositivoTipoContadora { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> DispositivoTipoPlaca { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> EstiloEsquema { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EstiloEsquemaDetalle { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> EstiloTipoEsquemaDetalle { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> GeografiaCiudad { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> GeografiaCodigoPostal { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Geografia.Pais> GeografiaPais { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> GeografiaProvincia { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Geografia.Zona> GeografiaZona { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> OperacionTipoContenedor { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> OperacionTipoEvento { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> OperacionTipoTransaccion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> RegionalizacionLenguaje { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> RegionalizacionLenguajeItem { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> SeguridadAplicacion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> SeguridadAplicacionParametro { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> SeguridadAplicacionParametroValor { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> SeguridadFuncion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> SeguridadMenu { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> SeguridadRol { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> SeguridadRolFuncion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> SeguridadTipoAplicacion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> SeguridadTipoFuncion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> SeguridadTipoMenu { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> SeguridadUsuario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> SeguridadUsuarioRol { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> SeguridadUsuarioSector { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Configuracion> SincronizacionConfiguracion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> SincronizacionEntidad { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> TurnoAgendaTurno { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> TurnoEsquemaDetalleTurno { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> TurnoEsquemaTurno { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> ValorDenominacion { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Moneda> ValorMoneda { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> ValorRelacionMonedaTipoValor { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Tipo> ValorTipo { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> VisualizacionPerfil { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> VisualizacionPerfilItem { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> VisualizacionPerfilTipo { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMoneda> PlantillaMoneda { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> PlantillaMonedaDetalle { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> OrigenValor { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Impresion.TipoTicket> TipoTicket { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Impresion.Ticket> Ticket { get; set; } = new();
    }
}
