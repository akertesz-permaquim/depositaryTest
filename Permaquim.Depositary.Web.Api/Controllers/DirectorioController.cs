using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DirectorioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_GRUPO = "Directorio.Grupo";
        private const string ENTIDAD_EMPRESA = "Directorio.Empresa";
        private const string ENTIDAD_SUCURSAL = "Directorio.Sucursal";
        private const string ENTIDAD_SECTOR = "Directorio.Sector";
        private const string ENTIDAD_RELACIONMONEDASUCURSAL = "Directorio.RelacionMonedaSucursal";

        #region Endpoints

        [HttpGet]
        [Route("ObtenerDirectorio")]
        [Authorize]
        public async Task<IActionResult> ObtenerDirectorio()
        {
            DirectorioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroDirectorioGrupoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_GRUPO);

                if (SincroDirectorioGrupoId.HasValue)
                {
                    data.Grupos = ObtenerGruposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_GRUPO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDirectorioGrupoId.Value);
                }

                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroDirectorioEmpresaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_EMPRESA);

                if (SincroDirectorioEmpresaId.HasValue)
                {
                    data.Empresas = ObtenerEmpresasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_EMPRESA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDirectorioEmpresaId.Value);
                }

                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroDirectorioSucursalId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SUCURSAL);

                if (SincroDirectorioSucursalId.HasValue)
                {
                    data.Sucursales = ObtenerSucursalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SUCURSAL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDirectorioSucursalId.Value);
                }

                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroDirectorioSectorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SECTOR);

                if (SincroDirectorioSectorId.HasValue)
                {
                    data.Sectores = ObtenerSectoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SECTOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDirectorioSectorId.Value);
                }

                Int64? SincroDirectorioRelacionMonedaSucursalId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL);

                if (SincroDirectorioRelacionMonedaSucursalId.HasValue)
                {
                    data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDirectorioRelacionMonedaSucursalId.Value);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerGrupos")]
        [Authorize]
        public async Task<IActionResult> ObtenerGrupos()
        {
            DirectorioGrupoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_GRUPO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Grupos = ObtenerGruposBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_GRUPO));
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
        [Route("ObtenerEmpresas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEmpresas()
        {
            DirectorioEmpresaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_EMPRESA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Empresas = ObtenerEmpresasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_EMPRESA));
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
        [Route("ObtenerSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerSucursales()
        {
            DirectorioSucursalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SUCURSAL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Sucursales = ObtenerSucursalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SUCURSAL));
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
        [Route("ObtenerSectores")]
        [Authorize]
        public async Task<IActionResult> ObtenerSectores()
        {
            DirectorioSectorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SECTOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Sectores = ObtenerSectoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SECTOR));
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
        [Route("ObtenerRelacionesMonedasSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerRelacionesMonedasSucursales()
        {
            DirectorioRelacionMonedaSucursalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL));
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

        private List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> ObtenerGruposBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Grupo oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Directorio.Grupo.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Directorio.Grupo.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> ObtenerEmpresasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Empresa oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Directorio.Empresa.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Directorio.Empresa.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> ObtenerSucursalesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Sucursal oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Directorio.Sucursal.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Directorio.Sucursal.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.Sector> ObtenerSectoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.Sector> result = new();
            DepositaryWebApi.Business.Tables.Directorio.Sector oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Directorio.Sector.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Directorio.Sector.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> ObtenerRelacionesMonedasSucursalesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> result = new();
            DepositaryWebApi.Business.Tables.Directorio.RelacionMonedaSucursal oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Directorio.RelacionMonedaSucursal.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Directorio.RelacionMonedaSucursal.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
