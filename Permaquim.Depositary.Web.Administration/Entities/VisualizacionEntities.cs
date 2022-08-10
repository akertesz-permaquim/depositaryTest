namespace Permaquim.Depositary.Web.Administration.VisualizacionEntities
{
    public enum TipoPerfil
    {
        NoEspecificado = 0,
        Grupo = 1,
        Empresa = 2,
        Sucursal = 3,
        Sector = 4
    }
    public class PerfilReferencia
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
    }
}
