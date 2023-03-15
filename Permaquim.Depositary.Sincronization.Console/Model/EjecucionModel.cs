using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class EjecucionModel : IModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Depositario.Entities.Tables.Sincronizacion.Ejecucion Ejecucion { get; set; } = new();

        void IModel.Process()
        {
            SynchronizationController.executionController = new();

            SynchronizationController.executionController.BeginTransaction();

            if (SynchronizationController.HasOpenedExecution())
            {
                Ejecucion = SynchronizationController.currentExecution;

                Ejecucion.FechaFin = DateTime.Now;

                SynchronizationController.executionController.Update(Ejecucion);

            }
            else
            {
                Ejecucion.EsPrimeraSincronizacion = false;
                Ejecucion.Finalizada = false;
                Ejecucion.FechaFin = null;
                Ejecucion.FechaInicio = DateTime.Now;
                Ejecucion.DepositarioId = DatabaseController.CurrentDepositaryId;

                SynchronizationController.executionController.Add(Ejecucion);
            }
        }

        public void Persist()
        {
            SynchronizationController.executionController.EndTransaction(true);
            SynchronizationController.currentExecution = Ejecucion;

            //Se deja marcada la ejecucion como finalizada (en memoria) para despues poder marcarla ante algun fallo.
            SynchronizationController.currentExecution.Finalizada = true; 
        }

    }
}
