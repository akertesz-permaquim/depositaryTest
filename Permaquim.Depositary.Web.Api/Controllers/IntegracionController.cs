using DepositaryWebApi.Business.Views.Integracion;
using DepositaryWebApi.Entities.Tables.Operacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegracionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private const string ENTIDAD_TIPOLOG = "Integracion";
        public IntegracionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Endpoints

        [HttpGet]
        [Route("Transacciones")]
        [Authorize]
        public async Task<IntegracionTransaccionModel> Transacciones()
        {

            IntegracionTransaccionModel returnValue = new();

            OperacionTransaccion TransaccionEntities = new();
            TransaccionEntities.Items();
            foreach (var item in TransaccionEntities.Result)
            {
                returnValue.Transacciones.Add(item);

            }

            OperacionTransaccionDetalle TransaccionDetalleEntities = new();
            TransaccionDetalleEntities.Items();
            foreach (var item in TransaccionDetalleEntities.Result)
            {
                returnValue.TransaccionesDetalles.Add(item);

            }

            OperacionTransaccionSobre TransaccionSobreEntities = new();
            TransaccionSobreEntities.Items();
            foreach (var item in TransaccionSobreEntities.Result)
            {
                returnValue.TransaccionesSobres.Add(item);

            }


            OperacionTransaccionSobreDetalle TransaccionSobreDetalleEntities = new();
            TransaccionSobreDetalleEntities.Items();
            foreach (var item in TransaccionSobreDetalleEntities.Result)
            {
                returnValue.TransaccionesSobresDetalles.Add(item);

            }


            return returnValue;
        }

  
        #endregion

    }
}