using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionalizacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegionalizacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_LENGUAJE = "Regionalizacion.Lenguaje";
        private const string ENTIDAD_LENGUAJEITEM = "Regionalizacion.LenguajeItem";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerRegionalizacion")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerRegionalizacion([FromBody] RegionalizacionModel data)
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
                        Int64? SincroRegionalizacionLenguajeId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_LENGUAJE);

                        if (SincroRegionalizacionLenguajeId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_LENGUAJE) ? data.SincroDates[ENTIDAD_LENGUAJE] : fechaSincronizacionDefault;
                            data.Lenguajes = ObtenerLenguajesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroRegionalizacionLenguajeId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroRegionalizacionLenguajeItemId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_LENGUAJEITEM);

                        if (SincroRegionalizacionLenguajeItemId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_LENGUAJEITEM) ? data.SincroDates[ENTIDAD_LENGUAJEITEM] : fechaSincronizacionDefault;
                            data.LenguajeItems = ObtenerLenguajesItemsBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroRegionalizacionLenguajeItemId.Value);
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
        [Route("ObtenerLenguajes")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerLenguajes()
        {
            RegionalizacionLenguajeModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_LENGUAJE);

            if (SincronizacionId.HasValue)
            {

                try
                {
                    data.Lenguajes = ObtenerLenguajesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_LENGUAJE));
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
        [Route("ObtenerLenguajesItems")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerLenguajesItems()
        {
            RegionalizacionLenguajeItemModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_LENGUAJEITEM);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.LenguajesItems = ObtenerLenguajesItemsBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_LENGUAJEITEM));
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
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> ObtenerLenguajesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> result = new();
            DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Regionalizacion.Lenguaje.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> ObtenerLenguajesItemsBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> result = new();
            DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
