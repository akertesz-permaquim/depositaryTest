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
        private const string ENTIDAD_CUENTA = "Banca.Provincia";
        private const string ENTIDAD_TIPOCUENTA = "Banca.Ciudad";
        private const string ENTIDAD_USUARIOCUENTA = "Banca.CodigoPostal";

        #region Endpoints

        [HttpGet]
        [Route("ObtenerBanca")]
        [Authorize]
        public async Task<IActionResult> ObtenerBanca()
        {
            BancaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroBancaBancoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_BANCO);

                if (SincroBancaBancoId.HasValue)
                {
                    data.Bancos = ObtenerBancosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_BANCO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroBancaBancoId.Value);
                }

                Int64? SincroBancaTipoCuentaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA);

                if (SincroBancaTipoCuentaId.HasValue)
                {
                    data.TiposCuenta = ObtenerTiposCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroBancaTipoCuentaId.Value);
                }

                Int64? SincroBancaCuentaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CUENTA);

                if (SincroBancaCuentaId.HasValue)
                {
                    data.Cuentas = ObtenerCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CUENTA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroBancaCuentaId.Value);
                }

                Int64? SincroBancaUsuarioCuentaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA);

                if (SincroBancaUsuarioCuentaId.HasValue)
                {
                    data.UsuariosCuenta = ObtenerUsuariosCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroBancaUsuarioCuentaId.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerBancos")]
        [Authorize]
        public async Task<IActionResult> ObtenerBancos()
        {
            BancaBancoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_BANCO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Bancos = ObtenerBancosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_BANCO));
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
        [Route("ObtenerCuentas")]
        [Authorize]
        public async Task<IActionResult> ObtenerCuentas()
        {
            BancaCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Cuentas = ObtenerCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CUENTA));
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
        [Route("ObtenerTiposCuenta")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposCuenta()
        {
            BancaTipoCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposCuenta = ObtenerTiposCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCUENTA));
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
        [Route("ObtenerUsuariosCuenta")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosCuenta()
        {
            BancaUsuarioCuentaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.UsuariosCuenta = ObtenerUsuariosCuentasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_USUARIOCUENTA));
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
