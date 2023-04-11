using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AplicacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_CONFIGURACION = "Aplicacion.Configuracion";
        private const string ENTIDAD_CONFIGURACIONEMPRESA = "Aplicacion.ConfiguracionEmpresa";
        private const string ENTIDAD_TIPODATO = "Aplicacion.ConfiguracionTipoDato";
        private const string ENTIDAD_VALIDACIONDATO = "Aplicacion.ConfiguracionValidacionDato";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerAplicacion")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerAplicacion([FromBody] AplicacionModel data)
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
                        Int64? SincroAplicacionTipoDatoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPODATO);

                        if (SincroAplicacionTipoDatoId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPODATO) ? data.SincroDates[ENTIDAD_TIPODATO] : fechaSincronizacionDefault;
                            data.TiposDatos = ObtenerTiposDatosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionTipoDatoId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroAplicacionValidacionDatoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_VALIDACIONDATO);

                        if (SincroAplicacionValidacionDatoId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_VALIDACIONDATO) ? data.SincroDates[ENTIDAD_VALIDACIONDATO] : fechaSincronizacionDefault;
                            data.ValidacionesDatos = ObtenerValidacionesDatosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionValidacionDatoId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroAplicacionConfiguracionId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_CONFIGURACION);

                        if (SincroAplicacionConfiguracionId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CONFIGURACION) ? data.SincroDates[ENTIDAD_CONFIGURACION] : fechaSincronizacionDefault;
                            data.Configuraciones = ObtenerConfiguracionesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionId.Value);
                        }

                        Int64? SincroAplicacionConfiguracionEmpresaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_CONFIGURACIONEMPRESA);

                        if (SincroAplicacionConfiguracionEmpresaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CONFIGURACIONEMPRESA) ? data.SincroDates[ENTIDAD_CONFIGURACIONEMPRESA] : fechaSincronizacionDefault;
                            data.ConfiguracionesEmpresas = ObtenerConfiguracionesEmpresasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionEmpresaId.Value);
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
        [Route("ObtenerTiposDatos")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTiposDatos()
        {
            AplicacionTipoDatoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPODATO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposDatos = ObtenerTiposDatosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPODATO));
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
        [Route("ObtenerValidacionesDatos")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerValidacionesDatos()
        {
            AplicacionValidacionDatoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_VALIDACIONDATO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ValidacionesDatos = ObtenerValidacionesDatosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_VALIDACIONDATO));
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
        [Route("ObtenerConfiguraciones")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerConfiguraciones()
        {
            AplicacionConfiguracionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Configuraciones = ObtenerConfiguracionesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACION));
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
        [Route("ObtenerConfiguracionesEmpresas")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerConfiguracionesEmpresas()
        {
            AplicacionConfiguracionEmpresaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ConfiguracionesEmpresas = ObtenerConfiguracionesEmpresasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA));
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
        private List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionTipoDato> ObtenerTiposDatosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionTipoDato> result = new();
            DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionTipoDato oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionTipoDato.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionTipoDato.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> ObtenerValidacionesDatosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> result = new();
            DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionValidacionDato oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ObtenerConfiguracionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> result = new();
            DepositaryWebApi.Business.Tables.Aplicacion.Configuracion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Aplicacion.Configuracion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Aplicacion.Configuracion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ObtenerConfiguracionesEmpresasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa> result = new();
            DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionEmpresa oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
