﻿using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class EstiloModel : IModel
    {

        public List<Depositario.Entities.Tables.Estilo.Esquema> Esquema { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquema = SynchronizationController.obtenerFechaUltimaSincronizacion("Estilo.Esquema");

            SincroDates.Add("Estilo.Esquema", fechaSincroEsquema);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEsquemaDetalle = SynchronizationController.obtenerFechaUltimaSincronizacion("Estilo.EsquemaDetalle");

            SincroDates.Add("Estilo.EsquemaDetalle", fechaSincroEsquemaDetalle);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoEsquemaDetalle = SynchronizationController.obtenerFechaUltimaSincronizacion("Estilo.TipoEsquemaDetalle");

            SincroDates.Add("Estilo.TipoEsquemaDetalle", fechaSincroTipoEsquemaDetalle);
        }

        public void Persist()
        {
            try
            {
                if (TipoEsquemaDetalle.Count > 0)
                {
                    Depositario.Business.Tables.Estilo.TipoEsquemaDetalle oTipoEsquemaDetalle = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Estilo.TipoEsquemaDetalle");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TipoEsquemaDetalle)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.TipoEsquemaDetalle", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un AddOrUpdate con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                oTipoEsquemaDetalle.AddOrUpdate(item);
                            }
                            else
                            {
                                oTipoEsquemaDetalle.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Esquema.Count > 0)
                {
                    Depositario.Business.Tables.Estilo.Esquema oEsquema = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Estilo.Esquema");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Esquema)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.Esquema", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un AddOrUpdate con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                oEsquema.AddOrUpdate(item);
                            }
                            else
                            {
                                oEsquema.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (EsquemaDetalle.Count > 0)
                {
                    Depositario.Business.Tables.Estilo.EsquemaDetalle oEsquemaDetalle = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Estilo.EsquemaDetalle");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EsquemaDetalle)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.EsquemaDetalle", item.Id);

                            Int64? esquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.Esquema", item.EsquemaId);
                            Int64? tipoEsquemaDetalleIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.TipoEsquemaDetalle", item.TipoEsquemaDetalleId);

                            if (esquemaIdOrigen.HasValue && tipoEsquemaDetalleIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EsquemaId = esquemaIdOrigen.Value;
                                item.TipoEsquemaDetalleId = tipoEsquemaDetalleIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un AddOrUpdate con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    oEsquemaDetalle.AddOrUpdate(item);
                                }
                                else
                                {
                                    oEsquemaDetalle.Add(item);
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
