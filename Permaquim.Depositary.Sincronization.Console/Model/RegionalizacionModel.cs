using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class RegionalizacionModel : IModel
    {
        public List<Depositario.Entities.Tables.Regionalizacion.Lenguaje> Lenguaje { get; set; } = new();

        public List<Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; } = new();

        void IModel.Process()
        {
            try
            {
                Depositario.Business.Tables.Regionalizacion.Lenguaje lenguaje = new();
                foreach (var item in Lenguaje)
                {
                    lenguaje.Where.Clear();
                    lenguaje.Where.Add(Depositario.Business.Tables.Regionalizacion.Lenguaje.ColumnEnum.Nombre,
                        Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                    lenguaje.Items();

                    if (lenguaje.Result.Count == 0)
                        lenguaje.Add(item);
                    else
                        lenguaje.Update(item);
                }

                Depositario.Business.Tables.Regionalizacion.LenguajeItem lenguajeItem = new();
                foreach (var item in LenguajeItems)
                {
                    lenguajeItem.Where.Clear();
                    lenguajeItem.Where.Add(Depositario.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId,
                        Depositario.sqlEnum.OperandEnum.Equal, item.LenguajeId);
                    lenguajeItem.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.Clave,
                                Depositario.sqlEnum.OperandEnum.Equal, item.Clave);
                    lenguajeItem.Items();
                    if(lenguajeItem.Result.Count == 0)
                    lenguajeItem.Add(item);
                    else
                        lenguajeItem.Update(item);
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
        public void Persist()
        {
            throw new NotImplementedException();
        }

 
    }
}
