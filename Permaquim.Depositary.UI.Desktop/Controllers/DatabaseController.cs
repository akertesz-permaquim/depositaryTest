using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Security;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class DatabaseController
    {
        private static Depositario.Entities.Relations.Dispositivo.Depositario _currentDepositary = null;
        private static Depositario.Entities.Relations.Dispositivo.DepositarioContadora _currentDepositaryCounter = null;
        private static Depositario.Entities.Relations.Dispositivo.DepositarioPlaca _currentDepositaryIoboard = null;
        private static Depositario.Entities.Relations.Operacion.TipoTransaccion _currentOperation;
        private static List<Depositario.Entities.Relations.Dispositivo.ComandoContadora> _currentDepositaryCounterCommands = null;
        private static List<Depositario.Entities.Relations.Dispositivo.ComandoPlaca> _currentDepositaryIoBoardCommands = null;
        private static Depositario.Entities.Relations.Valor.Moneda _currentCurrency;

        private const string CIERRE_DIARIO = "Cierre diario";

        public static int AvailableTurnsCount { get; set; }

        public static Depositario.Entities.Relations.Valor.OrigenValor CurrentDepositOrigin { get; set; }

        /// <summary>
        /// Representa el usuario registrado en el Sistema
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Seguridad.Usuario CurrentUser { get; private set; }
        /// <summary>
        /// Representa la sesión actual
        /// </summary>
        public static Permaquim.Depositario.Entities.Tables.Operacion.Sesion CurrentSession { get; private set; }


        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno _currentTurn { get; private set; }
        /// <summary>
        /// Representa el turno actual
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno CurrentTurn
        {
            get
            {

                if (_currentTurn == null)
                {
                    // Verifica que eista un turno disponible para el depositario / sector
                    Permaquim.Depositario.Business.Relations.Operacion.Turno entities = new();
                    entities.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Habilitado,
                        Depositario.sqlEnum.OperandEnum.Equal, true);
                    entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                    entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.SectorId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                    entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.FechaCierre,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);
                    entities.Items();

                    if (entities.Result.Count != 0)
                    {
                        _currentTurn = entities.Result.FirstOrDefault();
                    }

                }
                return _currentTurn;
            }
        }

        public static Depositario.Entities.Relations.Operacion.CierreDiario CurrentDailyClosing
        {
            get
            {
                Depositario.Business.Relations.Operacion.CierreDiario entity = new();
                entity.Where.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Fecha,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);
                entity.Items();
                if (entity.Result.Count > 0)
                    return entity.Result.FirstOrDefault();
                else
                {
                    Depositario.Business.Tables.Operacion.CierreDiario entityTables = new();
                    entityTables.Add(new Depositario.Entities.Tables.Operacion.CierreDiario()
                    {
                        DepositarioId = CurrentDepositary.Id,
                        FechaCreacion = DateTime.Now,
                        Nombre = "Cierre Diario inicial",
                        SesionId = CurrentSession.Id,
                        UsuarioCreacion = CurrentUser.Id

                    });

                    return CurrentDailyClosing;
                }

            }
        }

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

                    _currentDepositary = entity.Items().FirstOrDefault();
                }

                return _currentDepositary;

            }
        }

        public static Permaquim.Depositario.Entities.Relations.Dispositivo.DepositarioContadora CurrentDepositaryCounter
        {
            get
            {
                if (_currentDepositaryCounter == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.DepositarioContadora entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.DepositarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.Habilitado,
                      Depositario.sqlEnum.OperandEnum.Equal, true);
                    _currentDepositaryCounter = entity.Items().FirstOrDefault();
                }

                return _currentDepositaryCounter;
             }
        }

        public static Permaquim.Depositario.Entities.Relations.Dispositivo.DepositarioPlaca CurrentDepositaryIoboard
        {
            get
            {
                if (_currentDepositaryIoboard == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.DepositarioPlaca entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.DepositarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.Habilitado,
                      Depositario.sqlEnum.OperandEnum.Equal, true);

                    _currentDepositaryIoboard = entity.Items().FirstOrDefault();
                }
                
                return _currentDepositaryIoboard;
            }
        }

        public static List<Permaquim.Depositario.Entities.Relations.Dispositivo.ComandoContadora> CurrentDepositaryCounterCommands
        {
            get
            {
                if (_currentDepositaryCounterCommands == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.ComandoContadora entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.TipoContadoraId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositaryCounter.TipoContadoraId.Id);
                    _currentDepositaryCounterCommands = entity.Items();
                }

                return _currentDepositaryCounterCommands;
            }
        }


        public static List<Permaquim.Depositario.Entities.Relations.Dispositivo.ComandoPlaca> CurrentDepositaryIoBoardCommands
        {
            get
            {
                if (_currentDepositaryIoBoardCommands == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.ComandoPlaca entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.TipoPlacaId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositaryIoboard.TipoPlacaId.Id);
                    _currentDepositaryIoBoardCommands = entity.Items();
                }

                return _currentDepositaryIoBoardCommands;
            }
        }
        /// <summary>
        /// Representa el contenedor actual
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Operacion.Contenedor CurrentContainer
        {
            get
            {
                Permaquim.Depositario.Business.Relations.Operacion.Contenedor entity = new();
                entity.Where.Add(Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre,
               Depositario.sqlEnum.OperandEnum.Equal, null);
                entity.Items();

                if (entity.Result.Count > 0)
                    return entity.Result.FirstOrDefault();
                else
                {

                    Depositario.Business.Tables.Operacion.Contenedor entityTables = new();
                    entityTables.Add(new Depositario.Entities.Tables.Operacion.Contenedor()
                    {
                        FechaApertura = DateTime.Now,
                        Habilitado = true,
                        Identificador = String.Empty,
                        TipoId = 0, // Default de tipo
                        DepositarioId = CurrentDepositary.Id,
                        FechaCreacion = DateTime.Now,
                        Nombre = "Contenedor *",
                        UsuarioCreacion = CurrentUser.Id

                    }); ;

                    return CurrentContainer;
                }

            }
        }

        public static Permaquim.Depositario.Entities.Relations.Valor.Moneda CurrentCurrency
        {
            get { return _currentCurrency; }
            set { _currentCurrency = value; }
        }

        public static Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion CurrentOperation
        {
            get { return _currentOperation; }
            set { _currentOperation = value; }
        }

        private static Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta _currentUserBankAccount;

        public static Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta CurrentUserBankAccount
        {
            get { return _currentUserBankAccount; }
            set { _currentUserBankAccount = value; }
        }


        public static Permaquim.Depositario.Entities.Relations.Seguridad.Usuario Login(string user, string password)
        {

            Permaquim.Depositario.Entities.Relations.Seguridad.Usuario usuario = new();

            try
            {
                Permaquim.Depositario.Business.Relations.Seguridad.Usuario usuarios = new();
                usuarios.Where.Add(Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.NickName,
                    Permaquim.Depositario.sqlEnum.OperandEnum.Equal, user);
                usuarios.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                    Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.Password, Permaquim.Depositario.sqlEnum.OperandEnum.Equal, Cryptography.Hash(password));
                usuarios.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                    Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
                usuarios.Items();
                if (usuarios.Result.Count > 0)
                {
                    usuario = usuarios.Result.FirstOrDefault();
                    CurrentUser = usuario;

                    // Se genera una sesión
                    Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
                    CurrentSession = sesiones.Add(CurrentDepositary.Id, CurrentUser.Id, DateTime.Now, null, null);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);

                return usuario;
            }

        }

        public static void LogOff(bool IsAutoLoOff)
        {
            if (CurrentSession != null)
            {
                Permaquim.Depositario.Business.Tables.Operacion.Sesion session = new();
                CurrentSession.FechaCierre = DateTime.Now;
                CurrentSession.EsCierreAutomatico = IsAutoLoOff;
                session.Update(CurrentSession);
                CurrentUser = null;
                _currentCurrency = new();
            }

            CurrentUser = null;
            CurrentCurrency = null;
            _currentOperation = null;
            _currentUserBankAccount = null;
            _currentOperation = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion> GetTransactionTypes()
        {
            Permaquim.Depositario.Business.Relations.Operacion.TipoTransaccion entities = new();
            entities.Where.Add(Permaquim.Depositario.Business.Relations.Operacion.TipoTransaccion.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);

            return entities.Items();
        }
        /// <summary>
        /// Monedas disponibles en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Valor.RelacionMonedaTipoValor> GetEnvelopeValues()
        {

            Permaquim.Depositario.Business.Relations.Valor.RelacionMonedaTipoValor entities = new();

            entities.Where.Add(Depositario.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentCurrency.Id);
            return entities.Items();

        }

        /// <summary>
        /// Monedas disponibles en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Valor.Moneda> GetCurrencies()
        {

            Permaquim.Depositario.Business.Relations.Directorio.RelacionMonedaSucursal monedasucursal = new();
            monedasucursal.Where.Add(Depositario.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.SucursalId.Id);
            monedasucursal.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);

            monedasucursal.Items();

            var monedas = monedasucursal.Result.DistinctBy(x => x.MonedaId.Id).Select(x => x.MonedaId.Id).ToList();

            Permaquim.Depositario.Business.Relations.Valor.Moneda currencies = new();

            // si no existen monedas habilitadas para la sucursal, se retorna vacío.
            if (monedas.Count > 0)
            {
                currencies.Where.Add(Permaquim.Depositario.Business.Relations.Valor.Moneda.ColumnEnum.Habilitado,
                    Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
                currencies.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                    Permaquim.Depositario.Business.Relations.Valor.Moneda.ColumnEnum.Id,
                    Permaquim.Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                currencies.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Valor.Moneda.ColumnEnum.Id,
                Permaquim.Depositario.sqlEnum.OperandEnum.In, monedas);
                return currencies.Items();
            }

            return currencies.Items();

        }
        /// <summary>
        /// Cuentas bancarias del usuario registrado
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta> GetUserBankAccounts()
        {
            Permaquim.Depositario.Business.Relations.Banca.UsuarioCuenta entities = new();
            entities.Where.Add(Permaquim.Depositario.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioId,
            Permaquim.Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.Id);

            entities.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.Id,
            Permaquim.Depositario.sqlEnum.OperandEnum.NotEqual, 0);
            return entities.Items();
        }

        /// <summary>
        /// Origenes del depósito
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Valor.OrigenValor> GetDepositOrigin()
        {
            Permaquim.Depositario.Business.Relations.Valor.OrigenValor entities = new();
            entities.Where.Add(Permaquim.Depositario.Business.Relations.Valor.OrigenValor.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);

            entities.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Valor.OrigenValor.ColumnEnum.Id,
            Permaquim.Depositario.sqlEnum.OperandEnum.NotEqual, 0);
            return entities.Items();
        }
        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor CreateContainer()
        {
            Permaquim.Depositario.Entities.Tables.Operacion.Contenedor returnValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Contenedor entities = new();

            if (CurrentContainer != null)
            {
                var currentcontainer = entities.Items(CurrentContainer.Id).FirstOrDefault();
                currentcontainer.FechaCierre = DateTime.Now;

                // Primero actualiza la fecha de cierre de la bolsa actual
                entities.Update(currentcontainer);
            }

            //Luego genera una nueva
            Permaquim.Depositario.Business.Tables.Operacion.TipoContenedor typesOfContainer = new();

            entities.Add(new Depositario.Entities.Tables.Operacion.Contenedor()
            {
                FechaApertura = DateTime.Now,
                FechaCierre = null,
                FechaCreacion = DateTime.Now,
                FechaModificacion = null,
                Habilitado = true,
                Identificador = string.Empty,
                Nombre = string.Empty,
                TipoId = typesOfContainer.Items().FirstOrDefault().Id,
                UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id,
                UsuarioModificacion = null,
                DepositarioId = CurrentDepositary.Id


            });

            return returnValue;
        }


        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor UpdateContainerIdentifier(string bagIdentifier)
        {
            Permaquim.Depositario.Entities.Tables.Operacion.Contenedor returnValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Contenedor entities = new();

            if (CurrentContainer != null)
            {
                entities.Update(new Depositario.Entities.Tables.Operacion.Contenedor()
                {
                    Id = CurrentContainer.Id,
                    FechaApertura = CurrentContainer.FechaApertura,
                    FechaCierre = CurrentContainer.FechaCierre,
                    FechaCreacion = CurrentContainer.FechaCreacion,
                    FechaModificacion = DateTime.Now,
                    Habilitado = CurrentContainer.Habilitado,
                    Identificador = bagIdentifier,
                    Nombre = bagIdentifier,
                    TipoId = CurrentContainer.TipoId.Id,
                    UsuarioCreacion = CurrentContainer.UsuarioCreacion.Id,
                    UsuarioModificacion = CurrentUser.Id

                });
            }
            return returnValue;
        }


        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetTodaysOperationsHeaders()
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();
            transaction.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);
            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.UtcNow.Date);
            transaction.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);
            transaction.Items();

            return transaction.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetOperationsHeaders(
            DateTime dateFrom, DateTime dateTo, long userId, long turnId)
        {


            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, dateFrom.Date);
            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.LessThanOrEqual, dateTo.AddDays(1).Date);
            if (userId > -1)
            {
                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioId,
                    Depositario.sqlEnum.OperandEnum.Equal, userId);
            }

            if (turnId > -1)
            {
                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                    Depositario.sqlEnum.OperandEnum.Equal, turnId);
            }

            //transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, 
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
            //    Depositario.sqlEnum.OperandEnum.Equal, turnId);
            transaction.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetCurrentTurnOperationsHeaders()
        {
            List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> returnValue;
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaccion = new();

            if (DatabaseController.AvailableTurnsCount > 0)
            {
                transaccion.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentTurn.Id);
                transaccion.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);

                returnValue = transaccion.Items();
            }
            return transaccion.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionDetalle>
            GetOperationsDetails(long transactionId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetail = new();
            transactionDetail.OrderByParameter.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);
            transactionDetail.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);

            transactionDetail.OrderByParameter.Add(
                Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId);

            transactionDetail.Items();

            return transactionDetail.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Valor.Denominacion> GetCurrentCurrencyDenominations()
        {
            Permaquim.Depositario.Business.Relations.Valor.Denominacion denominacion = new();
            denominacion.Where.Add(Permaquim.Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentCurrency.Id);
            denominacion.OrderByParameter.Add(Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.Unidades);

            return denominacion.Items();
        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionSobreDetalle>
            GetEnvelopeOperationsDetails(long transactionId)
        {
            Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobreDetalle transaccionDetalle = new();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transaccionsobre = new();
            transaccionsobre.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);
            transaccionsobre.Items();
            if (transaccionsobre.Result.Count > 0)
            {

                transaccionDetalle.OrderByParameter.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);
                transaccionDetalle.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId,
                    Depositario.sqlEnum.OperandEnum.Equal, transaccionsobre.Result.FirstOrDefault().Id);
                transaccionDetalle.Items();

            }
            return transaccionDetalle.Result;

        }

        public static bool VerifySchedule()
        {
            Permaquim.Depositario.Business.Relations.Turno.AgendaTurno entities = new();
            entities.Where.Add(Depositario.Business.Relations.Turno.AgendaTurno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            return entities.Items().Count > 0;
        }

        public static Permaquim.Depositario.Entities.Tables.Operacion.Turno GetTurnSchedule()
        {

            // Verifica que eista un turno disponible para el depositario / sector
            // 

            Permaquim.Depositario.Entities.Tables.Operacion.Turno? newTurn = new();

            Permaquim.Depositario.Business.Tables.Operacion.Turno entities = new();
            entities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.IsNull, 0);

            
            entities.Items();

            AvailableTurnsCount = entities.Result.Count;

            if (entities.Result.Count == 0)
            {

                // No encuentro, entonces busco en Agenda turno si hay un turno disponible para
                // hoy y para mi sector

                Permaquim.Depositario.Business.Tables.Turno.AgendaTurno entitiesAgendaTurno = new();

                entitiesAgendaTurno.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha,
                    Depositario.sqlEnum.OperandEnum.Equal, DateTime.Now.Date);
                entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado,
                    Depositario.sqlEnum.OperandEnum.Equal, true);

                entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotIn, GetUsedTurns());

                entitiesAgendaTurno.OrderBy.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Secuencia,
                    Depositario.sqlEnum.DirEnum.ASC);



                entitiesAgendaTurno.Items();

                if (entitiesAgendaTurno.Result.Count == 0)
                {
                    // No eisten turnos dados de alta para el depositario,
                    // no se puede depositar.
                    AvailableTurnsCount = entitiesAgendaTurno.Result.Count;
                    newTurn = null;
                    _currentTurn = null;
                }
                else
                {
                    var availableTurn = entitiesAgendaTurno.Result.FirstOrDefault();

                    newTurn = entities.Add(new Permaquim.Depositario.Entities.Tables.Operacion.Turno()
                    {
                        CierreDiarioId = null,
                        DepositarioId = CurrentDepositary.Id,
                        Fecha = DateTime.Now,
                        FechaApertura = DateTime.Now,
                        FechaCierre = null,
                        FechaCreacion = DateTime.Now,
                        FechaModificacion = null,
                        Habilitado = true,
                        Observaciones = "Apertura automática por inicio de sesión.",
                        Secuencia = availableTurn.Secuencia,
                        SectorId = CurrentDepositary.SectorId.Id,
                        TurnoDepositarioId = availableTurn.Id,
                        UsuarioCreacion = CurrentUser.Id,
                        UsuarioModificacion = null
                    });

                    _currentTurn = null;

                    AvailableTurnsCount = entitiesAgendaTurno.Result.Count;
                }

            }
            else
            {
                newTurn = entities.Result.FirstOrDefault();
            }

            return newTurn;
        }

        private static List<long> GetUsedTurns()
        {
            List<long> resultValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Turno entities = new();
            entities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.IsNotNull, 0);
            entities.Items();

            foreach (var item in entities.Result)
            {
                resultValue.Add(item.TurnoDepositarioId);
            }

            return resultValue;

        }

        public static Permaquim.Depositario.Entities.Tables.Operacion.Turno CloseCurrentTurn()
        {
            try
            {

                Permaquim.Depositario.Business.Tables.Operacion.Turno entities = new();

                Permaquim.Depositario.Entities.Tables.Operacion.Turno newTurn = new();

                CurrentTurn.FechaCierre = DateTime.Now;
                entities.Update(new Depositario.Entities.Tables.Operacion.Turno()
                {
                    Id = CurrentTurn.Id,
                    //CierreDiarioId = CurrentTurn.CierreDiarioId.Id,
                    DepositarioId = CurrentTurn.DepositarioId.Id,
                    Fecha = CurrentTurn.Fecha,
                    FechaApertura = CurrentTurn.FechaApertura,
                    FechaCierre = DateTime.Now,
                    FechaCreacion = CurrentTurn.FechaCreacion,

                    Habilitado = CurrentTurn.Habilitado,
                    Observaciones = CurrentTurn.Observaciones,
                    SectorId = CurrentTurn.SectorId,
                    Secuencia = CurrentTurn.Secuencia,
                    TurnoDepositarioId = CurrentTurn.TurnoDepositarioId.Id,
                    UsuarioCreacion = CurrentTurn.UsuarioCreacion.Id,
                    UsuarioModificacion = CurrentTurn.UsuarioModificacion.Id,
                    FechaModificacion = DateTime.Now

                });


                newTurn = GetTurnSchedule();


                return newTurn;

            }
            catch (Exception ex)
            {
                Permaquim.Depositario.Business.Tables.Auditoria.Log log = new();
                log.Add((long)LogTypeEnum.Information, 1, DateTime.Now, ex.Message, ex.StackTrace,
                    "Cambio de turno", "DatabaseController.CloseCurrentTurn",
                    CurrentUser.Id);
                return null;
            }
        }

        public static Depositario.Entities.Tables.Operacion.CierreDiario CloseCurrentDay()
        {
            Depositario.Business.Tables.Operacion.CierreDiario entities = new();

            var currentDailyclosing = entities.Items(CurrentDailyClosing.Id).FirstOrDefault();

            currentDailyclosing.Fecha = DateTime.Now;
            currentDailyclosing.UsuarioModificacion = CurrentUser.Id;
            currentDailyclosing.FechaModificacion = DateTime.Now;
            entities.Update(currentDailyclosing);

            Depositario.Entities.Tables.Operacion.CierreDiario
            newClosing = entities.Add(new Permaquim.Depositario.Entities.Tables.Operacion.CierreDiario()
            {
                FechaCreacion = DateTime.Now,
                FechaModificacion = null,
                Nombre = CIERRE_DIARIO,
                SesionId = CurrentSession.Id,
                UsuarioCreacion = CurrentUser.Id,
                UsuarioModificacion = null
            });

            Depositario.Business.Tables.Operacion.Turno turnos = new();

            turnos.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            turnos.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.CierreDiarioId,
                 Depositario.sqlEnum.OperandEnum.IsNull, 0);

            foreach (var item in turnos.Items())
            {
                item.CierreDiarioId = newClosing.Id;
                turnos.Update(item);
            }

            return newClosing;
        }
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

        public static string GetEnterpriseParameterValue(string key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entities = new();
            entities.Where.Add(Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Clave,
                Depositario.sqlEnum.OperandEnum.Equal, key);
            entities.Items();
            if (entities.Result.Count > 0)
                return entities.Result.FirstOrDefault().Valor;

            return returnValue;
        }

        public static bool IsCurrencyInTemplate
        {
            get
            {
                bool returnValue = false;

                Permaquim.Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle entities = new();

                entities.Where.Add(Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.MonedaId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentCurrency.Id);
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.PlantillaMonedaId,
                   Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.ModeloId.PlantillaMonedaId.Id);
                entities.Items();

                returnValue = entities.Result.Count > 0;

                return returnValue;
            }
        }


        public static bool CurrencyHasDenominations
        {
            get
            {
                bool returnValue = false;

                Permaquim.Depositario.Business.Tables.Valor.Denominacion entities = new();

                entities.Where.Add(Depositario.Business.Tables.Valor.Denominacion.ColumnEnum.MonedaId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentCurrency.Id);

                entities.Items();

                returnValue = entities.Result.Count > 0;

                return returnValue;
            }
        }

        public static bool IsFuntionEnabled(long functionId)
        {
            bool returnValue = false;

            try
            {
                if (CurrentUser == null)
                {
                    returnValue = false;
                }
                else
                {
                    Permaquim.Depositario.Business.Tables.Seguridad.UsuarioRol usuarioRolEntities = new();
                    usuarioRolEntities.Where.Add(Depositario.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.UsuarioId,
                         Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.Id);
                    usuarioRolEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.AplicacionId,
                        Depositario.sqlEnum.OperandEnum.Equal, Global.Constants.APPLICATION_ID);

                    usuarioRolEntities.Items();

                    if (usuarioRolEntities.Result.Count > 0)
                    {

                        Permaquim.Depositario.Business.Tables.Seguridad.RolFuncion rolFuncionentities = new();
                        rolFuncionentities.Where.Add(Depositario.Business.Tables.Seguridad.RolFuncion.ColumnEnum.FuncionId,
                            Depositario.sqlEnum.OperandEnum.Equal, functionId);
                        rolFuncionentities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                            Depositario.Business.Tables.Seguridad.RolFuncion.ColumnEnum.RolId,
                            Depositario.sqlEnum.OperandEnum.Equal, usuarioRolEntities.Result.FirstOrDefault().RolId);
                        rolFuncionentities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                             Depositario.Business.Tables.Seguridad.RolFuncion.ColumnEnum.Habilitado,
                             Depositario.sqlEnum.OperandEnum.Equal, true);


                        rolFuncionentities.Items();
                        if (rolFuncionentities.Result.Count > 0)
                            returnValue = rolFuncionentities.Result.FirstOrDefault().PuedeVisualizar;
                    }
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return returnValue;
            }
        }

        public static List<Permaquim.Depositario.Entities.Tables.Regionalizacion.Lenguaje> GetLanguageList()
        {
            Permaquim.Depositario.Business.Tables.Regionalizacion.Lenguaje entities = new();

            entities.Where.Add(Depositario.Business.Tables.Regionalizacion.Lenguaje.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Items();

            return entities.Result;
        }

        public static List<Permaquim.Depositario.Entities.Tables.Seguridad.Usuario> GetUserList()
        {
            Permaquim.Depositario.Business.Tables.Seguridad.Usuario entities = new();

            entities.Where.Add(Depositario.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Items();

            return entities.Result;
        }
        public static List<Permaquim.Depositario.Entities.Tables.Turno.AgendaTurno> GetTurnList()
        {
            Permaquim.Depositario.Business.Tables.Turno.AgendaTurno entities = new();

            entities.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Items();

            return entities.Result;
        }

        public static bool SetLanguageId(long languageId)
        {
            Permaquim.Depositario.Business.Tables.Seguridad.Usuario entities = new();

            var user = entities.Items(CurrentUser.Id).FirstOrDefault();
            user.LenguajeId = languageId;
            return entities.Update(user) != 0;
        }
        public static void CreateSession()
        {
            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesion = new();
            sesion.Add(CurrentDepositary.Id, DatabaseController.CurrentUser.Id, DateTime.Now, null, null);
        }

        public static List<Depositario.Entities.Views.Reporte.Contenedores> GetBaghistoryItems()
        {
            Depositario.Business.Views.Reporte.Contenedores entities = new();
           

            return entities.Items();
        }
        public static List<DailyClosingItem> GetDailyClosingItems()
        {
            List<DailyClosingItem> returnValue = new();
            DailyClosingItem newItem = null;

            Permaquim.Depositario.Business.Relations.Valor.Moneda currencyEntities = new();
            // Por cada registro de la tabla de ralación tipo moneda / valor , si la modena 
            // está habilitada para este depositario, cargo los datos de las ultimas transacciones sin cierre.
            foreach (var currencyItem in currencyEntities.Items())
            {
                if (currencyItem.Habilitado == true)
                {
                    newItem = new DailyClosingItem()
                    {
                        Moneda = currencyItem.Nombre,
                        CantidadOperaciones = 0,
                        TotalAValidar = 0,
                        TotalValidado = 0,
                        Total = 0
                    };

                    // cargo las tx de esta moneda    
                    Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();

                    transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.DepositarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, 0);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.MonedaId,
                        Depositario.sqlEnum.OperandEnum.Equal, currencyItem.Id);
                    transactionEntities.OrderBy.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId);

                    foreach (var transaccionItem in transactionEntities.Items())
                    {
                        newItem.CantidadOperaciones += 1;
                        newItem.TotalValidado += transaccionItem.TotalValidado;
                        newItem.TotalAValidar += transaccionItem.TotalAValidar;
                        newItem.Total += transaccionItem.TotalValidado + transaccionItem.TotalAValidar;
                    }

                    if (newItem.Total > 0)
                        returnValue.Add(newItem);
                }

            }

            return returnValue;

        }

        public static List<BagContentItem> GetBillBagContentItems()
        {
            List<BagContentItem> returnValue = new(); // BagContentItem newBagContentItem = new();

            Permaquim.Depositario.Business.Tables.Valor.Moneda currencyEntities = new();
            currencyEntities.Where.Add(Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            foreach (var currencyItem in currencyEntities.Items())
            {
                Permaquim.Depositario.Business.Tables.Valor.Denominacion denominationsEntities = new();

                denominationsEntities.Where.Add(Depositario.Business.Tables.Valor.Denominacion.ColumnEnum.MonedaId,
                    Depositario.sqlEnum.OperandEnum.Equal, currencyItem.Id);

                foreach (var denominationItem in denominationsEntities.Items())
                {
                    BagContentItem newBagContentItem = new();

                    Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
                    transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.MonedaId,
                        Depositario.sqlEnum.OperandEnum.Equal, currencyItem.Id);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                        Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.BillDeposit);

                    foreach (var transactionItem in transactionEntities.Items())
                    {
                        Permaquim.Depositario.Business.Tables.Operacion.TransaccionDetalle transactionDetalleEntities = new();

                        transactionDetalleEntities.Where.Add(
                            Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                            Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);
                        transactionDetalleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                            Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId,
                            Depositario.sqlEnum.OperandEnum.Equal, denominationItem.Id);

                        foreach (var transactionDetalleItem in transactionDetalleEntities.Items())
                        {
                            newBagContentItem.Cantidad += transactionDetalleItem.CantidadUnidades;
                            newBagContentItem.Moneda = currencyItem.Nombre;
                            newBagContentItem.Denominacion = denominationItem.Nombre;
                            newBagContentItem.Total += (transactionDetalleItem.CantidadUnidades * denominationItem.Unidades);
                        }
                    }

                    if (newBagContentItem.Total > 0)
                        returnValue.Add(newBagContentItem);
                }
            }
            return returnValue;
        }
        public static List<BagContentItem> GetEnvelopeBagContentItems()
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);

            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Tables.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);

                BagContentItem newBagContentItem = new();
                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {
                    newBagContentItem.Cantidad = 1;
                    newBagContentItem.Moneda =
                        transactionEnvelopeDetailItem.CodigoSobre.Length == 0 ? "S/C" : transactionEnvelopeDetailItem.CodigoSobre;

                }

                returnValue.Add(newBagContentItem);

            }

            return returnValue;
        }

        public static long GetCurrencySequence()
        {
            long returnValue = 0;
            Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle entity = new();
            entity.Where.Add(Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.PlantillaMonedaId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.ModeloId.PlantillaMonedaId.Id);
            entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.MonedaId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentCurrency.Id);

            entity.Items();
            if (entity.Result.Count > 0)
                returnValue = entity.Result.FirstOrDefault().Secuencia;

               return returnValue;
        }
    }
}
