using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ImpresionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_TIPOTICKET = "Impresion.TipoTicket";
        private const string ENTIDAD_TICKET = "Impresion.Ticket";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerImpresion")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerImpresion([FromBody] ImpresionModel data)
        {
            try
            {
                Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

                if (data.SynchronizationExecutionId.HasValue)
                {

                    //Por defecto se indica una fecha minima para no usar nulos
                    DateTime fechaSincronizacionDefault = new(1900, 1, 1);

                    Int64? EjecucionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion("Sincronizacion.Ejecucion", depositarioId, data.SynchronizationExecutionId.Value);

                    if (EjecucionId.HasValue)
                    {

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroImpresionTipoTicketId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOTICKET);

                        if (SincroImpresionTipoTicketId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOTICKET) ? data.SincroDates[ENTIDAD_TIPOTICKET] : fechaSincronizacionDefault;
                            data.TiposTickets = ObtenerTiposTicketsBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroImpresionTipoTicketId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroImpresionTicketId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TICKET);

                        if (SincroImpresionTicketId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TICKET) ? data.SincroDates[ENTIDAD_TICKET] : fechaSincronizacionDefault;
                            data.Tickets = ObtenerTicketsBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroImpresionTicketId.Value);
                        }
                        return Ok(data);
                    }
                    else
                    {
                        AuditController.Log("Depositario: " + depositarioId.ToString() + " " + Global.Constants.ERROR_NO_SYNCHRONIZATION_ROW_GENERATED);
                        return BadRequest(Global.Constants.ERROR_NO_SYNCHRONIZATION_ROW_GENERATED);
                    }
                }
                else
                {
                    AuditController.Log("Depositario: " + depositarioId.ToString() + " " + Global.Constants.ERROR_NO_SYNCHRONIZATION_ID_SENT);
                    return BadRequest(Global.Constants.ERROR_NO_SYNCHRONIZATION_ID_SENT);
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerTickets")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTickets()
        {
            ImpresionTicketModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TICKET);

            if (SincronizacionId.HasValue)
            {

                try
                {
                    data.Tickets = ObtenerTicketsBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TICKET));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposTickets")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposTickets()
        {
            ImpresionTipoTicketModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOTICKET);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposTickets = ObtenerTiposTicketsBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOTICKET));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Impresion.TipoTicket> ObtenerTiposTicketsBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Impresion.TipoTicket> result = new();
            DepositaryWebApi.Business.Tables.Impresion.TipoTicket oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Impresion.TipoTicket.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Impresion.TipoTicket.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Impresion.Ticket> ObtenerTicketsBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Impresion.Ticket> result = new();
            DepositaryWebApi.Business.Tables.Impresion.Ticket oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Impresion.Ticket.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Impresion.Ticket.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
