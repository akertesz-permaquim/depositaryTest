﻿using static Permaquim.Depositary.Sincronization.Console.Enumerations;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class DatabaseController
    {
        public static string GetApplicationParameterValue(string key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entities = new();
            entities.Where.Add(Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Clave,
                Depositario.sqlEnum.OperandEnum.Equal, key);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.SucursalId.EmpresaId.Id);

            entities.Items();
            if (entities.Result.Count > 0)
                return entities.Result.FirstOrDefault().Valor;

            return returnValue;
        }

        private static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario? _currentDepositary = null;
        public static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario CurrentDepositary
        {
            get
            {
                if (_currentDepositary == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.Depositario entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id,
                        Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado,
                      Depositario.sqlEnum.OperandEnum.Equal, true);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                      Depositario.sqlEnum.OperandEnum.Equal, ConfigurationController.GetCurrentDepositaryCode());

                    entity.Items();

                    if (entity.Result.Count > 0)
                        _currentDepositary = entity.Result.FirstOrDefault();
                }

                return _currentDepositary;
            }
        }

        private static long? _currentDepositaryId = null;

        public static long? CurrentDepositaryId
        {
            get
            {
                if (!_currentDepositaryId.HasValue)
                {
                    if (CurrentDepositary != null)
                        _currentDepositaryId = CurrentDepositary.Id;
                }

                return _currentDepositaryId;
            }
        }


        public static DateTime GetLastSincronizationDate(EntitiesEnum entity)
        {
            DateTime returnValue = new DateTime(1999, 11, 11, 9, 0, 0, 0); // Hasar!

            Depositario.Business.Tables.Sincronizacion.Entidad entities = new();
            entities.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            entities.Items();

            if (entities.Result.Count > 0)
            {
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera headerEntities = new();
                headerEntities.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId,
                    Depositario.sqlEnum.OperandEnum.Equal, entities.Result.FirstOrDefault().Id);

                //Filtramos solo procesos que concluyeron OK.
                headerEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin,
                    Depositario.sqlEnum.OperandEnum.IsNotNull, true);

                //Ordeno todo DESC para obtener la ultima sincronizacion correcta de la entidad.
                headerEntities.OrderBy.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);

                headerEntities.TopQuantity = 1;

                headerEntities.Items();

                if (headerEntities.Result.Count > 0)
                {
                    returnValue = headerEntities.Result.FirstOrDefault().Fechainicio;
                }
            }

            return returnValue;
        }

        #region Operaciones
        public static List<Depositario.Entities.Tables.Operacion.Sesion> GetSessions()
        {
            var lastSincronizationDate = GetLastSincronizationDate(EntitiesEnum.Operacion_Sesion);

            Depositario.Business.Tables.Operacion.Sesion session = new();

            session.Where.Add(Depositario.Business.Tables.Operacion.Sesion.ColumnEnum.FechaInicio,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            session.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Sesion.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            session.Items();

            //Map master id's
            if (session.Result.Count > 0)
            {
                foreach (var sessionRow in session.Result)
                {
                    Int64? mapDepositarioId = null;
                    if (sessionRow.DepositarioId.HasValue)
                        mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, sessionRow.DepositarioId.Value);
                    Int64? mapUsuarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, sessionRow.UsuarioId);

                    if (mapUsuarioId.HasValue && mapDepositarioId.HasValue)
                    {
                        sessionRow.DepositarioId = mapDepositarioId;
                        sessionRow.UsuarioId = mapUsuarioId.Value;
                    }
                }
            }

            return session.Result;
        }

        public static List<Depositario.Entities.Tables.Operacion.CierreDiario> GetDailyclosingItems()
        {
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_CierreDiario);
            Depositario.Business.Tables.Operacion.CierreDiario dailyclosing = new();

            dailyclosing.Where.Add(Depositario.Business.Tables.Operacion.CierreDiario.ColumnEnum.FechaCreacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            dailyclosing.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.CierreDiario.ColumnEnum.FechaModificacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            dailyclosing.Items();

            //Map master id's
            if (dailyclosing.Result.Count > 0)
            {
                foreach (var dailyClosingRow in dailyclosing.Result)
                {
                    Int64? mapDepositarioId = null;
                    if (dailyClosingRow.DepositarioId.HasValue)
                        mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, dailyClosingRow.DepositarioId.Value);
                    Int64? mapUsuarioCreacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, dailyClosingRow.UsuarioCreacion);
                    Int64? mapUsuarioModificacionId = null;
                    if (dailyClosingRow.UsuarioModificacion.HasValue)
                        mapUsuarioModificacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, dailyClosingRow.UsuarioModificacion.Value);

                    if (mapDepositarioId.HasValue && mapUsuarioCreacionId.HasValue)
                    {
                        dailyClosingRow.DepositarioId = mapDepositarioId;
                        dailyClosingRow.UsuarioCreacion = mapUsuarioCreacionId.Value;
                        dailyClosingRow.UsuarioModificacion = mapUsuarioModificacionId;
                        dailyClosingRow.CodigoCierre = dailyClosingRow.CodigoCierre + "-" + dailyClosingRow.Id.ToString();
                    }
                }
            }

            return dailyclosing.Result;
        }

        public static List<Depositario.Entities.Tables.Operacion.Turno> GetTurns()
        {
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Turno);
            Depositario.Business.Tables.Operacion.Turno turn = new();

            turn.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCreacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            turn.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaModificacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            turn.Items();

            //Map master id's
            if (turn.Result.Count > 0)
            {
                foreach (var turnRow in turn.Result)
                {
                    Int64? mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, turnRow.DepositarioId);
                    Int64? mapSectorId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, turnRow.SectorId);
                    Int64? mapTurnoDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Turno_AgendaTurno, turnRow.TurnoDepositarioId);
                    Int64? mapUsuarioCreacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, turnRow.UsuarioCreacion);
                    Int64? mapUsuarioModificacionId = null;
                    if (turnRow.UsuarioModificacion.HasValue)
                        mapUsuarioModificacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, turnRow.UsuarioModificacion.Value);

                    if (mapDepositarioId.HasValue && mapUsuarioCreacionId.HasValue && mapTurnoDepositarioId.HasValue && mapSectorId.HasValue)
                    {
                        turnRow.DepositarioId = mapDepositarioId.Value;
                        turnRow.UsuarioCreacion = mapUsuarioCreacionId.Value;
                        turnRow.TurnoDepositarioId = mapTurnoDepositarioId.Value;
                        turnRow.SectorId = mapSectorId.Value;
                        turnRow.UsuarioModificacion = mapUsuarioModificacionId;
                        turnRow.CodigoTurno = turnRow.CodigoTurno + "-" + turnRow.Id.ToString();
                    }
                }
            }

            return turn.Result;
        }
        public static List<Depositario.Entities.Tables.Operacion.Contenedor> GetContainers()
        {
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Contenedor);
            Depositario.Business.Tables.Operacion.Contenedor container = new();

            container.Where.Add(Depositario.Business.Tables.Operacion.Contenedor.ColumnEnum.FechaCreacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
            container.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Contenedor.ColumnEnum.FechaModificacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            container.Items();

            //Map master id's
            if (container.Result.Count > 0)
            {
                foreach (var containerRow in container.Result)
                {
                    Int64? mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, containerRow.DepositarioId);
                    Int64? mapTipoId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoContenedor, containerRow.TipoId);
                    Int64? mapUsuarioCreacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, containerRow.UsuarioCreacion);
                    Int64? mapUsuarioModificacionId = null;
                    if (containerRow.UsuarioModificacion.HasValue)
                        mapUsuarioModificacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, containerRow.UsuarioModificacion.Value);

                    if (mapDepositarioId.HasValue && mapUsuarioCreacionId.HasValue && mapTipoId.HasValue)
                    {
                        containerRow.DepositarioId = mapDepositarioId.Value;
                        containerRow.UsuarioCreacion = mapUsuarioCreacionId.Value;
                        containerRow.TipoId = mapTipoId.Value;
                        containerRow.UsuarioModificacion = mapUsuarioModificacionId;
                    }
                }
            }

            return container.Result;
        }

        public static List<Depositario.Entities.Tables.Operacion.Transaccion> GetTransactions()
        {
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Transaccion);
            Depositario.Business.Tables.Operacion.Transaccion transaction = new();

            transaction.Where.OpenParentheses();

            transaction.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.FechaCreacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.OR, Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.FechaModificacion, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            transaction.Where.CloseParentheses();

            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.Finalizada,
            Depositario.sqlEnum.OperandEnum.Equal, true);

            transaction.Items();

            //Map master id's
            if (transaction.Result.Count > 0)
            {
                foreach (var transactionRow in transaction.Result)
                {
                    Int64? mapTipoId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoTransaccion, transactionRow.TipoId);
                    Int64? mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, transactionRow.DepositarioId);
                    Int64? mapSectorId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, transactionRow.SectorId);
                    Int64? mapSucursalId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sucursal, transactionRow.SucursalId);
                    Int64? mapMonedaId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, transactionRow.MonedaId);
                    Int64? mapUsuarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, transactionRow.UsuarioId);
                    Int64? mapUsuarioCreacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, transactionRow.UsuarioCreacion);
                    Int64? mapUsuarioModificacionId = null;
                    if (transactionRow.UsuarioModificacion.HasValue)
                        mapUsuarioModificacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, transactionRow.UsuarioModificacion.Value);

                    Int64? mapOrigenValorId = null;
                    if (transactionRow.OrigenValorId.HasValue)
                    {
                        mapOrigenValorId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_OrigenValor, transactionRow.OrigenValorId.Value);
                    }

                    Int64? mapCuentaId = null;
                    if (transactionRow.CuentaId.HasValue)
                        mapCuentaId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_Cuenta, transactionRow.CuentaId.Value);

                    if (mapTipoId.HasValue && mapDepositarioId.HasValue && mapUsuarioCreacionId.HasValue && mapSectorId.HasValue && mapSucursalId.HasValue && mapMonedaId.HasValue && mapUsuarioId.HasValue)
                    {
                        transactionRow.TipoId = mapTipoId.Value;
                        transactionRow.DepositarioId = mapDepositarioId.Value;
                        transactionRow.SectorId = mapSectorId.Value;
                        transactionRow.CuentaId = mapCuentaId;
                        transactionRow.SucursalId = mapSucursalId.Value;
                        transactionRow.MonedaId = mapMonedaId.Value;
                        transactionRow.UsuarioId = mapUsuarioId.Value;
                        transactionRow.OrigenValorId = mapOrigenValorId;
                        transactionRow.CodigoOperacion = transactionRow.CodigoOperacion + "-" + transactionRow.Id.ToString();
                        transactionRow.UsuarioCreacion = mapUsuarioCreacionId.Value;
                        transactionRow.UsuarioModificacion = mapUsuarioModificacionId;
                    }
                }
            }

            return transaction.Result;
        }

        public static List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> GetTransactionDetails(List<Depositario.Entities.Tables.Operacion.Transaccion> transactions)
        {
            List<Depositario.Entities.Tables.Operacion.TransaccionDetalle> result = new();

            if (transactions.Count > 0)
            {
                //var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionDetalle);
                Depositario.Business.Tables.Operacion.TransaccionDetalle transactionDetail = new();
                transactionDetail.Where.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, Depositario.sqlEnum.OperandEnum.In, transactions.Select(x => x.Id).ToList());
                //transactionDetail.Where.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.Fecha,
                //    Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);
                transactionDetail.OrderBy.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId);

                transactionDetail.Items();

                //Map master id's
                if (transactionDetail.Result.Count > 0)
                {
                    foreach (var transactionDetailRow in transactionDetail.Result)
                    {
                        Int64? mapDenominacionId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Denominacion, transactionDetailRow.DenominacionId);

                        if (mapDenominacionId.HasValue)
                        {
                            transactionDetailRow.DenominacionId = mapDenominacionId.Value;
                        }
                    }

                    result = transactionDetail.Result;
                }

            }

            return result;
        }
        public static List<Depositario.Entities.Tables.Operacion.TransaccionSobre> GetEnvelopeTransaction(List<Depositario.Entities.Tables.Operacion.Transaccion> transactions)
        {
            List<Depositario.Entities.Tables.Operacion.TransaccionSobre> result = new();

            if (transactions.Count > 0)
            {
                //var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionSobre);
                Depositario.Business.Tables.Operacion.TransaccionSobre envelopeTransaction = new();
                envelopeTransaction.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobre.ColumnEnum.TransaccionId, Depositario.sqlEnum.OperandEnum.In, transactions.Select(x => x.Id).ToList());
                envelopeTransaction.OrderBy.Add(Depositario.Business.Tables.Operacion.TransaccionSobre.ColumnEnum.TransaccionId);

                //envelopeTransaction.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobre.ColumnEnum.Fecha,
                //    Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

                envelopeTransaction.Items();

                if (envelopeTransaction.Result.Count > 0)
                    result = envelopeTransaction.Result;

            }

            return result;
        }

        public static List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> GetEnvelopeTransactionDetails(List<Depositario.Entities.Tables.Operacion.TransaccionSobre> envelopeTransactions)
        {
            List<Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> result = new();

            if (envelopeTransactions.Count > 0)
            {
                //var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_TransaccionSobreDetalle);
                Depositario.Business.Tables.Operacion.TransaccionSobreDetalle envelopeTransactionDetail = new();
                envelopeTransactionDetail.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId, Depositario.sqlEnum.OperandEnum.In, envelopeTransactions.Select(x => x.Id).ToList());
                envelopeTransactionDetail.OrderBy.Add(Depositario.Business.Tables.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId);
                //envelopeTransactionDetail.Where.Add(Depositario.Business.Tables.Operacion.TransaccionSobreDetalle.ColumnEnum.Fecha,
                //Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

                envelopeTransactionDetail.Items();

                //Map master id's
                if (envelopeTransactionDetail.Result.Count > 0)
                {
                    foreach (var envelopeTransactionDetailRow in envelopeTransactionDetail.Result)
                    {
                        Int64? mapRelacionMonedaTipoValorId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor, envelopeTransactionDetailRow.RelacionMonedaTipoValorId);

                        if (mapRelacionMonedaTipoValorId.HasValue)
                        {
                            envelopeTransactionDetailRow.RelacionMonedaTipoValorId = mapRelacionMonedaTipoValorId.Value;
                        }
                    }
                }

                result = envelopeTransactionDetail.Result;
            }

            return result;
        }

        public static List<Depositario.Entities.Tables.Operacion.Evento> GetEvents()
        {
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Operacion_Evento);
            Depositario.Business.Tables.Operacion.Evento events = new();

            events.Where.Add(Depositario.Business.Tables.Operacion.Evento.ColumnEnum.Fecha,
            Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            events.Items();

            //Map master id's
            if (events.Result.Count > 0)
            {
                Int64? mapTipoId;
                Int64? mapDepositarioId;

                foreach (var eventRow in events.Result)
                {
                    mapTipoId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Operacion_TipoEvento, eventRow.TipoId);
                    mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, eventRow.DepositarioId);

                    if (mapTipoId.HasValue && mapDepositarioId.HasValue)
                    {
                        eventRow.TipoId = mapTipoId.Value;
                        eventRow.DepositarioId = mapDepositarioId.Value;
                    }
                }
            }

            return events.Result;
        }

        public static Depositario.Entities.Tables.Dispositivo.DepositarioEstado? GetState()
        {
            Depositario.Entities.Tables.Dispositivo.DepositarioEstado result = null;
            var lastSincronizationDate = GetLastSincronizationDate(Enumerations.EntitiesEnum.Dispositivo_DepositarioEstado);
            Depositario.Business.Tables.Dispositivo.DepositarioEstado state = new();

            //state.Where.Add(Depositario.Business.Tables.Operacion.Evento.ColumnEnum.Fecha,
            //Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, lastSincronizationDate);

            state.Items();

            //Map master id's
            if (state.Result.Count > 0)
            {
                Int64? mapDepositarioId;

                var stateRow = state.Result.FirstOrDefault();

                mapDepositarioId = SynchronizationController.ObtenerIdOrigenDetalleSincronizacion(Enumerations.EntitiesEnum.Dispositivo_Depositario, stateRow.DepositarioId);

                if (mapDepositarioId.HasValue)
                {
                    stateRow.DepositarioId = mapDepositarioId.Value;
                }

                result = stateRow;
            }

            return result;
        }

        #endregion

    }
}
