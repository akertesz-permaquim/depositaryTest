using DepositaryWebApi.Entities.Views.Integracion;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class IntegracionTransaccionModel
    {


        //public string CodigoExternoDepositario { get; set; }
        //public List<Contenedor> Contenedores { get; set; }
        public List<OperacionTransaccion>? Transacciones { get; set; } = new();
        public List<OperacionTransaccionDetalle>? TransaccionesDetalles { get; set; } = new();
        public List<OperacionTransaccionSobre>? TransaccionesSobres { get; set; } = new();
        public List<OperacionTransaccionSobreDetalle>? TransaccionesSobresDetalles { get; set; } = new();


    }
  
}
