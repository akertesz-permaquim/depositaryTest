﻿namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class TransaccionController
    {

        #region Depositos
        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> ObtenerTransaccionesPorDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTransaccionesPorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTransaccionesPorDepositario();

            resultado = oSP.Items(pDepositarioID);

            return resultado;
        }

        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccion> ObtenerDetalleTransaccion(Int64 pTransaccionID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccion> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccion>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerDetalleTransaccion oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerDetalleTransaccion();

            resultado = oSP.Items(pTransaccionID);

            return resultado;
        }

        #endregion

        #region Depositos con sobre
        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> ObtenerTransaccionesSobrePorDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario();

            resultado = oSP.Items(pDepositarioID);

            return resultado;
        }

        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> ObtenerDetalleTransaccionSobre(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerDetalleTransaccionSobre oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerDetalleTransaccionSobre();

            resultado = oSP.Items(pDepositarioID);

            return resultado;
        }

        #endregion

        #region Eventos
        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario> ObtenerEventosPorDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerEventosPorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerEventosPorDepositario();

            resultado = oSP.Items(pDepositarioID);

            return resultado;
        }
        #endregion
    }
}
