namespace Permaquim.Depositary.Web.Api.Model
{
    public class IntegracionValoresModel
    {
        public List<DepositaryWebApi.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Valor.OrigenValor> OrigenesValores { get; set; } = new();
    }
}
