using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class OperacionModel:IModel
    {
        private DateTime _startDateTime = DateTime.MinValue;

        public string CodigoExternoDepositario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Sesion> Sesiones { get; set; }
        public List<Depositario.Entities.Tables.Operacion.CierreDiario> CierresDiarios { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Turno> Turnos { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Contenedor> Contenedores { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Transaccion> Transacciones { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> TransaccionesDetalles { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobre> TransaccionesSobres { get; set; }
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionesSobresDetalles { get; set; }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        void IModel.Process()
        {
            _startDateTime = DateTime.Now;
            DateTime lastSincronizationDate;

            CodigoExternoDepositario = DatabaseController.CurrentDepositary.CodigoExterno;

            Sesiones = DatabaseController.GetSessions();

            CierresDiarios = DatabaseController.GetDailyclosingItems();
 
            Turnos = DatabaseController.GetTurns();

            Contenedores = DatabaseController.GetContainers();

            Transacciones = DatabaseController.GetTransactions();

            TransaccionesDetalles = DatabaseController.GetTransactionDetails();

            TransaccionesSobres = DatabaseController.GetEnvelopeTransaction();

            TransaccionesSobresDetalles = DatabaseController.GetEnvelopeTransactionDetails();
        }
        public void Persist()
        {
            DateTime endSincronizationDate = DateTime.Now;

            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_Sesion, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_CierreDiario, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_Turno, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_Contenedor, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_Transaccion, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_TransaccionDetalle, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_TransaccionSobre, _startDateTime, endSincronizationDate);
            DatabaseController.SaveEntitySincronizationDate(
                Enumerations.EntitiesEnum.Operacion_TransaccionSobreDetalle, _startDateTime, endSincronizationDate);

        }
    }
}
