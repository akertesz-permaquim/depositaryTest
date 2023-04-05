using Permaquim.Depositario;
using Permaquim.Depositario.Business.Relations.Valor;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Security;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class DatabaseController
    {

        public enum ConnectionStatusEnum
        {
            None = 0,
            Connected = 1,
            Disconnected = 2,
            UnInitialized = 3
        }
        private static Depositario.Entities.Relations.Dispositivo.Depositario _currentDepositary = null;
        private static Depositario.Entities.Relations.Dispositivo.DepositarioContadora _currentDepositaryCounter = null;
        private static Depositario.Entities.Relations.Dispositivo.DepositarioPlaca _currentDepositaryIoboard = null;
        private static Depositario.Entities.Relations.Operacion.TipoTransaccion _currentOperation;
        private static List<Depositario.Entities.Relations.Dispositivo.ComandoContadora> _currentDepositaryCounterCommands = null;
        private static List<Depositario.Entities.Relations.Dispositivo.ComandoPlaca> _currentDepositaryIoBoardCommands = null;
        private static Depositario.Entities.Relations.Valor.Moneda _currentCurrency;
        private static Depositario.Business.Tables.Dispositivo.DepositarioEstado _depositaryStatusEntities = null;
        private static Depositario.Entities.Tables.Dispositivo.DepositarioEstado _depositaryStatus = null;

        private static Permaquim.Depositario.Business.Relations.Operacion.Turno _turnEntities = new();
        private static Permaquim.Depositario.Business.Relations.Operacion.Turno _lastTurnentities = new();
        private static Permaquim.Depositario.Entities.Tables.Operacion.Turno? _newTurn = new();
        private static Depositario.Business.Relations.Operacion.Turno _turnRelations = new();
        private static Permaquim.Depositario.Business.Tables.Operacion.Turno _turnScheduleEntities = new();
        private static Permaquim.Depositario.Business.Tables.Turno.AgendaTurno _entitiesAgendaTurno = new();
        private static Permaquim.Depositario.Business.Tables.Operacion.Turno _usedturnsEntities = new();

        private const string CIERRE_DIARIO = "Cierre diario";
        private const string CIERRE_DIARIO_INICIAL = "Cierre Diario inicial";
        private const string RETIRO_SIN_USUARIO = "Retiro sin usuario";

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

        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno _lastTurn { get; private set; }

        private static Int64? _timeoutGeneral;

        /// <summary>
        /// Representa el turno actual
        /// </summary>
        public static Int64 TimeoutGeneral
        { get
            {
                if (_timeoutGeneral == null)
                {
                    _timeoutGeneral = Convert.ToInt64(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_GENERAL"));
                }
                return (Int64)_timeoutGeneral;
            }
        }


        /// <summary>
        /// Representa el turno actual
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno CurrentTurn
        {
            get
            {

                if (_currentTurn == null)
                {
                    // Verifica que exista un turno disponible para el depositario / sector
                    _turnEntities.Where.Clear();

                    _turnEntities.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Habilitado,
                        Depositario.sqlEnum.OperandEnum.Equal, true);
                    _turnEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                    _turnEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.SectorId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                    _turnEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Operacion.Turno.ColumnEnum.FechaCierre,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);
                    _turnEntities.Items();

                    if (_turnEntities.Result.Count != 0)
                    {
                        _currentTurn = _turnEntities.Result.FirstOrDefault();
                    }

                }
                return _currentTurn;
            }
        }

        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno LastTurn
        {
            get
            {

                // Verifica que exista un turno disponible para el depositario / sector
                _lastTurnentities.Where.Clear();
                _lastTurnentities.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Habilitado,
                    Depositario.sqlEnum.OperandEnum.Equal, true);
                _lastTurnentities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                _lastTurnentities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.SectorId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                _lastTurnentities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.FechaCierre,
                Depositario.sqlEnum.OperandEnum.IsNotNull, 0);
                _lastTurnentities.OrderBy.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Id, Depositario.sqlEnum.DirEnum.DESC);

                _lastTurnentities.Items();

                if (_lastTurnentities.Result.Count != 0)
                {
                    _lastTurn = _lastTurnentities.Result.FirstOrDefault();
                }


                return _lastTurn;
            }
        }
        public static Depositario.Entities.Relations.Operacion.CierreDiario LastDailyClosing
        {
            get
            {
                Depositario.Business.Relations.Operacion.CierreDiario entity = new();

                entity.Where.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Fecha,
                    Depositario.sqlEnum.OperandEnum.IsNotNull, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.DepositarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                entity.OrderBy.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);
                entity.TopQuantity = 1;

                entity.Items();

                if (entity.Result.Count > 0)
                    return entity.Result.FirstOrDefault();
                else
                    return null;
            }
        }
        public static Depositario.Entities.Relations.Operacion.CierreDiario CurrentDailyClosing
        {
            get
            {
                Depositario.Entities.Relations.Operacion.CierreDiario returnValue = null;

                Depositario.Business.Relations.Operacion.CierreDiario entity = new();
                entity.Where.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Fecha,
                    Depositario.sqlEnum.OperandEnum.IsNotNull, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.DepositarioId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                entity.Items();

                if (entity.Result.Count > 0)
                    returnValue = entity.Result.LastOrDefault();

                return returnValue;

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

        public static Int32 GetPollingInterval()
        {
            int returnValue = 0;
            Permaquim.Depositario.Business.Relations.Dispositivo.ConfiguracionDepositario entity = new();
            entity.Where.Add(Depositario.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, 0);
            entity.Items();
            if (entity.Result.Count > 0)
                returnValue = Convert.ToInt32(entity.Result.FirstOrDefault().Valor);
            return returnValue;
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
               Depositario.sqlEnum.OperandEnum.IsNull, 0);
                entity.Items();

                if (entity.Result.Count > 0)
                    return entity.Result.LastOrDefault();
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
                        Nombre = "Contenedor Inicial",
                        UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id

                    }); ;

                    return CurrentContainer;
                }

            }
        }

        public static Permaquim.Depositario.Entities.Relations.Operacion.Contenedor GetContainer(long containerId)
        {
            Permaquim.Depositario.Business.Relations.Operacion.Contenedor entity = new();
            return entity.Items(containerId).FirstOrDefault();
        }

        /// <summary>
        /// Representa el contenedor anterior
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Operacion.Contenedor LastContainer
        {
            get
            {
                Permaquim.Depositario.Business.Relations.Operacion.Contenedor entity = new();
                entity.Where.Add(Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.FechaCierre,
                Depositario.sqlEnum.OperandEnum.IsNotNull, 0);
                entity.OrderBy.Add(Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);
                entity.TopQuantity = 1;

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
                        Nombre = "Contenedor last",
                        UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id

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
        public static Permaquim.Depositario.Entities.Tables.Operacion.Sesion CreateSession(long userId)
        {
            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
            CurrentSession = sesiones.Add(CurrentDepositary.Id, userId, DateTime.Now, null, null);
            return CurrentSession;
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
            StyleController.ResetSchema();

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

        public static List<Permaquim.Depositario.Entities.Relations.Valor.RelacionMonedaTipoValor> GetCurrencyValueRelations()
        {
            List<Permaquim.Depositario.Entities.Relations.Valor.RelacionMonedaTipoValor> returnValue = new();

            Permaquim.Depositario.Business.Relations.Valor.RelacionMonedaTipoValor entities = new();

            if (DatabaseController.CurrentCurrency != null)
            {
                entities.Where.Add(Depositario.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentCurrency.Id);
            }

            return entities.Items();

            return returnValue;

        }

        /// <summary>
        /// Monedas disponibles en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<Permaquim.Depositario.Entities.Relations.Valor.Moneda> GetCurrencies(bool onlyEnabledCurrencies = true)
        {

            List<Permaquim.Depositario.Entities.Relations.Valor.Moneda> returnValue = new();

            Permaquim.Depositario.Business.Relations.Dispositivo.DepositarioMoneda depositarioMoneda = new();
            depositarioMoneda.Where.Add(Depositario.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);

            if (onlyEnabledCurrencies)
            {
                depositarioMoneda.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
            }

            depositarioMoneda.Items();

            var monedas = depositarioMoneda.Result.DistinctBy(x => x.MonedaId.Id).Select(x => x.MonedaId.Id).ToList();

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
                returnValue = currencies.Items();
            }

            return returnValue;

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

        public static List<Permaquim.Depositario.Entities.Relations.Valor.OrigenValor> GetDepositOrigins()
        {
            Permaquim.Depositario.Business.Relations.Valor.OrigenValor entities = new();
            entities.Where.Add(Permaquim.Depositario.Business.Relations.Valor.OrigenValor.ColumnEnum.Habilitado,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Valor.OrigenValor.ColumnEnum.EmpresaId,
            Permaquim.Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.EmpresaId.Id);
            entities.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                Permaquim.Depositario.Business.Relations.Valor.OrigenValor.ColumnEnum.Id,
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

            return entities.Items();
        }
        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor CreateContainer()
        {
            Permaquim.Depositario.Entities.Tables.Operacion.Contenedor returnValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Contenedor entities = new();
            try
            {
                entities.BeginTransaction();

                if (CurrentContainer != null)
                {
                    var currentcontainer = entities.Items(CurrentContainer.Id).FirstOrDefault();
                    currentcontainer.FechaCierre = DateTime.Now;
                    currentcontainer.FechaModificacion = DateTime.Now;
                    currentcontainer.UsuarioModificacion = CurrentUser == null ? null : CurrentUser.Id;

                    // Primero actualiza la fecha de cierre de la bolsa actual
                    entities.Update(currentcontainer);

                    // Da de alta la transaccion
                    Permaquim.Depositario.Business.Tables.Operacion.Transaccion transaction = new(entities);
                    transaction.Add(new Permaquim.Depositario.Entities.Tables.Operacion.Transaccion()
                    {
                        CierreDiarioId = null,
                        CodigoOperacion =
                                DatabaseController.CurrentDepositary.CodigoExterno + "-" + DateTime.Now.ToString("yyMMdd"),
                        ContenedorId = currentcontainer.Id,
                        CuentaId = null,
                        DepositarioId = CurrentDepositary.Id,
                        EsDepositoAutomatico = false,
                        Fecha = DateTime.Now,
                        Finalizada = true,
                        MonedaId = DefaultCurrency().Id,
                        OrigenValorId = null, // NO ESPECIFICADO
                        SectorId = CurrentDepositary.SectorId.Id,
                        SesionId = CurrentSession.Id,
                        SucursalId = CurrentDepositary.SectorId.SucursalId.Id,
                        TipoId = (long)Global.Enumerations.OperationTypeEnum.ValueExtraction,
                        TotalAValidar = 0,
                        TotalValidado = 0,
                        TurnoId = CurrentTurn != null ? CurrentTurn.Id : LastTurn.Id,
                        UsuarioId = CurrentUser == null ? 0 : CurrentUser.Id,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id,

                    }); ;

                }
                //Luego genera una nueva

                var newcontainer = entities.Add(new Depositario.Entities.Tables.Operacion.Contenedor()
                {
                    FechaApertura = DateTime.Now,
                    FechaCierre = null,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = null,
                    Habilitado = true,
                    Identificador = string.Empty,
                    Nombre = string.Empty,
                    TipoId = CurrentDepositary.TipoContenedorId.Id,
                    UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id,
                    UsuarioModificacion = null,
                    DepositarioId = CurrentDepositary.Id

                });

                // Si el usuario es nulo, es que se trata de un retiro sin usuario logueado,
                // por lo tanto graba el evento en la tabla correspondiente
                if (CurrentUser == null)
                {
                    EventController.CreateEvent(EventTypeEnum.Cambio_de_Contenedor_Sin_usuario,
                        RETIRO_SIN_USUARIO, RETIRO_SIN_USUARIO);

                }

                entities.EndTransaction(true);
                return returnValue;
            }
            catch (Exception ex)
            {
                entities.EndTransaction(false);
                AuditController.Log(ex);
                return null;
            }
        }


        public static bool UserlessValueExtractionEventDetected()
        {
            bool returnValue = false;

            Permaquim.Depositario.Business.Tables.Operacion.Evento operationEvent = new();
            operationEvent.OrderBy.Add(Depositario.Business.Tables.Operacion.Evento.ColumnEnum.Id, Depositario.sqlEnum.DirEnum.DESC);
            operationEvent.TopQuantity = 1;
            operationEvent.Items();

            if (operationEvent.Result.Count > 0)
            {
                returnValue = operationEvent.Result.FirstOrDefault().TipoId == (long)Global.Enumerations.EventTypeEnum.Cambio_de_Contenedor_Sin_usuario;
            }

            return returnValue;
        }

        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor UpdateContainerIdentifier(string bagIdentifier,
            bool requiresIdentifier)
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
                    Identificador = requiresIdentifier == true ? bagIdentifier : String.Empty,
                    Nombre = CurrentDepositary.CodigoExterno.ToString() + "-" + CurrentContainer.Id.ToString(),
                    TipoId = CurrentContainer.TipoId.Id,
                    UsuarioCreacion = CurrentContainer.UsuarioCreacion.Id,
                    UsuarioModificacion = CurrentUser.Id,
                    DepositarioId = CurrentDepositary.Id,

                }); ;

            }
            return returnValue;
        }



        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetTodaysOperationsHeaders()
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();
            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);
            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.UtcNow.Date);
            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);
            transaction.Items();

            return transaction.Result;

        }


        public static Depositario.Entities.Relations.Operacion.TransaccionSobre GetEnvelopeTransactionHeader(
            long transactionId)
        {
            Depositario.Business.Relations.Operacion.TransaccionSobre envelopeTransaction = new();
            envelopeTransaction.Items(transactionId);

            return envelopeTransaction.Result.FirstOrDefault();
        }

        public static List<Depositario.Entities.Relations.Operacion.TransaccionSobreDetalle> GetEnvelopeTransactionDetails(
       long envelopeId)
        {
            Depositario.Business.Relations.Operacion.TransaccionSobreDetalle envelopeTransactionDetail = new();
            envelopeTransactionDetail.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId,
               Depositario.sqlEnum.OperandEnum.Equal, envelopeId);

            envelopeTransactionDetail.Items();

            return envelopeTransactionDetail.Result;
        }

        public static Depositario.Entities.Relations.Operacion.Transaccion GetTransactionHeader(
        long transactionId)
        {
            Depositario.Business.Relations.Operacion.Transaccion transaction = new();
            transaction.Items(transactionId);

            return transaction.Result.FirstOrDefault();

        }

        public static List<Depositario.Entities.Relations.Operacion.TransaccionDetalle> GetTransactionDetails(
            long transactionId)
        {
            Depositario.Business.Relations.Operacion.TransaccionDetalle transaction = new();
            transaction.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);
            transaction.Items();

            return transaction.Result;

        }

        public static List<Depositario.Entities.Relations.Operacion.Transaccion> GetOperationsHeaders(
            DateTime dateFrom, DateTime dateTo, long userId, long turnId, long typeId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, dateFrom);
            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.LessThanOrEqual, dateTo);
            if (userId > -1)
            {
                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioId,
                    Depositario.sqlEnum.OperandEnum.Equal, userId);
            }
            if (typeId > -1)
            {
                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId,
                    Depositario.sqlEnum.OperandEnum.Equal, typeId);
            }

            if (turnId > -1)
            {
                Permaquim.Depositario.Business.Relations.Turno.AgendaTurno scheduleTurns = new();
                scheduleTurns.Where.Add(Depositario.Business.Relations.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId,
                    Depositario.sqlEnum.OperandEnum.Equal, turnId);
                scheduleTurns.Items();

                List<Int64> arrayTurns = new();

                if (scheduleTurns.Result.Count > 0)
                {

                    foreach (var item in scheduleTurns.Result)
                    {
                        foreach (var subItem in item.ListOf_Turno_TurnoDepositarioId)
                        {
                            arrayTurns.Add(subItem.Id);
                        }
                    }

                }

                if (arrayTurns.Count == 0)
                    arrayTurns.Add(-1);

                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.In, arrayTurns);

            }

            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static List<Depositario.Entities.Relations.Operacion.Transaccion> GetTurnsDetails(
            long turnId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, turnId);

            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static List<Depositario.Entities.Relations.Operacion.Transaccion> GetDailyClosingDetails(
    long dailyClosingId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.Equal, dailyClosingId);

            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionDetalle> GetDailyClosingDetail
           (long dailyclosingId)
        {
            List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionDetalle> returnValue = new();

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactionHeader = new();
            transactionHeader.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
             Depositario.sqlEnum.OperandEnum.Equal, dailyclosingId);
            transactionHeader.Items();

            if (transactionHeader.Result.Count > 0)
            {
                Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetail = new();
                transactionDetail.OrderBy.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);
                transactionDetail.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionHeader.Result.FirstOrDefault().Id);

                transactionDetail.OrderBy.Add(
                    Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId);

                transactionDetail.Items();
                returnValue = transactionDetail.Result;
            }

            return returnValue;

        }
        public static List<Depositario.Entities.Relations.Operacion.Turno> GetTurnChangeHeaders(
       DateTime dateFrom, DateTime dateTo, long userId, long turnId)
        {
            Permaquim.Depositario.Business.Relations.Operacion.Turno turn = new();

            turn.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.Between, dateFrom, dateTo.AddHours(23).AddMinutes(59));

            if (userId > -1)
            {
                turn.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.UsuarioCreacion,
                              Depositario.sqlEnum.OperandEnum.Equal, userId);
            }

            if (turnId > -1)
            {
                Permaquim.Depositario.Business.Relations.Turno.AgendaTurno scheduleTurns = new();
                scheduleTurns.Where.Add(Depositario.Business.Relations.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId, Depositario.sqlEnum.OperandEnum.Equal, turnId);
                scheduleTurns.Items();

                List<Int64> arrayTurns = new();

                if (scheduleTurns.Result.Count > 0)
                {
                    foreach (var item in scheduleTurns.Result)
                        arrayTurns.Add(item.Id);
                }

                if (arrayTurns.Count == 0)
                    arrayTurns.Add(-1);

                turn.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.TurnoDepositarioId,
                              Depositario.sqlEnum.OperandEnum.In, arrayTurns);
            }


            turn.Items();

            return turn.Result;

        }


        public static List<Depositario.Entities.Relations.Operacion.CierreDiario> GetDailyClosingHeaders(
    DateTime dateFrom, DateTime dateTo, long userId)
        {


            Permaquim.Depositario.Business.Relations.Operacion.CierreDiario transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.Between, dateFrom, dateTo);
            if (userId > -1)
            {
                transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.UsuarioCreacion,
                    Depositario.sqlEnum.OperandEnum.Equal, userId);
            }


            transaction.OrderBy.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static Depositario.Entities.Relations.Operacion.Transaccion GetOperationsHeader(
            long transacionId)
        {
            Permaquim.Depositario.Entities.Relations.Operacion.Transaccion returnValue = new();

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.OperandEnum.Equal, transacionId);

            transaction.Items();
            if (transaction.Result.Count > 0)
                returnValue = transaction.Result.FirstOrDefault();

            return returnValue;

        }
        public static Depositario.Entities.Tables.Operacion.Transaccion GetOperationHeader(
        long transacionId)
        {
            Permaquim.Depositario.Entities.Tables.Operacion.Transaccion returnValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transaction = new();

            transaction.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.OperandEnum.Equal, transacionId);

            transaction.Items();
            if (transaction.Result.Count > 0)
                returnValue = transaction.Result.FirstOrDefault();

            return returnValue;

        }

        public static List<BillContentResumeItem>
            GetCurrentContainerTransactions()
        {
            List<BillContentResumeItem> returnValue = new();


            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
            transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.In, txs);
            transactionDetails.Items();

            foreach (var transactionDetailItem in transactionDetails.Result)
            {

                returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;

            }


            return returnValue;

        }


        public static List<BillContentResumeItem>
      GetCurrentDailyClosingTransactions()
        {
            List<BillContentResumeItem> returnValue = new();


            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.IsNull, 0);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
            transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.In, txs);
            transactionDetails.Items();

            foreach (var transactionDetailItem in transactionDetails.Result)
            {

                returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;

            }


            return returnValue;

        }

        public static List<BillContentResumeItem>
                GetCurrentTurnTransactions()
        {
            List<BillContentResumeItem> returnValue = new();


            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentTurn.Id);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
            transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.In, txs);
            transactionDetails.Items();

            foreach (var transactionDetailItem in transactionDetails.Result)
            {

                returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;

            }


            return returnValue;

        }

        //public static List<BillContentResumeItem> GetLastTurnTransactions()
        //{
        //    List<BillContentResumeItem> returnValue = new();

        //    // Monedas
        //    var currencies = GetCurrencies(false);

        //    foreach (var currencyItem in currencies)
        //    {
        //        foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
        //        {

        //            BillContentResumeItem newBagBillContentResumeItem = new()
        //            {
        //                MonedaId = currencyItem.Id,
        //                Moneda = currencyItem.Codigo,
        //                DenominacionId = currencyDenominationItem.Id,
        //                Denominacion = currencyDenominationItem.Nombre,
        //                UnidadesDenominacion = currencyDenominationItem.Unidades
        //            };
        //            returnValue.Add(newBagBillContentResumeItem);
        //        }

        //    }

        //    // Transacciones
        //    Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
        //    transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
        //        Depositario.sqlEnum.OperandEnum.Equal, LastTurn.Id);
        //    transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
        //        Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
        //        Depositario.sqlEnum.OperandEnum.Equal, true);
        //    transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

        //    transactions.Items();

        //    var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

        //    Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
        //    transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
        //        Depositario.sqlEnum.OperandEnum.In, txs);
        //    transactionDetails.Items();

        //    foreach (var transactionDetailItem in transactionDetails.Result)
        //    {

        //        returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;

        //    }
        //    returnValue = returnValue.Where(x => x.Total > 0).ToList<BillContentResumeItem>();

        //    return returnValue;

        //}

        public static List<BillContentResumeItem> GetTurnTransactions(Int64 TurnId)
        {
            List<BillContentResumeItem> returnValue = new();

            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, TurnId);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            if (transactions.Result.Count > 0)
            {
                var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

                if (txs.Count > 0)
                {
                    Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
                    transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                        Depositario.sqlEnum.OperandEnum.In, txs);
                    transactionDetails.Items();

                    foreach (var transactionDetailItem in transactionDetails.Result)
                    {
                        returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;
                    }

                }
            }

            foreach (var item in returnValue)
            {
                item.Total = item.Cantidad * item.UnidadesDenominacion;
            }

            returnValue = returnValue.Where(x => x.Total > 0).ToList<BillContentResumeItem>();

            return returnValue;

        }

        public static List<BagContentItem> GetTurnEnvelopeBagContentItems(Int64 TurnId)
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);
            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
               Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TurnoId,
               Depositario.sqlEnum.OperandEnum.Equal, TurnId);
            //         transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.Finalizada,
            //Depositario.sqlEnum.OperandEnum.Equal, true);


            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);

                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda =
                            transactionEnvelopeDetailItem.CodigoSobre.Length == 0 ? "S/C" : transactionEnvelopeDetailItem.CodigoSobre;
                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        var ret = returnValue.Find(x => x.Moneda.Equals(newBagContentItem.Moneda)
                           && x.Denominacion.Equals(newBagContentItem.Denominacion));
                        if (ret == null)
                            returnValue.Add(newBagContentItem);
                        else
                            ret.Cantidad += item.CantidadDeclarada;
                    }
                }


            }

            return returnValue;
        }

        public static List<BillContentResumeItem> GetDailyClosingTransactions(Int64 DailyClosingId)
        {
            List<BillContentResumeItem> returnValue = new();


            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.Equal, DailyClosingId);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
            if (txs.Count > 0)
            {
                transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.In, txs);

                transactionDetails.Items();

                foreach (var transactionDetailItem in transactionDetails.Result)
                {

                    returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;
                    returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Total =
                        returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad *
                        returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).UnidadesDenominacion;

                }
                returnValue = returnValue.Where(x => x.Total > 0).ToList();
            }
            return returnValue;

        }

        public static List<BillContentResumeItem> GetLastClosingDayTransactions()
        {
            List<BillContentResumeItem> returnValue = new();


            // Monedas
            var currencies = GetCurrencies(false);

            foreach (var currencyItem in currencies)
            {
                foreach (var currencyDenominationItem in GetCurrencyDenominations(currencyItem.Id))
                {

                    BillContentResumeItem newBagBillContentResumeItem = new()
                    {
                        MonedaId = currencyItem.Id,
                        Moneda = currencyItem.Codigo,
                        DenominacionId = currencyDenominationItem.Id,
                        Denominacion = currencyDenominationItem.Nombre,
                        UnidadesDenominacion = currencyDenominationItem.Unidades
                    };
                    returnValue.Add(newBagBillContentResumeItem);
                }

            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.Equal, LastDailyClosing.Id);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
            transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.In, txs);
            transactionDetails.Items();

            foreach (var transactionDetailItem in transactionDetails.Result)
            {

                returnValue.Find(x => x.DenominacionId == transactionDetailItem.DenominacionId.Id).Cantidad += transactionDetailItem.CantidadUnidades;

            }


            return returnValue;

        }

        public static List<BagBillContentResume> GetCurrentContainerResume(Global.Enumerations.OperationTypeEnum depositType)
        {
            List<BagBillContentResume> returnValue = new();


            // Monedas
            var currencies = GetCurrencies();

            foreach (var currencyItem in currencies)
            {
                BagBillContentResume newBagBillContentResume = new()
                {
                    Moneda = currencyItem.Codigo,
                    MonedaId = currencyItem.Id

                };
                returnValue.Add(newBagBillContentResume);
            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);
            transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, depositType);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            if (txs.Count != 0)
            {
                if (depositType == OperationTypeEnum.BillDeposit)
                {
                    Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
                    transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                        Depositario.sqlEnum.OperandEnum.In, txs);
                    transactionDetails.Items();

                    foreach (var transactionDetailItem in transactionDetails.Result)
                    {
                        var element =
                        returnValue.Find(x => x.Moneda ==
                        transactionDetailItem.DenominacionId.MonedaId.Codigo);
                        element.Total +=
                        transactionDetailItem.CantidadUnidades * transactionDetailItem.DenominacionId.Unidades;
                        element.FormattedTotal = transactionDetailItem.TransaccionId.MonedaId.Simbolo +
                                " " + element.Total;
                        element.CantidadBilletes += transactionDetailItem.CantidadUnidades;
                    }
                }
                if (depositType == OperationTypeEnum.EnvelopeDeposit)
                {
                    Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopes = new();
                    transactionEnvelopes.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                        Depositario.sqlEnum.OperandEnum.In, txs);
                    transactionEnvelopes.Items();

                    foreach (var transactionEnvelopeItem in transactionEnvelopes.Result)
                    {

                        foreach (var transaccionSobreDetalleItem in
                            transactionEnvelopeItem.ListOf_TransaccionSobreDetalle_SobreId)
                        {
                            var element =
                            returnValue.Find(x => x.Moneda ==
                            transaccionSobreDetalleItem.RelacionMonedaTipoValorId.MonedaId.Codigo);
                            element.Total += transaccionSobreDetalleItem.CantidadDeclarada;
                            element.FormattedTotal = transaccionSobreDetalleItem.RelacionMonedaTipoValorId.MonedaId.Simbolo +
                                " " + element.Total;
                        }
                    }

                }
            }
            return returnValue;

        }

        public static List<BagBillContentResume> GetContainerResume(long containerId, Global.Enumerations.OperationTypeEnum depositType)
        {
            List<BagBillContentResume> returnValue = new();


            // Monedas
            var currencies = GetCurrencies();

            foreach (var currencyItem in currencies)
            {
                BagBillContentResume newBagBillContentResume = new()
                {
                    Moneda = currencyItem.Codigo,
                    MonedaId = currencyItem.Id

                };
                returnValue.Add(newBagBillContentResume);
            }

            // Transacciones
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transactions = new();
            transactions.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, containerId);
            transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, depositType);
            //transactions.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transactions.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId);

            transactions.Items();

            var txs = transactions.Result.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

            if (txs.Count != 0)
            {
                if (depositType == OperationTypeEnum.BillDeposit)
                {
                    Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetails = new();
                    transactionDetails.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                        Depositario.sqlEnum.OperandEnum.In, txs);
                    transactionDetails.Items();

                    foreach (var transactionDetailItem in transactionDetails.Result)
                    {
                        var element =
                        returnValue.Find(x => x.Moneda ==
                        transactionDetailItem.DenominacionId.MonedaId.Codigo);
                        element.Total +=
                        transactionDetailItem.CantidadUnidades * transactionDetailItem.DenominacionId.Unidades;
                        element.FormattedTotal = transactionDetailItem.TransaccionId.MonedaId.Simbolo +
                                " " + element.Total;
                        element.CantidadBilletes += transactionDetailItem.CantidadUnidades;

                    }
                }
                if (depositType == OperationTypeEnum.EnvelopeDeposit)
                {
                    Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopes = new();
                    transactionEnvelopes.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                        Depositario.sqlEnum.OperandEnum.In, txs);
                    transactionEnvelopes.Items();

                    foreach (var transactionEnvelopeItem in transactionEnvelopes.Result)
                    {

                        foreach (var transaccionSobreDetalleItem in
                            transactionEnvelopeItem.ListOf_TransaccionSobreDetalle_SobreId)
                        {
                            var element =
                            returnValue.Find(x => x.Moneda ==
                            transaccionSobreDetalleItem.RelacionMonedaTipoValorId.MonedaId.Codigo);
                            element.Total += transaccionSobreDetalleItem.CantidadDeclarada;
                            element.FormattedTotal = transaccionSobreDetalleItem.RelacionMonedaTipoValorId.MonedaId.Simbolo +
                                " " + element.Total;
                        }
                    }

                }
            }
            return returnValue;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetCurrentTurnOperationsHeaders()
        {
            List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> returnValue;
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaccion = new();

            //if (DatabaseController.AvailableTurnsCount > 0)
            //{
            transaccion.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentTurn.Id);
            transaccion.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);

            returnValue = transaccion.Items();
            //}
            return transaccion.Result;

        }
        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetCurrentDailyclosingOperationsHeaders()
        {
            List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> returnValue;
            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaccion = new();

            transaccion.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.IsNull, 0);
            //transaccion.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
            //    Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Finalizada,
            //    Depositario.sqlEnum.OperandEnum.Equal, true);
            transaccion.OrderBy.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);

            returnValue = transaccion.Items();

            return transaccion.Result;

        }
        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionDetalle>
            GetOperationsDetails(long transactionId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transactionDetail = new();
            transactionDetail.OrderBy.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);
            transactionDetail.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);

            transactionDetail.OrderBy.Add(
                Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId);

            transactionDetail.Items();

            return transactionDetail.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Valor.Denominacion> GetCurrentCurrencyDenominations()
        {
            Permaquim.Depositario.Business.Relations.Valor.Denominacion denominacion = new();
            denominacion.Where.Add(Permaquim.Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentCurrency.Id);
            denominacion.OrderBy.Add(Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.Unidades);

            return denominacion.Items();
        }

        public static List<Permaquim.Depositario.Entities.Relations.Valor.Denominacion> GetCurrencyDenominations(long currencyId)
        {
            Permaquim.Depositario.Business.Relations.Valor.Denominacion denominacion = new();
            denominacion.Where.Add(Permaquim.Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, currencyId);
            denominacion.OrderBy.Add(Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.Unidades);

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

                transaccionDetalle.OrderBy.Add(
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
        /// <summary>
        /// Verifica que exista un turno disponible para el depositario / sector
        /// El turno debe ser del dia de hoy y no estar cerrado
        /// </summary>
        /// <returns>Turno</returns>
        public static Permaquim.Depositario.Entities.Tables.Operacion.Turno GetTurnSchedule()
        {

            // Verifica que exista un turno disponible para el depositario / sector
            // El turno debe ser del dia de hoy y no estar cerrado
            _newTurn = null;
            _turnRelations.Where.Clear();
             _turnScheduleEntities.Where.Clear();
            _turnScheduleEntities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
                Depositario.sqlEnum.OperandEnum.IsNull, 0);
            _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.Equal, DateTime.Now.Date);


            _turnScheduleEntities.Items();


            if (_turnScheduleEntities.Result.Count == 0)
            {


                //Recupera el último Turno abierto
                _turnScheduleEntities.Where.Clear();
                _turnScheduleEntities.OrderBy.Clear();

                _turnScheduleEntities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                    Depositario.sqlEnum.OperandEnum.Equal, true);
                _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                _turnScheduleEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);

                _turnScheduleEntities.OrderBy.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Fecha,
                    Depositario.sqlEnum.DirEnum.DESC);
                _turnScheduleEntities.OrderBy.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Secuencia,
                    Depositario.sqlEnum.DirEnum.DESC);


                _turnScheduleEntities.Items();
                if (_turnScheduleEntities.Result.Count == 0)

                {

                    // No encuentro, entonces busco en Agenda turno si hay un turno disponible para
                    // hoy y para mi sector

 
                    _entitiesAgendaTurno.Where.Clear();
                    _entitiesAgendaTurno.OrderBy.Clear();

                    _entitiesAgendaTurno.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId,
                        Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
                    _entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha,
                        Depositario.sqlEnum.OperandEnum.LessThanOrEqual, DateTime.Now.Date);
                    _entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado,
                        Depositario.sqlEnum.OperandEnum.Equal, true);

                    _entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Id,
                        Depositario.sqlEnum.OperandEnum.NotIn, GetUsedTurns(false));

                    _entitiesAgendaTurno.OrderBy.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha,
                        Depositario.sqlEnum.DirEnum.ASC);
                    _entitiesAgendaTurno.OrderBy.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Secuencia,
                        Depositario.sqlEnum.DirEnum.ASC);


                    _entitiesAgendaTurno.Items();

                    if (_entitiesAgendaTurno.Result.Count == 0)
                    {
                        // No existen turnos dados de alta para el depositario,
                        // no se puede depositar.
                        _newTurn = null;
                        _currentTurn = null;
                    }
                    else
                    {
                        var availableTurn = _entitiesAgendaTurno.Result.FirstOrDefault();

                        _newTurn = _turnScheduleEntities.Add(new Permaquim.Depositario.Entities.Tables.Operacion.Turno()
                        {
                            CierreDiarioId = null,
                            DepositarioId = CurrentDepositary.Id,
                            Fecha = availableTurn.Fecha.Date,
                            FechaApertura = DateTime.Now,
                            FechaCierre = null,
                            FechaCreacion = DateTime.Now,
                            FechaModificacion = null,
                            Habilitado = true,
                            Observaciones = "Apertura automática.",
                            Secuencia = availableTurn.Secuencia,
                            SectorId = CurrentDepositary.SectorId.Id,
                            TurnoDepositarioId = availableTurn.Id,
                            UsuarioCreacion = CurrentUser == null ? 0 : CurrentUser.Id,
                            UsuarioModificacion = null,
                            CodigoTurno = CurrentDepositary.CodigoExterno + "-" + DateTime.Now.ToString("yyMMdd")
                        });

                        //_currentTurn = null;
                    }
                }
                else
                {
                    //Seteamos el ultimo turno abierto
                    _newTurn = _turnScheduleEntities.Result.FirstOrDefault();
                }
            }
            else
            {
                //Si existe turno para hoy y sin cerrar lo seteamos
                _newTurn = _turnScheduleEntities.Result.FirstOrDefault();
            }

            if (_newTurn != null)
            {
                _turnRelations.Items(_newTurn.Id);
                _currentTurn = _turnRelations.Result.FirstOrDefault();
            }


            return _newTurn;
        }

        public static int GetAvailableTurns()
        {
            List<Permaquim.Depositario.Entities.Tables.Turno.AgendaTurno> returnValue = new();

            List<long> usedTurns = GetUsedTurns();

            List<long> programmedTurns = GetProgrammedTurns();

            return programmedTurns.Count - usedTurns.Count;

        }

        public static int GetPreviousDaysTurns()
        {
            Permaquim.Depositario.Business.Tables.Operacion.Turno entitiesOperacionTurno = new();

            entitiesOperacionTurno.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entitiesOperacionTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.LessThan, DateTime.Now.Date);
            entitiesOperacionTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entitiesOperacionTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
                Depositario.sqlEnum.OperandEnum.IsNull, 0);

            entitiesOperacionTurno.OrderBy.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Secuencia,
                Depositario.sqlEnum.DirEnum.ASC);
            entitiesOperacionTurno.Items();


            return entitiesOperacionTurno.Result.Count;

        }

        private static List<long> GetUsedTurns(bool currentDay = true)
        {
            List<long> resultValue = new();

            
            _usedturnsEntities.Where.Clear();
            _usedturnsEntities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            _usedturnsEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            _usedturnsEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            _usedturnsEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.IsNotNull, 0);

            if (currentDay)
                _usedturnsEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Fecha,
                    Depositario.sqlEnum.OperandEnum.Equal, DateTime.Now.Date);

            _usedturnsEntities.Items();

            foreach (var item in _usedturnsEntities.Result)
            {
                resultValue.Add(item.TurnoDepositarioId);
            }

            return resultValue;

        }

        private static List<long> GetProgrammedTurns()
        {
            List<long> resultValue = new();

            Permaquim.Depositario.Business.Tables.Turno.AgendaTurno entitiesAgendaTurno = new();

            entitiesAgendaTurno.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.Equal, DateTime.Now.Date);
            entitiesAgendaTurno.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            entitiesAgendaTurno.OrderBy.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Secuencia,
                Depositario.sqlEnum.DirEnum.ASC);

            entitiesAgendaTurno.Items();

            foreach (var item in entitiesAgendaTurno.Result)
            {
                resultValue.Add(item.Id);
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
                    DepositarioId = CurrentTurn.DepositarioId.Id,
                    Fecha = CurrentTurn.Fecha,
                    FechaApertura = CurrentTurn.FechaApertura,
                    FechaCierre = DateTime.Now,
                    FechaCreacion = CurrentTurn.FechaCreacion,
                    Habilitado = CurrentTurn.Habilitado,
                    Observaciones = CurrentTurn.Observaciones,
                    SectorId = CurrentTurn.SectorId.Id,
                    Secuencia = CurrentTurn.Secuencia,
                    TurnoDepositarioId = CurrentTurn.TurnoDepositarioId.Id,
                    UsuarioCreacion = CurrentTurn.UsuarioCreacion.Id,
                    UsuarioModificacion = CurrentTurn.UsuarioModificacion.Id,
                    FechaModificacion = DateTime.Now,
                    CodigoTurno = CurrentTurn.CodigoTurno
                });

                if (IsLastTurn(CurrentTurn))
                {
                    ClosePendingDays();
                    ReportController.DailyClosingToPrint = CurrentDailyClosing;
                    if (ParameterController.PrintsDailyClosing)
                    {
                        for (int i = 0; i < ParameterController.PrintDailyClosingQuantity; i++)
                        {
                            if (CurrentDailyClosing != null)
                            {
                                ReportController.PrintReport(ReportTypeEnum.DailyClosing,
                                    DatabaseController.GetDailyClosingEnvelopeBagContentItems(CurrentDailyClosing.Id),
                                    DatabaseController.GetDailyClosingTransactions(CurrentDailyClosing.Id), i);
                            }
                        }
                    }
                }

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

        public static bool ClosePendingTurns()
        {
            bool returnValue = false;
            Permaquim.Depositario.Entities.Tables.Operacion.Turno refTurn = null;
            try
            {
             
                while (refTurn == null || refTurn.Fecha < DateTime.Today)
                {
                    refTurn = CloseCurrentTurn();
                }

  
                returnValue = true;

            }
            catch (Exception ex)
            {
                Permaquim.Depositario.Business.Tables.Auditoria.Log log = new();
                log.Add((long)LogTypeEnum.Information, 1, DateTime.Now, ex.Message, ex.StackTrace,
                    "Cambio de turnos abiertos", "DatabaseController.ClosePendingTurns",
                    CurrentUser.Id);
                returnValue = false;
            }

            return returnValue;
        }
    

        private static bool IsLastTurn(Permaquim.Depositario.Entities.Relations.Operacion.Turno turn)
        {
            bool returnValue = false;
            Permaquim.Depositario.Business.Tables.Turno.AgendaTurno entities = new();
            entities.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Where.Add(sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, Depositario.sqlEnum.OperandEnum.Equal, turn.Fecha);
            entities.Items();
            if (entities.Result.Count > 0)
            {
                returnValue = turn.Secuencia == entities.Result.Count;
            }

            return returnValue;
        }
        private static bool IsLastTurn(Permaquim.Depositario.Entities.Tables.Operacion.Turno turn)
        {
            bool returnValue = false;
            Permaquim.Depositario.Business.Tables.Turno.AgendaTurno entities = new();
            entities.Where.Add(Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Where.Add(sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, Depositario.sqlEnum.OperandEnum.Equal, turn.Fecha);
            entities.Items();
            if (entities.Result.Count > 0)
            {
                returnValue = turn.Secuencia == entities.Result.Count;
            }

            return returnValue;
        }
        public static Depositario.Entities.Tables.Operacion.CierreDiario ClosePendingDays()
        {
            Depositario.Business.Tables.Operacion.CierreDiario closingEntities = new();

            Depositario.Entities.Tables.Operacion.CierreDiario newClosing = null;

            var lastTurn = LastTurn;

            try
            {
                closingEntities.BeginTransaction();

                newClosing = closingEntities.Add(new Permaquim.Depositario.Entities.Tables.Operacion.CierreDiario()
                {
                    Fecha = lastTurn.Fecha, // Indica la fecha del cierre
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = null,
                    Nombre = CIERRE_DIARIO,
                    SesionId = CurrentSession.Id,
                    UsuarioCreacion = CurrentUser == null ? 0: CurrentUser.Id,
                    UsuarioModificacion = null,
                    DepositarioId = CurrentDepositary.Id,
                    CodigoCierre = CurrentDepositary.CodigoExterno + "-" + DateTime.Now.ToString("yyMMdd")
                });

                Depositario.Business.Tables.Operacion.Turno turnos = new(closingEntities);

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

                Depositario.Business.Tables.Operacion.Transaccion transacciones = new(closingEntities);

                transacciones.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);

                foreach (var item in transacciones.Items())
                {
                    item.CierreDiarioId = newClosing.Id;
                    item.FechaModificacion = DateTime.Now;
                    item.UsuarioModificacion = CurrentUser.Id;
                    transacciones.Update(item);
                }

                closingEntities.EndTransaction(true);
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                closingEntities.EndTransaction(false);
            }

            return newClosing;
        }
        public static Permaquim.Depositario.Entities.Relations.Valor.Moneda DefaultCurrency()
        {
            Permaquim.Depositario.Entities.Relations.Valor.Moneda returnValue = null;

            foreach (var item in DatabaseController.CurrentDepositary.SectorId.SucursalId.ListOf_RelacionMonedaSucursal_SucursalId)
            {
                if (item.EsDefault)
                {
                    returnValue = item.MonedaId;
                    break;
                }
            }
            return returnValue;
        }
        public static string GetApplicationParameterValue(string key)
        {
            string returnValue = string.Empty;
            try
            {

                Permaquim.Depositario.Business.Tables.Aplicacion.Configuracion entities = new();
                entities.Where.Add(Depositario.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave,
                    Depositario.sqlEnum.OperandEnum.Equal, key);
                entities.Items();
                if (entities.Result.Count > 0)
                    return entities.Result.FirstOrDefault().Valor;
            }
            catch (Exception)
            {

                returnValue = String.Empty;
            }

            return returnValue;
        }

        public static bool UserExpirationDateReached()
        {
            bool returnValue;

            var expirationDays = GetEnterpriseParameterValue("DIAS_EXPIRACION_USUARIO");
            if (CurrentUser.FechaExpiracion == null) // Super usuario
                returnValue = false;
            else
                returnValue = DateTime.Now >= CurrentUser.FechaExpiracion;

            return returnValue;
        }

        public static bool UserAllowedInSector()
        {
            bool returnValue;

            Permaquim.Depositario.Business.Tables.Seguridad.UsuarioSector entities = new();
            entities.Where.Add(Depositario.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.UsuarioId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.Habilitado,
           Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.SectorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.Id);
            entities.Items();

            return entities.Result.Count > 0;
        }

        public static string GetEnterpriseParameterValue(string key)
        {
            string returnValue = string.Empty;
            try
            {


                Permaquim.Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa entities = new();
                entities.Where.Add(Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Clave,
                    Depositario.sqlEnum.OperandEnum.Equal, key);
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId,
                   Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.SucursalId.EmpresaId.Id);
                entities.Items();
                if (entities.Result.Count > 0)
                    return entities.Result.FirstOrDefault().Valor;
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
            }

            return returnValue;

        }

        public static string GetDepositaryParameterValue(string key)
        {
            string returnValue = string.Empty;


            Permaquim.Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario typeEntities = new();
            typeEntities.Where.Add(Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.Clave,
                Depositario.sqlEnum.OperandEnum.Equal, key);
            typeEntities.Items();
            if (typeEntities.Result.Count > 0)
            {

                var typeEntity = typeEntities.Result.FirstOrDefault();

                Permaquim.Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entities = new();
                entities.Where.Add(Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId,
                    Depositario.sqlEnum.OperandEnum.Equal, typeEntity.Id);
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId,
                   Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
                entities.Items();
                if (entities.Result.Count > 0)
                    return entities.Result.FirstOrDefault().Valor;
            }

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

        public static bool CurrencyHasValueRelation
        {
            get
            {
                bool returnValue = false;

                Permaquim.Depositario.Business.Tables.Valor.RelacionMonedaTipoValor entities = new();

                entities.Where.Add(Depositario.Business.Tables.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId,
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
                    // Se consultan los roles que tiene el usuario
                    foreach (var usuarioRol in CurrentUser.ListOf_UsuarioRol_UsuarioId)
                    {
                        // Se obtiene el rol de la aplicación Desktop
                        if (usuarioRol.RolId.AplicacionId.Id == Global.Constants.APPLICATION_ID)
                        {
                            if (usuarioRol.Habilitado)
                            {
                                foreach (var relFuncion in usuarioRol.RolId.ListOf_RolFuncion_RolId.Where(x=> x.Habilitado == true))
                                {
                                    if (relFuncion.FuncionId.Habilitado && relFuncion.FuncionId.Id == functionId)
                                        return true;
                                }
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return returnValue;
            }
        }

        public static bool IsFuntionEnabled(long functionId, long userId)
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
                    // Se consultan los roles que tiene el usuario
                    foreach (var usuarioRol in CurrentUser.ListOf_UsuarioRol_UsuarioId)
                    {
                        // Se obtiene el rol de la aplicación Desktop
                        if (usuarioRol.RolId.AplicacionId.Id == Global.Constants.APPLICATION_ID)
                        {
                            if (usuarioRol.Habilitado)
                            {
                                foreach (var relFuncion in usuarioRol.RolId.ListOf_RolFuncion_RolId)
                                {
                                    if (relFuncion.FuncionId.Habilitado && relFuncion.FuncionId.Id == functionId)
                                        return true;
                                }
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return returnValue;
            }
        }

        public static bool IsFuntionEnabled(string functionName)
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
                    // Se consultan los roles que tiene el usuario
                    foreach (var usuarioRol in CurrentUser.ListOf_UsuarioRol_UsuarioId)
                    {
                        // Se obtiene el rol de la aplicación Desktop
                        if (usuarioRol.RolId.AplicacionId.Id == Global.Constants.APPLICATION_ID )
                        {
                            if (usuarioRol.Habilitado)
                            {
                                foreach (var relFuncion in usuarioRol.RolId.ListOf_RolFuncion_RolId)
                                {
                                    if (relFuncion.FuncionId.Habilitado && relFuncion.FuncionId.Nombre.Equals(functionName))
                                        return true;
                                }
                            }
                        }
                    }
                }
   
                return false;
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

        public static List<Permaquim.Depositario.Entities.Tables.Seguridad.Usuario> GetUserList(bool singleUser)
        {
            Permaquim.Depositario.Business.Tables.Seguridad.Usuario entities = new();

            entities.Where.Add(Depositario.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Seguridad.Usuario.ColumnEnum.EmpresaId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.SectorId.SucursalId.EmpresaId.Id);

            if(singleUser)
            {
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Seguridad.Usuario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.Id);
            }

            entities.Items();

            return entities.Result;
        }
        public static List<TurnSearcher> GetTurnList()
        {
            List<TurnSearcher> resultado = new();

            Depositario.Business.Relations.Turno.EsquemaTurno oEsquemaTurno = new();

            oEsquemaTurno.Items();

            if (oEsquemaTurno.Result.Count > 0)
            {
                foreach (var esquema in oEsquemaTurno.Result)
                {
                    foreach (var esquemaDetalle in esquema.ListOf_EsquemaDetalleTurno_EsquemaTurnoId)
                    {
                        TurnSearcher turnoComboReporte = new();
                        turnoComboReporte.NombreEsquema = esquema.Nombre;
                        turnoComboReporte.NombreEsquemaDetalle = esquemaDetalle.Nombre;
                        turnoComboReporte.TurnoEsquemaDetalleId = esquemaDetalle.Id;

                        resultado.Add(turnoComboReporte);
                    }
                }
            }

            return resultado;
        }

        public static bool SetLanguageId(long languageId)
        {
            Permaquim.Depositario.Business.Tables.Seguridad.Usuario entities = new();

            var user = entities.Items(CurrentUser.Id).FirstOrDefault();
            user.LenguajeId = languageId;
            return entities.Update(user) != 0;
        }

        public static void SetBlockingEvent(string message, EventTypeEnum tipoId, string value)
        {

            EventController.CreateEvent(tipoId, message, value);
        }
        public static void SetDepositaryStatus(bool initialize = false)
        {
            if (_depositaryStatusEntities == null)
                _depositaryStatusEntities = new();

            if (_depositaryStatus == null)
                _depositaryStatus = new();

            _depositaryStatus.Id = 0;
            _depositaryStatus.ContadoraA = DeviceController.CounterStatus;
            _depositaryStatus.ContadoraB = String.Empty;
            _depositaryStatus.Contenedor = DeviceController.ContainerStatus;
            _depositaryStatus.DepositarioId = CurrentDepositary.Id;
            _depositaryStatus.Fecha = DateTime.Now;
            _depositaryStatus.FueraDeServicio = DeviceController.IsOutOfService;
            _depositaryStatus.Impresora = DeviceController.PrinterStatus;
            _depositaryStatus.Observaciones = DeviceController.Observations;
            _depositaryStatus.Placa = DeviceController.IoBoardStatus;
            _depositaryStatus.Puerta = DeviceController.GateStatus;

            if(initialize)
                _depositaryStatusEntities.AddOrUpdate(_depositaryStatus);
            else
                _depositaryStatusEntities.Update(_depositaryStatus);
        }

        public static void CreateSession()
        {
            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesion = new();
            sesion.Add(CurrentDepositary.Id, DatabaseController.CurrentUser.Id, DateTime.Now, null, null);
        }
        public static float GetBagPercentaje()
        {
            float resultado = 0;
            Int64 cantidadMaxima = 0;
            Int64 cantidadUnidadesAcumuladas = 0;
            Depositario.Business.Relations.Operacion.Contenedor contenedor = new();
            contenedor.Where.Add(Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.Id, Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);

            contenedor.Items();

            if (contenedor.Result.Count > 0)
            {
                cantidadMaxima = contenedor.Result.FirstOrDefault().TipoId.Capacidad;
                Depositario.Business.Relations.Operacion.Transaccion transacciones = new();
                transacciones.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);
                transacciones.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, Depositario.sqlEnum.OperandEnum.Equal,
                    Global.Enumerations.OperationTypeEnum.BillDeposit);
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
        public static List<Depositario.Entities.Views.Reporte.Contenedores> GetBagHistoryItems(DateTime FechaAperturaDesde,
                                                                                               DateTime FechaAperturaHasta,
                                                                                               DateTime? FechaCierreDesde,
                                                                                               DateTime? FechaCierreHasta,
                                                                                               string Identificador,
                                                                                               bool incluirBolsaActual = true)
        {
            Depositario.Business.Views.Reporte.Contenedores entities = new();
            entities.Where.Add(Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.FechaApertura, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, FechaAperturaDesde);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.FechaApertura, Depositario.sqlEnum.OperandEnum.LessThanOrEqual, FechaAperturaHasta);
            if (FechaCierreDesde.HasValue)
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.FechaCierre, Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, FechaCierreDesde.Value);
            if (FechaCierreHasta.HasValue)
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.FechaCierre, Depositario.sqlEnum.OperandEnum.LessThanOrEqual, FechaCierreHasta.Value);
            if (Identificador != "")
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.Identificador, Depositario.sqlEnum.OperandEnum.Like, "%" + Identificador + "%");

            if (!incluirBolsaActual)
                entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Views.Reporte.Contenedores.ColumnEnum.ContenedorId, Depositario.sqlEnum.OperandEnum.NotEqual,
                    CurrentContainer.Id);
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
                        Depositario.sqlEnum.OperandEnum.IsNull, 0);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.MonedaId,
                        Depositario.sqlEnum.OperandEnum.Equal, currencyItem.Id);
                    transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                        Depositario.sqlEnum.OperandEnum.NotEqual, Global.Enumerations.OperationTypeEnum.ValueExtraction);

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

        public static ConnectionStatusEnum IsInitialized()
        {
            ConnectionStatusEnum returnValue = ConnectionStatusEnum.None;
            try
            {
                Permaquim.Depositario.Business.Tables.Sincronizacion.Ejecucion entity = new();
                entity.Where.Add(Depositario.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.EsPrimeraSincronizacion, sqlEnum.OperandEnum.Equal, true);
                entity.Where.Add(sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.Finalizada, sqlEnum.OperandEnum.Equal, true);
                entity.Items();

                returnValue = entity.Result.Count > 0 ? ConnectionStatusEnum.Connected : ConnectionStatusEnum.UnInitialized;
            }
            catch (Exception ex)
            {
                if(((System.Runtime.InteropServices.ExternalException)ex).ErrorCode  == -2146232060)
                    returnValue = ConnectionStatusEnum.Disconnected;
            }
            return returnValue;
        }

        public static List<BagContentItem> GetBillCurrentContainerContentItems(long monedaId = -1)
        {
            List<BagContentItem> returnValue = new(); // BagContentItem newBagContentItem = new();

            Permaquim.Depositario.Business.Tables.Valor.Moneda currencyEntities = new();
            currencyEntities.Where.Add(Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            if (monedaId != -1) // Todas las monedas
            {
                currencyEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Id,
                            Depositario.sqlEnum.OperandEnum.Equal, monedaId);
            }

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
                            newBagContentItem.Moneda = currencyItem.Codigo;
                            newBagContentItem.Denominacion = denominationItem.Nombre;
                            newBagContentItem.Total += (transactionDetalleItem.CantidadUnidades * denominationItem.Unidades);
                            newBagContentItem.FormattedTotal = currencyItem.Simbolo + " " + newBagContentItem.Total.ToString();
                        }
                    }

                    if (newBagContentItem.Total > 0)
                        returnValue.Add(newBagContentItem);
                }
            }
            return returnValue;
        }
        public static List<BagContentItem> GetEnvelopeCurrentContainerContentItems(Int64 CurrencyId)
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
               Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.MonedaId,
               Depositario.sqlEnum.OperandEnum.Equal, CurrencyId);

            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);


                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        var ret = returnValue.Find(x => x.Moneda.Equals(newBagContentItem.Moneda)
                        && x.Denominacion.Equals(newBagContentItem.Denominacion));
                        if (ret == null)
                            returnValue.Add(newBagContentItem);
                        else
                            ret.Cantidad += item.CantidadDeclarada;

                    }
                }

            }

            return returnValue;
        }

        public static List<BagContentItem> GetBillLastContainerContentItems(long monedaId = -1)
        {
            List<BagContentItem> returnValue = new(); // BagContentItem newBagContentItem = new();

            Permaquim.Depositario.Business.Tables.Valor.Moneda currencyEntities = new();
            currencyEntities.Where.Add(Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            if (monedaId != -1) // Todas las monedas
            {
                currencyEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Id,
                            Depositario.sqlEnum.OperandEnum.Equal, monedaId);
            }

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
                        Depositario.sqlEnum.OperandEnum.Equal, LastContainer.Id);
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
                            newBagContentItem.Moneda = currencyItem.Codigo;
                            newBagContentItem.Denominacion = denominationItem.Nombre;
                            newBagContentItem.Total += (transactionDetalleItem.CantidadUnidades * denominationItem.Unidades);
                            newBagContentItem.FormattedTotal = currencyItem.Simbolo + " " + newBagContentItem.Total.ToString();
                        }
                    }

                    if (newBagContentItem.Total > 0)
                        returnValue.Add(newBagContentItem);
                }
            }
            return returnValue;
        }

        public static List<BagContentItem> GetBillContainerContentItems(long containerId, long monedaId = -1)
        {
            List<BagContentItem> returnValue = new(); // BagContentItem newBagContentItem = new();

            Permaquim.Depositario.Business.Tables.Valor.Moneda currencyEntities = new();
            currencyEntities.Where.Add(Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            if (monedaId != -1) // Todas las monedas
            {
                currencyEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Tables.Valor.Moneda.ColumnEnum.Id,
                            Depositario.sqlEnum.OperandEnum.Equal, monedaId);
            }

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
                        Depositario.sqlEnum.OperandEnum.Equal, containerId);
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
                            newBagContentItem.Moneda = currencyItem.Codigo;
                            newBagContentItem.Denominacion = denominationItem.Nombre;
                            newBagContentItem.Total += (transactionDetalleItem.CantidadUnidades * denominationItem.Unidades);
                            newBagContentItem.FormattedTotal = currencyItem.Simbolo + " " + newBagContentItem.Total.ToString();
                        }
                    }

                    if (newBagContentItem.Total > 0)
                        returnValue.Add(newBagContentItem);
                }
            }
            return returnValue;
        }

        public static List<BagContentItem> GetEnvelopeLastContainerContentItems()
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, LastContainer.Id);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);

            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);


                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        var ret = returnValue.Find(x => x.Moneda.Equals(newBagContentItem.Moneda)
                        && x.Denominacion.Equals(newBagContentItem.Denominacion));
                        if (ret == null)
                            returnValue.Add(newBagContentItem);
                        else
                            ret.Cantidad += item.CantidadDeclarada;

                    }
                }

            }

            return returnValue;
        }

        public static List<BagContentItem> GetEnvelopeContainerContentItems(long containerId)
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, containerId);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);

            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);


                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        var ret = returnValue.Find(x => x.Moneda.Equals(newBagContentItem.Moneda)
                        && x.Denominacion.Equals(newBagContentItem.Denominacion));
                        if (ret == null)
                            returnValue.Add(newBagContentItem);
                        else
                            ret.Cantidad += item.CantidadDeclarada;

                    }
                }

            }

            return returnValue;
        }

        public static List<BagContentItem> GetDailyClosingEnvelopeBagContentItems(Int64 DailyClosingId)
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);
            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
               Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
               Depositario.sqlEnum.OperandEnum.Equal, DailyClosingId);


            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);

                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda =
                            transactionEnvelopeDetailItem.CodigoSobre.Length == 0 ? "S/C" : transactionEnvelopeDetailItem.CodigoSobre;
                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        var ret = returnValue.Find(x => x.Moneda.Equals(newBagContentItem.Moneda)
                           && x.Denominacion.Equals(newBagContentItem.Denominacion));
                        if (ret == null)
                            returnValue.Add(newBagContentItem);
                        else
                            ret.Cantidad += item.CantidadDeclarada;
                    }
                }


            }

            return returnValue;
        }

        public static List<BagContentItem> GetLastclosingDayEnvelopeBagContentItems()
        {
            List<BagContentItem> returnValue = new List<BagContentItem>();

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactionEntities = new();
            transactionEntities.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.ContenedorId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);

            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, OperationTypeEnum.EnvelopeDeposit);
            transactionEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
               Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
               Depositario.sqlEnum.OperandEnum.Equal, LastDailyClosing.Id);


            foreach (var transactionItem in transactionEntities.Items())
            {

                Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transactionEnvelopeEntities = new();
                transactionEnvelopeEntities.Where.Add(
                    Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, transactionItem.Id);

                foreach (var transactionEnvelopeDetailItem in transactionEnvelopeEntities.Items())
                {

                    foreach (var item in transactionEnvelopeDetailItem.ListOf_TransaccionSobreDetalle_SobreId)
                    {
                        BagContentItem newBagContentItem = new();

                        newBagContentItem.Moneda =
                            transactionEnvelopeDetailItem.CodigoSobre.Length == 0 ? "S/C" : transactionEnvelopeDetailItem.CodigoSobre;
                        newBagContentItem.Moneda = transactionEnvelopeDetailItem.TransaccionId.MonedaId.Nombre;

                        newBagContentItem.Cantidad = item.CantidadDeclarada;
                        newBagContentItem.Denominacion = item.RelacionMonedaTipoValorId.TipoValorId.Nombre;

                        returnValue.Add(newBagContentItem);
                    }
                }


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
        public static string GetBasicConfigurationMessage()
        {
            StringBuilder builder = new();

            if (GetCurrencies().Count == 0)
                builder.AppendLine(MultilanguangeController.GetText(MultiLanguageEnum.MONEDAS_SIN_ASOCIAR_EN_SUCURSAL));
            if (DatabaseController.CurrentDepositaryCounter.PollTime <= 0)
                builder.AppendLine(MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_DE_ENCUESTA_NO_PUEDE_SER_CERO));
            if (DatabaseController.CurrentDepositaryCounter.Sleeptime <= 0)
                builder.AppendLine(MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_DE_ESPERA_NO_PUEDE_SER_CERO));
            if (CurrentUser != null)
            {
                if (GetCurrentContainerOccupationPercentage() >= ParameterController.RedBagPercent)
                    builder.AppendLine(MultilanguangeController.GetText(MultiLanguageEnum.LIMITE_CONTENEDOR_ALCANZADO));
            }
            // Validar Configuracion de depositario

            return builder.ToString();
        }


        public static decimal GetCurrentContainerOccupationPercentage()
        {
            decimal resultado = 0;
            Int64 cantidadMaxima = 0;
            Int64 cantidadUnidadesAcumuladas = 0;
            Permaquim.Depositario.Business.Relations.Operacion.Contenedor contenedor = new();
            contenedor.Where.Add(Permaquim.Depositario.Business.Relations.Operacion.Contenedor.ColumnEnum.Id,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);

            contenedor.Items();

            if (contenedor.Result.Count > 0)
            {
                cantidadMaxima = contenedor.Result.FirstOrDefault().TipoId.Capacidad;
                Permaquim.Depositario.Business.Relations.Operacion.Transaccion transacciones = new();
                transacciones.Where.Add(Permaquim.Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId,
                    Permaquim.Depositario.sqlEnum.OperandEnum.Equal, CurrentContainer.Id);
                transacciones.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,
                    Permaquim.Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId,
                    Permaquim.Depositario.sqlEnum.OperandEnum.Equal, Global.Enumerations.OperationTypeEnum.BillDeposit);
                transacciones.Items();

                foreach (var transaccion in transacciones.Result)
                {
                    var transaccionDetalles = transaccion.ListOf_TransaccionDetalle_TransaccionId;
                    foreach (var transaccionDetalle in transaccionDetalles)
                    {
                        cantidadUnidadesAcumuladas += transaccionDetalle.CantidadUnidades;
                    }
                }
                resultado = (decimal)cantidadUnidadesAcumuladas * 100 / cantidadMaxima;
            }
            return resultado;
        }




        public static Depositario.Entities.Tables.Impresion.Ticket GetTicket(ReportTypeEnum reportType)
        {

            Depositario.Entities.Tables.Impresion.Ticket resultValue = null;

            Depositario.Business.Tables.Impresion.Ticket ticket = new();
            ticket.Where.Add(Depositario.Business.Tables.Impresion.Ticket.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, (int)reportType);
            ticket.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Impresion.Ticket.ColumnEnum.DepositarioModeloId,
                Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary.ModeloId.Id);
            ticket.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Impresion.Ticket.ColumnEnum.EmpresaId,
            Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary.SectorId.SucursalId.EmpresaId.Id);

            ticket.Items();
            if (ticket.Result.Count > 0)
            {
                resultValue = ticket.Result.FirstOrDefault();
            }
            return resultValue;
        }


        public static string CompareDepositaryTemplateConfigurations(Int64 DepositarioId)
        {
            string resultado = "";

            //Evaluamos si todas las configuraciones que estan habilitadas en el template dispuesto por la
            //Tabla Dispositivo.TipoConfiguracionDepositario estan en la tabla Dispositivo.ConfiguracionDepositario

            Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario oTipoConfiguracionDepositario = new();
            oTipoConfiguracionDepositario.Where.Add(Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, true);
            oTipoConfiguracionDepositario.Items();

            if (oTipoConfiguracionDepositario.Result.Count > 0)
            {
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new();

                foreach (var configuracionTemplate in oTipoConfiguracionDepositario.Result)
                {
                    configuracionDepositario.Where.Clear();
                    configuracionDepositario.Where.Add(Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId, sqlEnum.OperandEnum.Equal, DepositarioId);
                    configuracionDepositario.Where.Add(sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, configuracionTemplate.Id);
                    configuracionDepositario.Items();

                    //Si no se encuentra la configuracion indicamos el nombre de la misma.
                    if (configuracionDepositario.Result.Count == 0)
                        resultado += configuracionTemplate.Nombre + ", ";

                }
            }

            return resultado;
        }
        public static List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> GetDepositaryCurrencies(Int64 DepositarioId)
        {
            List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> resultado = new();

            Depositario.Business.Tables.Dispositivo.DepositarioMoneda oDepositarioMoneda = new();
            oDepositarioMoneda.Where.Add(Depositario.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, DepositarioId);
            oDepositarioMoneda.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);

            oDepositarioMoneda.Items();

            resultado = oDepositarioMoneda.Result;

            return resultado;
        }
        public static Depositario.Entities.Relations.Seguridad.Usuario GetUser(long id)
        {
            Depositario.Business.Relations.Seguridad.Usuario entity = new();
            return entity.Items(id).FirstOrDefault();
        }
        public static Depositario.Entities.Relations.Dispositivo.Depositario GetDepositary(long id)
        {
            Depositario.Business.Relations.Dispositivo.Depositario entity = new();
            return entity.Items(id).FirstOrDefault();
        }
        public static Depositario.Entities.Relations.Operacion.Transaccion GetTransaction(long id)
        {
            Depositario.Business.Relations.Operacion.Transaccion entity = new();
            return entity.Items(id).FirstOrDefault();
        }

        public static Depositario.Entities.Relations.Banca.Cuenta GetBankAccount(long id)
        {
            Depositario.Business.Relations.Banca.Cuenta entity = new();
            return entity.Items(id).FirstOrDefault();
        }
        public static Depositario.Entities.Relations.Valor.OrigenValor GetValueOrigin(long id)
        {
            Depositario.Business.Relations.Valor.OrigenValor entity = new();
            return entity.Items(id).FirstOrDefault();
        }
        public static Depositario.Entities.Relations.Valor.RelacionMonedaTipoValor GetCurrencyValueRelation(long id)
        {
            Depositario.Business.Relations.Valor.RelacionMonedaTipoValor entity = new();
            return entity.Items(id).FirstOrDefault();
        }
    }
}
