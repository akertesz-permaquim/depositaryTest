using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiometriaController : ControllerBase
    {

        #region Endpoints
        [HttpGet]
        [Route("ObtenerHuellasDactilares")]
        [Authorize]
        public async Task<IActionResult> ObtenerHuellasDactilares()
        {
            BiometriaHuellaDactilarModel data = new();

            try
            {
                data.HuellasDactilares = ObtenerHuellasDactilaresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> ObtenerHuellasDactilaresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> result = new();
            DepositaryWebApi.Business.Tables.Biometria.HuellaDactilar oEntities = new();

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
