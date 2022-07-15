namespace Permaquim.Depositary.Web.Api.Model
{
    public class TurnoAgendaTurnoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.AgendaTurno> Agendas { get; set; } = new();
    }
    public class TurnoEsquemaDetalleTurnoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno> EsquemasDetalles { get; set; } = new();
    }
    public class TurnoEsquemaTurnoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno> Esquemas { get; set; } = new();
    }
}
