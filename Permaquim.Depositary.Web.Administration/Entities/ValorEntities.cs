namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class Moneda
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public Int64 PaisId { get; set; }
        public string Codigo { get; set; }
        public string Simbolo { get; set; }
        public int IndiceEnContadora { get; set; }
        public bool Habilitado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
