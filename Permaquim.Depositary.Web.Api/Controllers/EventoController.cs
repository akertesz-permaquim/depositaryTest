using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EventoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_EVENTO = "Operacion.Evento";
        private const string ENTIDAD_DEPOSITARIOESTADO = "Dispositivo.DepositarioEstado";

        #region PostEndpoints

        [HttpPost]
        [Route("SincronizarEventos")]
        [Authorize]
        public async Task<IActionResult> Eventos([FromBody] EventoModel model)
        {
            long depositarioId = SynchronizationController.ObtenerIdDepositario(model.CodigoExternoDepositario);

            try
            {
                if (model.Eventos.Count > 0)
                {
                    DepositaryWebApi.Business.Tables.Operacion.Evento eventoController = new();

                    //Iniciamos un registro de sincronizacion de la entidad
                    Int64? SincronizacionEventoId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_EVENTO);
                    Int64? idEventoExistente;
                    foreach (var eventoItem in model.Eventos)
                    {
                        eventoItem.OrigenEvento_Id = eventoItem.Id;
                        idEventoExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_EVENTO, depositarioId, eventoItem.OrigenEvento_Id.Value);
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

                DepositaryWebApi.Business.Tables.Dispositivo.DepositarioEstado estadoDepositarioController = new();

                //Iniciamos un registro de sincronizacion de la entidad
                Int64? SincronizacionEstadoDispositivoId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_DEPOSITARIOESTADO);
                Int64? idEstadoDepositarioExistente;

                model.Estado.OrigenEstado_Id = model.Estado.Id;
                idEstadoDepositarioExistente = SynchronizationController.obtenerIdDestinoDetalleSincronizacion(ENTIDAD_DEPOSITARIOESTADO, depositarioId, model.Estado.OrigenEstado_Id.Value);
                if (idEstadoDepositarioExistente.HasValue)
                {
                    model.Estado.Id = idEstadoDepositarioExistente.Value;
                    estadoDepositarioController.Update(model.Estado);
                }
                else
                    estadoDepositarioController.Add(model.Estado);

                SynchronizationController.guardarDetalleSincronizacion(SincronizacionEstadoDispositivoId.Value, model.Estado.OrigenEstado_Id.Value, model.Estado.Id);

                //Cerramos el registro de sincronizacion de la entidad
                if (SincronizacionEstadoDispositivoId.HasValue)
                    SynchronizationController.finalizarCabeceraSincronizacion(SincronizacionEstadoDispositivoId.Value);

                return Ok();
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}
