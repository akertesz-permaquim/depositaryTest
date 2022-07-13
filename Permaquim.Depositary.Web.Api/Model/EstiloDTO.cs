namespace Permaquim.Depositary.Web.Api.Model
{
    public class EstiloDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Estilo.Esquema> Esquema { get; set; }

        public List<DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle> EsquemaDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle> TipoEsquemaDetalle { get; set; }

    }
}
