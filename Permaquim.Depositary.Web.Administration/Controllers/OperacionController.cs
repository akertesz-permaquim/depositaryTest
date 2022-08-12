﻿namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class OperacionController
    {

        #region Depositos
        public static List<MonitorEntities.TransaccionValidadaMonitor> ObtenerTransaccionesValidadasMonitor(Int64 pDepositarioID)
        {
            List<MonitorEntities.TransaccionValidadaMonitor> resultado = new();

            List<Depositary.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoMoneda);
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.RetiroValores);
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoBillete);

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            foreach (var transaccion in transacciones)
            {
                //Entities.Moneda? moneda = ObtenerMonedaTransaccion(transaccion.Id);
                var moneda = transaccion.MonedaId;
                if (moneda != null)
                {
                    MonitorEntities.TransaccionValidadaMonitor transaccionValidadaMonitor = new();
                    var usuarioTransaccion = transaccion.UsuarioId;
                    var usuarioCuenta = transaccion.UsuarioCuentaId;
                    var cuentaTransaccion = usuarioCuenta.CuentaId;
                    var detallesUsuarioCuenta = usuarioCuenta.UsuarioId;
                    transaccionValidadaMonitor.TransaccionId = transaccion.Id;
                    transaccionValidadaMonitor.TipoTransaccion = transaccion.TipoId.Nombre;
                    transaccionValidadaMonitor.Banco = cuentaTransaccion.BancoId.Nombre;
                    transaccionValidadaMonitor.Cuenta = cuentaTransaccion.Nombre;
                    transaccionValidadaMonitor.DepositarioId = transaccion._DepositarioId;
                    transaccionValidadaMonitor.FechaTransaccion = transaccion.Fecha;
                    transaccionValidadaMonitor.TotalValidado = moneda.Codigo + " " + transaccion.TotalValidado.ToString();
                    transaccionValidadaMonitor.UsuarioCuenta = detallesUsuarioCuenta.Nombre + " " + detallesUsuarioCuenta.Apellido;
                    transaccionValidadaMonitor.UsuarioTransaccion = usuarioTransaccion.Nombre + " " + usuarioTransaccion.Apellido;
                    transaccionValidadaMonitor.Moneda = moneda.Nombre;
                    resultado.Add(transaccionValidadaMonitor);
                }

            }

            return resultado;
        }

        public static List<MonitorEntities.DetalleTransaccionValidadaMonitor> ObtenerDetalleTransaccionValidadaMonitor(Int64 pTransaccionId)
        {
            List<MonitorEntities.DetalleTransaccionValidadaMonitor> resultado = new();

            Depositary.Business.Relations.Operacion.TransaccionDetalle transaccionDetalles = new();
            transaccionDetalles.Where.Add(Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, Depositary.sqlEnum.OperandEnum.Equal, pTransaccionId);
            transaccionDetalles.OrderByParameter.Add(Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Fecha, Depositary.sqlEnum.DirEnum.DESC);

            transaccionDetalles.Items();

            foreach (var transaccionDetalle in transaccionDetalles.Result)
            {
                var denominacionEnTransaccion = resultado.FirstOrDefault(x => x.DenominacionId == transaccionDetalle._DenominacionId);
                if (denominacionEnTransaccion != null)
                {
                    denominacionEnTransaccion.CantidadUnidades += transaccionDetalle.CantidadUnidades;
                    denominacionEnTransaccion.TotalValidado += (double)transaccionDetalle.DenominacionId.Unidades * transaccionDetalle.CantidadUnidades;
                }
                else
                {
                    var denominacion = transaccionDetalle.DenominacionId;
                    var moneda = denominacion.MonedaId;
                    MonitorEntities.DetalleTransaccionValidadaMonitor detalleTransaccionValidadaMonitor = new();
                    detalleTransaccionValidadaMonitor.TransaccionId = transaccionDetalle._TransaccionId;
                    detalleTransaccionValidadaMonitor.TransaccionDetalleId = transaccionDetalle.Id;
                    detalleTransaccionValidadaMonitor.ImagenDenominacion = transaccionDetalle.DenominacionId.Imagen;
                    detalleTransaccionValidadaMonitor.Denominacion = transaccionDetalle.DenominacionId.Nombre;
                    detalleTransaccionValidadaMonitor.DenominacionId = transaccionDetalle._DenominacionId;
                    detalleTransaccionValidadaMonitor.FechaTransaccionDetalle = transaccionDetalle.Fecha;
                    detalleTransaccionValidadaMonitor.CantidadUnidades = transaccionDetalle.CantidadUnidades;
                    detalleTransaccionValidadaMonitor.TotalValidado = (double)denominacion.Unidades * transaccionDetalle.CantidadUnidades;
                    detalleTransaccionValidadaMonitor.CodigoMoneda = moneda.Codigo;

                    resultado.Add(detalleTransaccionValidadaMonitor);
                }
            }
            return resultado;
        }

        public static List<Depositary.Entities.Relations.Operacion.Transaccion> ObtenerTransaccionesPorDepositario(Int64 pDepositarioId, bool bolsaActual, List<Int64>? monedasId = null, List<Int64>? tiposTransaccion = null, DateTime? pFechaDesde = null)
        {
            List<Depositary.Entities.Relations.Operacion.Transaccion> resultado = new();
            Depositary.Business.Relations.Operacion.Transaccion oTransaccion = new();
            oTransaccion.Where.Add(Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);
            //Si se solicita lo que esta en bolsa actualmente se busca solo en el contenedor indicado y si no se trae el historico.
            if (bolsaActual)
            {
                Int64? bolsaColocada = ObtenerBolsaColocada(pDepositarioId);
                if (bolsaColocada.HasValue)
                    oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, Depositary.sqlEnum.OperandEnum.Equal, bolsaColocada.Value);
                else
                    return resultado; //Si no hay bolsa colocada devolvemos result vacio.
            }
            if (monedasId != null)
            {
                oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId, Depositary.sqlEnum.OperandEnum.In, monedasId);

            }
            if (tiposTransaccion != null)
            {
                oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.In, tiposTransaccion);
            }
            if (pFechaDesde != null)
            {
                oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, pFechaDesde);
            }
            oTransaccion.OrderByParameter.Add(Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, Depositary.sqlEnum.DirEnum.DESC);

            oTransaccion.Items();

            foreach (var transaccion in oTransaccion.Result)
            {
                resultado.Add(transaccion);
            }


            return resultado;
        }

        public static Int64? ObtenerBolsaColocada(Int64 pDepositario)
        {
            Int64? bolsaColocada = new();

            Depositary.Business.Relations.Operacion.Contenedor oContenedor = new();
            oContenedor.Where.Add(Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre, Depositary.sqlEnum.OperandEnum.IsNull, 0); oContenedor.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre, Depositary.sqlEnum.OperandEnum.IsNull, 0);
            oContenedor.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, pDepositario);
            oContenedor.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre, Depositary.sqlEnum.OperandEnum.IsNull, 0);
            oContenedor.OrderByParameter.Add(Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaApertura, Depositary.sqlEnum.DirEnum.DESC);
            oContenedor.Items();

            if (oContenedor.Result.Count > 0)
            {
                bolsaColocada = oContenedor.Result.FirstOrDefault().Id;
                //foreach (var contenedor in oContenedor.Result)
                //{
                //    var bolsaTransaccion = contenedor.ListOf_Transaccion_ContenedorId.FirstOrDefault(x => x._DepositarioId == pDepositario);

                //    if (bolsaTransaccion != null)
                //    {
                //        bolsaColocada = bolsaTransaccion._ContenedorId;
                //        return bolsaColocada;
                //    }

                //}
            }

            return bolsaColocada;
        }

        #endregion

        #region Depositos con sobre
        public static List<MonitorEntities.TransaccionAValidarMonitor> ObtenerTransaccionesAValidarMonitor(Int64 pDepositarioID)
        {
            List<MonitorEntities.TransaccionAValidarMonitor> resultado = new();

            List<Depositary.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoSobre);

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            foreach (var transaccion in transacciones)
            {
                var transaccionSobre = transaccion.ListOf_TransaccionSobre_TransaccionId.FirstOrDefault();
                if (transaccionSobre != null)
                {
                    var moneda = transaccion.MonedaId;
                    var usuarioCuenta = transaccion.UsuarioCuentaId;
                    var cuenta = usuarioCuenta.CuentaId;
                    var banco = cuenta.BancoId;
                    var usuarioCuentaUsuario = usuarioCuenta.UsuarioId;
                    var usuarioTransaccion = transaccion.UsuarioId;
                    MonitorEntities.TransaccionAValidarMonitor transaccionAValidarMonitor = new();
                    transaccionAValidarMonitor.Banco = banco.Nombre;
                    transaccionAValidarMonitor.TipoTransaccion = transaccion.TipoId.Nombre;
                    transaccionAValidarMonitor.CodigoSobre = transaccionSobre.CodigoSobre;
                    transaccionAValidarMonitor.Cuenta = cuenta.Nombre;
                    transaccionAValidarMonitor.DepositarioId = transaccion._DepositarioId;
                    transaccionAValidarMonitor.FechaTransaccion = transaccion.Fecha;
                    transaccionAValidarMonitor.FechaTransaccionSobre = transaccionSobre.Fecha;
                    transaccionAValidarMonitor.TotalAValidar = moneda.Codigo + " " + transaccion.TotalAValidar.ToString();
                    transaccionAValidarMonitor.UsuarioCuenta = usuarioCuentaUsuario.Nombre + " " + usuarioCuentaUsuario.Apellido;
                    transaccionAValidarMonitor.UsuarioTransaccion = usuarioTransaccion.Nombre + " " + usuarioTransaccion.Apellido;
                    transaccionAValidarMonitor.TransaccionId = transaccion.Id;
                    transaccionAValidarMonitor.TransaccionSobreId = transaccionSobre.Id;
                    transaccionAValidarMonitor.Moneda = moneda.Nombre;
                    resultado.Add(transaccionAValidarMonitor);
                }

            }

            return resultado;
        }

        public static List<MonitorEntities.DetalleTransaccionAValidarMonitor> ObtenerDetalleTransaccionAValidarMonitor(Int64 pTransaccionSobreId)
        {
            List<MonitorEntities.DetalleTransaccionAValidarMonitor> resultado = new();

            Depositary.Business.Relations.Operacion.TransaccionSobreDetalle transaccionSobreDetalles = new();
            transaccionSobreDetalles.Where.Add(Depositary.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId, Depositary.sqlEnum.OperandEnum.Equal, pTransaccionSobreId);
            transaccionSobreDetalles.OrderByParameter.Add(Depositary.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.Fecha, Depositary.sqlEnum.DirEnum.DESC);

            transaccionSobreDetalles.Items();

            foreach (var transaccionDetalleSobre in transaccionSobreDetalles.Result)
            {
                var relacionMonedaTipoValor = transaccionDetalleSobre.RelacionMonedaTipoValorId;
                MonitorEntities.DetalleTransaccionAValidarMonitor detalleTransaccionAValidarMonitor = new();
                detalleTransaccionAValidarMonitor.TransaccionSobreId = transaccionDetalleSobre._SobreId;
                detalleTransaccionAValidarMonitor.TransaccionSobreDetalleId = transaccionDetalleSobre.Id;
                detalleTransaccionAValidarMonitor.FechaTransaccionSobreDetalle = transaccionDetalleSobre.Fecha;
                detalleTransaccionAValidarMonitor.CantidadDeclarada = transaccionDetalleSobre.CantidadDeclarada;
                detalleTransaccionAValidarMonitor.CodigoMoneda = relacionMonedaTipoValor.MonedaId.Codigo;
                detalleTransaccionAValidarMonitor.TipoValor = relacionMonedaTipoValor.TipoValorId.Nombre;
                detalleTransaccionAValidarMonitor.ValorDeclarado = transaccionDetalleSobre.ValorDeclarado;
                resultado.Add(detalleTransaccionAValidarMonitor);
            }

            return resultado;
        }


        #endregion

        #region Existencias

        public static float ObtenerPorcentajeOcupacionBolsa(Int64 pContenedorId)
        {
            float resultado = 0;
            Int64 cantidadMaxima = 0;
            Int64 cantidadUnidadesAcumuladas = 0;
            Depositary.Business.Relations.Operacion.Contenedor contenedor = new();
            contenedor.Where.Add(Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pContenedorId);

            contenedor.Items();

            if (contenedor.Result.Count > 0)
            {
                cantidadMaxima = contenedor.Result.FirstOrDefault().TipoId.Capacidad;
                Depositary.Business.Relations.Operacion.Transaccion transacciones = new();
                transacciones.Where.Add(Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, Depositary.sqlEnum.OperandEnum.Equal, pContenedorId);
                transacciones.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TransaccionEntities.TipoTransaccion.DepositoBillete);
                transacciones.Items();

                foreach (var transaccion in transacciones.Result)
                {
                    var transaccionDetalles = transaccion.ListOf_TransaccionDetalle_TransaccionId;
                    foreach (var transaccionDetalle in transaccionDetalles)
                    {
                        cantidadUnidadesAcumuladas += transaccionDetalle.CantidadUnidades;
                    }
                }
                resultado = (float)cantidadUnidadesAcumuladas * 100 / cantidadMaxima;
            }
            return resultado;
        }
        public static List<MonitorEntities.ExistenciaValidada> ObtenerExistenciasValidadasPorDepositario(Int64 pDepositarioID)
        {
            List<MonitorEntities.ExistenciaValidada> resultado = new();

            List<Depositary.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoMoneda);
            //tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.RetiroValores);
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoBillete);

            //Entities.Moneda? monedaPrincipal = DepositarioController.ObtenerMonedaPrincipalDepositario(pDepositarioID);

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            //Tengo que agrupar las posiciones de las transacciones por denominacion.
            foreach (var transaccion in transacciones)
            {
                foreach (var transaccionDetalle in transaccion.ListOf_TransaccionDetalle_TransaccionId)
                {
                    var itemExistenciaValidada = resultado.FirstOrDefault(x => x.DenominacionId == transaccionDetalle._DenominacionId);
                    if (itemExistenciaValidada != null)
                    {
                        itemExistenciaValidada.CantidadValidada += transaccionDetalle.CantidadUnidades;
                    }
                    else
                    {
                        Depositary.Entities.Relations.Valor.Denominacion denominacion = new();
                        Depositary.Entities.Relations.Valor.Moneda moneda = new();

                        MonitorEntities.ExistenciaValidada existenciaValidada = new();

                        denominacion = transaccionDetalle.DenominacionId;
                        moneda = denominacion.MonedaId;

                        existenciaValidada.CantidadValidada = transaccionDetalle.CantidadUnidades;
                        existenciaValidada.MonedaId = moneda.Id;
                        existenciaValidada.Moneda = moneda.Nombre;
                        existenciaValidada.Denominacion = denominacion.MonedaId.Codigo + " " + denominacion.Nombre;
                        existenciaValidada.DenominacionId = denominacion.Id;
                        existenciaValidada.ImagenDenominacion = denominacion.Imagen;
                        existenciaValidada.DepositarioId = transaccion._DepositarioId;
                        resultado.Add(existenciaValidada);
                    }
                }
            }

            return resultado;
        }

        public static List<MonitorEntities.ExistenciaAValidar> ObtenerExistenciasAValidarPorDepositario(Int64 pDepositarioID)
        {
            List<MonitorEntities.ExistenciaAValidar> resultado = new();

            List<Depositary.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoSobre);
            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            //Tengo que agrupar las posiciones de las transacciones de sobre por tipo de valor.
            foreach (var transaccion in transacciones)
            {
                var depositosSobre = transaccion.ListOf_TransaccionSobre_TransaccionId;
                foreach (var transaccionSobre in depositosSobre)
                {
                    var detallesTransaccionSobre = transaccionSobre.ListOf_TransaccionSobreDetalle_SobreId;
                    foreach (var detalleTransaccionSobre in detallesTransaccionSobre)
                    {
                        var relacionMonedaTipoValor = detalleTransaccionSobre.RelacionMonedaTipoValorId;
                        var tipoValorAValidar = resultado.FirstOrDefault(x => x.TipoValorId == relacionMonedaTipoValor._TipoValorId);
                        if (tipoValorAValidar != null)
                        {
                            tipoValorAValidar.Cantidad += detalleTransaccionSobre.CantidadDeclarada;
                        }
                        else
                        {
                            MonitorEntities.ExistenciaAValidar nuevoTipoValorAValidar = new();
                            var tipoValor = relacionMonedaTipoValor.TipoValorId;
                            nuevoTipoValorAValidar.Cantidad = detalleTransaccionSobre.CantidadDeclarada;
                            nuevoTipoValorAValidar.Moneda = relacionMonedaTipoValor.MonedaId.Nombre;
                            nuevoTipoValorAValidar.TipoValorId = tipoValor.Id;
                            nuevoTipoValorAValidar.TipoValor = tipoValor.Nombre;
                            nuevoTipoValorAValidar.DepositarioId = pDepositarioID;
                            nuevoTipoValorAValidar.ImagenTipoValor = tipoValor.Imagen;

                            resultado.Add(nuevoTipoValorAValidar);
                        }
                    }

                }
            }
            return resultado;

        }

        #endregion

        #region Eventos

        public static List<MonitorEntities.Evento> ObtenerEventosPorDepositario(Int64 pDepositarioId)
        {
            List<MonitorEntities.Evento> resultado = new();

            Depositary.Business.Relations.Operacion.Evento oEvento = new();
            oEvento.Where.Add(Depositary.Business.Relations.Operacion.Evento.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);
            oEvento.OrderByParameter.Add(Depositary.Business.Relations.Operacion.Evento.ColumnEnum.Fecha, Depositary.sqlEnum.DirEnum.DESC);

            oEvento.Items();

            foreach (var evento in oEvento.Result)
            {
                MonitorEntities.Evento auxEvento = new();
                auxEvento.FechaEvento = evento.Fecha;
                auxEvento.Valor = evento.Valor;
                auxEvento.Mensaje = evento.Mensaje;
                auxEvento.TipoEvento = evento.TipoId.Nombre;
                auxEvento.DepositarioId = evento._DepositarioId;
                resultado.Add(auxEvento);
            }

            return resultado;
        }

        #endregion

        #region Totales generales

        public static List<MonitorEntities.TotalGeneral> ObtenerTotalesGeneralesPorDepositarioSegunMoneda(Int64 pDepositarioID)
        {
            List<MonitorEntities.TotalGeneral> resultado = new();
            List<Depositary.Entities.Relations.Operacion.Transaccion> transacciones = new();

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, null);

            foreach (var transaccion in transacciones)
            {
                var moneda = transaccion.MonedaId;

                if (moneda != null)
                {
                    var itemTotalGeneral = resultado.FirstOrDefault(x => x.MonedaId == moneda.Id);
                    if (itemTotalGeneral != null)
                    {
                        itemTotalGeneral.TotalAValidar += transaccion.TotalAValidar;
                        itemTotalGeneral.TotalValidado += transaccion.TotalValidado;
                    }
                    else
                    {
                        MonitorEntities.TotalGeneral totalGeneral = new();

                        totalGeneral.TotalAValidar = transaccion.TotalAValidar;
                        totalGeneral.TotalValidado = transaccion.TotalValidado;
                        totalGeneral.Moneda = moneda.Nombre;
                        totalGeneral.MonedaId = moneda.Id;
                        totalGeneral.DepositarioId = transaccion._DepositarioId;
                        resultado.Add(totalGeneral);
                    }
                }
            }
            return resultado;
        }

        public static List<Depositary.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado> ObtenerTotalesGeneralesPorMonedaDepositario(Int64 pDepositarioID)
        {
            List<Depositary.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado> resultado = new List<Depositary.Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado>();
            Depositary.Business.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario oSP = new Depositary.Business.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario();

            oSP.Items(pDepositarioID);

            resultado = oSP.MappedResultSet.Resultado;

            return resultado;
        }

        #endregion

        #region Dashboard

        public static string ObtenerCantidadTransaccionesPorDia(DateTime pFecha, List<Int64> pEmpresasSeleccionadas)
        {
            string resultado = "";

            //Crear una funcion que me devuelva una lista de depositarios por empresa
            var depositarios = DepositarioController.ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

            if (depositarios != null)
            {
                if (depositarios.Count > 0)
                {
                    //Levanto transacciones con un IN y con la fecha de hoy.
                    Depositary.Business.Relations.Operacion.Transaccion oTransaccion = new();
                    oTransaccion.Where.Add(Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, pFecha);
                    oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.In, depositarios);
                    oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.LessThan, pFecha.AddDays(1));

                    oTransaccion.Items();

                    resultado = oTransaccion.Result.Count.ToString();
                }
            }

            return resultado;
        }
        #endregion

        #region Dashboard

        public static List<Entities.TransaccionTipoCantidad> ObtenerCantidadTipoTransacciones(List<Int64> pEmpresasSeleccionadas)
        {
            List<Entities.TransaccionTipoCantidad> resultado = new();

            int transaccionesTotales = 0;
            var depositarios = DepositarioController.ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

            if (depositarios != null)
            {
                if (depositarios.Count > 0)
                {
                    Depositary.Business.Relations.Operacion.Transaccion oTransaccion = new();
                    oTransaccion.Where.Add(Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Today);
                    oTransaccion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.In, depositarios);

                    oTransaccion.Items();

                    if (oTransaccion.Result.Count > 0)
                    {
                        foreach (var transaccion in oTransaccion.Result)
                        {
                            var existenciaTipoTransaccion = resultado.FirstOrDefault(x => x.TipoTransaccionId == transaccion._TipoId);
                            if (existenciaTipoTransaccion != null)
                            {
                                existenciaTipoTransaccion.CantidadTipoTransaccion++;
                            }
                            else
                            {
                                Entities.TransaccionTipoCantidad transaccionTipoCantidad = new();
                                transaccionTipoCantidad.NombreTipoTransaccion = transaccion.TipoId.Nombre;
                                transaccionTipoCantidad.CantidadTipoTransaccion = 1;
                                transaccionTipoCantidad.TipoTransaccionId = transaccion._TipoId;
                                resultado.Add(transaccionTipoCantidad);
                            }
                            transaccionesTotales++;
                        }
                    }
                }
            }


            foreach (var transaccionTipo in resultado)
            {
                transaccionTipo.NombreTipoTransaccionConPorcentaje = transaccionTipo.NombreTipoTransaccion + ": " + ((decimal)transaccionTipo.CantidadTipoTransaccion * 100 / transaccionesTotales).ToString("n2") + "%";
            }

            return resultado;
        }

        #endregion

        public static List<TransaccionEntities.Contenedor> ObtenerContenedores(bool obtenerSoloHabilitados = true)
        {
            List<TransaccionEntities.Contenedor> resultado = new();

            Depositary.Business.Tables.Operacion.Contenedor oContenedor = new();
            if (obtenerSoloHabilitados)
                oContenedor.Where.Add(Depositary.Business.Tables.Operacion.Contenedor.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oContenedor.Items();

            if (oContenedor.Result.Count > 0)
            {
                foreach (var contenedor in oContenedor.Result)
                {
                    TransaccionEntities.Contenedor contenedorEntitie = new();
                    contenedorEntitie.ContenedorId = contenedor.Id;
                    contenedorEntitie.Identificador = contenedor.Identificador;

                    resultado.Add(contenedorEntitie);
                }
            }

            return resultado;
        }

        public static List<TurnoEntities.TurnoComboReporte> ObtenerTurnosReporte()
        {
            List<TurnoEntities.TurnoComboReporte> resultado = new();

            Depositary.Business.Relations.Turno.EsquemaTurno oEsquemaTurno = new();

            oEsquemaTurno.Items();

            if (oEsquemaTurno.Result.Count > 0)
            {
                foreach (var esquema in oEsquemaTurno.Result)
                {
                    foreach(var esquemaDetalle in esquema.ListOf_EsquemaDetalleTurno_EsquemaTurnoId)
                    {
                        TurnoEntities.TurnoComboReporte turnoComboReporte = new();
                        turnoComboReporte.NombreEsquema = esquema.Nombre;
                        turnoComboReporte.NombreEsquemaDetalle = esquemaDetalle.Nombre;
                        turnoComboReporte.TurnoEsquemaDetalleId = esquemaDetalle.Id;

                        resultado.Add(turnoComboReporte);
                    }
                }
            }

            return resultado;
        }

    }
}