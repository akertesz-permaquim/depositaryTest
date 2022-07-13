using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {

        public enum OperationTypeEnum
        {
            None = 0,
            BillDeposit = 1,
            CoinDeposit = 2,
            EnvelopeDeposit = 3,
            ValueExtraction = 4
        }
        [HttpPost]
        [Route("SincronizarTransacciones")]
        [Authorize]
        public async Task<IActionResult> Transacciones([FromBody] OperacionDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Transaccion transaccionEntity = new();

            try
            {
                long depositarioId = ObtenerIdDepositario(model.CodigoExternoDepositario);

                transaccionEntity.BeginTransaction();

                foreach (var item in model.Transaccion)
                {
                    item.DepositarioId = depositarioId;
                    transaccionEntity.Add(item);
                }

                DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle transaccionDetalleEntity = new(transaccionEntity);
                foreach (var item in model.TransaccionDetalle)
                {
                    transaccionDetalleEntity.Add(item);
                }

                DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre transaccionSobreEntity = new(transaccionEntity);
                foreach (var item in model.TransaccionSobre)
                {
                    transaccionSobreEntity.Add(item);
                }

                DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalleEntity = new(transaccionEntity);
                foreach (var item in model.TransaccionSobreDetalle)
                {
                    transaccionSobreDetalleEntity.Add(item);
                }

                transaccionEntity.EndTransaction(true);

                return Ok();
            }
            catch (Exception)
            {
                transaccionEntity.EndTransaction(false);
                return BadRequest();
            }

        }

        private long ObtenerIdDepositario(string codigoExterno)
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario entities = new();
            entities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, codigoExterno);
            entities.Items();
            return entities.Result.FirstOrDefault().Id;
        }
    }
}
