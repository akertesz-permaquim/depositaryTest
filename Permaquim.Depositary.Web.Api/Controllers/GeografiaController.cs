using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeografiaController : ControllerBase
    {
        #region Endpoints
        [HttpGet]
        [Route("ObtenerGeografia")]
        [Authorize]
        public async Task<IActionResult> ObtenerGeografia()
        {
            GeografiaModel data = new();

            Int64 depositarioId = 2;

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroGeografiaPaisId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Pais");

                if (SincroGeografiaPaisId.HasValue)
                {
                    data.Paises = ObtenerPaisesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Pais"));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaPaisId.Value);
                }

                Int64? SincroGeografiaProvinciaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Provincia");

                if (SincroGeografiaProvinciaId.HasValue)
                {
                    data.Provincias = ObtenerProvinciasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Provincia"));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaProvinciaId.Value);
                }

                Int64? SincroGeografiaCiudadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Ciudad");

                if (SincroGeografiaCiudadId.HasValue)
                {
                    data.Ciudades = ObtenerCiudadesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Ciudad"));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaCiudadId.Value);
                }

                Int64? SincroGeografiaCodigoPostalId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.CodigoPostal");

                if (SincroGeografiaCodigoPostalId.HasValue)
                {
                    data.CodigosPostales = ObtenerCodigosPostalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.CodigoPostal"));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroGeografiaCodigoPostalId.Value);
                }

                Int64? SincroGeografiaZonaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Zona");

                if (SincroGeografiaZonaId.HasValue)
                {
                    data.Zonas = ObtenerZonasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Zona"));
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

            Int64 depositarioId = 2;

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Pais");

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Paises = ObtenerPaisesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Pais"));

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

            Int64 depositarioId = 2;

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Provincia");

            if (SincronizacionId.HasValue)
            {
                try
                {

                    data.Provincias = ObtenerProvinciasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Provincia"));
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

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerCiudades")]
        [Authorize]
        public async Task<IActionResult> ObtenerCiudades()
        {
            GeografiaCiudadModel data = new();

            Int64 depositarioId = 2;

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Ciudad");

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Ciudades = ObtenerCiudadesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Ciudad"));

                    //Cerramos el registro de sincronizacion de la entidad.
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerZonas")]
        [Authorize]
        public async Task<IActionResult> ObtenerZonas()
        {
            GeografiaZonaModel data = new();
            Int64 depositarioId = 2;

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Zona");

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Zonas = ObtenerZonasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Zona"));

                    //Cerramos el registro de sincronizacion de la entidad.
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
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

            Int64 depositarioId = 2;

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Geografia.Zona");

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.CodigosPostales = ObtenerCodigosPostalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, "Geografia.Pais"));
                    
                    //Cerramos el registro de sincronizacion de la entidad.
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionId.Value);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }

        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Geografia.Pais> ObtenerPaisesBD(DateTime fechaUltimosCambios)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Pais> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Pais oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Pais.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Pais.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> ObtenerProvinciasBD(DateTime fechaUltimosCambios)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Provincia oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Provincia.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Provincia.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> ObtenerCiudadesBD(DateTime fechaUltimosCambios)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Ciudad oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Ciudad.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Ciudad.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Zona> ObtenerZonasBD(DateTime fechaUltimosCambios)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Zona> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Zona oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.Zona.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.Zona.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> ObtenerCodigosPostalesBD(DateTime fechaUltimosCambios)
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> result = new();
            DepositaryWebApi.Business.Tables.Geografia.CodigoPostal oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Geografia.CodigoPostal.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Geografia.CodigoPostal.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimosCambios);

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
