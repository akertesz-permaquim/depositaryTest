using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ImpresionModel : IModel
    {
        public List<Depositario.Entities.Tables.Impresion.TipoTicket> TiposTickets { get; set; } = new();
        public List<Depositario.Entities.Tables.Impresion.Ticket> Tickets { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoTicket = SynchronizationController.obtenerFechaUltimaSincronizacion("Impresion.TipoTicket");

            SincroDates.Add("Impresion.TipoTicket", fechaSincroTipoTicket);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTicket = SynchronizationController.obtenerFechaUltimaSincronizacion("Impresion.Ticket");

            SincroDates.Add("Impresion.Ticket", fechaSincroTicket);
        }
        public void Persist()
        {
            try
            {
                if (TiposTickets.Count > 0)
                {
                    Depositario.Business.Tables.Impresion.TipoTicket tipoTicket = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Impresion.TipoTicket");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposTickets)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Impresion.TipoTicket", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                tipoTicket.Update(item);
                            }
                            else
                            {
                                tipoTicket.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Tickets.Count > 0)
                {
                    Depositario.Business.Tables.Impresion.Ticket ticket = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Impresion.Ticket");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Tickets)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Impresion.Ticket", item.Id);

                            Int64? tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Impresion.TipoTicket", item.TipoId);
                            Int64? depositarioModeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Modelo", item.DepositarioModeloId);
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);

                            if (tipoIdOrigen.HasValue && depositarioModeloIdOrigen.HasValue && empresaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoIdOrigen.Value;
                                item.DepositarioModeloId = depositarioModeloIdOrigen.Value;
                                item.EmpresaId = empresaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    ticket.Update(item);
                                }
                                else
                                {
                                    ticket.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
