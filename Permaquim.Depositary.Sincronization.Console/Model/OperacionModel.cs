using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class OperacionModel:IModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Sesion> Sesion { get; set; }
        public List<Depositario.Entities.Tables.Operacion.CierreDiario> CierreDiario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Turno> Turno { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Contenedor> Contenedor { get; set; }
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

            Depositario.Business.Tables.Operacion.Sesion session = new();
            Sesion = session.Items();

            Depositario.Business.Tables.Operacion.CierreDiario dailyclosing = new();
            CierreDiario = dailyclosing.Items();

            Depositario.Business.Tables.Operacion.Turno turn = new();
            Turno = turn.Items();

            Depositario.Business.Tables.Operacion.Contenedor container = new();
            Contenedor = container.Items();

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
