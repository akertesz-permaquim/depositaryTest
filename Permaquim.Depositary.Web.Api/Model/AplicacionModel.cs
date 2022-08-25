namespace Permaquim.Depositary.Web.Api.Model
{
    public class AplicacionModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> Configuraciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionesEmpresas { get; set; } = new();
    }
    public class AplicacionConfiguracionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> Configuraciones { get; set; } = new();
    }
    public class AplicacionConfiguracionEmpresaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa> ConfiguracionesEmpresas { get; set; } = new();
    }
}
