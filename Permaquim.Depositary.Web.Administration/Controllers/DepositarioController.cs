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

        public static DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado ObtenerInformacionDepositario(Int64 pDepositarioId)
        {
            DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado resultado = new DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado();
            DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerInformacionDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerInformacionDepositario();

            oSP.Items(pDepositarioId);

            resultado = oSP.MappedResultSet.Resultado.FirstOrDefault();

            return resultado;
        }
    }
}
