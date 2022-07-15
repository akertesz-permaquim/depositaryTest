using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class LenguajeModel : IModel
    {
        public List<Permaquim.Depositario.Entities.Tables.Regionalizacion.Lenguaje> Lenguaje { get; set; }

        public List<Permaquim.Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; }

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
