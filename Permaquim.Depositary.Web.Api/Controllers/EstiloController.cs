using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EstiloController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_ESQUEMA = "Estilo.Esquema";
        private const string ENTIDAD_ESQUEMADETALLE = "Estilo.EsquemaDetalle";
        private const string ENTIDAD_TIPOESQUEMADETALLE = "Estilo.TipoEsquemaDetalle";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerEstilo")]
        [Authorize]
        public async Task<IActionResult> ObtenerEstilo([FromBody] EstiloModel data)
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
                        Int64? SincroEstiloEsquemaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ESQUEMA);

                        if (SincroEstiloEsquemaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ESQUEMA) ? data.SincroDates[ENTIDAD_ESQUEMA] : fechaSincronizacionDefault;
                            data.Esquema = ObtenerEsquemasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroEstiloEsquemaId.Value);
                        }

                        Int64? SincroEstiloEsquemaDetalleId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ESQUEMADETALLE);

                        if (SincroEstiloEsquemaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ESQUEMADETALLE) ? data.SincroDates[ENTIDAD_ESQUEMADETALLE] : fechaSincronizacionDefault;
                            data.EsquemaDetalle = ObtenerEsquemasDetallesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroEstiloEsquemaId.Value);
                        }

                        Int64? SincroEstiloTipoEsquemaDetalleId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOESQUEMADETALLE);

                        if (SincroEstiloTipoEsquemaDetalleId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOESQUEMADETALLE) ? data.SincroDates[ENTIDAD_TIPOESQUEMADETALLE] : fechaSincronizacionDefault;
                            data.TipoEsquemaDetalle = ObtenerTiposEsquemasDetallesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroEstiloTipoEsquemaDetalleId.Value);
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
        [Route("ObtenerEsquemas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemas()
        {
            EstiloEsquemaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMA);

            if (SincronizacionId.HasValue)
            {

                try
                {
                    data.Esquemas = ObtenerEsquemasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMA));
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
        [Route("ObtenerEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemasDetalles()
        {
            EstiloEsquemaDetalleModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLE);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.EsquemasDetalles = ObtenerEsquemasDetallesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLE));
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
        [Route("ObtenerTiposEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposEsquemasDetalles()
        {
            EstiloTipoEsquemaDetalleModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOESQUEMADETALLE);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposEsquemasDetalles = ObtenerTiposEsquemasDetallesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOESQUEMADETALLE));
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
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> ObtenerEsquemasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> result = new();
            DepositaryWebApi.Business.Tables.Estilo.Esquema oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Estilo.Esquema.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Estilo.Esquema.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> ObtenerEsquemasDetallesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> result = new();
            DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> ObtenerTiposEsquemasDetallesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> result = new();
            DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Estilo.TipoEsquemaDetalle.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
