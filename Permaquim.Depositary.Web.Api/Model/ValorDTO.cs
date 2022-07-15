namespace Permaquim.Depositary.Web.Api.Model
{
    public class ValorDenominacionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
    }
    public class ValorMonedaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
    }
    public class ValorTipoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
    }
    public class ValorRelacionMonedaTipoValorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
    }
}
