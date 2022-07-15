using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionalizacionController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerRegionalizacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerRegionalizacion()
        {
            RegionalizacionModel data = new();

            try
            {
                data.Lenguajes = ObtenerLenguajesBD();
                data.LenguajeItems = ObtenerLenguajesItemsBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerLenguajes")]
        [Authorize]
        public async Task<IActionResult> ObtenerLenguajes()
        {
            RegionalizacionLenguajeModel data = new();

            try
            {
                data.Lenguajes = ObtenerLenguajesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerLenguajesItems")]
        [Authorize]
        public async Task<IActionResult> ObtenerLenguajesItems()
        {
            RegionalizacionLenguajeItemModel data = new();

            try
            {
                data.LenguajesItems = ObtenerLenguajesItemsBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> ObtenerLenguajesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> result = new();
            DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> ObtenerLenguajesItemsBD()
        {
            List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> result = new();
            DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem oEntities = new();

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
