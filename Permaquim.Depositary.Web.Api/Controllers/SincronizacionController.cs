using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SincronizacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SincronizacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_ENTIDAD = "Sincronizacion.Entidad";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerSincronizacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerSincronizacion([FromBody] SincronizacionModel data)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaSincronizacionDefault = new(1900, 1, 1);

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroSincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ENTIDAD);

                if (SincroSincronizacionEntidadId.HasValue)
                {
                    var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ENTIDAD) ? data.SincroDates[ENTIDAD_ENTIDAD] : fechaSincronizacionDefault;
                    data.Entidades = ObtenerEntidadesBD(fechaDiferencial);
                    SynchronizationController.finalizarCabeceraSincronizacion(SincroSincronizacionEntidadId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEntidades")]
        [Authorize]
        public async Task<IActionResult> ObtenerEntidades()
        {
            SincronizacionEntidadModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ENTIDAD);

            if (SincronizacionId.HasValue)
            {

                try
                {
                    data.Entidades = ObtenerEntidadesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ENTIDAD));
                }
                catch (Exception ex)
                {
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
        private List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> ObtenerEntidadesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> result = new();
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
