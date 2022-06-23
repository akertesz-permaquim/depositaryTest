namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class DepositarioCarga
    {
        public Int64 DepositarioId { get; set; }
        public string NombreDepositario { get; set; }
        public Int64 CantidadTransacciones { get; set; }
    }
    public class TransaccionTipoCantidad
    {
        public Int64 TipoTransaccionId { get; set; }
        public string NombreTipoTransaccion { get; set; }
        public Int64 CantidadTipoTransaccion { get; set; }
    }
}
