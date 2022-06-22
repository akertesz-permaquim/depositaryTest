using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class DatabaseController
    {
        /// <summary>
        /// Representa el usuario registrado en el Sistema
        /// </summary>
        public static Permaquim.Depositario.Entities.Relations.Seguridad.Usuario CurrentUser { get; private set; }

        public static Permaquim.Depositario.Entities.Tables.Operacion.Sesion CurrentSession { get; private set; }

        public static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario CurrentDepositary { 
            get
            {
                Permaquim.Depositario.Business.Relations.Dispositivo.Depositario entity = new();
                entity.Where.Add(Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual,0);
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
               Depositario.sqlEnum.OperandEnum.IsNull, null);
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
                usuarios.Where.Add(Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.NickName, Permaquim.Depositario.sqlEnum.OperandEnum.Equal, user);
                usuarios.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND,Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.Password, Permaquim.Depositario.sqlEnum.OperandEnum.Equal, password);
                usuarios.Where.Add(Permaquim.Depositario.sqlEnum.ConjunctionEnum.AND, Permaquim.Depositario.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, Permaquim.Depositario.sqlEnum.OperandEnum.Equal, true);
                usuarios.Items();
                if (usuarios.Result.Count > 0)
                {
                    usuario = usuarios.Result.FirstOrDefault();
                    CurrentUser = usuario;
                    
                    // Se genera una sesión
                    Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
                    CurrentSession = sesiones.Add(CurrentUser.Id, DateTime.Now, null, null);
                }
                
                return usuario;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                
                return usuario;
            }
 
        }

        public static void LogOff()
        {
            CurrentUser = null;
            _currentCurrency = new();
            Permaquim.Depositario.Business.Tables.Operacion.Sesion session = new();
            CurrentSession.FechaCierre = DateTime.Now;
            CurrentSession.EsCierreAutomatico = false;
            session.Update(CurrentSession);

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
            
            return currencies.Items(-1);





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


        public static Permaquim.Depositario.Entities.Tables.Operacion.Contenedor UpdateandCreateContainer(string bagIdentifier)
        {
            Permaquim.Depositario.Entities.Tables.Operacion.Contenedor returnValue = new();

            Permaquim.Depositario.Business.Tables.Operacion.Contenedor entities = new();

            var currentcontainer = entities.Items(CurrentContainer.Id).FirstOrDefault();
            currentcontainer.FechaCierre = DateTime.Now;

            // Primero actualiza la fecha de cierre de la bolsa actual
            entities.Update(currentcontainer);

            Permaquim.Depositario.Business.Tables.Operacion.TipoContenedor typesOfContainer = new();


            //Luego genera una nueva
            entities.Add(new Depositario.Entities.Tables.Operacion.Contenedor()
            {
                FechaApertura = DateTime.Now,
                FechaCierre = null,
                FechaCreacion = DateTime.Now,
                FechaModificacion = null,
                Habilitado = true,
                Identificador = bagIdentifier,
                Nombre = bagIdentifier,
                TipoId = typesOfContainer.Items().FirstOrDefault().Id,
                UsuarioCreacion = CurrentUser.Id,
                UsuarioModificacion = null

            });


            return returnValue;
        }


        public static List<Permaquim.Depositario.Entities.Relations.Operacion.Transaccion> GetOperationsHeaders()
        {

            Permaquim.Depositario.Business.Relations.Operacion.Transaccion transaccion = new();
            transaccion.OrderByParameter.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Id, 
                Depositario.sqlEnum.DirEnum.DESC);
            transaccion.Where.Add(Depositario.Business.Relations.Operacion.Transaccion.ColumnEnum.Fecha, 
                Depositario.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.UtcNow.Date);
            transaccion.Items();

            return transaccion.Result;

        }
        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionDetalle> GetOperationsDetails(long transactionId)
        {

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionDetalle transaccionDetalle = new();
            transaccionDetalle.OrderByParameter.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.Id,
                Depositario.sqlEnum.DirEnum.DESC);
            transaccionDetalle.Where.Add(Depositario.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);
            transaccionDetalle.Items();

            return transaccionDetalle.Result;

        }
        public static List<Permaquim.Depositario.Entities.Relations.Operacion.TransaccionSobreDetalle>
            GetenvelopeOperationsDetails(long transactionId)
        {
            Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobreDetalle transaccionDetalle = new();

            Permaquim.Depositario.Business.Relations.Operacion.TransaccionSobre transaccionsobre = new();
            transaccionsobre.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId,
                Depositario.sqlEnum.OperandEnum.Equal, transactionId);
            transaccionsobre.Items();
            if (transaccionsobre.Result.Count > 0) {

                transaccionDetalle.OrderByParameter.Add(Depositario.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);
                transaccionDetalle.Where.Add(Depositario.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId,
                    Depositario.sqlEnum.OperandEnum.Equal, transaccionsobre.Result.FirstOrDefault().Id);
                transaccionDetalle.Items();

            }
            return transaccionDetalle.Result;

        }

        public static Permaquim.Depositario.Entities.Relations.Operacion.Turno TurnClosing()
        {
            return null;
        }

        public static Permaquim.Depositario.Entities.Relations.Operacion.CierreDiario DailyClosing()
        {
            return null;
        }
        public static void AccountClosing()
        {
            
        }
    }
}
