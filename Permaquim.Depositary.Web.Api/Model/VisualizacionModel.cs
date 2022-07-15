namespace Permaquim.Depositary.Web.Api.Model
{
    public class VisualizacionPerfilModel
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.Perfil> Perfiles { get; set; } = new();
    }
    public class VisualizacionPerfilItemModel
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem> PerfilesItems { get; set; } = new();
    }
    public class VisualizacionPerfilTipoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo> Tipos { get; set; } = new();
    }
}
