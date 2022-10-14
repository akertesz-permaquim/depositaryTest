using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TransaccionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_TRANSACCION = "Operacion.Transaccion";
        private const string ENTIDAD_TRANSACCIONDETALLE = "Operacion.TransaccionDetalle";
        private const string ENTIDAD_TRANSACCIONSOBRE = "Operacion.TransaccionSobre";
        private const string ENTIDAD_TRANSACCIONSOBREDETALLE = "Operacion.TransaccionSobreDetalle";
        private const string ENTIDAD_CIERREDIARIO = "Operacion.CierreDiario";
        private const string ENTIDAD_TURNO = "Operacion.Turno";
        private const string ENTIDAD_SESION = "Operacion.Sesion";
        private const string ENTIDAD_CONTENEDOR = "Operacion.Contenedor";
        private const string ENTIDAD_EVENTO = "Operacion.Evento";


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
            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);


            try
            {
                if (model.Eventos.Count > 0)
                {
                    DepositaryWebApi.Business.Tables.Operacion.Evento eventoController = new();

                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionEventoId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_EVENTO);

                    foreach (var eventoItem in model.Eventos)
                    {
                        eventoItem.OrigenEvento_Id = eventoItem.Id;
                        Int64? idEventoExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_EVENTO, depositarioId, eventoItem.OrigenEvento_Id.Value);
                        if (idEventoExistente.HasValue)
                        {
                            eventoItem.Id = idEventoExistente.Value;
                            eventoController.Update(eventoItem);
                        }
                        else
                            eventoController.Add(eventoItem);

                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionEventoId.Value, eventoItem.OrigenEvento_Id.Value, eventoItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionEventoId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEventoId.Value);
                }

                if (model.Contenedores.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionContenedorId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONTENEDOR);

                    DepositaryWebApi.Business.Tables.Operacion.Contenedor contenedorController = new();

                    foreach (var contenedorItem in model.Contenedores)
                    {
                        contenedorItem.OrigenContenedor_Id = contenedorItem.Id;
                        Int64? idContenedorExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CONTENEDOR, depositarioId, contenedorItem.OrigenContenedor_Id.Value);
                        if (idContenedorExistente.HasValue)
                        {
                            contenedorItem.Id = idContenedorExistente.Value;
                            contenedorController.Update(contenedorItem);
                        }
                        else
                            contenedorController.Add(contenedorItem);

                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionContenedorId.Value, contenedorItem.OrigenContenedor_Id.Value, contenedorItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionContenedorId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionContenedorId.Value);
                }

                if (model.Sesiones.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionSesionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SESION);

                    DepositaryWebApi.Business.Tables.Operacion.Sesion sesionController;
                    foreach (var sesionItem in model.Sesiones)
                    {
                        sesionController = new();
                        sesionItem.OrigenSesion_Id = sesionItem.Id;

                        Int64? idSesionExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_SESION, depositarioId, sesionItem.OrigenSesion_Id.Value);
                        if (idSesionExistente.HasValue)
                        {
                            sesionItem.Id = idSesionExistente.Value;
                            sesionController.Update(sesionItem);
                        }
                        else
                            sesionController.Add(sesionItem);

                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionSesionId.Value, sesionItem.OrigenSesion_Id.Value, sesionItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionSesionId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionSesionId.Value);
                }

                if (model.CierresDiarios.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionCierreDiarioId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CIERREDIARIO);

                    DepositaryWebApi.Business.Tables.Operacion.CierreDiario cierreDiarioController;
                    foreach (var cierreDiarioItem in model.CierresDiarios)
                    {
                        cierreDiarioController = new();
                        cierreDiarioItem.OrigenCierreDiario_Id = cierreDiarioItem.Id;
                        if (model.Sesiones.Count > 0)
                        {
                            var sesionAsociada = model.Sesiones.Where(x => x.OrigenSesion_Id == cierreDiarioItem.SesionId).FirstOrDefault();
                            if (sesionAsociada != null)
                                cierreDiarioItem.SesionId = sesionAsociada.Id;
                            else
                                cierreDiarioItem.SesionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_SESION, depositarioId, cierreDiarioItem.SesionId).Value;
                        }
                        else
                            cierreDiarioItem.SesionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_SESION, depositarioId, cierreDiarioItem.SesionId).Value;

                        Int64? idCierreDiarioExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CIERREDIARIO, depositarioId, cierreDiarioItem.OrigenCierreDiario_Id.Value);
                        if (idCierreDiarioExistente.HasValue)
                        {
                            cierreDiarioItem.Id = idCierreDiarioExistente.Value;
                            cierreDiarioController.Update(cierreDiarioItem);
                        }
                        else
                            cierreDiarioController.Add(cierreDiarioItem);

                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionCierreDiarioId.Value, cierreDiarioItem.OrigenCierreDiario_Id.Value, cierreDiarioItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionCierreDiarioId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionCierreDiarioId.Value);
                }


                if (model.Turnos.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionTurnoId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TURNO);

                    DepositaryWebApi.Business.Tables.Operacion.Turno turnoController;
                    foreach (var turnoItem in model.Turnos)
                    {
                        turnoController = new();
                        turnoItem.OrigenTurno_Id = turnoItem.Id;
                        if (turnoItem.CierreDiarioId.HasValue)
                        {
                            if (model.CierresDiarios.Count > 0)
                            {
                                var cierreDiarioAsociado = model.CierresDiarios.Where(x => x.OrigenCierreDiario_Id == turnoItem.CierreDiarioId).FirstOrDefault();
                                if (cierreDiarioAsociado != null)
                                    turnoItem.CierreDiarioId = cierreDiarioAsociado.Id;
                                else
                                    turnoItem.CierreDiarioId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CIERREDIARIO, depositarioId, turnoItem.CierreDiarioId.Value).Value;
                            }
                            else
                                turnoItem.CierreDiarioId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CIERREDIARIO, depositarioId, turnoItem.CierreDiarioId.Value).Value;
                        }

                        Int64? idTurnoExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TURNO, depositarioId, turnoItem.OrigenTurno_Id.Value);
                        if (idTurnoExistente.HasValue)
                        {
                            turnoItem.Id = idTurnoExistente.Value;
                            turnoController.Update(turnoItem);
                        }
                        else
                            turnoController.Add(turnoItem);

                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionTurnoId.Value, turnoItem.OrigenTurno_Id.Value, turnoItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTurnoId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionTurnoId.Value);
                }

                if (model.Transacciones.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionTransaccionId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TRANSACCION);
                    Int64? SincronizacionTransaccionDetalleId = null;
                    Int64? SincronizacionTransaccionSobreId = null;
                    Int64? SincronizacionTransaccionSobreDetalleId = null;

                    DepositaryWebApi.Business.Tables.Operacion.Transaccion transaccionController;
                    foreach (var transaccionItem in model.Transacciones)
                    {
                        transaccionController = new();
                        transaccionItem.OrigenTransaccion_Id = transaccionItem.Id;
                        Int64? idTransaccionExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TRANSACCION, depositarioId, transaccionItem.OrigenTransaccion_Id.Value);
                        if (!idTransaccionExistente.HasValue)
                        {
                            if (transaccionItem.SesionId.HasValue)
                            {
                                if (model.Sesiones.Count > 0)
                                {
                                    var SesionAsociada = model.Sesiones.Where(x => x.OrigenSesion_Id == transaccionItem.SesionId).FirstOrDefault();
                                    if (SesionAsociada != null)
                                        transaccionItem.SesionId = SesionAsociada.Id;
                                    else
                                        transaccionItem.SesionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_SESION, depositarioId, transaccionItem.SesionId.Value).Value;
                                }
                                else
                                    transaccionItem.SesionId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_SESION, depositarioId, transaccionItem.SesionId.Value).Value;
                            }

                            if (transaccionItem.CierreDiarioId.HasValue)
                            {
                                if (model.CierresDiarios.Count > 0)
                                {
                                    var cierreDiarioAsociado = model.CierresDiarios.Where(x => x.OrigenCierreDiario_Id == transaccionItem.CierreDiarioId).FirstOrDefault();
                                    if (cierreDiarioAsociado != null)
                                        transaccionItem.CierreDiarioId = cierreDiarioAsociado.Id;
                                    else
                                        transaccionItem.CierreDiarioId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CIERREDIARIO, depositarioId, transaccionItem.CierreDiarioId.Value).Value;
                                }
                                else
                                    transaccionItem.CierreDiarioId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CIERREDIARIO, depositarioId, transaccionItem.CierreDiarioId.Value).Value;
                            }

                            if (model.Turnos.Count > 0)
                            {
                                var turnoAsociado = model.Turnos.Where(x => x.OrigenTurno_Id == transaccionItem.TurnoId).FirstOrDefault();
                                if (turnoAsociado != null)
                                    transaccionItem.TurnoId = turnoAsociado.Id;
                                else
                                    transaccionItem.TurnoId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TURNO, depositarioId, transaccionItem.TurnoId).Value;
                            }
                            else
                                transaccionItem.TurnoId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TURNO, depositarioId, transaccionItem.TurnoId).Value;

                            if (model.Contenedores.Count > 0)
                            {
                                var contenedorAsociado = model.Contenedores.Where(x => x.OrigenContenedor_Id == transaccionItem.ContenedorId).FirstOrDefault();
                                if (contenedorAsociado != null)
                                    transaccionItem.ContenedorId = contenedorAsociado.Id;
                                else
                                    transaccionItem.ContenedorId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CONTENEDOR, depositarioId, transaccionItem.ContenedorId).Value;
                            }
                            else
                                transaccionItem.ContenedorId = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_CONTENEDOR, depositarioId, transaccionItem.ContenedorId).Value;

                            var newTransaccionEntity = transaccionController.Add(transaccionItem);

                            SynchronizationController.guardarDetalleSincronizacion(SincronizacionTransaccionId.Value, transaccionItem.OrigenTransaccion_Id.Value, transaccionItem.Id);

                            if (newTransaccionEntity != null)
                            {
                                bool existenTransaccionesDetalles = model.TransaccionesDetalles.Exists(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);
                                bool existeTransaccionSobre = model.TransaccionesSobres.Exists(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);

                                if (existenTransaccionesDetalles)
                                {
                                    var transaccionesDetalles = model.TransaccionesDetalles.Where(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);

                                    //Iniciamos un registro de sincronizacion de la entidad
                                    if (!SincronizacionTransaccionDetalleId.HasValue)
                                        SincronizacionTransaccionDetalleId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TRANSACCIONDETALLE);

                                    DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle transaccionDetalleController;
                                    foreach (var transaccionDetalle in transaccionesDetalles)
                                    {

                                        transaccionDetalleController = new();
                                        transaccionDetalle.TransaccionId = transaccionItem.Id;
                                        transaccionDetalle.OrigenTransaccionDetalle_Id = transaccionDetalle.Id;
                                        Int64? idTransaccionDetalleExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TRANSACCIONDETALLE, depositarioId, transaccionDetalle.OrigenTransaccionDetalle_Id.Value);

                                        if (!idTransaccionDetalleExistente.HasValue)
                                        {
                                            var newTransaccionDetalleEntity = transaccionDetalleController.AddOrUpdate(transaccionDetalle);
                                            SynchronizationController.guardarDetalleSincronizacion(SincronizacionTransaccionDetalleId.Value, transaccionDetalle.OrigenTransaccionDetalle_Id.Value, transaccionDetalle.Id);
                                        }
                                    }
                                }
                                else if (existeTransaccionSobre)
                                {
                                    var transaccionSobre = model.TransaccionesSobres.Where(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id).FirstOrDefault();
                                    //Iniciamos un registro de sincronizacion de la entidad
                                    if (!SincronizacionTransaccionSobreId.HasValue)
                                        SincronizacionTransaccionSobreId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TRANSACCIONSOBRE);

                                    DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre transaccionSobreController;
                                    transaccionSobreController = new();
                                    transaccionSobre.OrigenTransaccionSobre_Id = transaccionSobre.Id;

                                    Int64? idTransaccionSobreExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TRANSACCIONSOBRE, depositarioId, transaccionSobre.OrigenTransaccionSobre_Id.Value);

                                    if (!idTransaccionSobreExistente.HasValue)
                                    {
                                        transaccionSobre.TransaccionId = transaccionItem.Id;
                                        var newTransaccionSobreEntity = transaccionSobreController.Add(transaccionSobre);

                                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionTransaccionSobreId.Value, transaccionSobre.OrigenTransaccionSobre_Id.Value, transaccionSobre.Id);

                                        if (newTransaccionSobreEntity != null)
                                        {
                                            bool existenTransaccionesSobresDetalles = model.TransaccionesSobresDetalles.Exists(x => x.SobreId == transaccionSobre.OrigenTransaccionSobre_Id);

                                            if (existenTransaccionesSobresDetalles)
                                            {
                                                var transaccionesSobresDetalles = model.TransaccionesSobresDetalles.Where(x => x.SobreId == transaccionSobre.OrigenTransaccionSobre_Id);

                                                //Iniciamos un registro de sincronizacion de la entidad
                                                if (!SincronizacionTransaccionSobreDetalleId.HasValue)
                                                    SincronizacionTransaccionSobreDetalleId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TRANSACCIONSOBREDETALLE);

                                                DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalleController;
                                                foreach (var transaccionSobreDetalle in transaccionesSobresDetalles)
                                                {
                                                    transaccionSobreDetalleController = new();
                                                    transaccionSobreDetalle.SobreId = transaccionSobre.Id;
                                                    transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id = transaccionSobreDetalle.Id;

                                                    Int64? idTransaccionSobreDetalleExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_TRANSACCIONSOBREDETALLE, depositarioId, transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id.Value);

                                                    if (!idTransaccionSobreDetalleExistente.HasValue)
                                                    {
                                                        var newTransaccionSobreDetalleEntity = transaccionSobreDetalleController.AddOrUpdate(transaccionSobreDetalle);
                                                        SynchronizationController.guardarDetalleSincronizacion(SincronizacionTransaccionSobreDetalleId.Value, transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id.Value, transaccionSobreDetalle.Id);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionSobreDetalleId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionTransaccionSobreDetalleId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionSobreId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionTransaccionSobreId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionDetalleId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionTransaccionDetalleId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionId.HasValue)
                        SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionTransaccionId.Value);
                }


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SincronizarEventos")]
        [Authorize]
        public async Task<IActionResult> Eventos([FromBody] EventoModel model)
        {
            DepositaryWebApi.Business.Tables.Operacion.Evento eventoEntity = new();

            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Evento");

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
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

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

            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CONTENEDOR);

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
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

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

            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_CIERREDIARIO);

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
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

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

            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_SESION);

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
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

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

            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            //Iniciamos un registro de sincronizacion de la entidad
            Int64? SincronizacionEntidadId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TURNO);

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
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEntidadId.Value);

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
    }
}
