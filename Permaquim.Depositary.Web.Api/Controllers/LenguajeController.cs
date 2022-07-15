using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LenguajeController : ControllerBase
    {
        [HttpGet]
        [Route("ObtenerLenguaje")]
        [Authorize]
        public async Task<IActionResult> ObtenerLenguaje()
        {
            LenguajeModel data = new();

            data.Lenguaje = ObtenerLenguajeCabecera();
            data.LenguajeItems = ObtenerLenguajeItems();


            return Ok(data);

        }
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> ObtenerLenguajeCabecera()
        {

            DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje entities = new();
            return entities.Items();


        }
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> ObtenerLenguajeItems()
        {

            DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem entities = new();
            return entities.Items();


        }
    }
}
