using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.Sincronization.Console.Enumerations;

namespace Permaquim.Depositary.Sincronization.Console
{
    internal static class DatabaseController
    {
        public static string GetApplicationParameterValue(string key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Aplicacion.Configuracion entities = new();
            entities.Where.Add(Depositario.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave,
                Depositario.sqlEnum.OperandEnum.Equal, key);
            entities.Items();
            if (entities.Result.Count > 0)
                return entities.Result.FirstOrDefault().Valor;

            return returnValue;
        }
        public static Permaquim.Depositario.Entities.Tables.Dispositivo.Depositario CurrentDepositary
        {
            get
            {
                Permaquim.Depositario.Business.Tables.Dispositivo.Depositario entity = new();
                entity.Where.Add(Depositario.Business.Tables.Dispositivo.Depositario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado,
                  Depositario.sqlEnum.OperandEnum.Equal, true);
                return entity.Items().FirstOrDefault();
            }
        }
        public static DateTime GetLastSincronizationDate(EntitiesEnum entity)
        {
            DateTime returnValue = new DateTime(1999,11,11,9,0,0,0); // Hasar!

            Depositario.Business.Tables.Sincronizacion.Entidad entities = new();
            entities.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            entities.Items();

            if (entities.Result.Count > 0)
            {
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera headerEntities = new();
                headerEntities.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId,
                    Depositario.sqlEnum.OperandEnum.Equal, entities.Result.FirstOrDefault().Id);
                headerEntities.Items();
                if (headerEntities.Result.Count > 0)
                {
                    returnValue = headerEntities.Result.FirstOrDefault().Fechainicio;
                }

            }

            return returnValue;

        }

        public static List<Depositario.Entities.Tables.Operacion.Sesion> GetSessions()
        {
            var lastSincronizationDate = GetLastSincronizationDate(EntitiesEnum.Operacion_Sesion);

            Depositario.Business.Tables.Operacion.Sesion session = new();
            session.Where.Add(Depositario.Business.Tables.Operacion.Sesion.ColumnEnum.FechaInicio,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            session.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Sesion.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            return session.Items();
        }

        public static List<Depositario.Entities.Tables.Operacion.CierreDiario> GetDailyclosingItems()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_CierreDiario);
            Depositario.Business.Tables.Operacion.CierreDiario dailyclosing = new();
            dailyclosing.Where.Add(Depositario.Business.Tables.Operacion.CierreDiario.ColumnEnum.FechaCreacion,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            dailyclosing.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.CierreDiario.ColumnEnum.Fecha,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            return dailyclosing.Items();

        }

        public static List<Depositario.Entities.Tables.Operacion.Turno> GetTurns()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Turno);
            Depositario.Business.Tables.Operacion.Turno turn = new();
            turn.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCreacion,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            turn.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);


            return turn.Items();
        }
        public static List<Depositario.Entities.Tables.Operacion.Contenedor> GetContainers()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Contenedor);
            Depositario.Business.Tables.Operacion.Contenedor container = new();
            container.Where.Add(Depositario.Business.Tables.Operacion.Contenedor.ColumnEnum.FechaApertura,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            container.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Contenedor.ColumnEnum.FechaCierre,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            return container.Items();
        }

        public static List<Depositario.Entities.Tables.Operacion.Transaccion> GetTransactions()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Transaccion);
            Depositario.Business.Tables.Operacion.Transaccion transaccion = new();
            transaccion.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.Fecha,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            return transaccion.Items();
        }

        public static List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> GetTransactionDetails()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionDetalle);
            Depositario.Business.Tables.Operacion.TransaccionDetalle transaccionDetalle = new();
            transaccionDetalle.Where.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            transaccionDetalle.OrderBy.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId);

            return transaccionDetalle.Items();
        }
        public static List<Depositario.Entities.Tables.Operacion.TransaccionSobre> GetEnvelopeTransaction()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionSobre);
            Depositario.Business.Tables.Operacion.TransaccionSobre transaccionSobre = new();
            transaccionSobre.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobre.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            return transaccionSobre.Items();
        }

        public static List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> GetEnvelopeTransactionDetails()
        {
            var lastSincronizationDate = DatabaseController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionSobreDetalle);
            Depositario.Business.Tables.Operacion.TransaccionSobreDetalle transaccionSobreDetalle = new();
            transaccionSobreDetalle.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobreDetalle.ColumnEnum.Fecha,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            return transaccionSobreDetalle.Items();
        }

        public static void SaveEntitySincronizationDate(EntitiesEnum entity,DateTime startDate,DateTime endDate)
        {
            Depositario.Business.Tables.Sincronizacion.Entidad entities = new();
            entities.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            entities.Items();

            if (entities.Result.Count > 0)
            {
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera headerEntities = new();
                headerEntities.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId,
                    Depositario.sqlEnum.OperandEnum.Equal, entities.Result.FirstOrDefault().Id);
                headerEntities.Add(new Depositario.Entities.Tables.Sincronizacion.EntidadCabecera()
                {
                    DepositarioId = CurrentDepositary.Id,
                    EntidadId = entities.Result.FirstOrDefault().Id,
                    Fechafin = endDate,
                    Fechainicio = startDate,
                    Valor = String.Empty
                }); 

            }
        }
    }
}