using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_MONEDA = "Valor.Moneda";
        private const string ENTIDAD_DENOMINACION = "Valor.Denominacion";
        private const string ENTIDAD_TIPO = "Valor.Tipo";
        private const string ENTIDAD_RELACIONMONEDATIPOVALOR = "Valor.RelacionMonedaTipoValor";
        private const string ENTIDAD_ORIGENVALOR = "Valor.OrigenValor";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerValor")]
        [Authorize]
        public async Task<IActionResult> ObtenerValor([FromBody] ValorModel data)
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
                        Int64? SincroValorMonedaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_MONEDA);

                        if (SincroValorMonedaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_MONEDA) ? data.SincroDates[ENTIDAD_MONEDA] : fechaSincronizacionDefault;
                            data.Monedas = ObtenerMonedasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroValorMonedaId.Value);
                        }

                        Int64? SincroValorDenominacionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_DENOMINACION);

                        if (SincroValorDenominacionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_DENOMINACION) ? data.SincroDates[ENTIDAD_DENOMINACION] : fechaSincronizacionDefault;
                            data.Denominaciones = ObtenerDenominacionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroValorDenominacionId.Value);
                        }

                        Int64? SincroValorTipoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPO);

                        if (SincroValorTipoId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPO) ? data.SincroDates[ENTIDAD_TIPO] : fechaSincronizacionDefault;
                            data.Tipos = ObtenerTiposBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroValorTipoId.Value);
                        }

                        Int64? SincroValorRelacionMonedaTipoValorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_RELACIONMONEDATIPOVALOR);

                        if (SincroValorRelacionMonedaTipoValorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_RELACIONMONEDATIPOVALOR) ? data.SincroDates[ENTIDAD_RELACIONMONEDATIPOVALOR] : fechaSincronizacionDefault;
                            data.RelacionesMonedasTiposValores = ObtenerRelacionesMonedasTiposValoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroValorRelacionMonedaTipoValorId.Value);
                        }

                        Int64? SincroValorOrigenValorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ORIGENVALOR);

                        if (SincroValorOrigenValorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ORIGENVALOR) ? data.SincroDates[ENTIDAD_ORIGENVALOR] : fechaSincronizacionDefault;
                            data.OrigenesValores = ObtenerOrigenesValoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroValorOrigenValorId.Value);
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
        [Route("ObtenerMonedas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMonedas()
        {
            ValorMonedaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MONEDA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Monedas = ObtenerMonedasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MONEDA));
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
        [Route("ObtenerDenominaciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerDenominaciones()
        {
            ValorDenominacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DENOMINACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Denominaciones = ObtenerDenominacionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DENOMINACION));
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
        [Route("ObtenerTipos")]
        [Authorize]
        public async Task<IActionResult> ObtenerTipos()
        {
            ValorTipoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Tipos = ObtenerTiposBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPO));
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
        [Route("ObtenerRelacionesMonedasTiposValores")]
        [Authorize]
        public async Task<IActionResult> ObtenerRelacionesMonedasTiposValores()
        {
            ValorRelacionMonedaTipoValorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RelacionesMonedasTiposValores = ObtenerRelacionesMonedasTiposValoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR));
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
        [Route("ObtenerOrigenes")]
        [Authorize]
        public async Task<IActionResult> ObtenerOrigenes()
        {
            ValorOrigenValorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.OrigenesValores = ObtenerOrigenesValoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR));
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
        private List<DepositaryWebApi.Entities.Tables.Valor.Moneda> ObtenerMonedasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Moneda> result = new();
            DepositaryWebApi.Business.Tables.Valor.Moneda oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Valor.Moneda.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Valor.Moneda.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> ObtenerDenominacionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> result = new();
            DepositaryWebApi.Business.Tables.Valor.Denominacion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Valor.Denominacion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Valor.Denominacion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Valor.Tipo> ObtenerTiposBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Valor.Tipo> result = new();
            DepositaryWebApi.Business.Tables.Valor.Tipo oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Valor.Tipo.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Valor.Tipo.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> ObtenerRelacionesMonedasTiposValoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> result = new();
            DepositaryWebApi.Business.Tables.Valor.RelacionMonedaTipoValor oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Valor.RelacionMonedaTipoValor.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Valor.RelacionMonedaTipoValor.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> ObtenerOrigenesValoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> result = new();
            DepositaryWebApi.Business.Tables.Valor.OrigenValor oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Valor.OrigenValor.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Valor.OrigenValor.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
