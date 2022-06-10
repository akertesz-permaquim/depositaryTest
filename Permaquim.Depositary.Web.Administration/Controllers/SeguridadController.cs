namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class SeguridadController
    {
        public static DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario ObtenerUsuario(string pUsername, string pPassword)
        {
            DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario resultado = new DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario();
            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oTable = new DepositarioAdminWeb.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Password, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pPassword);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                resultado = oTable.Result.FirstOrDefault();
            }

            return resultado;
        }

        public static List<DepositarioAdminWeb.Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> ObtenerRolesPorUsuario(Int64 pUsuarioId)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Seguridad.ObtenerRolesPorUsuario>();
            DepositarioAdminWeb.Business.Procedures.Seguridad.ObtenerRolesPorUsuario oSP = new DepositarioAdminWeb.Business.Procedures.Seguridad.ObtenerRolesPorUsuario();
            resultado = oSP.Items(pUsuarioId);

            return resultado;
        }

    }
}
