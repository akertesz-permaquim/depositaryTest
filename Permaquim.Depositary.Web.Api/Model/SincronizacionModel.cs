namespace Permaquim.Depositary.Web.Api.Model
{
    public class SincronizacionModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> Entidades { get; set; } = new();
    }
    public class SincronizacionEntidadModel
    {
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> Entidades { get; set; } = new();
    }

    public class SincronizacionEjecucionModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion Ejecucion { get; set; }
    }

}
