namespace Permaquim.Depositary.Web.Api.Model
{
    public class OperacionDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Transaccion> Transaccion { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle> TransaccionDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobre { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobreDetalle { get; set; }
    }
}
