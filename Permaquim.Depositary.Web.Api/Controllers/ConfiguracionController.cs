using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfiguracionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("ObtenerConfiguracion")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerConfiguraciones()
        {
            string DepositaryCode = JwtController.GetDepositaryCode(HttpContext, _configuration);

            ConfiguracionModel data = new();

            data.ConfiguracionAplicacion = ObtenerConfiguracionAplicacion();
            data.ConfiguracionDepositario = ObtenerConfiguracionDepositario();

            return Ok(data);
        }
        private List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ObtenerConfiguracionAplicacion()
        {
            DepositaryWebApi.Business.Tables.Aplicacion.Configuracion entities = new();
            return entities.Items();

        }
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ObtenerConfiguracionDepositario()
        {
            DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario entities = new();
            return entities.Items();

        }
    }
}
