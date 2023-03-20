using DepositaryWebApi.Business.Relations.Aplicacion;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class ConfiguracionModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ConfiguracionAplicacion { get; set; }

        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionDepositario { get; set; }


    }
}
