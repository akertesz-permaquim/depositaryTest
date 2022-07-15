using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerEstilo")]
        [Authorize]
        public async Task<IActionResult> ObtenerEstilo()
        {
            EstiloModel data = new();

            try
            {
                data.Esquema = ObtenerEsquemasBD();
                data.EsquemaDetalle = ObtenerEsquemasDetallesBD();
                data.TipoEsquemaDetalle = ObtenerTiposEsquemasDetallesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);

        }

        [HttpGet]
        [Route("ObtenerEsquemas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemas()
        {
            EstiloEsquemaModel data = new();

            try
            {
                data.Esquemas = ObtenerEsquemasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemasDetalles()
        {
            EstiloEsquemaDetalleModel data = new();

            try
            {
                data.EsquemasDetalles = ObtenerEsquemasDetallesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposEsquemasDetalles()
        {
            EstiloTipoEsquemaDetalleModel data = new();

            try
            {
                data.TiposEsquemasDetalles = ObtenerTiposEsquemasDetallesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> ObtenerEsquemasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> result = new();
            DepositaryWebApi.Business.Tables.Estilo.Esquema oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEsquemasDetallesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> result = new();
            DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> ObtenerTiposEsquemasDetallesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> result = new();
            DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle oEntities = new();

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
