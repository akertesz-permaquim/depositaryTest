using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ImpresionModel : IModel
    {
        public List<Depositario.Entities.Tables.Impresion.TipoTicket> TiposTickets { get; set; } = new();
        public List<Depositario.Entities.Tables.Impresion.Ticket> Tickets { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoTicket = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Impresion_TipoTicket);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Impresion_TipoTicket).Replace("_", "."), fechaSincroTipoTicket);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTicket = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Impresion_Ticket);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Impresion_Ticket).Replace("_", "."), fechaSincroTicket);
        }
        public void Persist()
        {
            try
            {

                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposTickets.Count > 0)
                {
                    Depositario.Business.Tables.Impresion.TipoTicket tipoTicket = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Impresion_TipoTicket, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposTickets)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Impresion_TipoTicket, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Tickets.Count > 0)
                {
                    Depositario.Business.Tables.Impresion.Ticket ticket = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Impresion_Ticket, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoIdOrigen;
                        Int64? depositarioModeloIdOrigen;
                        Int64? empresaIdOrigen;
                        foreach (var item in Tickets)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Impresion_Ticket, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Impresion_TipoTicket, item.TipoId);
                            depositarioModeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.DepositarioModeloId);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);

                            if (tipoIdOrigen.HasValue && depositarioModeloIdOrigen.HasValue && empresaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoIdOrigen.Value;
                                item.DepositarioModeloId = depositarioModeloIdOrigen.Value;
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
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
