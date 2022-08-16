using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class RegionalizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Regionalizacion.Lenguaje> Lenguaje { get; set; } = new();

        public List<Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; } = new();

        void IModel.Process()
        {
            try
            {
                if (Lenguaje.Count > 0)
                {
                    Depositario.Business.Tables.Regionalizacion.Lenguaje lenguaje = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Regionalizacion.Lenguaje");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Lenguaje)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Regionalizacion.Lenguaje", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (lenguajeIdOrigen.HasValue)
                            {
                                item.Id = lenguajeIdOrigen.Value;
                                lenguaje.Update(item);
                            }
                            else
                            {
                                lenguaje.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }


                if (LenguajeItems.Count > 0)
                {
                    Depositario.Business.Tables.Regionalizacion.LenguajeItem lenguajeItem = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Regionalizacion.LenguajeItem");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in LenguajeItems)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? lenguajeItemIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Regionalizacion.LenguajeItem", item.Id);

                            Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Regionalizacion.Lenguaje", item.LenguajeId);

                            if (lenguajeIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.LenguajeId = lenguajeIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (lenguajeIdOrigen.HasValue)
                                {
                                    item.Id = lenguajeIdOrigen.Value;
                                    lenguajeItem.Update(item);
                                }
                                else
                                {
                                    lenguajeItem.Add(item);
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
        void IModel.Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public void Persist()
        {
            throw new NotImplementedException();
        }


    }
}
