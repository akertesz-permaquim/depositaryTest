namespace Permaquim.Depositary.Web.Api.Model
{
    public class EstiloDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> Esquema { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; }

    }
    public class EstiloEsquemaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> Esquemas { get; set; }

    }
    public class EstiloEsquemaDetalleDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EsquemasDetalles { get; set; }

    }
    public class EstiloTipoEsquemaDetalleDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> TiposEsquemasDetalles { get; set; }

    }
}
