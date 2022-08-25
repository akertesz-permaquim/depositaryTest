namespace Permaquim.Depositary.Web.Api.Model
{
    public class ImpresionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Impresion.TipoTicket> TiposTickets { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Impresion.Ticket> Tickets { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
    }
    public class ImpresionTipoTicketModel
    {
        public List<DepositaryWebApi.Entities.Tables.Impresion.TipoTicket> TiposTickets { get; set; } = new();
    }

    public class ImpresionTicketModel
    {
        public List<DepositaryWebApi.Entities.Tables.Impresion.Ticket> Tickets { get; set; } = new();
    }
}
