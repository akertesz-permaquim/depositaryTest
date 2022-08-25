namespace Permaquim.Depositary.Web.Api.Model
{
    public class SeguridadModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> TiposAplicaciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> Aplicaciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> AplicacionesParametros { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> AplicacionesParametrosValores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> TiposFunciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> TiposMenues { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> Roles { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> Funciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> RolesFunciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> Menues { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> Usuarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> UsuariosRoles { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> UsuariosSectores { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> IdentificadoresUsuarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> TiposIdentificadores { get; set; } = new();
    }
    public class SeguridadUsuarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Usuario> Usuarios { get; set; } = new();
    }
    public class SeguridadRolModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Rol> Roles { get; set; } = new();
    }
    public class SeguridadFuncionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Funcion> Funciones { get; set; } = new();
    }
    public class SeguridadMenuModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Menu> Menues { get; set; } = new();
    }
    public class SeguridadTipoMenuModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu> TiposMenues { get; set; } = new();
    }
    public class SeguridadTipoFuncionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion> TiposFunciones { get; set; } = new();
    }
    public class SeguridadTipoAplicacionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion> TiposAplicaciones { get; set; } = new();
    }
    public class SeguridadAplicacionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion> Aplicaciones { get; set; } = new();
    }
    public class SeguridadAplicacionParametroModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro> AplicacionesParametros { get; set; } = new();
    }
    public class SeguridadAplicacionParametroValorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor> AplicacionesParametrosValores { get; set; } = new();
    }
    public class SeguridadRolFuncionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion> RolesFunciones { get; set; } = new();
    }
    public class SeguridadUsuarioRolModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol> UsuariosRoles { get; set; } = new();
    }
    public class SeguridadUsuarioSectorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector> UsuariosSectores { get; set; } = new();
    }
    public class SeguridadIdentificadorUsuarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario> IdentificadoresUsuarios { get; set; } = new();
    }
    public class SeguridadTipoIdentificadorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador> TiposIdentificadores { get; set; } = new();
    }
}
