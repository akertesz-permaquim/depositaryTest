using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisualizacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VisualizacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_PERFIL = "Visualizacion.Perfil";
        private const string ENTIDAD_PERFILITEM = "Visualizacion.PerfilItem";
        private const string ENTIDAD_PERFILTIPO = "Visualizacion.PerfilTipo";

        #region Endpoints

        [HttpGet]
        [Route("ObtenerVisualizacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerVisualizacion()
        {
            VisualizacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroVisualizacionTipoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFILTIPO);

                if (SincroVisualizacionTipoId.HasValue)
                {
                    data.Tipos = ObtenerTiposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFILTIPO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroVisualizacionTipoId.Value);
                }

                Int64? SincroVisualizacionPerfilId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFIL);

                if (SincroVisualizacionPerfilId.HasValue)
                {
                    data.Perfiles = ObtenerPerfilesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFIL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroVisualizacionPerfilId.Value);
                }

                Int64? SincroVisualizacionPerfilItemId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFILITEM);

                if (SincroVisualizacionPerfilItemId.HasValue)
                {
                    data.PerfilesItems = ObtenerPerfilesItemsBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFILITEM));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroVisualizacionPerfilItemId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerPerfiles")]
        [Authorize]
        public async Task<IActionResult> ObtenerPerfiles()
        {
            VisualizacionPerfilModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFIL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Perfiles = ObtenerPerfilesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFIL));
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
        [Route("ObtenerTipos")]
        [Authorize]
        public async Task<IActionResult> ObtenerTipos()
        {
            VisualizacionPerfilTipoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFILTIPO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Tipos = ObtenerTiposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFILTIPO));
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
        [Route("ObtenerPerfilesItems")]
        [Authorize]
        public async Task<IActionResult> ObtenerPerfilesItems()
        {
            VisualizacionPerfilItemModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PERFILITEM);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.PerfilesItems = ObtenerPerfilesItemsBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PERFILITEM));
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
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> ObtenerPerfilesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.Perfil oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Visualizacion.Perfil.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Visualizacion.Perfil.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> ObtenerTiposBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilTipo oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> ObtenerPerfilesItemsBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> result = new();
            DepositaryWebApi.Business.Tables.Visualizacion.PerfilItem oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
