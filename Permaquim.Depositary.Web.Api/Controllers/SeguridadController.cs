using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SeguridadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_APLICACION = "Seguridad.Aplicacion";
        private const string ENTIDAD_APLICACIONPARAMETRO = "Seguridad.AplicacionParametro";
        private const string ENTIDAD_APLICACIONPARAMETROVALOR = "Seguridad.AplicacionParametroValor";
        private const string ENTIDAD_FUNCION = "Seguridad.Funcion";
        private const string ENTIDAD_IDENTIFICADORUSUARIO = "Seguridad.IdentificadorUsuario";
        private const string ENTIDAD_MENU = "Seguridad.Menu";
        private const string ENTIDAD_ROL = "Seguridad.Rol";
        private const string ENTIDAD_ROLFUNCION = "Seguridad.RolFuncion";
        private const string ENTIDAD_TIPOAPLICACION = "Seguridad.TipoAplicacion";
        private const string ENTIDAD_TIPOFUNCION = "Seguridad.TipoFuncion";
        private const string ENTIDAD_TIPOIDENTIFICADOR = "Seguridad.TipoIdentificador";
        private const string ENTIDAD_TIPOMENU = "Seguridad.TipoMenu";
        private const string ENTIDAD_USUARIO = "Seguridad.Usuario";
        private const string ENTIDAD_USUARIOROL = "Seguridad.UsuarioRol";
        private const string ENTIDAD_USUARIOSECTOR = "Seguridad.UsuarioSector";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerSeguridad")]
        [Authorize]
        public async Task<IActionResult> ObtenerSeguridad([FromBody] SeguridadModel data)
        {
            try
            {
                Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

                if (data.SynchronizationExecutionId.HasValue)
                {

                    //Por defecto se indica una fecha minima para no usar nulos
                    DateTime fechaSincronizacionDefault = new(1900, 1, 1);

                    Int64? EjecucionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion("Sincronizacion.Ejecucion", depositarioId, data.SynchronizationExecutionId.Value);

                    if (EjecucionId.HasValue)
                    {

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroSeguridadAplicacionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_APLICACION);

                        if (SincroSeguridadAplicacionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_APLICACION) ? data.SincroDates[ENTIDAD_APLICACION] : fechaSincronizacionDefault;
                            data.Aplicaciones = ObtenerAplicacionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionId.Value);
                        }

                        Int64? SincroSeguridadAplicacionParametroId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_APLICACIONPARAMETRO);

                        if (SincroSeguridadAplicacionParametroId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_APLICACIONPARAMETRO) ? data.SincroDates[ENTIDAD_APLICACIONPARAMETRO] : fechaSincronizacionDefault;
                            data.AplicacionesParametros = ObtenerAplicacionesParametrosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionParametroId.Value);
                        }

                        Int64? SincroSeguridadAplicacionParametroValorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_APLICACIONPARAMETROVALOR);

                        if (SincroSeguridadAplicacionParametroValorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_APLICACIONPARAMETROVALOR) ? data.SincroDates[ENTIDAD_APLICACIONPARAMETROVALOR] : fechaSincronizacionDefault;
                            data.AplicacionesParametrosValores = ObtenerAplicacionesParametrosValoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionParametroValorId.Value);
                        }

                        Int64? SincroSeguridadTipoIdentificadorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOIDENTIFICADOR);

                        if (SincroSeguridadTipoIdentificadorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOIDENTIFICADOR) ? data.SincroDates[ENTIDAD_TIPOIDENTIFICADOR] : fechaSincronizacionDefault;
                            data.TiposIdentificadores = ObtenerTiposIdentificadoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadTipoIdentificadorId.Value);
                        }

                        Int64? SincroSeguridadIdentificadorUsuarioId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_IDENTIFICADORUSUARIO);

                        if (SincroSeguridadIdentificadorUsuarioId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_IDENTIFICADORUSUARIO) ? data.SincroDates[ENTIDAD_IDENTIFICADORUSUARIO] : fechaSincronizacionDefault;
                            data.IdentificadoresUsuarios = ObtenerIdentificadoresUsuariosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadIdentificadorUsuarioId.Value);
                        }

                        Int64? SincroSeguridadRolId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ROL);

                        if (SincroSeguridadRolId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ROL) ? data.SincroDates[ENTIDAD_ROL] : fechaSincronizacionDefault;
                            data.Roles = ObtenerRolesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadRolId.Value);
                        }

                        Int64? SincroSeguridadUsuarioId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_USUARIO);

                        if (SincroSeguridadUsuarioId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_USUARIO) ? data.SincroDates[ENTIDAD_USUARIO] : fechaSincronizacionDefault;
                            data.Usuarios = ObtenerUsuariosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioId.Value);
                        }

                        Int64? SincroSeguridadUsuarioRolId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_USUARIOROL);

                        if (SincroSeguridadUsuarioRolId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_USUARIOROL) ? data.SincroDates[ENTIDAD_USUARIOROL] : fechaSincronizacionDefault;
                            data.UsuariosRoles = ObtenerUsuariosRolesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioRolId.Value);
                        }

                        Int64? SincroSeguridadUsuarioSectorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_USUARIOSECTOR);

                        if (SincroSeguridadUsuarioSectorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_USUARIOSECTOR) ? data.SincroDates[ENTIDAD_USUARIOSECTOR] : fechaSincronizacionDefault;
                            data.UsuariosSectores = ObtenerUsuariosSectoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioSectorId.Value);
                        }

                        Int64? SincroSeguridadTipoAplicacionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOAPLICACION);

                        if (SincroSeguridadTipoAplicacionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOAPLICACION) ? data.SincroDates[ENTIDAD_TIPOAPLICACION] : fechaSincronizacionDefault;
                            data.TiposAplicaciones = ObtenerTiposAplicacionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadTipoAplicacionId.Value);
                        }

                        Int64? SincroSeguridadTipoFuncionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOFUNCION);

                        if (SincroSeguridadTipoFuncionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOFUNCION) ? data.SincroDates[ENTIDAD_TIPOFUNCION] : fechaSincronizacionDefault;
                            data.TiposFunciones = ObtenerTiposFuncionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadTipoFuncionId.Value);
                        }

                        Int64? SincroSeguridadTipoMenuId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOMENU);

                        if (SincroSeguridadTipoMenuId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOMENU) ? data.SincroDates[ENTIDAD_TIPOMENU] : fechaSincronizacionDefault;
                            data.TiposMenues = ObtenerTiposMenuesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadTipoMenuId.Value);
                        }

                        Int64? SincroSeguridadFuncionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_FUNCION);

                        if (SincroSeguridadFuncionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_FUNCION) ? data.SincroDates[ENTIDAD_FUNCION] : fechaSincronizacionDefault;
                            data.Funciones = ObtenerFuncionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadFuncionId.Value);
                        }

                        Int64? SincroSeguridadRolFuncionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ROLFUNCION);

                        if (SincroSeguridadRolFuncionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ROLFUNCION) ? data.SincroDates[ENTIDAD_ROLFUNCION] : fechaSincronizacionDefault;
                            data.RolesFunciones = ObtenerRolesFuncionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadRolFuncionId.Value);
                        }

                        Int64? SincroSeguridadMenuId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_MENU);

                        if (SincroSeguridadMenuId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_MENU) ? data.SincroDates[ENTIDAD_MENU] : fechaSincronizacionDefault;
                            data.Menues = ObtenerMenuesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroSeguridadMenuId.Value);
                        }
                        return Ok(data);
                    }
                    else
                    {
                        AuditController.Log("Depositario: " + depositarioId.ToString() + " " + Global.Constants.ERROR_NO_SYNCHRONIZATION_ROW_GENERATED);
                        return BadRequest(Global.Constants.ERROR_NO_SYNCHRONIZATION_ROW_GENERATED);
                    }
                }
                else
                {
                    AuditController.Log("Depositario: " + depositarioId.ToString() + " " + Global.Constants.ERROR_NO_SYNCHRONIZATION_ID_SENT);
                    return BadRequest(Global.Constants.ERROR_NO_SYNCHRONIZATION_ID_SENT);
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            SeguridadUsuarioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Usuarios = ObtenerUsuariosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIO));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerAplicacionesParametros")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacionesParametros()
        {
            SeguridadAplicacionParametroModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.AplicacionesParametros = ObtenerAplicacionesParametrosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerAplicacionesParametrosValores")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacionesParametrosValores()
        {
            SeguridadAplicacionParametroValorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.AplicacionesParametrosValores = ObtenerAplicacionesParametrosValoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerRolesFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerRolesFunciones()
        {
            SeguridadRolFuncionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROLFUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RolesFunciones = ObtenerRolesFuncionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROLFUNCION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerUsuariosRoles")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosRoles()
        {
            SeguridadUsuarioRolModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOROL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosRoles = ObtenerUsuariosRolesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOROL));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerUsuariosSectores")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosSectores()
        {
            SeguridadUsuarioSectorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosSectores = ObtenerUsuariosSectoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        [Authorize]
        public async Task<IActionResult> ObtenerRoles()
        {
            SeguridadRolModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Roles = ObtenerRolesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROL));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerMenues")]
        [Authorize]
        public async Task<IActionResult> ObtenerMenues()
        {
            SeguridadMenuModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MENU);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Menues = ObtenerMenuesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MENU));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerFunciones()
        {
            SeguridadFuncionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_FUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Funciones = ObtenerFuncionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_FUNCION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposFunciones()
        {
            SeguridadTipoFuncionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposFunciones = ObtenerTiposFuncionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposMenues")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposMenues()
        {
            SeguridadTipoMenuModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOMENU);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposMenues = ObtenerTiposMenuesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOMENU));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposAplicaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposAplicaciones()
        {
            SeguridadTipoAplicacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposAplicaciones = ObtenerTiposAplicacionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerAplicaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicaciones()
        {
            SeguridadAplicacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Aplicaciones = ObtenerAplicacionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerIdentificadoresUsuarios")]
        [Authorize]
        public async Task<IActionResult> ObtenerIdentificadoresUsuarios()
        {
            SeguridadIdentificadorUsuarioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.IdentificadoresUsuarios = ObtenerIdentificadoresUsuariosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposIdentificadores")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposIdentificadores()
        {
            SeguridadTipoIdentificadorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposIdentificadores = ObtenerTiposIdentificadoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> ObtenerUsuariosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Usuario oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Usuario.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.Usuario.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> ObtenerRolesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Rol oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Rol.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.Rol.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> ObtenerRolesFuncionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.RolFuncion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.RolFuncion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.RolFuncion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> ObtenerTiposAplicacionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoAplicacion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.TipoAplicacion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.TipoAplicacion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> ObtenerTiposFuncionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoFuncion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.TipoFuncion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.TipoFuncion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> ObtenerTiposMenuesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoMenu oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.TipoMenu.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.TipoMenu.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> ObtenerUsuariosRolesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioRol oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> ObtenerUsuariosSectoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioSector oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> ObtenerAplicacionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Aplicacion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Aplicacion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.Aplicacion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> ObtenerAplicacionesParametrosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametro oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametro.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametro.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> ObtenerAplicacionesParametrosValoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametroValor oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametroValor.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametroValor.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> ObtenerFuncionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Funcion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Funcion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.Funcion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> ObtenerMenuesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Menu oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Menu.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.Menu.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> ObtenerIdentificadoresUsuariosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.IdentificadorUsuario oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.IdentificadorUsuario.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.IdentificadorUsuario.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> ObtenerTiposIdentificadoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoIdentificador oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.TipoIdentificador.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Seguridad.TipoIdentificador.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion
    }
}
