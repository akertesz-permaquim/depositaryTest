namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DepositarioController
    {
        public static List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios> ObtenerDepositarios()
        {
            List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios>();
            DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios oSP = new DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios();
            
            resultado = oSP.Items();

            return resultado;
        }
    }
}
