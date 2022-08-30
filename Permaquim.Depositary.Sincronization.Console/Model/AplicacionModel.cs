using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class AplicacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionTipoDato> TiposDatos { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionValidacionDato> ValidacionesDatos { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> Configuraciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionesEmpresas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionTipoDato = SynchronizationController.obtenerFechaUltimaSincronizacion("Aplicacion.ConfiguracionTipoDato");

            SincroDates.Add("Aplicacion.ConfiguracionTipoDato", fechaSincroConfiguracionTipoDato);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionValidacionDato = SynchronizationController.obtenerFechaUltimaSincronizacion("Aplicacion.ConfiguracionValidacionDato");

            SincroDates.Add("Aplicacion.ConfiguracionValidacionDato", fechaSincroConfiguracionValidacionDato);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracion = SynchronizationController.obtenerFechaUltimaSincronizacion("Aplicacion.Configuracion");

            SincroDates.Add("Aplicacion.Configuracion", fechaSincroConfiguracion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroConfiguracionEmpresa = SynchronizationController.obtenerFechaUltimaSincronizacion("Aplicacion.ConfiguracionEmpresa");

            SincroDates.Add("Aplicacion.ConfiguracionEmpresa", fechaSincroConfiguracionEmpresa);
        }
        public void Persist()
        {
            try
            {
                if (TiposDatos.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionTipoDato configuracionTipoDato = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Aplicacion.ConfiguracionTipoDato");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposDatos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionTipoDato", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                configuracionTipoDato.Update(item);
                            }
                            else
                            {
                                configuracionTipoDato.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (ValidacionesDatos.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionValidacionDato configuracionValidacionDato = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Aplicacion.ConfiguracionValidacionDato");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ValidacionesDatos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionValidacionDato", item.Id);

                            Int64? tipoDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionTipoDato", item.TipoDatoId);

                            if (tipoDatoIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoDatoId = tipoDatoIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    configuracionValidacionDato.Update(item);
                                }
                                else
                                {
                                    configuracionValidacionDato.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Configuraciones.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.Configuracion configuracion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Aplicacion.Configuracion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Configuraciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.Configuracion", item.Id);

                            Int64? aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.AplicacionId);
                            Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionValidacionDato", item.ValidacionDatoId);

                            if (aplicacionIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    configuracion.Update(item);
                                }
                                else
                                {
                                    configuracion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (ConfiguracionesEmpresas.Count > 0)
                {
                    Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa configuracionEmpresa = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Aplicacion.ConfiguracionEmpresa");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in ConfiguracionesEmpresas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionEmpresa", item.Id);
                            Int64? validacionDatoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Aplicacion.ConfiguracionValidacionDato", item.ValidacionDatoId);
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);

                            if (empresaIdOrigen.HasValue && validacionDatoIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.ValidacionDatoId = validacionDatoIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    configuracionEmpresa.Update(item);
                                }
                                else
                                {
                                    configuracionEmpresa.Add(item);
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
