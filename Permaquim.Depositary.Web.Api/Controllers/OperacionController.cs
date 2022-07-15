using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {

        public enum OperationTypeEnum
        {
            None = 0,
            BillDeposit = 1,
            CoinDeposit = 2,
            EnvelopeDeposit = 3,
            ValueExtraction = 4
        }

        #region PostEndpoints

        [HttpPost]
        [Route("SincronizarTransacciones")]
        [Authorize]
        public async Task<IActionResult> Transacciones([FromBody] TransaccionDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Transaccion transaccionEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Transaccion");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    transaccionEntity.BeginTransaction();

                    foreach (var item in model.Transaccion)
                    {
                        item.DepositarioId = depositarioId;
                        transaccionEntity.Add(item);
                    }

                    DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle transaccionDetalleEntity = new(transaccionEntity);
                    foreach (var item in model.TransaccionDetalle)
                    {
                        transaccionDetalleEntity.Add(item);
                    }

                    DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre transaccionSobreEntity = new(transaccionEntity);
                    foreach (var item in model.TransaccionSobre)
                    {
                        transaccionSobreEntity.Add(item);
                    }

                    DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalleEntity = new(transaccionEntity);
                    foreach (var item in model.TransaccionSobreDetalle)
                    {
                        transaccionSobreDetalleEntity.Add(item);
                    }

                    transaccionEntity.EndTransaction(true);

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    transaccionEntity.EndTransaction(false);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        [HttpPost]
        [Route("SincronizarEventos")]
        [Authorize]
        public async Task<IActionResult> Eventos([FromBody] EventoDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Evento eventoEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Evento");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    foreach (var item in model.Evento)
                    {
                        item.DepositarioId = depositarioId;
                        eventoEntity.Add(item);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        [HttpPost]
        [Route("SincronizarContenedores")]
        [Authorize]
        public async Task<IActionResult> Contenedores([FromBody] ContenedorDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Contenedor contenedorEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Contenedor");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    foreach (var item in model.Contenedor)
                    {
                        item.DepositarioId = depositarioId;
                        contenedorEntity.Add(item);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        [HttpPost]
        [Route("SincronizarCierresDiarios")]
        [Authorize]
        public async Task<IActionResult> CierresDiarios([FromBody] CierreDiarioDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Contenedor cierreDiarioEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.CierreDiario");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    foreach (var item in model.CierreDiario)
                    {
                        item.DepositarioId = depositarioId;
                        cierreDiarioEntity.Add(item);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        [HttpPost]
        [Route("SincronizarSesiones")]
        [Authorize]
        public async Task<IActionResult> Sesiones([FromBody] SesionDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Sesion sesionEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Sesion");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    foreach (var item in model.Sesion)
                    {
                        item.DepositarioId = depositarioId;
                        sesionEntity.Add(item);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        [HttpPost]
        [Route("SincronizarTurnos")]
        [Authorize]
        public async Task<IActionResult> Turnos([FromBody] TurnoDTO model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Transaccion turnoEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Turno");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    turnoEntity.BeginTransaction();

                    foreach (var item in model.Turno)
                    {
                        item.DepositarioId = depositarioId;
                        turnoEntity.Add(item);
                    }

                    DepositaryWebApi.Business.Tables.Operacion.TurnoUsuario turnoUsuarioEntity = new(turnoEntity);
                    foreach (var item in model.TurnoUsuario)
                    {
                        turnoUsuarioEntity.Add(item);
                    }

                    turnoEntity.EndTransaction(true);

                    //Cerramos el registro de sincronizacion de la entidad
                    SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

                    return Ok();
                }
                catch (Exception ex)
                {
                    turnoEntity.EndTransaction(false);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No se pudo encontrar la entidad a sincronizar en Sincronizacion.Entidad");
            }

        }

        #endregion

        #region GetEndpoints

        [HttpGet]
        [Route("ObtenerTiposTransacciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposTransacciones()
        {
            OperacionTipoTransaccionDTO data = new();

            try
            {
                data.TiposTransacciones = ObtenerTiposTransaccionesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposContenedores")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposContenedores()
        {
            OperacionTipoContenedorDTO data = new();

            try
            {
                data.TiposContenedores = ObtenerTiposContenedoresBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposEventos")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposEventos()
        {
            OperacionTipoEventoDTO data = new();

            try
            {
                data.TiposEventos = ObtenerTiposEventosBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> ObtenerTiposTransaccionesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> ObtenerTiposContenedoresBD()
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoContenedor oEntities = new();

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> ObtenerTiposEventosBD()
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoEvento oEntities = new();

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
