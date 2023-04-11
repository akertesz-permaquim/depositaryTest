using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuditoriaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_TIPOLOG = "Auditoria.TipoLog";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerAuditoria")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerAuditoria([FromBody] AuditoriaModel data)
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
                        try
                        {
                            //Iniciamos un registro de sincronizacion de la entidad.
                            Int64? SincroAuditoriaTipoLogId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOLOG);

                            if (SincroAuditoriaTipoLogId.HasValue)
                            {
                                var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOLOG) ? data.SincroDates[ENTIDAD_TIPOLOG] : fechaSincronizacionDefault;
                                data.TiposLog = ObtenerTiposLogBD(fechaDiferencial);
                                SynchronizationController.finalizarCabeceraSincronizacion(SincroAuditoriaTipoLogId.Value);
                            }

                        }
                        catch (Exception ex)
                        {
                            AuditController.Log(ex);
                            return BadRequest(ex.Message);
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
        [Route("ObtenerTiposLog")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposLog()
        {
            AuditoriaTipoLogModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOLOG);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposLog = ObtenerTiposLogBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOLOG));

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

        private List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> ObtenerTiposLogBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> result = new();
            DepositaryWebApi.Business.Tables.Auditoria.TipoLog oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Auditoria.TipoLog.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Auditoria.TipoLog.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
