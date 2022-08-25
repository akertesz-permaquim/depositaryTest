using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ValorModel : IModel
    {
        public List<Depositario.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.OrigenValor> OrigenesValores { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();


        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipo = SynchronizationController.obtenerFechaUltimaSincronizacion("Valor.Tipo");

            SincroDates.Add("Valor.Tipo", fechaSincroTipo);

            DateTime fechaSincroMoneda = SynchronizationController.obtenerFechaUltimaSincronizacion("Valor.Moneda");

            SincroDates.Add("Valor.Moneda", fechaSincroMoneda);

            DateTime fechaSincroDenominacion = SynchronizationController.obtenerFechaUltimaSincronizacion("Valor.Denominacion");

            SincroDates.Add("Valor.Denominacion", fechaSincroDenominacion);

            DateTime fechaSincroRelacionMonedaTipoValor = SynchronizationController.obtenerFechaUltimaSincronizacion("Valor.RelacionMonedaTipoValor");

            SincroDates.Add("Valor.RelacionMonedaTipoValor", fechaSincroRelacionMonedaTipoValor);

            DateTime fechaSincroOrigenValor = SynchronizationController.obtenerFechaUltimaSincronizacion("Valor.OrigenValor");

            SincroDates.Add("Valor.OrigenValor", fechaSincroOrigenValor);

        }
        public void Persist()
        {
            try
            {
                if (Tipos.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Tipo tipo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Valor.Tipo");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Tipos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Tipo", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                tipo.Update(item);
                            }
                            else
                            {
                                tipo.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (OrigenesValores.Count > 0)
                {
                    Depositario.Business.Tables.Valor.OrigenValor origenValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Valor.OrigenValor");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in OrigenesValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.OrigenValor", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                origenValor.Update(item);
                            }
                            else
                            {
                                origenValor.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Monedas.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Moneda moneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Valor.Moneda");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Monedas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.Id);

                            Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Pais", item.PaisId);

                            if (paisIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PaisId = paisIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    moneda.Update(item);
                                }
                                else
                                {
                                    moneda.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Denominaciones.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Denominacion denominacion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Valor.Denominacion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Denominaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Denominacion", item.Id);

                            Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Tipo", item.TipoValorId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);

                            if (tipoValorIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoValorId = tipoValorIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    denominacion.Update(item);
                                }
                                else
                                {
                                    denominacion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (RelacionesMonedasTiposValores.Count > 0)
                {
                    Depositario.Business.Tables.Valor.RelacionMonedaTipoValor relacionMonedaTipoValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Valor.RelacionMonedaTipoValor");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in RelacionesMonedasTiposValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.RelacionMonedaTipoValor", item.Id);

                            Int64? tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Tipo", item.TipoValorId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);

                            if (tipoValorIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoValorId = tipoValorIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    relacionMonedaTipoValor.Update(item);
                                }
                                else
                                {
                                    relacionMonedaTipoValor.Add(item);
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
