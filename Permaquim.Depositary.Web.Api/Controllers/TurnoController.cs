﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("ObtenerTurno")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerTurno([FromBody] TurnoModel data)
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
                        Int64? SincroGeografiaPaisId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_AGENDATURNO);

                        if (SincroGeografiaPaisId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_AGENDATURNO) ? data.SincroDates[ENTIDAD_AGENDATURNO] : fechaSincronizacionDefault;
                            data.Agendas = ObtenerAgendasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaPaisId.Value);
                        }

                        Int64? SincroGeografiaProvinciaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ESQUEMATURNO);

                        if (SincroGeografiaProvinciaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ESQUEMATURNO) ? data.SincroDates[ENTIDAD_ESQUEMATURNO] : fechaSincronizacionDefault;
                            data.Esquemas = ObtenerEsquemasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaProvinciaId.Value);
                        }

                        Int64? SincroGeografiaCiudadId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ESQUEMADETALLETURNO);

                        if (SincroGeografiaCiudadId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ESQUEMADETALLETURNO) ? data.SincroDates[ENTIDAD_ESQUEMADETALLETURNO] : fechaSincronizacionDefault;
                            data.EsquemasDetalles = ObtenerEsquemasDetallesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaCiudadId.Value);
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
        [Route("ObtenerAgendas")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerAgendas()
        {
            TurnoAgendaTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_AGENDATURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Agendas = ObtenerAgendasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_AGENDATURNO));
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
        [Route("ObtenerEsquemas")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerEsquemas()
        {
            TurnoEsquemaTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Esquemas = ObtenerEsquemasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMATURNO));
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
        [Route("ObtenerEsquemasDetalles")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerEsquemasDetalles()
        {
            TurnoEsquemaDetalleTurnoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.EsquemasDetalles = ObtenerEsquemasDetallesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ESQUEMADETALLETURNO));
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
