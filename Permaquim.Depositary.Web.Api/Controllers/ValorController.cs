using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValorController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerDenominaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerDenominaciones()
        {
            ValorDenominacionModel data = new();

            try
            {
                data.Denominaciones = ObtenerDenominacionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerMonedas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMonedas()
        {
            ValorMonedaModel data = new();

            try
            {
                data.Monedas = ObtenerMonedasBD();
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
            ValorTipoModel data = new();

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
        [Route("ObtenerRelacionesMonedasTiposValores")]
        [Authorize]
        public async Task<IActionResult> ObtenerRelacionesMonedasTiposValores()
        {
            ValorRelacionMonedaTipoValorModel data = new();

            try
            {
                data.RelacionesMonedasTiposValores = ObtenerRelacionesMonedasTiposValoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> ObtenerDenominacionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> result = new();
            DepositaryWebApi.Business.Tables.Valor.Denominacion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Valor.Moneda> ObtenerMonedasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Moneda> result = new();
            DepositaryWebApi.Business.Tables.Valor.Moneda oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Valor.Tipo> ObtenerTiposBD()
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Tipo> result = new();
            DepositaryWebApi.Business.Tables.Valor.Tipo oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> ObtenerRelacionesMonedasTiposValoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> result = new();
            DepositaryWebApi.Business.Tables.Valor.RelacionMonedaTipoValor oEntities = new();

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
