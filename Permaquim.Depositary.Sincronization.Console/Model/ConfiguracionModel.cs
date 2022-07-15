
using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ConfiguracionModel:IModel
    {
        public List<Permaquim.Depositario.Entities.Tables.Aplicacion.Configuracion> ConfiguracionAplicacion { get; set; }

        public List<Permaquim.Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionDispositivo { get; set; }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
