using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class EstiloModel : IModel
    {
        public List<Depositario.Entities.Tables.Estilo.Esquema> Esquema { get; set; }

        public List<Depositario.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; }
        public List<Depositario.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        void IModel.Process()
        {
            try
            {



                Depositario.Business.Tables.Estilo.Esquema esquema = new();
                foreach (var item in Esquema)
                {
                    esquema.AddOrUpdate(item);
                }



                Depositario.Business.Tables.Estilo.TipoEsquemaDetalle tipoEsquemaDetalle = new();
                foreach (var item in TipoEsquemaDetalle)
                {
                    tipoEsquemaDetalle.AddOrUpdate(item);
                }


                Depositario.Business.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();
                foreach (var item in EsquemaDetalle)
                {
                    esquemaDetalle.AddOrUpdate(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
