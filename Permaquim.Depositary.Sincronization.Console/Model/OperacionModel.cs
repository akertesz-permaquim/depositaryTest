using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class OperacionModel:IModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Transaccion> Transaccion { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> TransaccionDetalle { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobre> TransaccionSobre { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobreDetalle { get; set; }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        void IModel.Process()
        {

            CodigoExternoDepositario = DatabaseController.CurrentDepositary.CodigoExterno;

            Depositario.Business.Tables.Operacion.Transaccion transaccion = new();
            Transaccion = transaccion.Items();

            Depositario.Business.Tables.Operacion.TransaccionDetalle transaccionDetalle = new();
            transaccionDetalle.OrderBy.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId);
            TransaccionDetalle = transaccionDetalle.Items();

            Depositario.Business.Tables.Operacion.TransaccionSobre transaccionSobre = new();
            TransaccionSobre = transaccionSobre.Items();

            Depositario.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalle = new();
            TransaccionSobreDetalle = transaccionSobreDetalle.Items();
        }
    }
}
