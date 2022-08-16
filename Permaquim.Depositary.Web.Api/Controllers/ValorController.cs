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

        [HttpGet]
        [Route("ObtenerValor")]
        [Authorize]
        public async Task<IActionResult> ObtenerValor()
        {
            ValorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroValorMonedaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MONEDA);

                if (SincroValorMonedaId.HasValue)
                {
                    data.Monedas = ObtenerMonedasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MONEDA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroValorMonedaId.Value);
                }

                Int64? SincroValorDenominacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DENOMINACION);

                if (SincroValorDenominacionId.HasValue)
                {
                    data.Denominaciones = ObtenerDenominacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DENOMINACION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroValorDenominacionId.Value);
                }

                Int64? SincroValorTipoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPO);

                if (SincroValorTipoId.HasValue)
                {
                    data.Tipos = ObtenerTiposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroValorTipoId.Value);
                }

                Int64? SincroValorRelacionMonedaTipoValorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR);

                if (SincroValorRelacionMonedaTipoValorId.HasValue)
                {
                    data.RelacionesMonedasTiposValores = ObtenerRelacionesMonedasTiposValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroValorRelacionMonedaTipoValorId.Value);
                }

                Int64? SincroValorOrigenValorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR);

                if (SincroValorOrigenValorId.HasValue)
                {
                    data.OrigenesValores = ObtenerOrigenesValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroValorOrigenValorId.Value);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerMonedas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMonedas()
        {
            ValorMonedaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MONEDA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Monedas = ObtenerMonedasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MONEDA));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DENOMINACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Denominaciones = ObtenerDenominacionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DENOMINACION));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Tipos = ObtenerTiposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPO));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                //Cerramos el registro de sincronizacion de la entidad.
                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RelacionesMonedasTiposValores = ObtenerRelacionesMonedasTiposValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDATIPOVALOR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.OrigenesValores = ObtenerOrigenesValoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ORIGENVALOR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);
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
