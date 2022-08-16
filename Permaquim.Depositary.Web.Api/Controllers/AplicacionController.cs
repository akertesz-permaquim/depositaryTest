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

        [HttpGet]
        [Route("ObtenerAplicacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerAplicacion()
        {
            AplicacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroAplicacionConfiguracionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACION);

                if (SincroAplicacionConfiguracionId.HasValue)
                {
                    data.Configuraciones = ObtenerConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionId.Value);
                }

                Int64? SincroAplicacionConfiguracionEmpresaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA);

                if (SincroAplicacionConfiguracionEmpresaId.HasValue)
                {
                    data.ConfiguracionesEmpresas = ObtenerConfiguracionesEmpresasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroAplicacionConfiguracionEmpresaId.Value);
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
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Configuraciones = ObtenerConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACION));
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
        [Route("ObtenerConfiguracionesEmpresas")]
        [Authorize]
        public async Task<IActionResult> ObtenerConfiguracionesEmpresas()
        {
            AplicacionConfiguracionEmpresaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ConfiguracionesEmpresas = ObtenerConfiguracionesEmpresasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONEMPRESA));
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
