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
        private readonly IConfiguration _configuration;

        public OperacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_TIPOTRANSACCION = "Operacion.TipoTransaccion";
        private const string ENTIDAD_TIPOEVENTO = "Operacion.TipoEvento";
        private const string ENTIDAD_TIPOCONTENEDOR = "Operacion.TipoContenedor";

        public enum OperationTypeEnum
        {
            None = 0,
            BillDeposit = 1,
            CoinDeposit = 2,
            EnvelopeDeposit = 3,
            ValueExtraction = 4
        }

        #region PostEndpoints

        [HttpPost]
        [Route("ObtenerOperacion")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerOperacion([FromBody] OperacionModel data)
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
                        Int64? SincroOperacionTipoEventoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOEVENTO);

                        if (SincroOperacionTipoEventoId.HasValue)
                        {
                            data.TiposEventos = ObtenerTiposEventosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO));
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroOperacionTipoEventoId.Value);
                        }

                        Int64? SincroOperacionTipoContenedorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOCONTENEDOR);

                        if (SincroOperacionTipoContenedorId.HasValue)
                        {
                            data.TiposContenedores = ObtenerTiposContenedoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR));
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroOperacionTipoContenedorId.Value);
                        }

                        Int64? SincroOperacionTipoTransaccionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOTRANSACCION);

                        if (SincroOperacionTipoTransaccionId.HasValue)
                        {
                            data.TiposTransacciones = ObtenerTiposTransaccionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION));
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroOperacionTipoTransaccionId.Value);
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
        [Route("ObtenerTiposTransacciones")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposTransacciones()
        {
            OperacionTipoTransaccionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposTransacciones = ObtenerTiposTransaccionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposContenedores")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposContenedores()
        {
            OperacionTipoContenedorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposContenedores = ObtenerTiposContenedoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

                SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerTiposEventos")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposEventos()
        {
            OperacionTipoEventoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposEventos = ObtenerTiposEventosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO));
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                    return BadRequest(ex.Message);
                }

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

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> ObtenerTiposTransaccionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> ObtenerTiposContenedoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoContenedor oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoContenedor.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoContenedor.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> ObtenerTiposEventosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoEvento oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoEvento.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoEvento.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
