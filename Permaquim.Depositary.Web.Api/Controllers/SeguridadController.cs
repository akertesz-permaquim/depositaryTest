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

        [HttpGet]
        [Route("ObtenerSeguridad")]
        [Authorize]
        public async Task<IActionResult> ObtenerSeguridad()
        {
            SeguridadModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroSeguridadAplicacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACION);

                if (SincroSeguridadAplicacionId.HasValue)
                {
                    data.Aplicaciones = ObtenerAplicacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionId.Value);
                }

                Int64? SincroSeguridadAplicacionParametroId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO);

                if (SincroSeguridadAplicacionParametroId.HasValue)
                {
                    data.AplicacionesParametros = ObtenerAplicacionesParametrosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionParametroId.Value);
                }

                Int64? SincroSeguridadAplicacionParametroValorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR);

                if (SincroSeguridadAplicacionParametroValorId.HasValue)
                {
                    data.AplicacionesParametrosValores = ObtenerAplicacionesParametrosValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadAplicacionParametroValorId.Value);
                }

                Int64? SincroSeguridadTipoIdentificadorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR);

                if (SincroSeguridadTipoIdentificadorId.HasValue)
                {
                    data.TiposIdentificadores = ObtenerTiposIdentificadoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadTipoIdentificadorId.Value);
                }

                Int64? SincroSeguridadIdentificadorUsuarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO);

                if (SincroSeguridadIdentificadorUsuarioId.HasValue)
                {
                    data.IdentificadoresUsuarios = ObtenerIdentificadoresUsuariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadIdentificadorUsuarioId.Value);
                }

                Int64? SincroSeguridadRolId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROL);

                if (SincroSeguridadRolId.HasValue)
                {
                    data.Roles = ObtenerRolesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadRolId.Value);
                }

                Int64? SincroSeguridadUsuarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIO);

                if (SincroSeguridadUsuarioId.HasValue)
                {
                    data.Usuarios = ObtenerUsuariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioId.Value);
                }

                Int64? SincroSeguridadUsuarioRolId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOROL);

                if (SincroSeguridadUsuarioRolId.HasValue)
                {
                    data.UsuariosRoles = ObtenerUsuariosRolesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOROL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioRolId.Value);
                }

                Int64? SincroSeguridadUsuarioSectorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR);

                if (SincroSeguridadUsuarioSectorId.HasValue)
                {
                    data.UsuariosSectores = ObtenerUsuariosSectoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadUsuarioSectorId.Value);
                }

                Int64? SincroSeguridadTipoAplicacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION);

                if (SincroSeguridadTipoAplicacionId.HasValue)
                {
                    data.TiposAplicaciones = ObtenerTiposAplicacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadTipoAplicacionId.Value);
                }

                Int64? SincroSeguridadTipoFuncionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION);

                if (SincroSeguridadTipoFuncionId.HasValue)
                {
                    data.TiposFunciones = ObtenerTiposFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadTipoFuncionId.Value);
                }

                Int64? SincroSeguridadTipoMenuId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOMENU);

                if (SincroSeguridadTipoMenuId.HasValue)
                {
                    data.TiposMenues = ObtenerTiposMenuesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOMENU));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadTipoMenuId.Value);
                }

                Int64? SincroSeguridadFuncionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_FUNCION);

                if (SincroSeguridadFuncionId.HasValue)
                {
                    data.Funciones = ObtenerFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_FUNCION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadFuncionId.Value);
                }

                Int64? SincroSeguridadRolFuncionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROLFUNCION);

                if (SincroSeguridadRolFuncionId.HasValue)
                {
                    data.RolesFunciones = ObtenerRolesFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROLFUNCION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadRolFuncionId.Value);
                }

                Int64? SincroSeguridadMenuId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MENU);

                if (SincroSeguridadMenuId.HasValue)
                {
                    data.Menues = ObtenerMenuesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MENU));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroSeguridadMenuId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            SeguridadUsuarioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Usuarios = ObtenerUsuariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIO));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.AplicacionesParametros = ObtenerAplicacionesParametrosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETRO));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.AplicacionesParametrosValores = ObtenerAplicacionesParametrosValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACIONPARAMETROVALOR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROLFUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RolesFunciones = ObtenerRolesFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROLFUNCION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOROL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosRoles = ObtenerUsuariosRolesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOROL));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosSectores = ObtenerUsuariosSectoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOSECTOR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ROL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Roles = ObtenerRolesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ROL));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MENU);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Menues = ObtenerMenuesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MENU));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_FUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Funciones = ObtenerFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_FUNCION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposFunciones = ObtenerTiposFuncionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOFUNCION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOMENU);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposMenues = ObtenerTiposMenuesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOMENU));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposAplicaciones = ObtenerTiposAplicacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOAPLICACION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_APLICACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Aplicaciones = ObtenerAplicacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_APLICACION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.IdentificadoresUsuarios = ObtenerIdentificadoresUsuariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_IDENTIFICADORUSUARIO));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposIdentificadores = ObtenerTiposIdentificadoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOIDENTIFICADOR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
