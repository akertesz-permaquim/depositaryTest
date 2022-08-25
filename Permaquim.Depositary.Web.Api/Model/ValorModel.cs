namespace Permaquim.Depositary.Web.Api.Model
{
    public class ValorModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> OrigenesValores { get; set; } = new();
    }
    public class ValorDenominacionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
    }
    public class ValorMonedaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
    }
    public class ValorTipoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
    }
    public class ValorRelacionMonedaTipoValorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
    }
    public class ValorOrigenValorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> OrigenesValores { get; set; } = new();
    }
}
