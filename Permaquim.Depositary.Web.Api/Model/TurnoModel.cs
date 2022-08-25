namespace Permaquim.Depositary.Web.Api.Model
{
    public class TurnoModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> Esquemas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> EsquemasDetalles { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> Agendas { get; set; } = new();

    }
    public class TurnoAgendaTurnoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> Agendas { get; set; } = new();
    }
    public class TurnoEsquemaDetalleTurnoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> EsquemasDetalles { get; set; } = new();
    }
    public class TurnoEsquemaTurnoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> Esquemas { get; set; } = new();
    }
}
