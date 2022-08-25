using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class SincronizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Sincronizacion.Entidad> Entidades { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEntidad = SynchronizationController.obtenerFechaUltimaSincronizacion("Sincronizacion.Entidad");

            SincroDates.Add("Sincronizacion.Entidad", fechaSincroEntidad);
        }

        public void Persist()
        {
            try
            {
                if (Entidades.Count > 0)
                {
                    Depositario.Business.Tables.Sincronizacion.Entidad entidad = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Sincronizacion.Entidad");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Entidades)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Sincronizacion.Entidad", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                entidad.Update(item);
                            }
                            else
                            {
                                entidad.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
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
