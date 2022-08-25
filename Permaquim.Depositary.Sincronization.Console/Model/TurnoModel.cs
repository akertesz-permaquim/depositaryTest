using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class TurnoModel : IModel
    {
        public List<Depositario.Entities.Tables.Turno.EsquemaTurno> Esquemas { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.EsquemaDetalleTurno> EsquemasDetalles { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.AgendaTurno> Agendas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquemaTurno = SynchronizationController.obtenerFechaUltimaSincronizacion("Turno.EsquemaTurno");

            SincroDates.Add("Turno.EsquemaTurno", fechaSincroEsquemaTurno);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquemaDetalleTurno = SynchronizationController.obtenerFechaUltimaSincronizacion("Turno.EsquemaDetalleTurno");

            SincroDates.Add("Turno.EsquemaDetalleTurno", fechaSincroEsquemaDetalleTurno);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroAgendaTurno = SynchronizationController.obtenerFechaUltimaSincronizacion("Turno.AgendaTurno");

            SincroDates.Add("Turno.AgendaTurno", fechaSincroAgendaTurno);

        }
        public void Persist()
        {
            try
            {
                if (Esquemas.Count > 0)
                {
                    Depositario.Business.Tables.Turno.EsquemaTurno esquemaTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Turno.EsquemaTurno");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Esquemas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Turno.EsquemaTurno", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                esquemaTurno.Update(item);
                            }
                            else
                            {
                                esquemaTurno.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (EsquemasDetalles.Count > 0)
                {
                    Depositario.Business.Tables.Turno.EsquemaDetalleTurno esquemaDetalleTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Turno.EsquemaDetalleTurno");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EsquemasDetalles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Turno.EsquemaDetalleTurno", item.Id);

                            Int64? esquemaTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Turno.EsquemaTurno", item.EsquemaTurnoId);

                            if (esquemaTurnoIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EsquemaTurnoId = esquemaTurnoIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    esquemaDetalleTurno.Update(item);
                                }
                                else
                                {
                                    esquemaDetalleTurno.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Agendas.Count > 0)
                {
                    Depositario.Business.Tables.Turno.AgendaTurno agendaTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Turno.AgendaTurno");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Agendas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Turno.AgendaTurno", item.Id);

                            Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sector", item.SectorId);
                            Int64? esquemaDetalleTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Turno.EsquemaDetalleTurno", item.EsquemaDetalleTurnoId);


                            if (esquemaDetalleTurnoIdOrigen.HasValue && sectorIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EsquemaDetalleTurnoId = esquemaDetalleTurnoIdOrigen.Value;
                                item.SectorId = sectorIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    agendaTurno.Update(item);
                                }
                                else
                                {
                                    agendaTurno.Add(item);
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
