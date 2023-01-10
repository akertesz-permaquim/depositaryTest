namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class SynchronizationController
    {
        private static DepositaryWebApi.Business.Tables.Sincronizacion.Entidad _bTablesEntidad = new();
        private static DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera _bTablesEntidadCabecera = new();
        private static DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle _bTablesEntidadDetalle = new();
        private static DepositaryWebApi.Business.Tables.Dispositivo.Depositario _bTablesDepositario = new();

        public static Int64? iniciarCabeceraSincronizacion(Int64 pDepositarioId, string pNombreEntidad)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            using (DepositaryWebApi.Business.Tables.Sincronizacion.Entidad bTablesEntidad = new())
            {
                bTablesEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pNombreEntidad);
                bTablesEntidad.Items();

                if (bTablesEntidad.Result.Count > 0)
                {
                    var entidadSincronizacion = bTablesEntidad.Result.FirstOrDefault();
                    //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                    using (DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacionEntidadCabecera = new())
                    {
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
                }
            }

            return resultado;
        }

        public static bool finalizarCabeceraSincronizacion(Int64 pCabeceraSincronizacionId)
        {
            //Por defecto no se pudo registrar el cierre de la sincronizacion para la entidad.
            bool resultado = false;
            //Buscamos el registro en funcion del id recibido
            using (DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new())
            {
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
            }

            return resultado;
        }

        public static DateTime obtenerFechaUltimaSincronizacion(Int64 pDepositarioId, string pNombreEntidad)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaUltimaSincronizacion = new(1900, 1, 1);

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            using (DepositaryWebApi.Business.Tables.Sincronizacion.Entidad bTablesEntidad = new())
            {
                bTablesEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pNombreEntidad);
                bTablesEntidad.Items();

                if (bTablesEntidad.Result.Count > 0)
                {
                    //Buscamos la ultima sincro que realizo el depositario en cuestion
                    using (DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new())
                    {
                        bTablesEntidadCabecera.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, bTablesEntidad.Result.FirstOrDefault().Id);
                        bTablesEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pDepositarioId);
                        bTablesEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, DepositaryWebApi.sqlEnum.OperandEnum.IsNotNull, null);
                        bTablesEntidadCabecera.OrderBy.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, DepositaryWebApi.sqlEnum.DirEnum.DESC);
                        bTablesEntidadCabecera.Items();

                        if (bTablesEntidadCabecera.Result.Count > 0)
                        {
                            fechaUltimaSincronizacion = bTablesEntidadCabecera.Result.FirstOrDefault().Fechainicio;
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
            using (DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new())
            {
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
            }

            return resultado;
        }

        public static Int64? obtenerIdDestinoDetalleSincronizacion(string pEntidadNombre, Int64 pDepositarioId, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            //DepositaryWebApi.Business.Procedures.Sincronizacion.ObtenerIdDestino obtenerIdDestino = new();

            //try
            //{
            //    obtenerIdDestino.Items(pEntidadNombre, pDepositarioId, pIdOrigen);

            //    if(obtenerIdDestino.Resultset.Count>0)
            //    {
            //        return obtenerIdDestino.Resultset.FirstOrDefault().DestinoId;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    AuditController.Log(ex);
            //    throw (ex);
            //}

            using (DepositaryWebApi.Business.Tables.Sincronizacion.Entidad bTablesEntidad = new())
            {

                bTablesEntidad.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pEntidadNombre);

                bTablesEntidad.Items();

                if (bTablesEntidad.Result.Count > 0)
                {
                    Int64 pEntidadId = bTablesEntidad.Result.FirstOrDefault().Id;

                    using (DepositaryWebApi.Business.Relations.Sincronizacion.EntidadCabecera bTablesEntidadCabecera = new())
                    {

                        bTablesEntidadCabecera.Where.Add(DepositaryWebApi.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pEntidadId);
                        bTablesEntidadCabecera.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pDepositarioId);

                        bTablesEntidadCabecera.Items();

                        if (bTablesEntidadCabecera.Result.Count > 0)
                        {
                            foreach (var entidadCabecera in bTablesEntidadCabecera.Result)
                            {
                                var detalles = entidadCabecera.ListOf_EntidadDetalle_EntidadCabeceraId.FirstOrDefault(x => x.OrigenId == pIdOrigen);

                                if (detalles != null)
                                {
                                    return detalles.DestinoId;
                                }

                                //using (DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle bTablesEntidadDetalle = new())
                                //{
                                //    bTablesEntidadDetalle.Where.Add(DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                                //    bTablesEntidadDetalle.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, pIdOrigen);

                                //    bTablesEntidadDetalle.Items();

                                //    if (bTablesEntidadDetalle.Result.Count > 0)
                                //        return bTablesEntidadDetalle.Result.FirstOrDefault().DestinoId;
                                //}
                            }
                        }
                    }
                }
            }

            return resultado;
        }

        public static long ObtenerIdDepositario(string codigoExterno)
        {
            using (DepositaryWebApi.Business.Tables.Dispositivo.Depositario bTablesDepositario = new())
            {
                bTablesDepositario.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                    DepositaryWebApi.sqlEnum.OperandEnum.Equal, codigoExterno);
                bTablesDepositario.Items();

                return bTablesDepositario.Result.FirstOrDefault().Id;
            }
        }
    }
}
