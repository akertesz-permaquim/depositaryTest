﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerUsuarios")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            SeguridadUsuarioDTO data = new();

            try
            {
                data.Usuarios = ObtenerUsuariosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerAplicacionesParametros")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacionesParametros()
        {
            SeguridadAplicacionParametroDTO data = new();

            try
            {
                data.AplicacionesParametros = ObtenerAplicacionesParametrosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerAplicacionesParametrosValores")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacionesParametrosValores()
        {
            SeguridadAplicacionParametroValorDTO data = new();

            try
            {
                data.AplicacionesParametrosValores = ObtenerAplicacionesParametrosValoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerRolesFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerRolesFunciones()
        {
            SeguridadRolFuncionDTO data = new();

            try
            {
                data.RolesFunciones = ObtenerRolesFuncionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerUsuariosRoles")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosRoles()
        {
            SeguridadUsuarioRolDTO data = new();

            try
            {
                data.UsuariosRoles = ObtenerUsuariosRolesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerUsuariosSectores")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosSectores()
        {
            SeguridadUsuarioSectorDTO data = new();

            try
            {
                data.UsuariosSectores = ObtenerUsuariosSectoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        [Authorize]
        public async Task<IActionResult> ObtenerRoles()
        {
            SeguridadRolDTO data = new();

            try
            {
                data.Roles = ObtenerRolesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerMenues")]
        [Authorize]
        public async Task<IActionResult> ObtenerMenues()
        {
            SeguridadMenuDTO data = new();

            try
            {
                data.Menues = ObtenerMenuesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerFunciones()
        {
            SeguridadFuncionDTO data = new();

            try
            {
                data.Funciones = ObtenerFuncionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposFunciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposFunciones()
        {
            SeguridadTipoFuncionDTO data = new();

            try
            {
                data.TiposFunciones = ObtenerTiposFuncionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposMenues")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposMenues()
        {
            SeguridadTipoMenuDTO data = new();

            try
            {
                data.TiposMenues = ObtenerTiposMenuesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposAplicaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposAplicaciones()
        {
            SeguridadTipoAplicacionDTO data = new();

            try
            {
                data.TiposAplicaciones = ObtenerTiposAplicacionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerAplicaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicaciones()
        {
            SeguridadAplicacionDTO data = new();

            try
            {
                data.Aplicaciones = ObtenerAplicacionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> ObtenerUsuariosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Usuario oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> ObtenerRolesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Rol oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> ObtenerRolesFuncionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.RolFuncion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> ObtenerTiposAplicacionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoAplicacion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> ObtenerTiposFuncionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoFuncion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> ObtenerTiposMenuesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoMenu oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> ObtenerUsuariosRolesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioRol oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> ObtenerUsuariosSectoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.UsuarioSector oEntities = new();

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

        private List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> ObtenerAplicacionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Aplicacion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> ObtenerAplicacionesParametrosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametro oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> ObtenerAplicacionesParametrosValoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.AplicacionParametroValor oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> ObtenerFuncionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Funcion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> ObtenerMenuesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.Menu oEntities = new();

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
