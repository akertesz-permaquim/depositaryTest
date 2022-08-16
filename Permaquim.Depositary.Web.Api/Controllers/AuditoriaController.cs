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

        [HttpGet]
        [Route("ObtenerTiposLog")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposLog()
        {
            AuditoriaTipoLogModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOLOG);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposLog = ObtenerTiposLogBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOLOG));

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
