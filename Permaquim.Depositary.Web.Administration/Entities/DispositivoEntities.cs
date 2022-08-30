namespace Permaquim.Depositary.Web.Administration.DispositivoEntities
{
    public class Depositario
    {
        public Int64 DepositarioId { get; set; }
        public string DepositarioNombre { get; set; }
        public Int64 SectorId { get; set; }
        public Int64 SucursalId { get; set; }
        public Int64 EmpresaId { get; set; }
    }
}