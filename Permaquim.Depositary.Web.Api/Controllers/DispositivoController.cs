using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DispositivoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_COMANDOCONTADORA = "Dispositivo.ComandoContadora";
        private const string ENTIDAD_COMANDOPLACA = "Dispositivo.ComandoPlaca";
        private const string ENTIDAD_CONFIGURACIONDEPOSITARIO = "Dispositivo.ConfiguracionDepositario";
        private const string ENTIDAD_DEPOSITARIO = "Dispositivo.Depositario";
        private const string ENTIDAD_DEPOSITARIOCONTADORA = "Dispositivo.DepositarioContadora";
        private const string ENTIDAD_DEPOSITARIOESTADO = "Dispositivo.DepositarioEstado";
        private const string ENTIDAD_DEPOSITARIOMONEDA = "Dispositivo.DepositarioMoneda";
        private const string ENTIDAD_DEPOSITARIOPLACA = "Dispositivo.DepositarioPlaca";
        private const string ENTIDAD_MARCA = "Dispositivo.Marca";
        private const string ENTIDAD_MODELO = "Dispositivo.Modelo";
        private const string ENTIDAD_PLANTILLAMONEDA = "Dispositivo.PlantillaMoneda";
        private const string ENTIDAD_PLANTILLAMONEDADETALLE = "Dispositivo.PlantillaMonedaDetalle";
        private const string ENTIDAD_TIPOCONFIGURACIONDEPOSITARIO = "Dispositivo.TipoConfiguracionDepositario";
        private const string ENTIDAD_TIPOCONTADORA = "Dispositivo.TipoContadora";
        private const string ENTIDAD_TIPOPLACA = "Dispositivo.TipoPlaca";

        #region Endpoints

        [HttpGet]
        [Route("ObtenerDispositivo")]
        [Authorize]
        public async Task<IActionResult> ObtenerDispositivo()
        {
            DispositivoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroDispositivoModeloId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MODELO);

                if (SincroDispositivoModeloId.HasValue)
                {
                    data.Modelos = ObtenerModelosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MODELO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoModeloId.Value);
                }

                Int64? SincroDispositivoMarcaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MARCA);

                if (SincroDispositivoMarcaId.HasValue)
                {
                    data.Marcas = ObtenerMarcasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MARCA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoMarcaId.Value);
                }

                Int64? SincroDispositivoDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIO);

                if (SincroDispositivoDepositarioId.HasValue)
                {
                    data.Depositarios = ObtenerDepositariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoDepositarioId.Value);
                }

                Int64? SincroDispositivoTipoPlacaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOPLACA);

                if (SincroDispositivoTipoPlacaId.HasValue)
                {
                    data.TiposPlacas = ObtenerTiposPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOPLACA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoTipoPlacaId.Value);
                }

                Int64? SincroDispositivoComandoPlacaId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_COMANDOPLACA);

                if (SincroDispositivoComandoPlacaId.HasValue)
                {
                    data.ComandosPlacas = ObtenerComandosPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_COMANDOPLACA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoComandoPlacaId.Value);
                }

                Int64? SincroDispositivoTipoConfiguracionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONFIGURACIONDEPOSITARIO);

                if (SincroDispositivoTipoConfiguracionId.HasValue)
                {
                    data.TiposConfiguraciones = ObtenerTiposConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONFIGURACIONDEPOSITARIO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoTipoConfiguracionId.Value);
                }

                Int64? SincroDispositivoPlacaDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOPLACA);

                if (SincroDispositivoPlacaDepositarioId.HasValue)
                {
                    data.PlacasDepositarios = ObtenerPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOPLACA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoPlacaDepositarioId.Value);
                }

                Int64? SincroDispositivoConfiguracionDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONDEPOSITARIO);

                if (SincroDispositivoConfiguracionDepositarioId.HasValue)
                {
                    data.ConfiguracionesDepositarios = ObtenerConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONDEPOSITARIO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoConfiguracionDepositarioId.Value);
                }

                Int64? SincroDispositivoTipoContadoraId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONTADORA);

                if (SincroDispositivoTipoContadoraId.HasValue)
                {
                    data.TiposContadoras = ObtenerTiposContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTADORA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoTipoContadoraId.Value);
                }

                Int64? SincroDispositivoContadoraDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOCONTADORA);

                if (SincroDispositivoContadoraDepositarioId.HasValue)
                {
                    data.ContadorasDepositarios = ObtenerContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOCONTADORA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoContadoraDepositarioId.Value);
                }

                Int64? SincroDispositivoComandoContadoraId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_COMANDOCONTADORA);

                if (SincroDispositivoComandoContadoraId.HasValue)
                {
                    data.ComandosContadoras = ObtenerComandosContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_COMANDOCONTADORA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoComandoContadoraId.Value);
                }

                Int64? SincroDispositivoMonedaDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOMONEDA);

                if (SincroDispositivoMonedaDepositarioId.HasValue)
                {
                    data.MonedasDepositarios = ObtenerMonedasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOMONEDA));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoMonedaDepositarioId.Value);
                }

                Int64? SincroDispositivoEstadoDepositarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOESTADO);

                if (SincroDispositivoEstadoDepositarioId.HasValue)
                {
                    data.EstadosDepositarios = ObtenerEstadosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOESTADO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroDispositivoEstadoDepositarioId.Value);
                }

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

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Depositarios = ObtenerDepositariosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIO));
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
        [Route("ObtenerMarcas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMarcas()
        {
            DispositivoMarcaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MARCA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Marcas = ObtenerMarcasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MARCA));
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
        [Route("ObtenerModelos")]
        [Authorize]
        public async Task<IActionResult> ObtenerModelos()
        {
            DispositivoModeloModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_MODELO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.Modelos = ObtenerModelosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_MODELO));
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
        [Route("ObtenerTiposPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposPlacas()
        {
            DispositivoTipoPlacaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOPLACA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposPlacas = ObtenerTiposPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOPLACA));
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
        [Route("ObtenerComandosContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerComandosContadoras()
        {
            DispositivoComandoContadoraModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_COMANDOCONTADORA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ComandosContadoras = ObtenerComandosContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_COMANDOCONTADORA));
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
        [Route("ObtenerComandosPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerComandosPlacas()
        {
            DispositivoComandoPlacaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_COMANDOPLACA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ComandosPlacas = ObtenerComandosPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_COMANDOPLACA));
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
        [Route("ObtenerConfiguraciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerConfiguraciones()
        {
            DispositivoConfiguracionDepositarioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONDEPOSITARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ConfiguracionesDepositarios = ObtenerConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_CONFIGURACIONDEPOSITARIO));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerContadoras()
        {
            DispositivoDepositarioContadoraModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOCONTADORA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.ContadorasDepositarios = ObtenerContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOCONTADORA));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
        }

        [HttpGet]
        [Route("ObtenerEstados")]
        [Authorize]
        public async Task<IActionResult> ObtenerEstados()
        {
            DispositivoDepositarioEstadoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOESTADO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.EstadosDepositarios = ObtenerEstadosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOESTADO));
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
        [Route("ObtenerPlacas")]
        [Authorize]
        public async Task<IActionResult> ObtenerPlacas()
        {
            DispositivoDepositarioPlacaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOPLACA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.PlacasDepositarios = ObtenerPlacasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOPLACA));
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
        [Route("ObtenerMonedas")]
        [Authorize]
        public async Task<IActionResult> ObtenerMonedas()
        {
            DispositivoDepositarioMonedaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOMONEDA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.MonedasDepositarios = ObtenerMonedasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOMONEDA));
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
        [Route("ObtenerTiposConfiguraciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposConfiguraciones()
        {
            DispositivoTipoConfiguracionDepositarioModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONFIGURACIONDEPOSITARIO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposConfiguraciones = ObtenerTiposConfiguracionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONFIGURACIONDEPOSITARIO));
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
        [Route("ObtenerTiposContadoras")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposContadoras()
        {
            DispositivoTipoContadoraModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONTADORA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposContadoras = ObtenerTiposContadorasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTADORA));
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
        [Route("ObtenerPlantillasMonedas")]
        [Authorize]
        public async Task<IActionResult> ObtenerPlantillasMonedas()
        {
            DispositivoPlantillaMonedaModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PLANTILLAMONEDA);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.PlantillasMonedas = ObtenerPlantillasMonedasBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PLANTILLAMONEDA));
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
        [Route("ObtenerPlantillasMonedasDetalles")]
        [Authorize]
        public async Task<IActionResult> ObtenerPlantillasMonedasDetalles()
        {
            DispositivoPlantillaMonedaDetalleModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_PLANTILLAMONEDADETALLE);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.PlantillasMonedasDetalles = ObtenerPlantillasMonedasDetallesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_PLANTILLAMONEDADETALLE));
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

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> ObtenerDepositariosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> ObtenerTiposContadorasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoContadora oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.TipoContadora.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.TipoContadora.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> ObtenerTiposConfiguracionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoConfiguracionDepositario oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> ObtenerMonedasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioMoneda oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> ObtenerPlacasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioPlaca oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.DepositarioPlaca.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.DepositarioPlaca.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> ObtenerEstadosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> ObtenerContadorasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.DepositarioContadora oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.DepositarioContadora.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.DepositarioContadora.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ObtenerConfiguracionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> ObtenerComandosPlacasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoPlaca oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.ComandoPlaca.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.ComandoPlaca.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> ObtenerComandosContadorasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.ComandoContadora oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.ComandoContadora.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.ComandoContadora.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> ObtenerMarcasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Marca oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Marca.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.Marca.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> ObtenerModelosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.Modelo oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Modelo.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.Modelo.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> ObtenerTiposPlacasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.TipoPlaca oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.TipoPlaca.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.TipoPlaca.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMoneda> ObtenerPlantillasMonedasBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMoneda> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMoneda oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMoneda.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMoneda.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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

        private List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> ObtenerPlantillasMonedasDetallesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> result = new();
            DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMonedaDetalle oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
