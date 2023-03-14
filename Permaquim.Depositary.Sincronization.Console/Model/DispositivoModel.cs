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
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> MonedasDepositarios { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        public void Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoConfiguracionDepositario = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario).Replace("_", "."), fechaSincroTipoConfiguracionDepositario);

            DateTime fechaSincroMarca = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_Marca);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_Marca).Replace("_", "."), fechaSincroMarca);

            DateTime fechaSincroPlantillaMoneda = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda).Replace("_", "."), fechaSincroPlantillaMoneda);

            DateTime fechaSincroPlantillaMonedaDetalle = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_PlantillaMonedaDetalle);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_PlantillaMonedaDetalle).Replace("_", "."), fechaSincroPlantillaMonedaDetalle);

            DateTime fechaSincroModelo = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_Modelo);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_Modelo).Replace("_", "."), fechaSincroModelo);

            DateTime fechaSincroTipoContadora = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_TipoContadora);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_TipoContadora).Replace("_", "."), fechaSincroTipoContadora);

            DateTime fechaSincroTipoPlaca = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca).Replace("_", "."), fechaSincroTipoPlaca);

            DateTime fechaSincroDepositario = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_Depositario);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_Depositario).Replace("_", "."), fechaSincroDepositario);

            DateTime fechaSincroDepositarioContadora = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_DepositarioContadora);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_DepositarioContadora).Replace("_", "."), fechaSincroDepositarioContadora);

            DateTime fechaSincroDepositarioEstado = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_DepositarioEstado);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_DepositarioEstado).Replace("_", "."), fechaSincroDepositarioEstado);

            DateTime fechaSincroDepositarioMoneda = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_DepositarioMoneda);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_DepositarioMoneda).Replace("_", "."), fechaSincroDepositarioMoneda);

            DateTime fechaSincroDepositarioPlaca = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_DepositarioPlaca);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_DepositarioPlaca).Replace("_", "."), fechaSincroDepositarioPlaca);

            DateTime fechaSincroComandoContadora = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_ComandoContadora);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_ComandoContadora).Replace("_", "."), fechaSincroComandoContadora);

            DateTime fechaSincroComandoPlaca = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_ComandoPlaca);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_ComandoPlaca).Replace("_", "."), fechaSincroComandoPlaca);

            DateTime fechaSincroConfiguracionDepositario = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_ConfiguracionDepositario);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Dispositivo_ConfiguracionDepositario).Replace("_", "."), fechaSincroConfiguracionDepositario);


        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposConfiguraciones.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario tipoConfiguracionDepositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? validacionDatoIdOrigen;
                        foreach (var item in TiposConfiguraciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Aplicacion_ConfiguracionValidacionDato, item.ValidacionDatoId);

                            if (usuarioCreacionIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                            {

                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Marcas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Marca marca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Marca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Marcas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Marca, item.Id);
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
                                    marca.Update(item);
                                }
                                else
                                {
                                    marca.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (PlantillasMonedas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.PlantillaMoneda plantillaMoneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PlantillasMonedas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, item.Id);
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
                                    plantillaMoneda.Update(item);
                                }
                                else
                                {
                                    plantillaMoneda.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (PlantillasMonedasDetalles.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle plantillaMonedaDetalle = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_PlantillaMonedaDetalle, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? plantillaMonedaIdOrigen;
                        Int64? monedaIdOrigen;
                        foreach (var item in PlantillasMonedasDetalles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_PlantillaMonedaDetalle, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, item.PlantillaMonedaId);

                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (plantillaMonedaIdOrigen.HasValue && monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;
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
                                    plantillaMonedaDetalle.Update(item);
                                }
                                else
                                {
                                    plantillaMonedaDetalle.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Modelos.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Modelo modelo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Modelo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? plantillaMonedaIdOrigen;
                        Int64? marcaIdOrigen;
                        foreach (var item in Modelos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            plantillaMonedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_PlantillaMoneda, item.PlantillaMonedaId);

                            marcaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Marca, item.MarcaId);

                            if (plantillaMonedaIdOrigen.HasValue && marcaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PlantillaMonedaId = plantillaMonedaIdOrigen.Value;
                                item.MarcaId = marcaIdOrigen.Value;
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
                                    modelo.Update(item);
                                }
                                else
                                {
                                    modelo.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposContadoras.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoContadora tipoContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? modeloIdOrigen;
                        foreach (var item in TiposContadoras)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);

                            if (modeloIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;
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
                                    tipoContadora.Update(item);
                                }
                                else
                                {
                                    tipoContadora.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposPlacas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.TipoPlaca tipoPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? modeloIdOrigen;
                        foreach (var item in TiposPlacas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);

                            if (modeloIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;
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
                                    tipoPlaca.Update(item);
                                }
                                else
                                {
                                    tipoPlaca.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Depositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.Depositario depositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_Depositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? sectorIdOrigen;
                        Int64? modeloIdOrigen;
                        Int64? tipoContenedorIdOrigen;

                        foreach (var item in Depositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);
                            modeloIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Modelo, item.ModeloId);
                            tipoContenedorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoContenedor, item.TipoContenedorId);

                            if (modeloIdOrigen.HasValue && sectorIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue && tipoContenedorIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ModeloId = modeloIdOrigen.Value;
                                item.SectorId = sectorIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;
                                item.TipoContenedorId = tipoContenedorIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (ContadorasDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioContadora depositarioContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? depositarioIdOrigen;
                        Int64? tipoContadoraIdOrigen;
                        foreach (var item in ContadorasDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_DepositarioContadora, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, item.TipoContadoraId);

                            if (depositarioIdOrigen.HasValue && tipoContadoraIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;
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
                                    depositarioContadora.Update(item);
                                }
                                else
                                {
                                    depositarioContadora.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }
                 
                if (MonedasDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioMoneda depositarioMoneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioMoneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? depositarioIdOrigen;
                        Int64? monedaIdOrigen;

                        foreach (var item in MonedasDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_DepositarioMoneda, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);


                            if (depositarioIdOrigen.HasValue && monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;
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
                                    depositarioMoneda.Update(item);
                                }
                                else
                                {
                                    depositarioMoneda.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }


                }

                if (PlacasDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.DepositarioPlaca depositarioPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? depositarioIdOrigen;
                        Int64? tipoPlacaIdOrigen;
                        foreach (var item in PlacasDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_DepositarioPlaca, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, item.TipoPlacaId);

                            if (depositarioIdOrigen.HasValue && tipoPlacaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.DepositarioId = depositarioIdOrigen.Value;
                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;
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
                                    depositarioPlaca.Update(item);
                                }
                                else
                                {
                                    depositarioPlaca.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }


                }

                if (ComandosContadoras.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ComandoContadora comandoContadora = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ComandoContadora, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoContadoraIdOrigen;
                        foreach (var item in ComandosContadoras)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_ComandoContadora, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoContadoraIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoContadora, item.TipoContadoraId);

                            if (tipoContadoraIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoContadoraId = tipoContadoraIdOrigen.Value;
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
                                    comandoContadora.Update(item);
                                }
                                else
                                {
                                    comandoContadora.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }


                }

                if (ComandosPlacas.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ComandoPlaca comandoPlaca = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ComandoPlaca, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoPlacaIdOrigen;
                        foreach (var item in ComandosPlacas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_ComandoPlaca, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoPlacaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoPlaca, item.TipoPlacaId);

                            if (tipoPlacaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoPlacaId = tipoPlacaIdOrigen.Value;
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
                                    comandoPlaca.Update(item);
                                }
                                else
                                {
                                    comandoPlaca.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }


                }

                if (ConfiguracionesDepositarios.Count > 0)
                {
                    Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_ConfiguracionDepositario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? depositarioIdOrigen;
                        Int64? tipoConfiguracionIdOrigen;
                        foreach (var item in ConfiguracionesDepositarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_ConfiguracionDepositario, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            depositarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, item.DepositarioId);
                            tipoConfiguracionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_TipoConfiguracionDepositario, item.TipoId);

                            if (depositarioIdOrigen.HasValue && tipoConfiguracionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoConfiguracionIdOrigen.Value;
                                item.DepositarioId = depositarioIdOrigen.Value;
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
                                    configuracionDepositario.Update(item);
                                }
                                else
                                {
                                    configuracionDepositario.Add(item);
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
