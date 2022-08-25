namespace Permaquim.Depositary.Web.Api.Model
{
    public class EstiloModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> Esquema { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; }

    }
    public class EstiloEsquemaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> Esquemas { get; set; }

    }
    public class EstiloEsquemaDetalleModel
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EsquemasDetalles { get; set; }

    }
    public class EstiloTipoEsquemaDetalleModel
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> TiposEsquemasDetalles { get; set; }

    }
}
