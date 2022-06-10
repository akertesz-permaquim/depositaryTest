namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class DepositarioMonitor
    {
        public Int64 DepositarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sector { get; set; }
        public string Sucursal { get; set; }
        public string Empresa { get; set; }
        public string NumeroSerie { get; set; }
        public string CodigoExterno { get; set; }
        public string Modelo { get; set; }
        public bool Habilitado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ValorTotalEnBolsa { get; set; }
        public string SemaforoOnline { get; set; }
        public string SemaforoAnomalia { get; set; }
        public string SemaforoOcupacionBolsa { get; set; }
    }
}
