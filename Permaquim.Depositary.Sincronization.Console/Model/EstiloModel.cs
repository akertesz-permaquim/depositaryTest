using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class EstiloModel : IModel
    {
        public List<Depositario.Entities.Tables.Estilo.Esquema> Esquema { get; set; } = new();

        public List<Depositario.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; } = new();
        public List<Depositario.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; } = new();
        public DateTime? SincroDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
                    esquema.Where.Clear();
                    esquema.Where.Add(Depositario.Business.Tables.Estilo.Esquema.ColumnEnum.Nombre,
                        Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                    esquema.Items();
                    if (esquema.Result.Count == 0)
                        esquema.Add(item);
                    else
                        esquema.Update(item);
                }

                Depositario.Business.Tables.Estilo.TipoEsquemaDetalle tipoEsquemaDetalle = new();
                foreach (var item in TipoEsquemaDetalle)
                {
                    tipoEsquemaDetalle.Where.Clear();
                    tipoEsquemaDetalle.Where.Add(Depositario.Business.Tables.Estilo.TipoEsquemaDetalle.ColumnEnum.Nombre,
                        Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                    tipoEsquemaDetalle.Items();
                    if (tipoEsquemaDetalle.Result.Count == 0)
                        tipoEsquemaDetalle.Add(item);
                    else
                        tipoEsquemaDetalle.Update(item);
                }

                Depositario.Business.Tables.Estilo.EsquemaDetalle esquemaDetalle = new();
                foreach (var item in EsquemaDetalle)
                {
                    esquemaDetalle.Where.Clear();
                    esquemaDetalle.Where.Add(Depositario.Business.Tables.Estilo.EsquemaDetalle.ColumnEnum.Nombre,
                        Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                    esquemaDetalle.Items();
                    if (esquemaDetalle.Result.Count == 0)
                        esquemaDetalle.Add(item);
                    else
                        esquemaDetalle.Update(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Persist()
        {
            throw new NotImplementedException();
        }

    }
}
