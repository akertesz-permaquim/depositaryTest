namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class AplicacionController
    {
        public static string ObtenerConfiguracion(string pClave)
        {
            string resultado= "";

            //Obtengo la aplicacion
            DepositarioAdminWeb.Business.Tables.Seguridad.Aplicacion oAplicacion = new();
            oAplicacion.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Aplicacion.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SeguridadEntities.TipoAplicacion.Web);
            oAplicacion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Aplicacion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oAplicacion.Items();

            if(oAplicacion.Result.Count>0)
            {
                DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion oConfiguracion = new();
                oConfiguracion.Where.Add(DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, oAplicacion.Result.FirstOrDefault().Id );
                oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pClave);

                oConfiguracion.Items();

                if(oConfiguracion.Result.Count>0)
                {
                    resultado = oConfiguracion.Result.FirstOrDefault().Valor;
                }
            }

            return resultado;
        }
    }
}
