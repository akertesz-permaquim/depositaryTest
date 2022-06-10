namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class TransaccionDepositarioMonedaDefault
    {
        public Int64 DepositarioId { get; set; }
        public Int64 TransaccionId { get; set; }
        public double TotalAValidar { get; set; }
        public double TotalValidado { get; set; }
        public Int64 MonedaId { get; set; }
    }
}
