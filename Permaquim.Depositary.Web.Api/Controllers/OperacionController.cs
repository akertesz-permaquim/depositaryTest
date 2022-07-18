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
        public async Task<IActionResult> Transacciones([FromBody] TransaccionModel model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Transaccion transaccionEntity = new();

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);




            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Transaccion");

            if (SincronizacionEntidadId.HasValue)
            {
                try
                {

                    DepositaryWebApi.Business.Tables.Operacion.Sesion sessionEntities = new();

                    foreach (var item in model.Sesion)
                    {
                        item.DepositarioId = depositarioId;
                        sessionEntities.AddOrUpdate(item);
                    }

                    DepositaryWebApi.Business.Tables.Operacion.CierreDiario dailyclosingEntities = new();

                    foreach (var item in model.CierreDiario)
                    {
                        item.DepositarioId = depositarioId;
                        dailyclosingEntities.AddOrUpdate(item);
                    }


                    DepositaryWebApi.Business.Tables.Operacion.Turno turnEntities = new();

                    foreach (var item in model.Turno)
                    {
                        item.DepositarioId = depositarioId;
                        turnEntities.AddOrUpdate(item);
                    }


                    DepositaryWebApi.Business.Tables.Operacion.Contenedor containerEntities = new();

                    foreach (var item in model.Contenedor)
                    {
                        item.DepositarioId = depositarioId;
                        containerEntities.AddOrUpdate(item);
                    }

                    transaccionEntity.BeginTransaction();

                    foreach (var transactionItem in model.Transaccion)
                    {
                        transactionItem.DepositarioId = depositarioId;
                        var previousTransactionId = transactionItem.Id;
                        var newTransaction = transaccionEntity.AddOrUpdate(transactionItem);

                        DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle transaccionDetalleEntity = new(transaccionEntity);

                        foreach (var itemDetail in model.TransaccionDetalle)
                        {
                            if (itemDetail.TransaccionId == previousTransactionId)
                            {
                                itemDetail.TransaccionId = newTransaction.Id;
                                transaccionDetalleEntity.AddOrUpdate(itemDetail);
                            }
                        }

                        DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre transaccionSobreEntity = new(transaccionEntity);
                        DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobre newEnvelope = new();

                        foreach (var itemEnvelope in model.TransaccionSobre)
                        {
                            var previousEnvelopeId = itemEnvelope.Id;

                            if (itemEnvelope.TransaccionId == previousTransactionId)
                            {
                                itemEnvelope.TransaccionId = newTransaction.Id;
                                newEnvelope = transaccionSobreEntity.AddOrUpdate(itemEnvelope);

                                DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalleEntity = new(transaccionEntity);
                                foreach (var itemEnvelopeDetail in model.TransaccionSobreDetalle)
                                {
                                    if (itemEnvelopeDetail.SobreId == previousEnvelopeId)
                                    {
                                        itemEnvelopeDetail.SobreId = newEnvelope.Id;
                                        transaccionSobreDetalleEntity.AddOrUpdate(itemEnvelopeDetail);
                                    }
                                }
                            }
                        }
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
        public async Task<IActionResult> Eventos([FromBody] EventoModel model)
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
        public async Task<IActionResult> Contenedores([FromBody] ContenedorModel model)
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
        public async Task<IActionResult> CierresDiarios([FromBody] CierreDiarioModel model)
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
        public async Task<IActionResult> Sesiones([FromBody] SesionModel model)
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
        public async Task<IActionResult> Turnos([FromBody] OperacionTurnoModel model)
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
            OperacionTipoTransaccionModel data = new();

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
            OperacionTipoContenedorModel data = new();

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
            OperacionTipoEventoModel data = new();

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
