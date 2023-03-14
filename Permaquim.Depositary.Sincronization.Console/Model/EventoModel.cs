using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class EventoModel : IModel
    {
        private DateTime _startDateTime = DateTime.MinValue;
        public string CodigoExternoDepositario { get; set; }
        public List<Depositario.Entities.Tables.Operacion.Evento> Eventos { get; set; } = new();
        public Depositario.Entities.Tables.Dispositivo.DepositarioEstado? Estado { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {
            _startDateTime = DateTime.Now;

            CodigoExternoDepositario = ConfigurationController.GetCurrentDepositaryCode();

            Eventos = DatabaseController.GetEvents();

            Estado = DatabaseController.GetState();

        }

        public void Persist()
        {
            DateTime endSincronizationDate = DateTime.Now;

            if (Eventos.Count > 0)
            {
                SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Operacion_Evento, _startDateTime, endSincronizationDate);
            }

            if (Estado != null)
                SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Dispositivo_DepositarioEstado, _startDateTime, endSincronizationDate);
        }

    }
}
