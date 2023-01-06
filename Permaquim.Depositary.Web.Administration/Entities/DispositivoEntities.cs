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

    public class DepositarioABM
    {
        public Depositary.Entities.Tables.Dispositivo.Depositario Depositario { get; set; }
        public string MensajeValidacion { get; set; }

        public string Empresa { get; set; }
        public string Sucursal { get; set; }

        public DepositarioABM()
        {
            Depositario = new();
            MensajeValidacion = "";
            Sucursal = "";
            Empresa = "";
        }
    }
}