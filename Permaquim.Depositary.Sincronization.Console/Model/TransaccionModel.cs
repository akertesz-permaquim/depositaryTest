using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;


namespace Permaquim.Depositary.Sincronization.Console
{
    public class TransaccionModel : IModel
    {
        private DateTime _startDateTime = DateTime.MinValue;

        DatabaseController DatabaseController = new();
        public string CodigoExternoDepositario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Sesion> Sesiones { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.CierreDiario> CierresDiarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Turno> Turnos { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Contenedor> Contenedores { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Transaccion> Transacciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> TransaccionesDetalles { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobre> TransaccionesSobres { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionesSobresDetalles { get; set; } = new();
        public List<Depositario.Entities.Tables.Operacion.Evento> Eventos { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        void IModel.Process()
        {
            _startDateTime = DateTime.Now;
            DateTime lastSincronizationDate;

            CodigoExternoDepositario = ConfigurationController.GetCurrentDepositaryCode();

            Eventos = DatabaseController.GetEvents();

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
                Enumerations.EntitiesEnum.Operacion_Evento, _startDateTime, endSincronizationDate);
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
