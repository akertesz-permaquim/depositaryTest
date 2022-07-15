using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        [HttpGet]
        [Route("ObtenerConfiguracion")]
        [Authorize]
        public async Task<IActionResult> ObtenerConfiguraciones()
        {
            ConfiguracionModel data = new();

                data.ConfiguracionAplicacion = ObtenerConfiguracionAplicacion();
                data.ConfiguracionDispositivo = ObtenerConfiguracionDepositario();


            return Ok(data);

        }
        private  List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ObtenerConfiguracionAplicacion()
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
