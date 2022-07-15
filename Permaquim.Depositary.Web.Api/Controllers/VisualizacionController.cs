using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisualizacionController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerPerfiles")]
        [Authorize]
        public async Task<IActionResult> ObtenerPerfiles()
        {
            VisualizacionPerfilModel data = new();

            try
            {
                data.Perfiles = ObtenerPerfilesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTipos")]
        [Authorize]
        public async Task<IActionResult> ObtenerTipos()
        {
            VisualizacionPerfilTipoModel data = new();

            try
            {
                data.Tipos = ObtenerTiposBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerPerfilesItems")]
        [Authorize]
        public async Task<IActionResult> ObtenerPerfilesItems()
        {
            VisualizacionPerfilItemModel data = new();

            try
            {
                data.PerfilesItems = ObtenerPerfilesItemsBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> ObtenerPerfilesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.Perfil oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> ObtenerTiposBD()
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilTipo oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> ObtenerPerfilesItemsBD()
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilItem oEntities = new();

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
