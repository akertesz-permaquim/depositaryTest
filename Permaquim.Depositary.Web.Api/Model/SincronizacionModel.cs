namespace Permaquim.Depositary.Web.Api.Model
{
    public class SincronizacionModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> Entidades { get; set; } = new();
    }
    public class SincronizacionEntidadModel
    {
        public List<DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad> Entidades { get; set; } = new();
    }
}
