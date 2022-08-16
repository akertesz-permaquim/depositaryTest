using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TurnoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_AGENDATURNO = "Turno.AgendaTurno";
        private const string ENTIDAD_ESQUEMADETALLETURNO = "Turno.EsquemaDetalleTurno";
        private const string ENTIDAD_ESQUEMATURNO = "Turno.EsquemaTurno";

        #region Endpoints

        [HttpGet]
        [Route("ObtenerTurno")]
        [Authorize]
        public async Task<IActionResult> ObtenerTurno()
        {
            TurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroGeografiaPaisId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_AGENDATURNO);

                if (SincroGeografiaPaisId.HasValue)
                {
                    data.Agendas = ObtenerAgendasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_AGENDATURNO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaPaisId.Value);
                }

                Int64? SincroGeografiaProvinciaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO);

                if (SincroGeografiaProvinciaId.HasValue)
                {
                    data.Esquemas = ObtenerEsquemasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaProvinciaId.Value);
                }

                Int64? SincroGeografiaCiudadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO);

                if (SincroGeografiaCiudadId.HasValue)
                {
                    data.EsquemasDetalles = ObtenerEsquemasDetallesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaCiudadId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerAgendas")]
        [Authorize]
        public async Task<IActionResult> ObtenerAgendas()
        {
            TurnoAgendaTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_AGENDATURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Agendas = ObtenerAgendasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_AGENDATURNO));
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
        [Route("ObtenerEsquemas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemas()
        {
            TurnoEsquemaTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Esquemas = ObtenerEsquemasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO));
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
        [Route("ObtenerEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemasDetalles()
        {
            TurnoEsquemaDetalleTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.EsquemasDetalles = ObtenerEsquemasDetallesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO));
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
        private List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> ObtenerAgendasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.AgendaTurno oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Turno.AgendaTurno.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Turno.AgendaTurno.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> ObtenerEsquemasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.EsquemaTurno oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Turno.EsquemaTurno.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Turno.EsquemaTurno.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> ObtenerEsquemasDetallesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.EsquemaDetalleTurno oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Turno.EsquemaDetalleTurno.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Turno.EsquemaDetalleTurno.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
