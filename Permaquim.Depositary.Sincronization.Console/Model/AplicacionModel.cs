using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class AplicacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> Configuraciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionesEmpresas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
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

                            if (aplicacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;

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

                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);

                            if (empresaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;

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
