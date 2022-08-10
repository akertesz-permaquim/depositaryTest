namespace Permaquim.Depositary.Web.Administration.TurnoEntities
{
    public class GrupoTurno
    {
        public Int64 GrupoId { get; set; }
        public string GrupoNombre { get; set; }
        public List<EmpresaTurno> Empresas { get; set; } = new();
    }
    public class EmpresaTurno
    {
        public Int64 EmpresaId { get; set; }
        public string EmpresaNombre { get; set; }

        public List<SucursalTurno> Sucursales { get; set; } = new();
    }

    public class SucursalTurno
    {
        public Int64 SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public List<SectorTurno> Sectores { get; set; } = new();

    }
    public class SectorTurno
    {
        public Int64 SectorId { get; set; }
        public string SectorNombre { get; set; }
    }

    public class TurnoComboReporte
    {
        public Int64 TurnoEsquemaDetalleId { get; set; }
        public string NombreEsquema { get; set; }
        public string NombreEsquemaDetalle { get; set; }
        public string Nombre
        {
            get
            {
                return NombreEsquema + " - " + NombreEsquemaDetalle;
            }
        }
    }

    public class AgendaTurno
    {
        public Int64 TurnoId { get; set; }
        public string TurnoNombre { get; set; }
    }

    public class AgendaTurnoABM
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string NombreAgenda { get; set; }
        public Int64 UsuarioId { get; set; }
        public Int64? EsquemaTurnoId { get; set; }
        public List<SectorTurno> Sectores { get; set; }

        public AgendaTurnoABM()
        {
            FechaDesde = DateTime.Today;
            FechaHasta = DateTime.Today;
            UsuarioId = 0;
            EsquemaTurnoId = null;
            Sectores = new();
        }
    }
}
