using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        [HttpPost]
        [Route("Transactions")]

        public async Task<IActionResult> Transactions([FromBody] RequestModel model)
        {



            return Ok();

        }
    }
}
