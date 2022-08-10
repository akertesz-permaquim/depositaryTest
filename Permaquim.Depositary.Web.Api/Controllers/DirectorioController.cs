using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerDirectorio")]
        [Authorize]
        public async Task<IActionResult> ObtenerDirectorio()
        {
            DirectorioModel data = new();

            try
            {
                data.Grupos = ObtenerGruposBD();
                data.Empresas = ObtenerEmpresasBD();
                data.Sucursales = ObtenerSucursalesBD();
                data.Sectores = ObtenerSectoresBD();
                data.TiposIdentificador = ObtenerTiposIdentificadoresBD();
                data.IdentificadoresUsuario = ObtenerIdentificadoresUsuariosBD();
                data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerGrupos")]
        [Authorize]
        public async Task<IActionResult> ObtenerGrupos()
        {
            DirectorioGrupoModel data = new();

            try
            {
                data.Grupos = ObtenerGruposBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEmpresas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEmpresas()
        {
            DirectorioEmpresaModel data = new();

            try
            {
                data.Empresas = ObtenerEmpresasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerSucursales()
        {
            DirectorioSucursalModel data = new();

            try
            {
                data.Sucursales = ObtenerSucursalesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerSectores")]
        [Authorize]
        public async Task<IActionResult> ObtenerSectores()
        {
            DirectorioSectorModel data = new();

            try
            {
                data.Sectores = ObtenerSectoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposIdentificadores")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposIdentificadores()
        {
            DirectorioTipoIdentificadorModel data = new();

            try
            {
                data.TiposIdentificador = ObtenerTiposIdentificadoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerRelacionesMonedasSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerRelacionesMonedasSucursales()
        {
            DirectorioRelacionMonedaSucursalModel data = new();

            try
            {
                data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerIdentificadoresUsuario")]
        [Authorize]
        public async Task<IActionResult> ObtenerIdentificadoresUsuario()
        {
            DirectorioIdentificadorUsuarioModel data = new();

            try
            {
                data.IdentificadoresUsuario = ObtenerIdentificadoresUsuariosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> ObtenerGruposBD()
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Grupo oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> ObtenerEmpresasBD()
        {
            List < DepositaryWebApi.Entities.Tables.Directorio.Empresa> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Empresa oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> ObtenerSucursalesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Sucursal oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Sector> ObtenerSectoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Sector> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Sector oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> ObtenerTiposIdentificadoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.TipoIdentificador oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> ObtenerIdentificadoresUsuariosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> result = new();
            DepositaryWebApi.Business.Tables.Seguridad.IdentificadorUsuario oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> ObtenerRelacionesMonedasSucursalesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> result = new();
            DepositaryWebApi.Business.Tables.Directorio.RelacionMonedaSucursal oEntities = new();

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
