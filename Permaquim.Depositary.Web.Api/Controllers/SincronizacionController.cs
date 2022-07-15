namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class SincronizacionController
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

                    eSincronizacionNuevaEntidadCabecera = (DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera)oSincronizacionEntidad.Add(eSincronizacionEntidadCabecera);

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
