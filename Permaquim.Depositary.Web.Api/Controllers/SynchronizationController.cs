namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class SynchronizationController
    {
        public static Int64? iniciarCabeceraSincronizacion(Int64 pDepositarioId, string pNombreEntidad)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                var entidadSincronizacion = oSincronizacionEntidad.Result.FirstOrDefault();
                //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionEntidadCabecera = new();

                eSincronizacionEntidadCabecera.EntidadId = entidadSincronizacion.Id;
                eSincronizacionEntidadCabecera.Fechainicio = DateTime.Now;
                eSincronizacionEntidadCabecera.DepositarioId = pDepositarioId;
                eSincronizacionEntidadCabecera.Valor = entidadSincronizacion.Nombre;

                try
                {
                    DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionNuevaEntidadCabecera = new();

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

        public static bool finalizarCabeceraSincronizacion(Int64 pCabeceraSincronizacionId)
        {
            //Por defecto no se pudo registrar el cierre de la sincronizacion para la entidad.
            bool resultado = false;
            //Buscamos el registro en funcion del id recibido
            DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
            oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pCabeceraSincronizacionId);
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

        public static DateTime obtenerFechaUltimaSincronizacion(Int64 pDepositarioId, string pNombreEntidad)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaUltimaSincronizacion = new(1900,1,1);

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                //Buscamos la ultima sincro que realizo el depositario en cuestion
                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, oSincronizacionEntidad.Result.FirstOrDefault().Id);
                oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pDepositarioId);
                oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, DepositaryWebApi.sqlEnum.OperandEnum.IsNotNull, null);
                oSincronizacionEntidadCabecera.OrderBy.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, DepositaryWebApi.sqlEnum.DirEnum.DESC);
                oSincronizacionEntidadCabecera.Items();

                if (oSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    fechaUltimaSincronizacion = oSincronizacionEntidadCabecera.Result.FirstOrDefault().Fechainicio;
                }
            }

            return fechaUltimaSincronizacion;
        }

        public static Int64? guardarDetalleSincronizacion(Int64 pEntidadCabeceraId, Int64 pOrigenId, Int64 pDestinoId)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
            DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle eSincronizacionEntidadDetalle = new();
            DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle eNuevaSincronizacionEntidadDetalle = new();

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

        public static Int64? obtenerIdDestinoDetalleSincronizacion(string pEntidadNombre, Int64 pDepositarioId, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pEntidadNombre);

            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                Int64 pEntidadId = oSincronizacionEntidad.Result.FirstOrDefault().Id;

                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();
                oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pEntidadId);
                oSincronizacionEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pDepositarioId);

                oSincronizacionEntidadCabecera.Items();

                if (oSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    foreach (var entidadCabecera in oSincronizacionEntidadCabecera.Result)
                    {
                        DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
                        oSincronizacionEntidadDetalle.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        oSincronizacionEntidadDetalle.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pIdOrigen);

                        oSincronizacionEntidadDetalle.Items();

                        if (oSincronizacionEntidadDetalle.Result.Count > 0)
                            return oSincronizacionEntidadDetalle.Result.FirstOrDefault().DestinoId;
                    }
                }
            }

            return resultado;
        }

        public static long ObtenerIdDepositario(string codigoExterno)
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario entities = new();
            entities.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, codigoExterno);
            entities.Items();
            return entities.Result.FirstOrDefault().Id;
        }
    }
}
