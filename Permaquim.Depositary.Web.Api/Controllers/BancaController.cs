using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BancaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_BANCO = "Banca.Banco";
        private const string ENTIDAD_CUENTA = "Banca.Cuenta";
        private const string ENTIDAD_TIPOCUENTA = "Banca.TipoCuenta";
        private const string ENTIDAD_USUARIOCUENTA = "Banca.UsuarioCuenta";

        #region Endpoints

        [HttpPost]
        [Route("ObtenerBanca")]
        [Authorize] 
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerBanca([FromBody] BancaModel data)
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
                        Int64? SincroBancaBancoId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_BANCO);

                        if (SincroBancaBancoId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_BANCO) ? data.SincroDates[ENTIDAD_BANCO] : fechaSincronizacionDefault;
                            data.Bancos = ObtenerBancosBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroBancaBancoId.Value);
                        }

                        Int64? SincroBancaTipoCuentaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_TIPOCUENTA);

                        if (SincroBancaTipoCuentaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_TIPOCUENTA) ? data.SincroDates[ENTIDAD_TIPOCUENTA] : fechaSincronizacionDefault;
                            data.TiposCuenta = ObtenerTiposCuentasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroBancaTipoCuentaId.Value);
                        }

                        Int64? SincroBancaCuentaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_CUENTA);

                        if (SincroBancaCuentaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_CUENTA) ? data.SincroDates[ENTIDAD_CUENTA] : fechaSincronizacionDefault;
                            data.Cuentas = ObtenerCuentasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroBancaCuentaId.Value);
                        }

                        Int64? SincroBancaUsuarioCuentaId = SynchronizationController.iniciarCabeceraSincronizacion(EjecucionId.Value, ENTIDAD_USUARIOCUENTA);

                        if (SincroBancaUsuarioCuentaId.HasValue)
                        {
                            var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_USUARIOCUENTA) ? data.SincroDates[ENTIDAD_USUARIOCUENTA] : fechaSincronizacionDefault;
                            data.UsuariosCuenta = ObtenerUsuariosCuentasBD(fechaDiferencial);
                            SynchronizationController.finalizarCabeceraSincronizacion(SincroBancaUsuarioCuentaId.Value);
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
        [Route("ObtenerBancos")]
        [Authorize] 
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerBancos()
        {
            BancaBancoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_BANCO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Bancos = ObtenerBancosBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_BANCO));
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
        [Route("ObtenerCuentas")]
        [Authorize] 
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerCuentas()
        {
            BancaCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Cuentas = ObtenerCuentasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CUENTA));
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
        [Route("ObtenerTiposCuenta")]
        [Authorize] [ApiExplorerSettings(IgnoreApi = true)]

        public async Task<IActionResult> ObtenerTiposCuenta()
        {
            BancaTipoCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposCuenta = ObtenerTiposCuentasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA));
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
        [Route("ObtenerUsuariosCuenta")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ObtenerUsuariosCuenta()
        {
            BancaUsuarioCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosCuenta = ObtenerUsuariosCuentasBD(SynchronizationController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA));
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

        private List<DepositaryWebApi.Entities.Tables.Banca.Banco> ObtenerBancosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Banca.Banco> result = new();
            DepositaryWebApi.Business.Tables.Banca.Banco oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Banca.Banco.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Banca.Banco.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> ObtenerCuentasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.Cuenta oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Banca.Cuenta.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Banca.Cuenta.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> ObtenerTiposCuentasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.TipoCuenta oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Banca.TipoCuenta.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Banca.TipoCuenta.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> ObtenerUsuariosCuentasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.UsuarioCuenta oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Banca.UsuarioCuenta.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Banca.UsuarioCuenta.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
