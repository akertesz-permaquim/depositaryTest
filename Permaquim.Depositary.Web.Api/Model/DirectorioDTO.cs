namespace Permaquim.Depositary.Web.Api.Model
{
    public class DirectorioGrupoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> Grupos { get; set; } = new();
    }
    public class DirectorioEmpresaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> Empresas { get; set; } = new();
    }
    public class DirectorioSucursalDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> Sucursales { get; set; } = new();
    }
    public class DirectorioSectorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sector> Sectores { get; set; } = new();
    }
    public class DirectorioIdentificadorUsuarioDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.IdentificadorUsuario> IdentificadoresUsuario { get; set; } = new();
    }
    public class DirectorioRelacionMonedaSucursalDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> RelacionesMonedasSucursales { get; set; } = new();
    }
    public class DirectorioTipoIdentificadorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.TipoIdentificador> TiposIdentificador { get; set; } = new();
    }
}
