using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeografiaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GeografiaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_PAIS = "Geografia.Pais";
        private const string ENTIDAD_PROVINCIA = "Geografia.Provincia";
        private const string ENTIDAD_CIUDAD = "Geografia.Ciudad";
        private const string ENTIDAD_CODIGOPOSTAL = "Geografia.CodigoPostal";
        private const string ENTIDAD_ZONA = "Geografia.Zona";

        #region Endpoints
        [HttpPost]
        [Route("ObtenerGeografia")]
        [Authorize]
        public async Task<IActionResult> ObtenerGeografia([FromBody] GeografiaModel data)
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
                        Int64? SincroGeografiaPaisId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_PAIS);

                        if (SincroGeografiaPaisId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_PAIS) ? data.SincroDates[ENTIDAD_PAIS] : fechaSincronizacionDefault;
                            data.Paises = ObtenerPaisesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaPaisId.Value);
                        }

                        Int64? SincroGeografiaProvinciaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_PROVINCIA);

                        if (SincroGeografiaProvinciaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_PROVINCIA) ? data.SincroDates[ENTIDAD_PROVINCIA] : fechaSincronizacionDefault;
                            data.Provincias = ObtenerProvinciasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaProvinciaId.Value);
                        }

                        Int64? SincroGeografiaCiudadId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_CIUDAD);

                        if (SincroGeografiaCiudadId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CIUDAD) ? data.SincroDates[ENTIDAD_CIUDAD] : fechaSincronizacionDefault;
                            data.Ciudades = ObtenerCiudadesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaCiudadId.Value);
                        }

                        Int64? SincroGeografiaCodigoPostalId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_CODIGOPOSTAL);

                        if (SincroGeografiaCodigoPostalId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CODIGOPOSTAL) ? data.SincroDates[ENTIDAD_CODIGOPOSTAL] : fechaSincronizacionDefault;
                            data.CodigosPostales = ObtenerCodigosPostalesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaCodigoPostalId.Value);
                        }

                        Int64? SincroGeografiaZonaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_ZONA);

                        if (SincroGeografiaZonaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_ZONA) ? data.SincroDates[ENTIDAD_ZONA] : fechaSincronizacionDefault;
                            data.Zonas = ObtenerZonasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroGeografiaZonaId.Value);
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
        [Route("ObtenerPaises")]
        [Authorize]
        public async Task<IActionResult> ObtenerPaises()
        {
            GeografiaPaisModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PAIS);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Paises = ObtenerPaisesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PAIS));

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
        [Route("ObtenerProvincias")]
        [Authorize]
        public async Task<IActionResult> ObtenerProvincias()
        {
            GeografiaProvinciaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PROVINCIA);

            if (SincronizacionId.HasValue)
            {
                try
                {

                    data.Provincias = ObtenerProvinciasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PROVINCIA));
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
        [Route("ObtenerCiudades")]
        [Authorize]
        public async Task<IActionResult> ObtenerCiudades()
        {
            GeografiaCiudadModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CIUDAD);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Ciudades = ObtenerCiudadesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CIUDAD));
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
        [Route("ObtenerZonas")]
        [Authorize]
        public async Task<IActionResult> ObtenerZonas()
        {
            GeografiaZonaModel data = new();
            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ZONA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Zonas = ObtenerZonasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ZONA));
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
        [Route("ObtenerCodigosPostales")]
        [Authorize]
        public async Task<IActionResult> ObtenerCodigosPostales()
        {
            GeografiaCodigoPostalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ZONA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.CodigosPostales = ObtenerCodigosPostalesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PAIS));
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
        private List<DepositaryWebApi.Entities.Tables.Geografia.Pais> ObtenerPaisesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Pais> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Pais oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Pais.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Pais.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> ObtenerProvinciasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Provincia oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Provincia.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Provincia.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> ObtenerCiudadesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Ciudad oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Ciudad.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Ciudad.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Zona> ObtenerZonasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Zona> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Zona oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Zona.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Zona.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> ObtenerCodigosPostalesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> result = new();
            DepositaryWebApi.Business.Tables.Geografia.CodigoPostal oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.CodigoPostal.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.CodigoPostal.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
