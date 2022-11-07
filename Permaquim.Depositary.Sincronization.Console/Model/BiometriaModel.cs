using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class BiometriaModel : IModel
    {
        public List<Depositario.Entities.Tables.Biometria.HuellaDactilar> HuellasDactilares { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroHuellaDactilar = SynchronizationController.obtenerFechaUltimaSincronizacion("Biometria.HuellaDactilar");

            SincroDates.Add("Biometria.HuellaDactilar", fechaSincroHuellaDactilar);
        }

        public void Persist()
        {
            try
            {
                if (HuellasDactilares.Count > 0)
                {
                    Depositario.Business.Tables.Biometria.HuellaDactilar huellaDactilar = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Biometria.HuellaDactilar");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in HuellasDactilares)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Biometria.HuellaDactilar", item.Id);
                            Int64? usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    Int64? usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    huellaDactilar.Update(item);
                                }
                                else
                                {
                                    huellaDactilar.Add(item);
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
