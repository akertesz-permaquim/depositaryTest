using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class VisualizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Visualizacion.Perfil> Perfiles { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilItem> PerfilesItems { get; set; } = new();
        public List<Depositario.Entities.Tables.Visualizacion.PerfilTipo> Tipos { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfil = SynchronizationController.obtenerFechaUltimaSincronizacion("Visualizacion.Perfil");

            SincroDates.Add("Visualizacion.Perfil", fechaSincroPerfil);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfilItem = SynchronizationController.obtenerFechaUltimaSincronizacion("Visualizacion.PerfilItem");

            SincroDates.Add("Visualizacion.PerfilItem", fechaSincroPerfilItem);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPerfilTipo = SynchronizationController.obtenerFechaUltimaSincronizacion("Visualizacion.PerfilTipo");

            SincroDates.Add("Visualizacion.PerfilTipo", fechaSincroPerfilTipo);
        }
        public void Persist()
        {
            try
            {
                if (Tipos.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.PerfilTipo perfilTipo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Visualizacion.PerfilTipo");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Tipos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.PerfilTipo", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                perfilTipo.Update(item);
                            }
                            else
                            {
                                perfilTipo.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Perfiles.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.Perfil perfil = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Visualizacion.Perfil");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Perfiles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.Perfil", item.Id);

                            Int64? perfilTipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.PerfilTipo", item.PerfilTipoId);

                            if (perfilTipoIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PerfilTipoId = perfilTipoIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    perfil.Update(item);
                                }
                                else
                                {
                                    perfil.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (PerfilesItems.Count > 0)
                {
                    Depositario.Business.Tables.Visualizacion.PerfilItem perfilItem = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Visualizacion.PerfilItem");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in PerfilesItems)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.PerfilItem", item.Id);

                            Int64? perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.Perfil", item.PerfilId);

                            if (perfilIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PerfilId = perfilIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    perfilItem.Update(item);
                                }
                                else
                                {
                                    perfilItem.Add(item);
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
