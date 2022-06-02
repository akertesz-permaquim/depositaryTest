namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class MultilenguajeController
    {
        public static List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> ObtenerTextosLenguaje(Int64 pUsuarioId)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>();
            DepositarioAdminWeb.Business.Procedures.Regionalizacion.ObtenerTextosLenguaje oSP = new DepositarioAdminWeb.Business.Procedures.Regionalizacion.ObtenerTextosLenguaje();

            oSP.Items(pUsuarioId);

            resultado = oSP.MappedResultSet.Resultado;

            return resultado;
        }
    }
}
