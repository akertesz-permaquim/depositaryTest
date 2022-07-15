namespace Permaquim.Depositary.Web.Api.Model
{
    public class SeguridadUsuarioDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> Usuarios { get; set; } = new();
    }
    public class SeguridadRolDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> Roles { get; set; } = new();
    }
    public class SeguridadFuncionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> Funciones { get; set; } = new();
    }
    public class SeguridadMenuDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> Menues { get; set; } = new();
    }
    public class SeguridadTipoMenuDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> TiposMenues { get; set; } = new();
    }
    public class SeguridadTipoFuncionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> TiposFunciones { get; set; } = new();
    }
    public class SeguridadTipoAplicacionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> TiposAplicaciones { get; set; } = new();
    }
    public class SeguridadAplicacionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> Aplicaciones { get; set; } = new();
    }
    public class SeguridadAplicacionParametroDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> AplicacionesParametros { get; set; } = new();
    }
    public class SeguridadAplicacionParametroValorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> AplicacionesParametrosValores { get; set; } = new();
    }
    public class SeguridadRolFuncionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> RolesFunciones { get; set; } = new();
    }
    public class SeguridadUsuarioRolDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> UsuariosRoles { get; set; } = new();
    }
    public class SeguridadUsuarioSectorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> UsuariosSectores { get; set; } = new();
    }
}
