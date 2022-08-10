namespace Permaquim.Depositary.Web.Api.Model
{
    public class DirectorioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> Grupos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> Empresas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> Sucursales { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sector> Sectores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> TiposIdentificador { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> IdentificadoresUsuario { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> RelacionesMonedasSucursales { get; set; } = new();
    }

    public class DirectorioGrupoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Grupo> Grupos { get; set; } = new();
    }
    public class DirectorioEmpresaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Empresa> Empresas { get; set; } = new();
    }
    public class DirectorioSucursalModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sucursal> Sucursales { get; set; } = new();
    }
    public class DirectorioSectorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.Sector> Sectores { get; set; } = new();
    }
    public class DirectorioIdentificadorUsuarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> IdentificadoresUsuario { get; set; } = new();
    }
    public class DirectorioRelacionMonedaSucursalModel
    {
        public List<DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal> RelacionesMonedasSucursales { get; set; } = new();
    }
    public class DirectorioTipoIdentificadorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> TiposIdentificador { get; set; } = new();
    }
}
