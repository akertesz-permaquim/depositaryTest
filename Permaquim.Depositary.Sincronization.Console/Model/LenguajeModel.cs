using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class LenguajeModel : IModel
    {
        public List<Depositario.Entities.Tables.Regionalizacion.Lenguaje> Lenguaje { get; set; }

        public List<Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; }

        void IModel.Process()
        {
            try
            {
                Depositario.Business.Tables.Regionalizacion.Lenguaje lenguaje = new();
                foreach (var item in Lenguaje)
                {
                    lenguaje.AddOrUpdate(item);
                }

                Depositario.Business.Tables.Regionalizacion.LenguajeItem lenguajeItem = new();
                foreach (var item in LenguajeItems)
                {
                    lenguajeItem.AddOrUpdate(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void IModel.Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
