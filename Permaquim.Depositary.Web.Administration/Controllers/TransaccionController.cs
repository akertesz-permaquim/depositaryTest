namespace Permaquim.Depositary.Web.Administration.Controllers
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

        //public static List<Entities.TransaccionDepositarioMonedaDefault> ObtenerTransaccionesDepositarioMonedaDefault(Int64 pDepositarioId, bool enBolsa)
        //{
        //    List<Entities.TransaccionDepositarioMonedaDefault> resultado = new();
        //    Entities.Moneda monedaDefaultDepositario = DepositarioController.ObtenerMonedaPrincipalDepositario(pDepositarioId);
        //    DepositarioAdminWeb.Business.Relations.Operacion.Transaccion oTransaccion = new();
        //    oTransaccion.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pDepositarioId);
        //    //Si se solicita lo que esta en bolsa actualmente se busca solo en el contenedor indicado
        //    if(enBolsa)
        //    {
        //        Int64? bolsaColocada = ObtenerBolsaColocada(pDepositarioId).Value;
        //        if (bolsaColocada.HasValue)
        //            oTransaccion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, bolsaColocada.Value);
        //        else
        //            return resultado; //Si no hay bolsa colocada devolvemos result vacio.
        //    }

        //    oTransaccion.Items();

        //    foreach(var transaccion in oTransaccion.Result)
        //    {
        //        Entities.TransaccionDepositarioMonedaDefault transaccionDepositarioMonedaDefault = new();

        //        transaccionDepositarioMonedaDefault.TransaccionId = transaccion.Id;
        //        transaccionDepositarioMonedaDefault.DepositarioId = transaccion.DepositarioId.Id;
        //        transaccionDepositarioMonedaDefault.TotalAValidar = transaccion.TotalAValidar;
        //        transaccionDepositarioMonedaDefault.TotalValidado = transaccion.TotalValidado;
        //        transaccionDepositarioMonedaDefault.MonedaId = transaccion.SucursalId.

        //        foreach(var transaccionDetalle in transaccion.ListOf_TransaccionDetalle_TransaccionId.Where(x => x.DenominacionId.MonedaId.Id == monedaDefaultDepositario.Id))
        //        {

        //        }


        //    }


        //    return resultado;
        //}

        public static Int64? ObtenerBolsaColocada(Int64 pDepositario)
        {
            Int64? bolsaColocada = new();

            DepositarioAdminWeb.Business.Relations.Operacion.Contenedor oContenedor = new();
            oContenedor.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Now);

            oContenedor.Items();

            foreach(var contenedor in oContenedor.Result)
            {
                foreach(var transaccion in contenedor.ListOf_Transaccion_ContenedorId.Where(x => x.DepositarioId.Id == pDepositario))
                {
                    bolsaColocada = contenedor.Id;
                }
            }

            return bolsaColocada;
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

        #region Existencias
        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado> ObtenerExistenciasPorDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerExistenciasPorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerExistenciasPorDepositario();

            oSP.Items(pDepositarioID);

            resultado = oSP.MappedResultSet.Resultado;

            return resultado;
        }
        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado> ObtenerExistenciasAValidarPorDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario();

            oSP.Items(pDepositarioID);

            resultado = oSP.MappedResultSet.Resultado;

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

        #region Totales generales

        public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado> ObtenerTotalesGeneralesPorMonedaDepositario(Int64 pDepositarioID)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado>();
            DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario();

            oSP.Items(pDepositarioID);

            resultado = oSP.MappedResultSet.Resultado;

            return resultado;
        }

        #endregion

        #region Dashboard

        public static int ObtenerCantidadTransaccionesPorDia(DateTime pFecha)
        {
            int resultado = 0;
            DepositarioAdminWeb.Business.Tables.Operacion.Transaccion oTransaccion = new();
            oTransaccion.Where.Add(DepositarioAdminWeb.Business.Tables.Operacion.Transaccion.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, pFecha);
            oTransaccion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Operacion.Transaccion.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.LessThan, pFecha.AddDays(1));
            resultado = oTransaccion.Items().Count;

            return resultado;
        }

        #endregion

    }
}
