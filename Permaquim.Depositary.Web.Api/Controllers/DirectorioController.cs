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

        [HttpPost]
        [Route("ObtenerDirectorio")]
        [Authorize]
        public async Task<IActionResult> ObtenerDirectorio([FromBody] DirectorioModel data)
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
                        Int64? SincroDirectorioGrupoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_GRUPO);

                        if (SincroDirectorioGrupoId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_GRUPO) ? data.SincroDates[ENTIDAD_GRUPO] : fechaSincronizacionDefault;
                            data.Grupos = ObtenerGruposBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroDirectorioGrupoId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroDirectorioEmpresaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_EMPRESA);

                        if (SincroDirectorioEmpresaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_EMPRESA) ? data.SincroDates[ENTIDAD_EMPRESA] : fechaSincronizacionDefault;
                            data.Empresas = ObtenerEmpresasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroDirectorioEmpresaId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroDirectorioSucursalId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_SUCURSAL);

                        if (SincroDirectorioSucursalId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_SUCURSAL) ? data.SincroDates[ENTIDAD_SUCURSAL] : fechaSincronizacionDefault;
                            data.Sucursales = ObtenerSucursalesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroDirectorioSucursalId.Value);
                        }

                        //Iniciamos un registro de sincronizacion de la entidad.
                        Int64? SincroDirectorioSectorId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_SECTOR);

                        if (SincroDirectorioSectorId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_SECTOR) ? data.SincroDates[ENTIDAD_SECTOR] : fechaSincronizacionDefault;
                            data.Sectores = ObtenerSectoresBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroDirectorioSectorId.Value);
                        }

                        Int64? SincroDirectorioRelacionMonedaSucursalId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_RELACIONMONEDASUCURSAL);

                        if (SincroDirectorioRelacionMonedaSucursalId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_RELACIONMONEDASUCURSAL) ? data.SincroDates[ENTIDAD_RELACIONMONEDASUCURSAL] : fechaSincronizacionDefault;
                            data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroDirectorioRelacionMonedaSucursalId.Value);
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
        [Route("ObtenerGrupos")]
        [Authorize]
        public async Task<IActionResult> ObtenerGrupos()
        {
            DirectorioGrupoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_GRUPO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Grupos = ObtenerGruposBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_GRUPO));
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
        [Route("ObtenerEmpresas")]
        [Authorize]
        public async Task<IActionResult> ObtenerEmpresas()
        {
            DirectorioEmpresaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_EMPRESA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Empresas = ObtenerEmpresasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_EMPRESA));
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

        [HttpGet]
        [Route("ObtenerSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerSucursales()
        {
            DirectorioSucursalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SUCURSAL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Sucursales = ObtenerSucursalesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SUCURSAL));
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

        [HttpGet]
        [Route("ObtenerSectores")]
        [Authorize]
        public async Task<IActionResult> ObtenerSectores()
        {
            DirectorioSectorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SECTOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Sectores = ObtenerSectoresBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_SECTOR));
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

        [HttpGet]
        [Route("ObtenerRelacionesMonedasSucursales")]
        [Authorize]
        public async Task<IActionResult> ObtenerRelacionesMonedasSucursales()
        {
            DirectorioRelacionMonedaSucursalModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.RelacionesMonedasSucursales = ObtenerRelacionesMonedasSucursalesBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_RELACIONMONEDASUCURSAL));
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
