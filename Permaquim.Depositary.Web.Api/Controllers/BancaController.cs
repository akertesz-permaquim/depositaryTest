using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancaController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerBancos")]
        [Authorize]
        public async Task<IActionResult> ObtenerBancos()
        {
            BancaBancoModel data = new();

            try
            {
                data.Bancos = ObtenerBancosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerCuentas")]
        [Authorize]
        public async Task<IActionResult> ObtenerCuentas()
        {
            BancaCuentaModel data = new();

            try
            {
                data.Cuentas = ObtenerCuentasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposCuenta")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposCuenta()
        {
            BancaTipoCuentaModel data = new();

            try
            {
                data.TiposCuenta = ObtenerTiposCuentasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerUsuariosCuenta")]
        [Authorize]
        public async Task<IActionResult> ObtenerUsuariosCuenta()
        {
            BancaUsuarioCuentaModel data = new();

            try
            {
                data.UsuariosCuenta = ObtenerUsuariosCuentasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Banca.Banco> ObtenerBancosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Banca.Banco> result = new();
            DepositaryWebApi.Business.Tables.Banca.Banco oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> ObtenerCuentasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.Cuenta oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> ObtenerTiposCuentasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.TipoCuenta oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> ObtenerUsuariosCuentasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> result = new();
            DepositaryWebApi.Business.Tables.Banca.UsuarioCuenta oEntities = new();

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
