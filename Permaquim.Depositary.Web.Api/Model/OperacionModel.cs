namespace Permaquim.Depositary.Web.Api.Model
{
    public class OperacionModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> TiposContenedores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> TiposEventos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> TiposTransacciones { get; set; } = new();
    }

    public class OperacionTipoContenedorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> TiposContenedores { get; set; } = new();
    }
    public class OperacionTipoEventoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> TiposEventos { get; set; } = new();
    }
    public class OperacionTipoTransaccionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> TiposTransacciones { get; set; } = new();
    }
}
