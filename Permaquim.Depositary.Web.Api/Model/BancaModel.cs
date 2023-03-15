namespace Permaquim.Depositary.Web.Api.Model
{
    public class BancaModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.Banco> Bancos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> TiposCuenta { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> Cuentas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> UsuariosCuenta { get; set; } = new();
    }
    public class BancaBancoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.Banco> Bancos { get; set; } = new();
    }

    public class BancaCuentaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.Cuenta> Cuentas { get; set; } = new();
    }
    public class BancaTipoCuentaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.TipoCuenta> TiposCuenta { get; set; } = new();
    }
    public class BancaUsuarioCuentaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta> UsuariosCuenta { get; set; } = new();
    }
}
