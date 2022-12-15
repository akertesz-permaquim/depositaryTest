using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    public static class SynchronizationController
    {
        public static Int64? IniciarCabeceraSincronizacionInicial(string pNombreEntidad)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                var entidadSincronizacion = oSincronizacionEntidad.Result.FirstOrDefault();
                //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionEntidadCabecera = new();

                eSincronizacionEntidadCabecera.EntidadId = entidadSincronizacion.Id;
                eSincronizacionEntidadCabecera.Fechainicio = DateTime.Now;
                eSincronizacionEntidadCabecera.DepositarioId = null;
                //eSincronizacionEntidadCabecera.DepositarioId = DatabaseController.CurrentDepositary != null ? DatabaseController.CurrentDepositary.Id : null;
                eSincronizacionEntidadCabecera.Valor = entidadSincronizacion.Nombre;

                try
                {
                    Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionNuevaEntidadCabecera = new();

                    eSincronizacionNuevaEntidadCabecera = oSincronizacionEntidadCabecera.Add(eSincronizacionEntidadCabecera);

                    resultado = eSincronizacionNuevaEntidadCabecera.Id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return resultado;
        }

        public static Int64? IniciarCabeceraSincronizacion(string pNombreEntidad)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                var entidadSincronizacion = oSincronizacionEntidad.Result.FirstOrDefault();
                //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionEntidadCabecera = new();

                eSincronizacionEntidadCabecera.EntidadId = entidadSincronizacion.Id;
                eSincronizacionEntidadCabecera.Fechainicio = DateTime.Now;
                eSincronizacionEntidadCabecera.DepositarioId = ConfigurationController.GetCurrentDepositaryId();
                eSincronizacionEntidadCabecera.Valor = entidadSincronizacion.Nombre;

                try
                {
                    Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionNuevaEntidadCabecera = new();

                    eSincronizacionNuevaEntidadCabecera = oSincronizacionEntidadCabecera.Add(eSincronizacionEntidadCabecera);

                    resultado = eSincronizacionNuevaEntidadCabecera.Id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return resultado;
        }

        public static bool FinalizarCabeceraSincronizacion(Int64 pCabeceraSincronizacionId)
        {
            //Por defecto no se pudo registrar el cierre de la sincronizacion para la entidad.
            bool resultado = false;
            //Buscamos el registro en funcion del id recibido
            Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
            oSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, Depositario.sqlEnum.OperandEnum.Equal, pCabeceraSincronizacionId);
            oSincronizacionEntidadCabecera.Items();

            if (oSincronizacionEntidadCabecera.Result.Count > 0)
            {
                var entidadSincronizacionCabecera = oSincronizacionEntidadCabecera.Result.FirstOrDefault();

                //Actualizamos la fecha de cierre y hacemos el update.
                entidadSincronizacionCabecera.Fechafin = DateTime.Now;

                try
                {
                    oSincronizacionEntidadCabecera.Update(entidadSincronizacionCabecera);
                    resultado = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return resultado;
        }

        public static DateTime obtenerFechaUltimaSincronizacion(string pNombreEntidad)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaUltimaSincronizacion = new(1900, 1, 1);

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                //Buscamos la ultima sincro que realizo el depositario en cuestion
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                oSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, oSincronizacionEntidad.Result.FirstOrDefault().Id);
                oSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, Depositario.sqlEnum.OperandEnum.IsNotNull, null);
                oSincronizacionEntidadCabecera.OrderBy.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, Depositario.sqlEnum.DirEnum.DESC);
                oSincronizacionEntidadCabecera.TopQuantity = 1;
                oSincronizacionEntidadCabecera.Items();

                if (oSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    fechaUltimaSincronizacion = oSincronizacionEntidadCabecera.Result.FirstOrDefault().Fechainicio;
                }
            }

            return fechaUltimaSincronizacion;
        }

        public static Int64? GuardarDetalleSincronizacion(Int64 pEntidadCabeceraId, Int64 pOrigenId, Int64 pDestinoId)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
            Depositario.Entities.Tables.Sincronizacion.EntidadDetalle eSincronizacionEntidadDetalle = new();
            Depositario.Entities.Tables.Sincronizacion.EntidadDetalle eNuevaSincronizacionEntidadDetalle = new();

            eSincronizacionEntidadDetalle.EntidadCabeceraId = pEntidadCabeceraId;
            eSincronizacionEntidadDetalle.FechaCreacion = DateTime.Now;
            eSincronizacionEntidadDetalle.OrigenId = pOrigenId;
            eSincronizacionEntidadDetalle.DestinoId = pDestinoId;

            try
            {
                eNuevaSincronizacionEntidadDetalle = oSincronizacionEntidadDetalle.Add(eSincronizacionEntidadDetalle);

                resultado = eNuevaSincronizacionEntidadDetalle.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Int64? ObtenerIdDestinoDetalleSincronizacion(string pEntidadNombre, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pEntidadNombre);

            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                Int64 pEntidadId = oSincronizacionEntidad.Result.FirstOrDefault().Id;

                Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                oSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, pEntidadId);
                oSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositario.sqlEnum.OperandEnum.Equal, ConfigurationController.GetCurrentDepositaryId());
                oSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, Depositario.sqlEnum.OperandEnum.IsNotNull, null);

                oSincronizacionEntidadCabecera.Items();

                if (oSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    foreach (var entidadCabecera in oSincronizacionEntidadCabecera.Result)
                    {
                        Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, Depositario.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, Depositario.sqlEnum.OperandEnum.Equal, pIdOrigen);

                        oSincronizacionEntidadDetalle.Items();

                        if (oSincronizacionEntidadDetalle.Result.Count > 0)
                            return oSincronizacionEntidadDetalle.Result.FirstOrDefault().DestinoId;
                    }
                }
            }

            return resultado;
        }

        private static Depositario.Business.Tables.Sincronizacion.Entidad SincronizacionEntidadController = new();
        private static Depositario.Business.Tables.Sincronizacion.EntidadCabecera SincronizacionEntidadCabeceraController = new();
        private static Depositario.Business.Tables.Sincronizacion.EntidadDetalle SincronizacionEntidadDetalleController = new();

        public static Int64? ObtenerIdOrigenDetalleSincronizacion(string pEntidadNombre, Int64 pIdDestino)
        {
            SincronizacionEntidadController.Where.Clear();
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            //Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            SincronizacionEntidadController.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pEntidadNombre);

            SincronizacionEntidadController.Items();

            if (SincronizacionEntidadController.Result.Count > 0)
            {
                SincronizacionEntidadCabeceraController.Where.Clear();
                SincronizacionEntidadCabeceraController.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, SincronizacionEntidadController.Result.FirstOrDefault().Id);
                SincronizacionEntidadCabeceraController.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositario.sqlEnum.OperandEnum.Equal, ConfigurationController.GetCurrentDepositaryId());
                SincronizacionEntidadCabeceraController.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, Depositario.sqlEnum.OperandEnum.IsNotNull, null);

                SincronizacionEntidadCabeceraController.Items();

                if (SincronizacionEntidadCabeceraController.Result.Count > 0)
                {
                    foreach (var entidadCabecera in SincronizacionEntidadCabeceraController.Result)
                    {
                        SincronizacionEntidadDetalleController.Where.Clear();
                        SincronizacionEntidadDetalleController.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, Depositario.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        SincronizacionEntidadDetalleController.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.DestinoId, Depositario.sqlEnum.OperandEnum.Equal, pIdDestino);
                        SincronizacionEntidadDetalleController.TopQuantity = 1;
                        SincronizacionEntidadDetalleController.Items();

                        if (SincronizacionEntidadDetalleController.Result.Count > 0)
                            return SincronizacionEntidadDetalleController.Result.FirstOrDefault().OrigenId;
                    }
                }
            }

            return null;
        }

        public static Int64? ObtenerIdDestinoDetalleSincronizacionInicial(string pEntidadNombre, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, pEntidadNombre);

            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                Int64 pEntidadId = oSincronizacionEntidad.Result.FirstOrDefault().Id;

                Depositario.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                oSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, pEntidadId);
                oSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositario.sqlEnum.OperandEnum.IsNull, null);
                //oSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary != null ? DatabaseController.CurrentDepositary.Id : null);

                oSincronizacionEntidadCabecera.Items();

                if (oSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    foreach (var entidadCabecera in oSincronizacionEntidadCabecera.Result)
                    {
                        Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, Depositario.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, Depositario.sqlEnum.OperandEnum.Equal, pIdOrigen);

                        oSincronizacionEntidadDetalle.Items();

                        if (oSincronizacionEntidadDetalle.Result.Count > 0)
                            return oSincronizacionEntidadDetalle.Result.FirstOrDefault().DestinoId;
                    }
                }
            }

            return resultado;
        }
    }
}
