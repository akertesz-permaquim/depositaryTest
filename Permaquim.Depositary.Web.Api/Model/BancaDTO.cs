namespace Permaquim.Depositary.Web.Api.Model
{
    public class BancaBancoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.Banco> Bancos { get; set; } = new();
    }

    public class BancaCuentaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> Cuentas { get; set; } = new();
    }
    public class BancaTipoCuentaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> TiposCuenta { get; set; } = new();
    }
    public class BancaUsuarioCuentaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> UsuariosCuenta { get; set; } = new();
    }
}
