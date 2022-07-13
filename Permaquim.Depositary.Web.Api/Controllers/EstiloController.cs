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
        [HttpGet]
        [Route("ObtenerEstilo")]
        [Authorize]
        public async Task<IActionResult> ObtenerEstilo()
        {
            EstiloDTO data = new();

            data.Esquema = ObtenerEstiloCabecera();
            data.EsquemaDetalle = ObtenerEstiloEsquemaDetalle();
            data.TipoEsquemaDetalle = ObtenerEstiloTipoEsquemaDetalle();


            return Ok(data);

        }
        private List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> ObtenerEstiloCabecera()
        {

            DepositaryWebApi.Business.Tables.Estilo.Esquema entities = new();
            return entities.Items();
        }
        private List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEstiloEsquemaDetalle()
        {

            DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle entities = new();
            return entities.Items();
        }
        private List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> ObtenerEstiloTipoEsquemaDetalle()
        {

            DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle entities = new();
            return entities.Items();
        }
    }
}
