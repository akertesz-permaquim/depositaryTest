using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class DatabaseController
    {
        /// <summary>
        /// Representa el usuario registrado en el Sistema
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Seguridad.Usuario CurrentUser { get; private set; }

        public static Permaquim.Depositario.Entities.Tables.Operacion.Sesion CurrentSession { get; private set; }

        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno CurrentTurn
        {
            get
            {
                Permaquim.Depositario.Business.Relations.Operacion.Turno entity = new();
                entity.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Operacion.Turno.ColumnEnum.FechaCierre,
                    Depositario.sqlEnum.OperandEnum.IsNull, 0);
                return entity.Items().FirstOrDefault();
            }
        }

        public static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario CurrentDepositary
        {
            get
            {
                Permaquim.Depositario.Business.Relations.Dispositivo.Depositario entity = new();
                entity.Where.Add(Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                return entity.Items().FirstOrDefault();
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
                return entity.Items().LastOrDefault();
            }
        }


        private static Permaquim.Depositario.Entities.Relations.Valor.Moneda _currentCurrency;

        public static Permaquim.Depositario.Entities.Relations.Valor.Moneda CurrentCurrency
        {
            get { return _currentCurrency; }
            set { _currentCurrency = value; }
        }

        private static Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion _currentOperation;

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


        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor CreateOrUpdateContainer(string bagIdentifier)
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

            Permaquim.Depositario.Business.Tables.Operacion.TipoContenedor typesOfContainer = new();

            if (bagIdentifier.Equals(string.Empty))
            {



                //Luego genera una nueva
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

            }
            else
            {
                entities.Update(new Depositario.Entities.Tables.Operacion.Contenedor()
                {
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
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, dateFrom);
            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, 
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha,
                Depositario.sqlEnum.OperandEnum.LessThanOrEqual, dateTo);
            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, 
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioId,
                Depositario.sqlEnum.OperandEnum.Equal, userId);
            transaction.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, 
                Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, turnId);
            transaction.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha);

            transaction.Items();

            return transaction.Result;

        }

        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetCurrentTurnOperationsHeaders()
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaccion = new();
            transaccion.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId,
                Depositario.sqlEnum.OperandEnum.Equal, CurrentTurn.Id);
            transaccion.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);

            transaccion.Items();

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
            Permaquim.Depositario.Entities.Tables.Operacion.Turno newTurn = new();

            Permaquim.Depositario.Business.Tables.Operacion.Turno entities = new();
            entities.Where.Add(Depositario.Business.Tables.Operacion.Turno.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.DepositarioId,
            Depositario.sqlEnum.OperandEnum.Equal, CurrentDepositary.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Operacion.Turno.ColumnEnum.FechaCierre,
            Depositario.sqlEnum.OperandEnum.IsNull, 0);
            entities.Items();

            if (entities.Result.Count == 0)
            {
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
                    Secuencia = 0,
                    SectorId = CurrentDepositary.SectorId.Id,
                    TurnoDepositarioId = CurrentDepositary.Id,
                    UsuarioCreacion = CurrentUser.Id,
                    UsuarioModificacion = null
                });
            }
            else
            {
                newTurn = entities.Result.FirstOrDefault();
            }


            return newTurn;
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
                    CierreDiarioId = CurrentTurn.CierreDiarioId.Id,
                    DepositarioId = CurrentTurn.DepositarioId.Id,
                    Fecha = CurrentTurn.Fecha,
                    FechaApertura = CurrentTurn.FechaApertura,
                    FechaCierre = DateTime.Now,
                    FechaCreacion = CurrentTurn.FechaCreacion,
                    FechaModificacion = CurrentTurn.FechaModificacion,
                    Habilitado = CurrentTurn.Habilitado,
                    Id = CurrentTurn.Id,
                    Observaciones = CurrentTurn.Observaciones,
                    SectorId = CurrentTurn.SectorId,
                    Secuencia = CurrentTurn.Secuencia,
                    TurnoDepositarioId = CurrentTurn.TurnoDepositarioId.Id,
                    UsuarioCreacion = CurrentTurn.UsuarioCreacion.Id,
                    UsuarioModificacion = CurrentTurn.UsuarioModificacion.Id
                      
                });

                
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
                    Secuencia = 0,
                    SectorId = CurrentDepositary.SectorId.Id,
                    TurnoDepositarioId = CurrentDepositary.Id,
                    UsuarioCreacion = CurrentUser.Id,
                    UsuarioModificacion = null
                });


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

        public static Permaquim.Depositario.Entities.Tables.Operacion.CierreDiario CloseCurrentDay()
        {
            Permaquim.Depositario.Business.Tables.Operacion.CierreDiario entities = new();

            Permaquim.Depositario.Entities.Tables.Operacion.CierreDiario
            newClosing = entities.Add(new Permaquim.Depositario.Entities.Tables.Operacion.CierreDiario()
            {
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = null,
                Nombre = "Cierre diario",
                SesionId = CurrentSession.Id,
                UsuarioCreacion = CurrentUser.Id,
                UsuarioModificacion = null
            });

            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transacions = new();
            transacions.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.CierreDiarioId,
                Depositario.sqlEnum.OperandEnum.Equal, 0);
            transacions.Items();

            foreach (var item in transacions.Result)
            {
                item.CierreDiarioId = newClosing.Id;
                transacions.Update(item);
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

        public static bool IsFuntionEnabled(long functionId)
        {
            bool returnValue = false;

            Permaquim.Depositario.Business.Tables.Seguridad.UsuarioRol usuarioRolEntities = new();
            usuarioRolEntities.Where.Add(Depositario.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.UsuarioId,
                 Depositario.sqlEnum.OperandEnum.Equal, CurrentUser.Id);
            usuarioRolEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.AplicacionId,
                Depositario.sqlEnum.OperandEnum.Equal, 1);

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

            return returnValue;
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
    }
}
