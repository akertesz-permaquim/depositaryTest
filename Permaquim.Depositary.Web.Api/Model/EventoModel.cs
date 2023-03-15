namespace Permaquim.Depositary.Web.Api.Model
{
    public class EventoModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public string CodigoExternoDepositario { get; set; }
        public List<NuevoEvento> Eventos { get; set; }
        public NuevoEstado? Estado { get; set; }
    }

    public class NuevoEvento : DepositaryWebApi.Entities.Tables.Operacion.Evento
    {
        public Int64? OrigenEvento_Id { get; set; }
    }
    public class NuevoEstado : DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado
    {
        public Int64? OrigenEstado_Id { get; set; }
    }
}
