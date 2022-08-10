namespace Permaquim.Depositary.Web.Administration.DirectorioEntities
{

    public class Empresa
    {
        public Int64 EmpresaId { get; set; }
        public string EmpresaNombre { get; set; }
    }
    public class Sucursal
    {
        public Int64 EmpresaId { get; set; }
        public Int64 SucursalId { get; set; }
        public string SucursalNombre { get; set; }

    }
    public class Sector
    {
        public Int64 SucursalId { get; set; }
        public Int64 SectorId { get; set; }
        public string SectorNombre { get; set; }

    }

    public class SectorDepositario
    {
        public Int64 SectorId { get; set; }
        public string EmpresaSucursalSectorNombre { get; set; }

    }
}
