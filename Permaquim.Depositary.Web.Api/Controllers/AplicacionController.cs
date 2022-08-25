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

        #region Endpoints

        [HttpPost]
        [Route("ObtenerAplicacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacion([FromBody] AplicacionModel data)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaSincronizacionDefault = new(1900, 1, 1);

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroAplicacionConfiguracionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACION);

                if (SincroAplicacionConfiguracionId.HasValue)
                {
                    var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CONFIGURACION) ? data.SincroDates[ENTIDAD_CONFIGURACION] : fechaSincronizacionDefault;
                    data.Configuraciones = ObtenerConfiguracionesBD(fechaDiferencial);
                    SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionId.Value);
                }

                Int64? SincroAplicacionConfiguracionEmpresaId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA);

                if (SincroAplicacionConfiguracionEmpresaId.HasValue)
                {
                    var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CONFIGURACIONEMPRESA) ? data.SincroDates[ENTIDAD_CONFIGURACIONEMPRESA] : fechaSincronizacionDefault;
                    data.ConfiguracionesEmpresas = ObtenerConfiguracionesEmpresasBD(fechaDiferencial);
                    SynchronizationController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionEmpresaId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerConfiguraciones")]
        [Authorize]
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
