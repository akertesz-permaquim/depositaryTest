using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        #region Endpoints

        [HttpGet]
        [Route("ObtenerDispositivo")]
        [Authorize]
        public async Task<IActionResult> ObtenerDispositivo()
        {
            DispositivoModel data = new();

            try
            {
                data.Modelos = ObtenerModelosBD();
                data.Marcas = ObtenerMarcasBD();
                data.Depositarios = ObtenerDepositariosBD();
                data.TiposPlacas = ObtenerTiposPlacasBD();
                data.ComandosPlacas = ObtenerComandosPlacasBD();
                data.TiposConfiguraciones = ObtenerTiposConfiguracionesBD();
                data.PlacasDepositarios = ObtenerPlacasBD();
                data.ConfiguracionesDepositarios = ObtenerConfiguracionesBD();
                data.TiposContadoras = ObtenerTiposContadorasBD();
                data.ContadorasDepositarios = ObtenerContadorasBD();
                data.ComandosContadoras = ObtenerComandosContadorasBD();
                data.ValoresDepositarios = ObtenerValoresBD();
                data.EstadosDepositarios = ObtenerEstadosBD();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerDepositarios")]
        [Authorize]
        public async Task<IActionResult> ObtenerDepositarios()
        {
            DispositivoDepositarioModel data = new();

            try
            {
                data.Depositarios = ObtenerDepositariosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerMarcas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMarcas()
        {
            DispositivoMarcaModel data = new();

            try
            {
                data.Marcas = ObtenerMarcasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerModelos")]
        [Authorize]
        public async Task<IActionResult> ObtenerModelos()
        {
            DispositivoModeloModel data = new();

            try
            {
                data.Modelos = ObtenerModelosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposPlacas()
        {
            DispositivoTipoPlacaModel data = new();

            try
            {
                data.TiposPlacas = ObtenerTiposPlacasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerComandosContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerComandosContadoras()
        {
            DispositivoComandoContadoraModel data = new();

            try
            {
                data.ComandosContadoras = ObtenerComandosContadorasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerComandosPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerComandosPlacas()
        {
            DispositivoComandoPlacaModel data = new();

            try
            {
                data.ComandosPlacas = ObtenerComandosPlacasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerConfiguraciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerConfiguraciones()
        {
            DispositivoConfiguracionDepositarioModel data = new();

            try
            {
                data.ConfiguracionesDepositarios = ObtenerConfiguracionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerContadoras()
        {
            DispositivoDepositarioContadoraModel data = new();

            try
            {
                data.ContadorasDepositarios = ObtenerContadorasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerEstados")]
        [Authorize]
        public async Task<IActionResult> ObtenerEstados()
        {
            DispositivoDepositarioEstadoModel data = new();

            try
            {
                data.EstadosDepositarios = ObtenerEstadosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerPlacas()
        {
            DispositivoDepositarioPlacaModel data = new();

            try
            {
                data.PlacasDepositarios = ObtenerPlacasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerValores")]
        [Authorize]
        public async Task<IActionResult> ObtenerValores()
        {
            DispositivoDepositarioValorModel data = new();

            try
            {
                data.ValoresDepositarios = ObtenerValoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposConfiguraciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposConfiguraciones()
        {
            DispositivoTipoConfiguracionDepositarioModel data = new();

            try
            {
                data.TiposConfiguraciones = ObtenerTiposConfiguracionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposContadoras()
        {
            DispositivoTipoContadoraModel data = new();

            try
            {
                data.TiposContadoras = ObtenerTiposContadorasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> ObtenerDepositariosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> ObtenerTiposContadorasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoContadora oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> ObtenerTiposConfiguracionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoConfiguracionDepositario oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioValor> ObtenerValoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioValor> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioValor oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> ObtenerPlacasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioPlaca oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> ObtenerEstadosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> ObtenerContadorasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioContadora oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ObtenerConfiguracionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> ObtenerComandosPlacasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoPlaca oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> ObtenerComandosContadorasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoContadora oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> ObtenerMarcasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Marca oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> ObtenerModelosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Modelo oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> ObtenerTiposPlacasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoPlaca oEntities = new();

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
