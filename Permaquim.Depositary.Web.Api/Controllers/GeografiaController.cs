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
        [HttpGet]
        [Route("ObtenerGeografia")]
        [Authorize]
        public async Task<IActionResult> ObtenerGeografia()
        {
            GeografiaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroGeografiaPaisId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PAIS);

                if (SincroGeografiaPaisId.HasValue)
                {
                    data.Paises = ObtenerPaisesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PAIS));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaPaisId.Value);
                }

                Int64? SincroGeografiaProvinciaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PROVINCIA);

                if (SincroGeografiaProvinciaId.HasValue)
                {
                    data.Provincias = ObtenerProvinciasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PROVINCIA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaProvinciaId.Value);
                }

                Int64? SincroGeografiaCiudadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CIUDAD);

                if (SincroGeografiaCiudadId.HasValue)
                {
                    data.Ciudades = ObtenerCiudadesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CIUDAD));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaCiudadId.Value);
                }

                Int64? SincroGeografiaCodigoPostalId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CODIGOPOSTAL);

                if (SincroGeografiaCodigoPostalId.HasValue)
                {
                    data.CodigosPostales = ObtenerCodigosPostalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CODIGOPOSTAL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaCodigoPostalId.Value);
                }

                Int64? SincroGeografiaZonaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ZONA);

                if (SincroGeografiaZonaId.HasValue)
                {
                    data.Zonas = ObtenerZonasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ZONA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaZonaId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerPaises")]
        [Authorize]
        public async Task<IActionResult> ObtenerPaises()
        {
            GeografiaPaisModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PAIS);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Paises = ObtenerPaisesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PAIS));

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
        [Route("ObtenerProvincias")]
        [Authorize]
        public async Task<IActionResult> ObtenerProvincias()
        {
            GeografiaProvinciaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PROVINCIA);

            if (SincronizacionId.HasValue)
            {
                try
                {

                    data.Provincias = ObtenerProvinciasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PROVINCIA));
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
        [Route("ObtenerCiudades")]
        [Authorize]
        public async Task<IActionResult> ObtenerCiudades()
        {
            GeografiaCiudadModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CIUDAD);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Ciudades = ObtenerCiudadesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CIUDAD));
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
        [Route("ObtenerZonas")]
        [Authorize]
        public async Task<IActionResult> ObtenerZonas()
        {
            GeografiaZonaModel data = new();
            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ZONA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Zonas = ObtenerZonasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_ZONA));
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
        [Route("ObtenerCodigosPostales")]
        [Authorize]
        public async Task<IActionResult> ObtenerCodigosPostales()
        {
            GeografiaCodigoPostalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_ZONA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.CodigosPostales = ObtenerCodigosPostalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PAIS));
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
