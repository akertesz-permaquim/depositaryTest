using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerAgendas")]
        [Authorize]
        public async Task<IActionResult> ObtenerAgendas()
        {
            TurnoAgendaTurnoDTO data = new();

            try
            {
                data.Agendas = ObtenerAgendasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEsquemas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemas()
        {
            TurnoEsquemaTurnoDTO data = new();

            try
            {
                data.Esquemas = ObtenerEsquemasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEsquemasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerEsquemasDetalles()
        {
            TurnoEsquemaDetalleTurnoDTO data = new();

            try
            {
                data.EsquemasDetalles = ObtenerEsquemasDetallesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> ObtenerAgendasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.AgendaTurno oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> ObtenerEsquemasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.EsquemaTurno oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> ObtenerEsquemasDetallesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> result = new();
            DepositaryWebApi.Business.Tables.Turno.EsquemaDetalleTurno oEntities = new();

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
