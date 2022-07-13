using DepositaryWebApi.Business.Relations.Aplicacion;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class ConfiguracionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion> ConfiguracionAplicacion { get; set; }

        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionDispositivo { get; set; }


    }
}
