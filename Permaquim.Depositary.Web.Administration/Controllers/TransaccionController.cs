﻿namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class TransaccionController
    {

        #region Depositos
        public static List<Entities.TransaccionValidadaMonitor> ObtenerTransaccionesValidadasMonitor(Int64 pDepositarioID)
        {
            List<Entities.TransaccionValidadaMonitor> resultado = new();

            List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoMoneda);
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.RetiroValores);
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoBillete);

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            foreach (var transaccion in transacciones)
            {
                Entities.Moneda? moneda = ObtenerMonedaTransaccion(transaccion.Id);
                if (moneda != null)
                {
                    Entities.TransaccionValidadaMonitor transaccionValidadaMonitor = new();
                    transaccionValidadaMonitor.TransaccionId = transaccion.Id;
                    transaccionValidadaMonitor.TipoTransaccion = transaccion.TipoId.Nombre;
                    transaccionValidadaMonitor.Banco = transaccion.UsuarioCuentaId.CuentaId.BancoId.Nombre;
                    transaccionValidadaMonitor.Cuenta = transaccion.UsuarioCuentaId.CuentaId.Nombre;
                    transaccionValidadaMonitor.Contenedor = transaccion.ContenedorId.Identificador;
                    transaccionValidadaMonitor.DepositarioId = transaccion._DepositarioId;
                    transaccionValidadaMonitor.FechaTransaccion = transaccion.Fecha;
                    transaccionValidadaMonitor.TotalValidado = moneda.Codigo + " " + transaccion.TotalValidado.ToString();
                    transaccionValidadaMonitor.UsuarioCuenta = transaccion.UsuarioCuentaId.UsuarioId.Nombre + " " + transaccion.UsuarioCuentaId.UsuarioId.Apellido;
                    transaccionValidadaMonitor.UsuarioTransaccion = transaccion.UsuarioId.ToString(); //REVISAR FALTA FK.
                    resultado.Add(transaccionValidadaMonitor);
                }

            }

            return resultado;
        }

        public static List<Entities.DetalleTransaccionValidadaMonitor> ObtenerDetalleTransaccionValidadaMonitor(Int64 pTransaccionId)
        {
            List<Entities.DetalleTransaccionValidadaMonitor> resultado = new();

            DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle transaccionDetalles = new();
            transaccionDetalles.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pTransaccionId);
            transaccionDetalles.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            transaccionDetalles.Items();

            foreach (var transaccionDetalle in transaccionDetalles.Result)
            {
                Entities.DetalleTransaccionValidadaMonitor detalleTransaccionValidadaMonitor = new();
                detalleTransaccionValidadaMonitor.TransaccionId = transaccionDetalle._TransaccionId;
                detalleTransaccionValidadaMonitor.TransaccionDetalleId = transaccionDetalle.Id;
                detalleTransaccionValidadaMonitor.ImagenDenominacion = transaccionDetalle.DenominacionId.Imagen;
                detalleTransaccionValidadaMonitor.Denominacion = transaccionDetalle.DenominacionId.Nombre;
                detalleTransaccionValidadaMonitor.FechaTransaccionDetalle = transaccionDetalle.Fecha;
                detalleTransaccionValidadaMonitor.CantidadUnidades = transaccionDetalle.CantidadUnidades;
                detalleTransaccionValidadaMonitor.Moneda = transaccionDetalle.DenominacionId.MonedaId.Nombre;
                resultado.Add(detalleTransaccionValidadaMonitor);
            }

            return resultado;
        }

        public static List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ObtenerTransaccionesPorDepositario(Int64 pDepositarioId, bool bolsaActual, Int64? monedaId = null, List<Int64>? tiposTransaccion = null)
        {
            List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> resultado = new();
            DepositarioAdminWeb.Business.Relations.Operacion.Transaccion oTransaccion = new();
            oTransaccion.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pDepositarioId);
            //Si se solicita lo que esta en bolsa actualmente se busca solo en el contenedor indicado y si no se trae el historico.
            if (bolsaActual)
            {
                Int64? bolsaColocada = ObtenerBolsaColocada(pDepositarioId);
                if (bolsaColocada.HasValue)
                    oTransaccion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, bolsaColocada.Value);
                else
                    return resultado; //Si no hay bolsa colocada devolvemos result vacio.
            }
            if (tiposTransaccion != null)
            {
                oTransaccion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.In, tiposTransaccion);
            }
            oTransaccion.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            oTransaccion.Items();

            foreach (var transaccion in oTransaccion.Result)
            {
                //Si se buscan con moneda default se filtra segun moneda.
                if (monedaId.HasValue)
                {
                    //Si la transaccion tiene la moneda principal entonces la guardo.
                    var monedaTransaccion = TransaccionController.ObtenerMonedaTransaccion(transaccion.Id);
                    if (monedaTransaccion != null)
                    {
                        if (monedaTransaccion.Id == monedaId)
                        {
                            resultado.Add(transaccion);
                        }
                    }
                }
                else
                {
                    resultado.Add(transaccion);
                }

            }


            return resultado;
        }

        public static Entities.Moneda? ObtenerMonedaTransaccion(Int64 pTransaccionId)
        {
            DepositarioAdminWeb.Entities.Relations.Valor.Moneda? moneda = null;
            Entities.Moneda? resultado = null;
            DepositarioAdminWeb.Business.Relations.Operacion.Transaccion oTransaccion = new();
            oTransaccion.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pTransaccionId);

            oTransaccion.Items();

            if (oTransaccion.Result.Count > 0)
            {
                var transaccion = oTransaccion.Result.FirstOrDefault();
                //Determinamos si es una transaccion validada o de tipo sobre.
                List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionDetalle> transaccionDetalles = new();
                transaccionDetalles = transaccion.ListOf_TransaccionDetalle_TransaccionId;

                if (transaccionDetalles.Count > 0)
                {
                    //Tomamos la primera posicion y con la denominacion obtenemos la moneda
                    moneda = transaccionDetalles.FirstOrDefault().DenominacionId.MonedaId;

                }
                else //se supone que si no es de dinero validado es de tipo sobre
                {
                    var transaccionSobre = transaccion.ListOf_TransaccionSobre_TransaccionId.FirstOrDefault();
                    if (transaccionSobre != null)
                    {
                        var transaccionSobreDetalle = transaccionSobre.ListOf_TransaccionSobreDetalle_SobreId.FirstOrDefault();
                        if (transaccionSobreDetalle != null)
                        {
                            //Tomamos la primera posicion y con la relacion de denominacion obtenemos la moneda
                            moneda = transaccionSobreDetalle.RelacionMonedaTipoValorId.MonedaId;
                        }

                    }

                }
            }

            if (moneda != null)
            {
                resultado = new();
                resultado.Id = moneda.Id;
                resultado.Nombre = moneda.Nombre;
                resultado.Codigo = moneda.Codigo;
                resultado.Simbolo = moneda.Simbolo;
                resultado.Habilitado = moneda.Habilitado;
                resultado.IndiceEnContadora = moneda.IndiceEnContadora;
                resultado.UsuarioCreacion = moneda.UsuarioCreacion.ToString();
                resultado.FechaCreacion = moneda.FechaCreacion;
                resultado.FechaModificacion = moneda.FechaModificacion;
                resultado.UsuarioModificacion = moneda.UsuarioModificacion.ToString();
            }

            return resultado;
        }

        public static Int64? ObtenerBolsaColocada(Int64 pDepositario)
        {
            Int64? bolsaColocada = new();

            DepositarioAdminWeb.Business.Relations.Operacion.Contenedor oContenedor = new();
            oContenedor.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Now);

            oContenedor.Items();

            if(oContenedor.Result.Count>0)
            {
                foreach (var contenedor in oContenedor.Result)
                {
                    var bolsaTransaccion = contenedor.ListOf_Transaccion_ContenedorId.FirstOrDefault(x => x._DepositarioId == pDepositario);

                    if (bolsaTransaccion != null)
                    {
                        bolsaColocada = bolsaTransaccion._ContenedorId;
                        return bolsaColocada;
                    }

                }
            }

            return bolsaColocada;
        }

        #endregion

        #region Depositos con sobre
        public static List<Entities.TransaccionAValidarMonitor> ObtenerTransaccionesAValidarMonitor(Int64 pDepositarioID)
        {
            List<Entities.TransaccionAValidarMonitor> resultado = new();

            List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> transacciones = new();

            List<Int64> tiposTransaccion = new();
            tiposTransaccion.Add((Int64)TransaccionEntities.TipoTransaccion.DepositoSobre);

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, tiposTransaccion);

            foreach (var transaccion in transacciones)
            {
                Entities.Moneda moneda = new();
                var transaccionSobre = transaccion.ListOf_TransaccionSobre_TransaccionId.FirstOrDefault();
                if(transaccionSobre!=null)
                {
                    moneda = ObtenerMonedaTransaccion(transaccion.Id);
                    var usuarioCuenta = transaccion.UsuarioCuentaId;
                    var cuenta = usuarioCuenta.CuentaId;
                    var banco = cuenta.BancoId;
                    var usuarioCuentaUsuario = usuarioCuenta.UsuarioId;
                    Entities.TransaccionAValidarMonitor transaccionAValidarMonitor = new();
                    transaccionAValidarMonitor.Banco = banco.Nombre;
                    transaccionAValidarMonitor.TipoTransaccion = transaccion.TipoId.Nombre;
                    transaccionAValidarMonitor.CodigoSobre = transaccionSobre.CodigoSobre;
                    transaccionAValidarMonitor.Cuenta = cuenta.Nombre;
                    transaccionAValidarMonitor.Contenedor = transaccion.ContenedorId.Identificador;
                    transaccionAValidarMonitor.DepositarioId = transaccion._DepositarioId;
                    transaccionAValidarMonitor.FechaTransaccion = transaccion.Fecha;
                    transaccionAValidarMonitor.FechaTransaccionSobre = transaccionSobre.Fecha;
                    transaccionAValidarMonitor.TotalAValidar = moneda.Codigo + " " + transaccion.TotalAValidar.ToString();
                    transaccionAValidarMonitor.UsuarioCuenta = usuarioCuentaUsuario.Nombre + " " + usuarioCuentaUsuario.Apellido;
                    transaccionAValidarMonitor.UsuarioTransaccion = transaccion.UsuarioId.ToString(); //REVISAR FALTA FK.
                    transaccionAValidarMonitor.UsuarioCuenta = usuarioCuentaUsuario.Nombre + " " + usuarioCuentaUsuario.Apellido;
                    transaccionAValidarMonitor.TransaccionId = transaccion.Id;
                    transaccionAValidarMonitor.TransaccionSobreId = transaccionSobre.Id;
                    resultado.Add(transaccionAValidarMonitor);
                }
                
            }

            return resultado;
        }

        public static List<Entities.DetalleTransaccionAValidarMonitor> ObtenerDetalleTransaccionAValidarMonitor(Int64 pTransaccionSobreId)
        {
            List<Entities.DetalleTransaccionAValidarMonitor> resultado = new();

            DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle transaccionSobreDetalles = new();
            transaccionSobreDetalles.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            transaccionSobreDetalles.Items();

            foreach (var transaccionDetalleSobre in transaccionSobreDetalles.Result)
            {
                Entities.DetalleTransaccionAValidarMonitor detalleTransaccionAValidarMonitor = new();
                detalleTransaccionAValidarMonitor.TransaccionSobreId = transaccionDetalleSobre.SobreId.Id;
                detalleTransaccionAValidarMonitor.TransaccionSobreDetalleId = transaccionDetalleSobre.Id;
                detalleTransaccionAValidarMonitor.FechaTransaccionSobreDetalle = transaccionDetalleSobre.Fecha;
                detalleTransaccionAValidarMonitor.CantidadDeclarada = transaccionDetalleSobre.CantidadDeclarada;
                detalleTransaccionAValidarMonitor.Moneda = transaccionDetalleSobre.RelacionMonedaTipoValorId.MonedaId.Nombre;
                detalleTransaccionAValidarMonitor.TipoValor = transaccionDetalleSobre.RelacionMonedaTipoValorId.TipoValorId.Nombre;
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
            DepositarioAdminWeb.Business.Relations.Operacion.Contenedor contenedor = new();
            contenedor.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Contenedor.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pContenedorId);

            contenedor.Items();

            if (contenedor.Result.Count > 0)
            {
                cantidadMaxima = contenedor.Result.FirstOrDefault().TipoId.Capacidad;
                DepositarioAdminWeb.Business.Relations.Operacion.Transaccion transacciones = new();
                transacciones.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pContenedorId);
                
                transacciones.Items();

                foreach (var transaccion in transacciones.Result)
                {
                    var transaccionDetalles = transaccion.ListOf_TransaccionDetalle_TransaccionId;
                    foreach (var transaccionDetalle in transaccionDetalles)
                    {
                        cantidadUnidadesAcumuladas += transaccionDetalle.CantidadUnidades;
                    }
                }
                resultado = cantidadUnidadesAcumuladas * 100 / cantidadMaxima;
            }
            return resultado;
        }
        public static List<Entities.ExistenciaValidada> ObtenerExistenciasValidadasPorDepositario(Int64 pDepositarioID)
        {
            List<Entities.ExistenciaValidada> resultado = new();

            List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> transacciones = new();

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
                        DepositarioAdminWeb.Entities.Relations.Valor.Denominacion denominacion = new();
                        DepositarioAdminWeb.Entities.Relations.Valor.Moneda moneda = new();

                        Entities.ExistenciaValidada existenciaValidada = new();

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
        //public static List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario> ObtenerEventosPorDepositario(Int64 pDepositarioID)
        //{
        //    List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Operacion.ObtenerEventosPorDepositario>();
        //    DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerEventosPorDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Operacion.ObtenerEventosPorDepositario();

        //    resultado = oSP.Items(pDepositarioID);

        //    return resultado;
        //}

        public static List<Entities.Evento> ObtenerEventosPorDepositario(Int64 pDepositarioId)
        {
            List<Entities.Evento> resultado = new();

            DepositarioAdminWeb.Business.Relations.Operacion.Evento oEvento = new();
            oEvento.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Evento.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pDepositarioId);
            oEvento.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Operacion.Evento.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            oEvento.Items();

            foreach(var evento in oEvento.Result)
            {
                Entities.Evento auxEvento = new();
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

        public static List<Entities.TotalGeneral> ObtenerTotalesGeneralesPorDepositarioSegunMoneda(Int64 pDepositarioID)
        {
            List<Entities.TotalGeneral> resultado = new();
            List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> transacciones = new();

            transacciones = ObtenerTransaccionesPorDepositario(pDepositarioID, true, null, null);

            foreach (var transaccion in transacciones)
            {
                Entities.Moneda? moneda = new();
                moneda = ObtenerMonedaTransaccion(transaccion.Id);

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
                        Entities.TotalGeneral totalGeneral = new();

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

        public static List<Entities.TransaccionTipoCantidad> ObtenerCantidadTipoTransacciones()
        {
            List<Entities.TransaccionTipoCantidad> resultado = new();
            DepositarioAdminWeb.Business.Relations.Operacion.Transaccion oTransaccion = new();
            oTransaccion.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Today);

            oTransaccion.Items();

            if(oTransaccion.Result.Count>0)
            {
                foreach(var transaccion in oTransaccion.Result)
                {
                    var existenciaTipoTransaccion = resultado.FirstOrDefault(x => x.TipoTransaccionId == transaccion._TipoId);
                    if(existenciaTipoTransaccion != null)
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
                }
            }

            return resultado;
        }

        #endregion

    }
}
