using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        [HttpGet]
        [Route("GetDeviceConfiguration")]
        public async Task<IActionResult> GetDeviceConfiguration([FromHeader] RequestModel model)
        {
            DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario configuration = new();

            configuration.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, GetDeviceId(model.Poronga));


            return Ok(configuration.Items());

        }

        private long GetDeviceId(string deviceNumber)
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario usuarioRol = new();

            usuarioRol.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, deviceNumber);

            return usuarioRol.Items().FirstOrDefault().Id;
        }
    }
}
