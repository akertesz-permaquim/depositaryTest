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
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("IniciarEjecucion")]
        [Authorize]
        public async Task<IActionResult> IniciarEjecucion([FromBody] SincronizacionEjecucionModel data)
        {
            try
            {
                Int64 depositarioId;

                if (data.Ejecucion.EsPrimeraSincronizacion)
                    depositarioId = Int64.Parse(JwtController.GetDepositaryCode(HttpContext));
                else
                    depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

                DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion nuevaEjecucion = new();

                //Generamos un registro de ejecucion para sincronizacion
                DepositaryWebApi.Business.Tables.Sincronizacion.Ejecucion bTablesEjecucion = new();
                nuevaEjecucion = bTablesEjecucion.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion()
                {
                    DepositarioId = depositarioId,
                    EsPrimeraSincronizacion = data.Ejecucion.EsPrimeraSincronizacion,
                    FechaFin = null,
                    FechaInicio = DateTime.Now,
                    Finalizada = false
                });

                DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera nuevaCabecera = new();

                //Obtenemos el Id de la entidad para la ejecucion de sincronizacion.
                Int64? EntidadId = SynchronizationController.ObtenerIdEntidad("Sincronizacion.Ejecucion");

                if (EntidadId.HasValue)
                {
                    //Generamos la cabecera correspondiente a la ejecucion
                    DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new();

                    nuevaCabecera = bTablesEntidadCabecera.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera()
                    {
                        EjecucionId = nuevaEjecucion.Id,
                        EntidadId = EntidadId.Value,
                        Fechainicio = DateTime.Now,
                        Valor = "Sincronizacion.Ejecucion",
                        Fechafin = null
                    });

                    DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle nuevoDetalle = new();

                    //Generamos el detalle de la sincronizacion para tener mapeado el ID.
                    DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle bTablesEntidadDetalle = new();
                    nuevoDetalle = bTablesEntidadDetalle.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle()
                    {
                        DestinoId = nuevaEjecucion.Id,
                        EntidadCabeceraId = nuevaCabecera.Id,
                        FechaCreacion = DateTime.Now,
                        OrigenId = data.Ejecucion.Id
                    });

                    //Cerramos la cabecera indicando la fecha de fin.
                    nuevaCabecera.Fechafin = DateTime.Now;
                    bTablesEntidadCabecera.Update(nuevaCabecera);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("FinalizarEjecucion")]
        [Authorize]
        public async Task<IActionResult> FinalizarEjecucion([FromBody] SincronizacionEjecucionModel data)
        {
            try
            {
                Int64 depositarioId;

                if (data.Ejecucion.EsPrimeraSincronizacion)
                    depositarioId = Int64.Parse(JwtController.GetDepositaryCode(HttpContext));
                else
                    depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

                Int64? EjecucionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion("Sincronizacion.Ejecucion", depositarioId, data.Ejecucion.Id);

                if (EjecucionId.HasValue)
                {
                    DepositaryWebApi.Business.Tables.Sincronizacion.Ejecucion bTablesEjecucion = new();
                    bTablesEjecucion.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, EjecucionId.Value);
                    bTablesEjecucion.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, depositarioId);
                    bTablesEjecucion.Items();

                    if (bTablesEjecucion.Result.Count > 0)
                    {
                        var ejecucion = bTablesEjecucion.Result.FirstOrDefault();
                        ejecucion.FechaFin = DateTime.Now;
                        ejecucion.Finalizada = data.Ejecucion.Finalizada;

                        bTablesEjecucion.Update(ejecucion);

                        return Ok();
                    }

                }

                return BadRequest(Global.Constants.ERROR_SYNCHRONIZATION_ID_NOT_FOUND);
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }
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
