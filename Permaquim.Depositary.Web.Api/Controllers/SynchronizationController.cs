namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class SynchronizationController
    {
        public static Int64? IniciarEjecucionSincronizacion(Int64 EjecucionOrigenId, bool EsPrimeraSincronizacion, Int64 DepositarioId)
        {
            Int64? resultado = null;
            DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion nuevaEjecucion = new();

            //Generamos un registro de ejecucion para sincronizacion
            DepositaryWebApi.Business.Tables.Sincronizacion.Ejecucion bTablesEjecucion = new();
            nuevaEjecucion = bTablesEjecucion.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion()
            {
                DepositarioId = DepositarioId,
                EsPrimeraSincronizacion = EsPrimeraSincronizacion,
                FechaFin = null,
                FechaInicio = DateTime.Now,
                Finalizada = false
            });

            DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera nuevaCabecera = new();

            //Obtenemos el Id de la entidad para la ejecucion de sincronizacion.
            Int64? EntidadId = ObtenerIdEntidad("Sincronizacion.Ejecucion");

            if (EntidadId.HasValue)
            {
                //Generamos la cabecera correspondiente a la ejecucion
                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new();

                nuevaCabecera = bTablesEntidadCabecera.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera()
                {
                    EjecucionId = nuevaEjecucion.Id,
                    EntidadId = EntidadId.Value,
                    Fechainicio = DateTime.Now,
                    Valor = "Sincronizacion.Ejecucion",
                    Fechafin = null
                });

                DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle nuevoDetalle = new();

                //Generamos el detalle de la sincronizacion para tener mapeado el ID.
                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle bTablesEntidadDetalle = new();
                nuevoDetalle = bTablesEntidadDetalle.Add(new DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle()
                {
                    DestinoId = nuevaEjecucion.Id,
                    EntidadCabeceraId = nuevaCabecera.Id,
                    FechaCreacion = DateTime.Now,
                    OrigenId = EjecucionOrigenId
                });

                //Cerramos la cabecera indicando la fecha de fin.
                nuevaCabecera.Fechafin = DateTime.Now;
                bTablesEntidadCabecera.Update(nuevaCabecera);

                resultado = nuevaEjecucion.Id;
            }

            return resultado;
        }

        public static Int64? iniciarCabeceraSincronizacion(Int64 EjecucionId, string pNombreEntidad)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad bTablesEntidad = new();
            bTablesEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pNombreEntidad);
            bTablesEntidad.Items();

            if (bTablesEntidad.Result.Count > 0)
            {
                var entidadSincronizacion = bTablesEntidad.Result.FirstOrDefault();
                //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new();

                DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionEntidadCabecera = new();

                eSincronizacionEntidadCabecera.EntidadId = entidadSincronizacion.Id;
                eSincronizacionEntidadCabecera.Fechainicio = DateTime.Now;
                eSincronizacionEntidadCabecera.EjecucionId = EjecucionId;
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
            DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new();

            bTablesEntidadCabecera.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pCabeceraSincronizacionId);
            bTablesEntidadCabecera.Items();

            if (bTablesEntidadCabecera.Result.Count > 0)
            {
                var entidadSincronizacionCabecera = bTablesEntidadCabecera.Result.FirstOrDefault();

                //Actualizamos la fecha de cierre y hacemos el update.
                entidadSincronizacionCabecera.Fechafin = DateTime.Now;

                try
                {
                    bTablesEntidadCabecera.Update(entidadSincronizacionCabecera);
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
            DateTime fechaUltimaSincronizacion = new(1900, 1, 1);

            //En funcion del depositario se buscan las instancias de sincronizacion que se registraron
            DepositaryWebApi.Business.Relations.Sincronizacion.Ejecucion bTablesEjecucion = new();
            bTablesEjecucion.Where.Add(DepositaryWebApi.Business.Relations.Sincronizacion.Ejecucion.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pDepositarioId);
            bTablesEjecucion.OrderBy.Add(DepositaryWebApi.Business.Relations.Sincronizacion.Ejecucion.ColumnEnum.FechaInicio, DepositaryWebApi.sqlEnum.DirEnum.DESC);
            bTablesEjecucion.Items();

            if (bTablesEjecucion.Result.Count > 0)
            {
                //Obtenemos el Id de la entidad a buscar.
                long? EntidadId = ObtenerIdEntidad(pNombreEntidad);

                if (EntidadId.HasValue)
                {
                    foreach (var ejecucion in bTablesEjecucion.Result)
                    {
                        foreach (var entidadCabecera in ejecucion.ListOf_EntidadCabecera_EjecucionId.Where(x => x._EntidadId == EntidadId.Value && x.Fechafin != null))
                        {
                            return entidadCabecera.Fechainicio;
                        }
                    }
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
            DepositaryWebApi.Business.Procedures.Sincronizacion.ObtenerIdDestino obtenerIdDestino = new();

            try
            {
                obtenerIdDestino.Items(pEntidadNombre, pIdOrigen, pDepositarioId);

                if (obtenerIdDestino.Resultset.Count > 0)
                {
                    return obtenerIdDestino.Resultset.FirstOrDefault().DestinoId;
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                throw ex;
            }

            return resultado;
        }

        public static long ObtenerIdDepositario(string codigoExterno)
        {
            DepositaryWebApi.Business.Tables.Dispositivo.Depositario bTablesDepositario = new();
            bTablesDepositario.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, codigoExterno);
            bTablesDepositario.Items();

            return bTablesDepositario.Result.FirstOrDefault().Id;
        }

        public static long? ObtenerIdEntidad(string nombreEntidad)
        {
            long? resultado = null;

            DepositaryWebApi.Business.Tables.Sincronizacion.Entidad bTablesEntidad = new();
            bTablesEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, nombreEntidad);
            bTablesEntidad.TopQuantity = 1;
            bTablesEntidad.Items();

            if (bTablesEntidad.Result.Count > 0)
                resultado = bTablesEntidad.Result.FirstOrDefault().Id;

            return resultado;
        }
    }
}
