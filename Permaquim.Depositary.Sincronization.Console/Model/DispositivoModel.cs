using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    internal class DispositivoModel : IModel
    {
        public List<Depositario.Entities.Tables.Dispositivo.Modelo> Modelos { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Marca> Marcas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMoneda> PlantillasMonedas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.PlantillaMonedaDetalle> PlantillasMonedasDetalles { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Depositario> Depositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoPlaca> TiposPlacas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoPlaca> ComandosPlacas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> TiposConfiguraciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioPlaca> PlacasDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionesDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoContadora> TiposContadoras { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioContadora> ContadorasDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoContadora> ComandosContadoras { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> MonedasDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioEstado> EstadosDepositarios { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public void Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoConfiguracionDepositario = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.TipoConfiguracionDepositario");

            SincroDates.Add("Dispositivo.TipoConfiguracionDepositario", fechaSincroTipoConfiguracionDepositario);

            DateTime fechaSincroMarca = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.Marca");

            SincroDates.Add("Dispositivo.Marca", fechaSincroMarca);

            DateTime fechaSincroPlantillaMoneda = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.PlantillaMoneda");

            SincroDates.Add("Dispositivo.PlantillaMoneda", fechaSincroPlantillaMoneda);

            DateTime fechaSincroPlantillaMonedaDetalle = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.PlantillaMonedaDetalle");

            SincroDates.Add("Dispositivo.PlantillaMonedaDetalle", fechaSincroPlantillaMonedaDetalle);

            DateTime fechaSincroModelo = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.Modelo");

            SincroDates.Add("Dispositivo.Modelo", fechaSincroModelo);

            DateTime fechaSincroTipoContadora = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.TipoContadora");

            SincroDates.Add("Dispositivo.TipoContadora", fechaSincroTipoContadora);

            DateTime fechaSincroTipoPlaca = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.TipoPlaca");

            SincroDates.Add("Dispositivo.TipoPlaca", fechaSincroTipoPlaca);

            DateTime fechaSincroDepositario = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.Depositario");

            SincroDates.Add("Dispositivo.Depositario", fechaSincroDepositario);

            DateTime fechaSincroDepositarioContadora = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.DepositarioContadora");

            SincroDates.Add("Dispositivo.DepositarioContadora", fechaSincroDepositarioContadora);

            DateTime fechaSincroDepositarioEstado = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.DepositarioEstado");

            SincroDates.Add("Dispositivo.DepositarioEstado", fechaSincroDepositarioEstado);

            DateTime fechaSincroDepositarioMoneda = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.DepositarioMoneda");

            SincroDates.Add("Dispositivo.DepositarioMoneda", fechaSincroDepositarioMoneda);

            DateTime fechaSincroDepositarioPlaca = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.DepositarioPlaca");

            SincroDates.Add("Dispositivo.DepositarioPlaca", fechaSincroDepositarioPlaca);

            DateTime fechaSincroComandoContadora = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.ComandoContadora");

            SincroDates.Add("Dispositivo.ComandoContadora", fechaSincroComandoContadora);

            DateTime fechaSincroComandoPlaca = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.ComandoPlaca");

            SincroDates.Add("Dispositivo.ComandoPlaca", fechaSincroComandoPlaca);

            DateTime fechaSincroConfiguracionDepositario = SynchronizationController.obtenerFechaUltimaSincronizacion("Dispositivo.ConfiguracionDepositario");

            SincroDates.Add("Dispositivo.ConfiguracionDepositario", fechaSincroConfiguracionDepositario);


        }
        public void Persist()
        {
            try
            {
                if (TiposConfiguraciones.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario tipoConfiguracionDepositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.TipoConfiguracionDepositario");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposConfiguraciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoConfiguracionDepositario", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                tipoConfiguracionDepositario.Update(item);
                            }
                            else
                            {
                                tipoConfiguracionDepositario.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Marcas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Marca marca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.Marca");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Marcas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Marca", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                marca.Update(item);
                            }
                            else
                            {
                                marca.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (PlantillasMonedas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.PlantillaMoneda plantillaMoneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.PlantillaMoneda");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlantillasMonedas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.PlantillaMoneda", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                plantillaMoneda.Update(item);
                            }
                            else
                            {
                                plantillaMoneda.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (PlantillasMonedasDetalles.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle plantillaMonedaDetalle = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.PlantillaMonedaDetalle");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlantillasMonedasDetalles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.PlantillaMonedaDetalle", item.Id);

                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.PlantillaMoneda", item.PlantillaMonedaId);

                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);

                            if(plantillaMonedaIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    plantillaMonedaDetalle.Update(item);
                                }
                                else
                                {
                                    plantillaMonedaDetalle.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Modelos.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Modelo modelo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.Modelo");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Modelos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Modelo", item.Id);

                            Int64? plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.PlantillaMoneda", item.PlantillaMonedaId);

                            Int64? marcaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Marca", item.MarcaId);

                            if (plantillaMonedaIdOrigen.HasValue && marcaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;
                                item.MarcaId = marcaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    modelo.Update(item);
                                }
                                else
                                {
                                    modelo.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposContadoras.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoContadora tipoContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.TipoContadora");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposContadoras)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoContadora", item.Id);

                            Int64? modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Modelo", item.ModeloId);

                            if (modeloIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    tipoContadora.Update(item);
                                }
                                else
                                {
                                    tipoContadora.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposPlacas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoPlaca tipoPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.TipoPlaca");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposPlacas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoPlaca", item.Id);

                            Int64? modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Modelo", item.ModeloId);

                            if (modeloIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    tipoPlaca.Update(item);
                                }
                                else
                                {
                                    tipoPlaca.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Depositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Depositario depositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.Depositario");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Depositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.Id);

                            Int64? sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sector", item.SectorId);
                            Int64? modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Modelo", item.ModeloId);

                            if (modeloIdOrigen.HasValue && sectorIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;
                                item.SectorId = sectorIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    depositario.Update(item);
                                }
                                else
                                {
                                    depositario.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (ContadorasDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioContadora depositarioContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.DepositarioContadora");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ContadorasDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.DepositarioContadora", item.Id);

                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.DepositarioId);
                            Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoContadora", item.TipoContadoraId);

                            if (depositarioIdOrigen.HasValue && tipoContadoraIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    depositarioContadora.Update(item);
                                }
                                else
                                {
                                    depositarioContadora.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (EstadosDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioEstado depositarioEstado = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.DepositarioEstado");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in EstadosDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.DepositarioEstado", item.Id);

                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.DepositarioId);

                            if (depositarioIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    depositarioEstado.Update(item);
                                }
                                else
                                {
                                    depositarioEstado.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (MonedasDepositario.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioMoneda depositarioMoneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.DepositarioMoneda");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in MonedasDepositario)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.DepositarioMoneda", item.Id);

                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.DepositarioId);
                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);

                            if (depositarioIdOrigen.HasValue && monedaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    depositarioMoneda.Update(item);
                                }
                                else
                                {
                                    depositarioMoneda.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }


                }

                if (PlacasDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioPlaca depositarioPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.DepositarioPlaca");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlacasDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.DepositarioPlaca", item.Id);

                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.DepositarioId);
                            Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoPlaca", item.TipoPlacaId);

                            if (depositarioIdOrigen.HasValue && tipoPlacaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    depositarioPlaca.Update(item);
                                }
                                else
                                {
                                    depositarioPlaca.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }


                }

                if (ComandosContadoras.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ComandoContadora comandoContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.ComandoContadora");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ComandosContadoras)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.ComandoContadora", item.Id);

                            Int64? tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoContadora", item.TipoContadoraId);

                            if (tipoContadoraIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    comandoContadora.Update(item);
                                }
                                else
                                {
                                    comandoContadora.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }


                }

                if (ComandosPlacas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ComandoPlaca comandoPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.ComandoPlaca");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ComandosPlacas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.ComandoPlaca", item.Id);

                            Int64? tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoPlaca", item.TipoPlacaId);

                            if (tipoPlacaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    comandoPlaca.Update(item);
                                }
                                else
                                {
                                    comandoPlaca.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }


                }

                if (ConfiguracionesDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Dispositivo.ConfiguracionDepositario");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ConfiguracionesDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.ConfiguracionDepositario", item.Id);

                            Int64? depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.Depositario", item.DepositarioId);
                            Int64? tipoConfiguracionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Dispositivo.TipoConfiguracionDepositario", item.TipoId);

                            if (depositarioIdOrigen.HasValue && tipoConfiguracionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoConfiguracionIdOrigen.Value;
                                item.DepositarioId = depositarioIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    configuracionDepositario.Update(item);
                                }
                                else
                                {
                                    configuracionDepositario.Add(item);
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
