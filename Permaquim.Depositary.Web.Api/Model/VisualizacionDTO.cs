namespace Permaquim.Depositary.Web.Api.Model
{
    public class VisualizacionPerfilDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> Perfiles { get; set; } = new();
    }
    public class VisualizacionPerfilItemDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> PerfilesItems { get; set; } = new();
    }
    public class VisualizacionPerfilTipoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> Tipos { get; set; } = new();
    }
}
