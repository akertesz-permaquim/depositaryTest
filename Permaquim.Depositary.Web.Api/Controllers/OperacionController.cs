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
        private readonly IConfiguration _configuration;

        public OperacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_TIPOTRANSACCION = "Operacion.TipoTransaccion";
        private const string ENTIDAD_TIPOEVENTO = "Operacion.TipoEvento";
        private const string ENTIDAD_TIPOCONTENEDOR = "Operacion.TipoContenedor";

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

            long depositarioId = SincronizacionController.ObtenerIdDepositario(model.CodigoExternoDepositario);
            DepositaryWebApi.Business.Tables.Operacion.Contenedor contenedorController = new();

            try
            {
                if (model.Contenedores.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionContenedorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Contenedor");

                    foreach (var contenedorItem in model.Contenedores)
                    {
                        contenedorItem.DepositarioId = depositarioId;
                        contenedorItem.OrigenContenedor_Id = contenedorItem.Id;
                        Int64? idContenedorExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Contenedor", depositarioId, contenedorItem.OrigenContenedor_Id.Value);
                        if (idContenedorExistente.HasValue)
                        {
                            contenedorItem.Id = idContenedorExistente.Value;
                            contenedorController.Update(contenedorItem);
                        }
                        else
                            contenedorController.Add(contenedorItem);

                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionContenedorId.Value, contenedorItem.OrigenContenedor_Id.Value, contenedorItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionContenedorId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionContenedorId.Value);
                }

                if (model.Sesiones.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionSesionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Sesion");

                    DepositaryWebApi.Business.Tables.Operacion.Sesion sesionController;
                    foreach (var sesionItem in model.Sesiones)
                    {
                        sesionController = new();
                        sesionItem.DepositarioId = depositarioId;
                        sesionItem.OrigenSesion_Id = sesionItem.Id;

                        Int64? idSesionExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Sesion", depositarioId, sesionItem.OrigenSesion_Id.Value);
                        if (idSesionExistente.HasValue)
                        {
                            sesionItem.Id = idSesionExistente.Value;
                            sesionController.Update(sesionItem);
                        }
                        else
                            sesionController.Add(sesionItem);

                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionSesionId.Value, sesionItem.OrigenSesion_Id.Value, sesionItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionSesionId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionSesionId.Value);
                }

                if (model.CierresDiarios.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionCierreDiarioId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.CierreDiario");

                    DepositaryWebApi.Business.Tables.Operacion.CierreDiario cierreDiarioController;
                    foreach (var cierreDiarioItem in model.CierresDiarios)
                    {
                        cierreDiarioController = new();
                        cierreDiarioItem.DepositarioId = depositarioId;
                        cierreDiarioItem.OrigenCierreDiario_Id = cierreDiarioItem.Id;
                        if (model.Sesiones.Count > 0)
                        {
                            var sesionAsociada = model.Sesiones.Where(x => x.OrigenSesion_Id == cierreDiarioItem.SesionId).FirstOrDefault();
                            if (sesionAsociada != null)
                                cierreDiarioItem.SesionId = sesionAsociada.Id;
                            else
                                cierreDiarioItem.SesionId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Sesion", depositarioId, cierreDiarioItem.SesionId).Value;
                        }
                        else
                            cierreDiarioItem.SesionId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Sesion", depositarioId, cierreDiarioItem.SesionId).Value;

                        Int64? idCierreDiarioExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.CierreDiario", depositarioId, cierreDiarioItem.OrigenCierreDiario_Id.Value);
                        if (idCierreDiarioExistente.HasValue)
                        {
                            cierreDiarioItem.Id = idCierreDiarioExistente.Value;
                            cierreDiarioController.Update(cierreDiarioItem);
                        }
                        else
                            cierreDiarioController.Add(cierreDiarioItem);

                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionCierreDiarioId.Value, cierreDiarioItem.OrigenCierreDiario_Id.Value, cierreDiarioItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionCierreDiarioId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionCierreDiarioId.Value);
                }


                if (model.Turnos.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionTurnoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Turno");

                    DepositaryWebApi.Business.Tables.Operacion.Turno turnoController;
                    foreach (var turnoItem in model.Turnos)
                    {
                        turnoController = new();
                        turnoItem.DepositarioId = depositarioId;
                        turnoItem.OrigenTurno_Id = turnoItem.Id;
                        if (turnoItem.CierreDiarioId.HasValue)
                        {
                            if (model.CierresDiarios.Count > 0)
                            {
                                var cierreDiarioAsociado = model.CierresDiarios.Where(x => x.OrigenCierreDiario_Id == turnoItem.CierreDiarioId).FirstOrDefault();
                                if (cierreDiarioAsociado != null)
                                    turnoItem.CierreDiarioId = cierreDiarioAsociado.Id;
                                else
                                    turnoItem.CierreDiarioId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.CierreDiario", depositarioId, turnoItem.CierreDiarioId.Value).Value;
                            }
                            else
                                turnoItem.CierreDiarioId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.CierreDiario", depositarioId, turnoItem.CierreDiarioId.Value).Value;
                        }

                        Int64? idTurnoExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Turno", depositarioId, turnoItem.OrigenTurno_Id.Value);
                        if (idTurnoExistente.HasValue)
                        {
                            turnoItem.Id = idTurnoExistente.Value;
                            turnoController.Update(turnoItem);
                        }
                        else
                            turnoController.Add(turnoItem);

                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionTurnoId.Value, turnoItem.OrigenTurno_Id.Value, turnoItem.Id);
                    }

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTurnoId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionTurnoId.Value);
                }

                if (model.Transacciones.Count > 0)
                {
                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionTransaccionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.Transaccion");
                    Int64? SincronizacionTransaccionDetalleId = null;
                    Int64? SincronizacionTransaccionSobreId = null;
                    Int64? SincronizacionTransaccionSobreDetalleId = null;

                    DepositaryWebApi.Business.Tables.Operacion.Transaccion transaccionController;
                    foreach (var transaccionItem in model.Transacciones)
                    {
                        transaccionController = new();
                        transaccionItem.DepositarioId = depositarioId;
                        transaccionItem.OrigenTransaccion_Id = transaccionItem.Id;
                        Int64? idTransaccionExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Transaccion", depositarioId, transaccionItem.OrigenTransaccion_Id.Value);
                        if (!idTransaccionExistente.HasValue)
                        {
                            if (model.Sesiones.Count > 0)
                            {
                                var SesionAsociada = model.Sesiones.Where(x => x.OrigenSesion_Id == transaccionItem.SesionId).FirstOrDefault();
                                if (SesionAsociada != null)
                                    transaccionItem.SesionId = SesionAsociada.Id;
                                else
                                    transaccionItem.SesionId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Sesion", depositarioId, transaccionItem.SesionId).Value;
                            }
                            else
                                transaccionItem.SesionId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Sesion", depositarioId, transaccionItem.SesionId).Value;

                            if (transaccionItem.CierreDiarioId.HasValue)
                            {
                                if (model.CierresDiarios.Count > 0)
                                {
                                    var cierreDiarioAsociado = model.CierresDiarios.Where(x => x.OrigenCierreDiario_Id == transaccionItem.CierreDiarioId).FirstOrDefault();
                                    if (cierreDiarioAsociado != null)
                                        transaccionItem.CierreDiarioId = cierreDiarioAsociado.Id;
                                    else
                                        transaccionItem.CierreDiarioId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.CierreDiario", depositarioId, transaccionItem.CierreDiarioId.Value).Value;
                                }
                                else
                                    transaccionItem.CierreDiarioId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.CierreDiario", depositarioId, transaccionItem.CierreDiarioId.Value).Value;
                            }

                            if (model.Turnos.Count > 0)
                            {
                                var turnoAsociado = model.Turnos.Where(x => x.OrigenTurno_Id == transaccionItem.TurnoId).FirstOrDefault();
                                if (turnoAsociado != null)
                                    transaccionItem.TurnoId = turnoAsociado.Id;
                                else
                                    transaccionItem.TurnoId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Turno", depositarioId, transaccionItem.TurnoId).Value;
                            }
                            else
                                transaccionItem.TurnoId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Turno", depositarioId, transaccionItem.TurnoId).Value;

                            if (model.Contenedores.Count > 0)
                            {
                                var contenedorAsociado = model.Contenedores.Where(x => x.OrigenContenedor_Id == transaccionItem.ContenedorId).FirstOrDefault();
                                if (contenedorAsociado != null)
                                    transaccionItem.ContenedorId = contenedorAsociado.Id;
                                else
                                    transaccionItem.ContenedorId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Contenedor", depositarioId, transaccionItem.ContenedorId).Value;
                            }
                            else
                                transaccionItem.ContenedorId = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.Contenedor", depositarioId, transaccionItem.ContenedorId).Value;

                            var newTransaccionEntity = transaccionController.Add(transaccionItem);

                            SincronizacionController.guardarDetalleSincronizacion(SincronizacionTransaccionId.Value, transaccionItem.OrigenTransaccion_Id.Value, transaccionItem.Id);

                            if (newTransaccionEntity != null)
                            {
                                bool existenTransaccionesDetalles = model.TransaccionesDetalles.Exists(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);
                                bool existeTransaccionSobre = model.TransaccionesSobres.Exists(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);

                                if (existenTransaccionesDetalles)
                                {
                                    var transaccionesDetalles = model.TransaccionesDetalles.Where(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id);

                                    //Iniciamos un registro de sincronizacion de la entidad
                                    if (!SincronizacionTransaccionDetalleId.HasValue)
                                        SincronizacionTransaccionDetalleId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.TransaccionDetalle");

                                    DepositaryWebApi.Business.Tables.Operacion.TransaccionDetalle transaccionDetalleController;
                                    foreach (var transaccionDetalle in transaccionesDetalles)
                                    {

                                        transaccionDetalleController = new();
                                        transaccionDetalle.TransaccionId = transaccionItem.Id;
                                        transaccionDetalle.OrigenTransaccionDetalle_Id = transaccionDetalle.Id;
                                        Int64? idTransaccionDetalleExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.TransaccionDetalle", depositarioId, transaccionDetalle.OrigenTransaccionDetalle_Id.Value);

                                        if (!idTransaccionDetalleExistente.HasValue)
                                        {
                                            var newTransaccionDetalleEntity = transaccionDetalleController.AddOrUpdate(transaccionDetalle);
                                            SincronizacionController.guardarDetalleSincronizacion(SincronizacionTransaccionDetalleId.Value, transaccionDetalle.OrigenTransaccionDetalle_Id.Value, transaccionDetalle.Id);
                                        }
                                    }
                                }
                                else if (existeTransaccionSobre)
                                {
                                    var transaccionSobre = model.TransaccionesSobres.Where(x => x.TransaccionId == transaccionItem.OrigenTransaccion_Id).FirstOrDefault();
                                    //Iniciamos un registro de sincronizacion de la entidad
                                    if (!SincronizacionTransaccionSobreId.HasValue)
                                        SincronizacionTransaccionSobreId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.TransaccionSobre");

                                    DepositaryWebApi.Business.Tables.Operacion.TransaccionSobre transaccionSobreController;
                                    transaccionSobreController = new();
                                    transaccionSobre.OrigenTransaccionSobre_Id = transaccionSobre.Id;

                                    Int64? idTransaccionSobreExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.TransaccionSobre", depositarioId, transaccionSobre.OrigenTransaccionSobre_Id.Value);

                                    if (!idTransaccionSobreExistente.HasValue)
                                    {
                                        transaccionSobre.TransaccionId = transaccionItem.Id;
                                        var newTransaccionSobreEntity = transaccionSobreController.Add(transaccionSobre);

                                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionTransaccionSobreId.Value, transaccionSobre.OrigenTransaccionSobre_Id.Value, transaccionSobre.Id);

                                        if (newTransaccionSobreEntity != null)
                                        {
                                            bool existenTransaccionesSobresDetalles = model.TransaccionesSobresDetalles.Exists(x => x.SobreId == transaccionSobre.OrigenTransaccionSobre_Id);

                                            if (existenTransaccionesSobresDetalles)
                                            {
                                                var transaccionesSobresDetalles = model.TransaccionesSobresDetalles.Where(x => x.SobreId == transaccionSobre.OrigenTransaccionSobre_Id);

                                                //Iniciamos un registro de sincronizacion de la entidad
                                                if (!SincronizacionTransaccionSobreDetalleId.HasValue)
                                                    SincronizacionTransaccionSobreDetalleId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, "Operacion.TransaccionSobreDetalle");

                                                DepositaryWebApi.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalleController;
                                                foreach (var transaccionSobreDetalle in transaccionesSobresDetalles)
                                                {
                                                    transaccionSobreDetalleController = new();
                                                    transaccionSobreDetalle.SobreId = transaccionSobre.Id;
                                                    transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id = transaccionSobreDetalle.Id;

                                                    Int64? idTransaccionSobreDetalleExistente = SincronizacionController.obtenerIdDestinoDetalleSincronizacion("Operacion.TransaccionSobreDetalle", depositarioId, transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id.Value);

                                                    if (!idTransaccionSobreDetalleExistente.HasValue)
                                                    {
                                                        var newTransaccionSobreDetalleEntity = transaccionSobreDetalleController.AddOrUpdate(transaccionSobreDetalle);
                                                        SincronizacionController.guardarDetalleSincronizacion(SincronizacionTransaccionSobreDetalleId.Value, transaccionSobreDetalle.OrigenTransaccionSobreDetalle_Id.Value, transaccionSobreDetalle.Id);
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
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionTransaccionSobreDetalleId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionSobreId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionTransaccionSobreId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionDetalleId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionTransaccionDetalleId.Value);

                    //Cerramos el registro de sincronizacion de la entidad
                    if (SincronizacionTransaccionId.HasValue)
                        SincronizacionController.finalizarCabeceraSincronizacion(SincronizacionTransaccionId.Value);
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
        [Route("ObtenerOperacion")]
        [Authorize]
        public async Task<IActionResult> ObtenerOperacion()
        {
            OperacionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroOperacionTipoEventoId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO);

                if (SincroOperacionTipoEventoId.HasValue)
                {
                    data.TiposEventos = ObtenerTiposEventosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroOperacionTipoEventoId.Value);
                }

                Int64? SincroOperacionTipoContenedorId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR);

                if (SincroOperacionTipoContenedorId.HasValue)
                {
                    data.TiposContenedores = ObtenerTiposContenedoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroOperacionTipoContenedorId.Value);
                }

                Int64? SincroOperacionTipoTransaccionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION);

                if (SincroOperacionTipoTransaccionId.HasValue)
                {
                    data.TiposTransacciones = ObtenerTiposTransaccionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION));
                    SincronizacionController.finalizarCabeceraSincronizacion(SincroOperacionTipoTransaccionId.Value);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerTiposTransacciones")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposTransacciones()
        {
            OperacionTipoTransaccionModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposTransacciones = ObtenerTiposTransaccionesBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOTRANSACCION));
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
        [Route("ObtenerTiposContenedores")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposContenedores()
        {
            OperacionTipoContenedorModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposContenedores = ObtenerTiposContenedoresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOCONTENEDOR));
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
        [Route("ObtenerTiposEventos")]
        [Authorize]
        public async Task<IActionResult> ObtenerTiposEventos()
        {
            OperacionTipoEventoModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO);

            if (SincronizacionId.HasValue)
            {
                try
                {
                    data.TiposEventos = ObtenerTiposEventosBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_TIPOEVENTO));
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

        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> ObtenerTiposTransaccionesBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoTransaccion.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> ObtenerTiposContenedoresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoContenedor oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoContenedor.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoContenedor.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
        private List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> ObtenerTiposEventosBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> result = new();
            DepositaryWebApi.Business.Tables.Operacion.TipoEvento oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Operacion.TipoEvento.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Operacion.TipoEvento.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

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
