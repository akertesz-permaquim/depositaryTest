﻿using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class TurnoModel : IModel
    {
        public List<Depositario.Entities.Tables.Turno.EsquemaTurno> Esquemas { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.EsquemaDetalleTurno> EsquemasDetalles { get; set; } = new();
        public List<Depositario.Entities.Tables.Turno.AgendaTurno> Agendas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;


        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquemaTurno = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Turno_EsquemaTurno);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Turno_EsquemaTurno).Replace("_", "."), fechaSincroEsquemaTurno);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquemaDetalleTurno = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno).Replace("_", "."), fechaSincroEsquemaDetalleTurno);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroAgendaTurno = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Turno_AgendaTurno);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Turno_AgendaTurno).Replace("_", "."), fechaSincroAgendaTurno);

        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (Esquemas.Count > 0)
                {
                    Depositario.Business.Tables.Turno.EsquemaTurno esquemaTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_EsquemaTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Esquemas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_EsquemaTurno, item.Id);
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
                                    esquemaTurno.Update(item);
                                }
                                else
                                {
                                    esquemaTurno.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (EsquemasDetalles.Count > 0)
                {
                    Depositario.Business.Tables.Turno.EsquemaDetalleTurno esquemaDetalleTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? esquemaTurnoIdOrigen;
                        foreach (var item in EsquemasDetalles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            esquemaTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_EsquemaTurno, item.EsquemaTurnoId);

                            if (esquemaTurnoIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EsquemaTurnoId = esquemaTurnoIdOrigen.Value;
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
                                    esquemaDetalleTurno.Update(item);
                                }
                                else
                                {
                                    esquemaDetalleTurno.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Agendas.Count > 0)
                {
                    Depositario.Business.Tables.Turno.AgendaTurno agendaTurno = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Turno_AgendaTurno, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? sectorIdOrigen;
                        Int64? esquemaDetalleTurnoIdOrigen;
                        foreach (var item in Agendas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_AgendaTurno, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);
                            esquemaDetalleTurnoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_EsquemaDetalleTurno, item.EsquemaDetalleTurnoId);

                            if (esquemaDetalleTurnoIdOrigen.HasValue && sectorIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EsquemaDetalleTurnoId = esquemaDetalleTurnoIdOrigen.Value;
                                item.SectorId = sectorIdOrigen.Value;
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
                                    agendaTurno.Update(item);
                                }
                                else
                                {
                                    agendaTurno.Add(item);
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
