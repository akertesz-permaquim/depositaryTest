using System.Security.Cryptography;
using System.Text;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class SeguridadController
    {
        private static Depositary.Business.Tables.Seguridad.Usuario _bTablesUsuario = new();
        private static Depositary.Business.Relations.Seguridad.Rol _bRelationsRol = new();
        private static Depositary.Business.Relations.Seguridad.RolFuncion _bRelationsRolFuncion = new();
        private static Depositary.Business.Relations.Seguridad.Menu _bRelationsMenu = new();

        public static Depositary.Entities.Tables.Seguridad.Usuario? LoguearUsuario(string pUsername, string pPassword)
        {
            Depositary.Entities.Tables.Seguridad.Usuario? resultado = new();

            _bTablesUsuario.Where.Clear();
            _bTablesUsuario.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, pUsername);
            _bTablesUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            _bTablesUsuario.Items();

            if (_bTablesUsuario.Result.Count > 0)
            {
                resultado = _bTablesUsuario.Result.FirstOrDefault();
                //Verificamos que el password coincida
                if (_bTablesUsuario.Result.FirstOrDefault().Password == Cryptography.Hash(pPassword))
                {
                    //Registramos fecha de ultimo login y reseteamos cantidad de logueos incorrectos
                    resultado.CantidadLogueosIncorrectos = 0;
                    resultado.FechaUltimoLogin = DateTime.Now;
                    _bTablesUsuario.Update(resultado);
                }
                else
                {
                    //Incrementamos la cantidad de logueos incorrectos
                    resultado.CantidadLogueosIncorrectos = resultado.CantidadLogueosIncorrectos + 1;

                    //Obtenemos el parametro (si existe) de cantidad maxima de logueos erroneos
                    int cantidadMaximaLogueosErroneos = ObtenerCantidadMaximaLogueosIncorrectos(resultado.EmpresaId);

                    if (resultado.CantidadLogueosIncorrectos >= cantidadMaximaLogueosErroneos && resultado.NickName != "su")
                    {
                        //Si llego a la cantidad de logueos incorrectos de tope lo bloqueamos (Siempre y cuando no sea el superusuario).
                        resultado.Bloqueado = true;
                    }

                    _bTablesUsuario.Update(resultado);
                }
                return resultado;
            }
            else
                return null;
        }

        public static int ObtenerCantidadMaximaLogueosIncorrectos(Int64 pEmpresaId)
        {
            string valorParametroMaxLogueosErroneos = AplicacionController.ObtenerConfiguracionEmpresa("CANTIDAD_MAXIMA_LOGUEOS_ERRONEOS", pEmpresaId);
            int cantidadMaximaLogueosErroneos;

            if (int.TryParse(valorParametroMaxLogueosErroneos, out cantidadMaximaLogueosErroneos))
            {
                return cantidadMaximaLogueosErroneos;
            }

            return 5; //Si no se encontro configuracion devolvemos este valor por defecto.
        }

        public static string ModificarPasswordUsuario(string pUsername, string pNewPassword)
        {
            string resultado = "";

            Depositary.Business.Tables.Seguridad.Usuario oTable = new Depositary.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                Depositary.Entities.Tables.Seguridad.Usuario oUsuario = new();
                oUsuario = oTable.Result.FirstOrDefault();
                //Actualizamos la fecha de expiracion si es que tenia una.
                if (oUsuario.FechaExpiracion.HasValue)
                    oUsuario.FechaExpiracion = ObtenerFechaExpiracion(oUsuario.EmpresaId);
                oUsuario.Password = Cryptography.Hash(pNewPassword);
                oUsuario.DebeCambiarPassword = false;
                oUsuario.FechaModificacion = DateTime.Now;
                try
                {
                    oTable.Update(oUsuario);
                }
                catch (Exception ex)
                {
                    resultado = ex.Message;
                }

            }

            return resultado;
        }

        public static string ReiniciarPasswordUsuario(string pUsername, List<Entities.TextoLenguaje> dataLenguaje)
        {
            string resultado = "";

            Depositary.Business.Tables.Seguridad.Usuario oTable = new Depositary.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                Depositary.Entities.Tables.Seguridad.Usuario oUsuario = new();
                oUsuario = oTable.Result.FirstOrDefault();
                //Actualizamos la fecha de expiracion si es que tenia una.
                if (oUsuario.FechaExpiracion.HasValue)
                    oUsuario.FechaExpiracion = ObtenerFechaExpiracion(oUsuario.EmpresaId);

                //Reiniciamos la password con el patron de primera letra nombre + primera letra apellido + documento.
                string password = oUsuario.Nombre.Substring(0, 1) + oUsuario.Apellido.Substring(0, 1) + oUsuario.Documento;
                oUsuario.Password = Cryptography.Hash(password);
                oUsuario.DebeCambiarPassword = false;
                try
                {
                    oTable.Update(oUsuario);
                }
                catch (Exception ex)
                {
                    resultado = ex.Message;
                }

            }
            else
            {
                resultado = MultilenguajeController.ObtenerTextoPorClave("ERROR_REINICIO_PASSWORD", dataLenguaje);
            }

            return resultado;
        }

        public static DateTime ObtenerFechaExpiracion(Int64 pEmpresaId)
        {
            //Por defecto la fecha de expiracion es dentro de 30 dias si es que no se definio por parametro.
            DateTime resultado = DateTime.Now.AddDays(30);
            string diasExpiracionParametro = "";
            diasExpiracionParametro = AplicacionController.ObtenerConfiguracionEmpresa("DIAS_EXPIRACION_USUARIO", pEmpresaId);
            if (diasExpiracionParametro != "")
            {
                int diasExpiracion;
                if (int.TryParse(diasExpiracionParametro, out diasExpiracion))
                {
                    resultado = DateTime.Now.AddDays(diasExpiracion);
                }
            }

            return resultado;
        }

        public static Depositary.Entities.Tables.Seguridad.Rol? ObtenerRolesPorUsuario(Int64 pUsuarioId)
        {
            Depositary.Entities.Tables.Seguridad.Rol? resultado = null;
            _bRelationsRol.Where.Clear();
            _bRelationsRol.Where.Add(Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, true);
            _bRelationsRol.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.AplicacionId, Depositary.sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);

            _bRelationsRol.Items();

            //Si no hay roles para la aplicacion web devuelvo nada.
            if (_bRelationsRol.Result.Count > 0)
            {
                foreach (var rol in _bRelationsRol.Result)
                {
                    var rolUsuario = rol.ListOf_UsuarioRol_RolId.FirstOrDefault(x => x._UsuarioId == pUsuarioId);
                    if (rolUsuario != null)
                    {
                        resultado = new();
                        resultado.Id = rol.Id;
                        resultado.DependeDe = rol._DependeDe;
                        resultado.Descripcion = rol.Descripcion;
                        resultado.FechaCreacion = rol.FechaCreacion;
                        resultado.FechaModificacion = rol.FechaModificacion;
                        resultado.Nombre = rol.Nombre;
                        resultado.Habilitado = rol.Habilitado;
                        resultado.UsuarioCreacion = rol._UsuarioCreacion;
                        resultado.UsuarioModificacion = rol._UsuarioModificacion;
                    }
                }
            }

            return resultado;
        }

        public static List<SeguridadEntities.Menu> ObtenerMenuesPorRol(Int64 pRolId)
        {
            List<SeguridadEntities.Menu> resultado = new();

            //Obtengo las funciones a las que puede acceder el rol.
            _bRelationsRolFuncion.Where.Clear();
            _bRelationsRolFuncion.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            _bRelationsRolFuncion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, Depositary.sqlEnum.OperandEnum.Equal, pRolId);

            _bRelationsRolFuncion.Items();

            if (_bRelationsRolFuncion.Result.Count > 0)
            {
                foreach (var rolfuncion in _bRelationsRolFuncion.Result)
                {
                    var funcion = rolfuncion.FuncionId;
                    foreach (var menuAccesible in funcion.ListOf_Menu_FuncionId.Where(x => x.Habilitado == true))
                    {
                        SeguridadEntities.Menu menu = new();
                        menu.MenuId = menuAccesible.Id;
                        menu.DependeDe = menuAccesible._DependeDe == 0 ? null : menuAccesible._DependeDe;
                        menu.MenuDescripcion = menuAccesible.Descripcion;
                        menu.MenuNombre = menuAccesible.Nombre;
                        menu.TipoMenuId = menuAccesible._TipoId;
                        menu.Imagen = menuAccesible.Imagen;
                        menu.Referencia = funcion.Referencia;

                        resultado.Add(menu);
                    }
                }
            }

            if (resultado.Count > 0)
            {
                //Verifico cuantos menues dependen de otros y si no estan en la lista los agrego.
                var menuesDependientes = resultado.Where(x => x.DependeDe != null).ToList();

                if (menuesDependientes.Count > 0)
                {
                    foreach (var menuDependiente in menuesDependientes)
                    {
                        if (!resultado.Exists(x => x.MenuId == menuDependiente.DependeDe.Value))
                        {
                            _bRelationsMenu.Where.Clear();
                            _bRelationsMenu.Where.Add(Business.Relations.Seguridad.Menu.ColumnEnum.Id, sqlEnum.OperandEnum.Equal, menuDependiente.DependeDe.Value);
                            _bRelationsMenu.Items();

                            if (_bRelationsMenu.Result.Count > 0)
                            {
                                var menuPadre = _bRelationsMenu.Result.FirstOrDefault();

                                SeguridadEntities.Menu menu = new();
                                menu.MenuId = menuPadre.Id;
                                menu.DependeDe = menuPadre._DependeDe == 0 ? null : menuPadre._DependeDe;
                                menu.MenuDescripcion = menuPadre.Descripcion;
                                menu.MenuNombre = menuPadre.Nombre;
                                menu.TipoMenuId = menuPadre._TipoId;
                                menu.Imagen = menuPadre.Imagen;
                                menu.Referencia = menuPadre.FuncionId.Referencia;

                                //Si este nuevo menu tiene un padre lo agrego a la lista asi se lo busca despues.
                                if (menu.DependeDe.HasValue)
                                {
                                    menuesDependientes.Add(menu);
                                }

                                resultado.Add(menu);
                            }
                        }
                    }
                }
            }

            return resultado;
        }



        public static List<SeguridadEntities.FuncionRol> ObtenerFuncionesPorRol(Int64 pRolId)
        {
            List<SeguridadEntities.FuncionRol> resultado = new();

            _bRelationsRolFuncion.Where.Clear();
            _bRelationsRolFuncion.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            _bRelationsRolFuncion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, Depositary.sqlEnum.OperandEnum.Equal, pRolId);

            _bRelationsRolFuncion.Items();

            if (_bRelationsRolFuncion.Result.Count > 0)
            {
                foreach (var rolfuncion in _bRelationsRolFuncion.Result)
                {
                    var funcion = rolfuncion.FuncionId;
                    if (funcion != null)
                    {
                        SeguridadEntities.FuncionRol funcionRol = new();
                        funcionRol.FuncionId = funcion.Id;
                        funcionRol.RolId = rolfuncion._RolId;
                        funcionRol.FuncionNombre = funcion.Nombre;
                        funcionRol.PuedeAgregar = rolfuncion.PuedeAgregar;
                        funcionRol.PuedeModificar = rolfuncion.PuedeModificar;
                        funcionRol.PuedeVisualizar = rolfuncion.PuedeVisualizar;
                        funcionRol.PuedeEliminar = rolfuncion.PuedeEliminar;

                        resultado.Add(funcionRol);
                    }
                }
            }

            return resultado;
        }

        public static Depositary.Entities.Tables.Seguridad.Usuario? ObtenerUsuarioPorMail(string pMail)
        {
            Depositary.Entities.Tables.Seguridad.Usuario? resultado = null;

            Depositary.Business.Tables.Seguridad.Usuario oUsuario = new();
            oUsuario.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Mail, Depositary.sqlEnum.OperandEnum.Equal, pMail);

            oUsuario.Items();

            if (oUsuario.Result.Count > 0)
            {
                resultado = oUsuario.Result.FirstOrDefault();
            }

            return resultado;
        }

        public static bool VerificarPermisoFuncion(string pFuncionNombre, List<SeguridadEntities.FuncionRol> pDataFunciones, string pFuncionAccion)
        {
            bool resultado = false;
            object? variable = null;

            if (pDataFunciones != null)
            {
                if (pDataFunciones.Count > 0)
                {
                    var item = pDataFunciones.FirstOrDefault(x => x.FuncionNombre == pFuncionNombre);

                    if (item != null)
                    {
                        bool valorPermiso;
                        var propiedadPermiso = item.GetType().GetProperty(pFuncionAccion);
                        if (propiedadPermiso != null)
                        {
                            try
                            {
                                valorPermiso = (bool)propiedadPermiso.GetValue(item, null);
                                resultado = valorPermiso;
                            }
                            catch (Exception ex)
                            {
                                resultado = false;
                                //throw (ex);
                            }
                        }
                    }
                }
            }

            return resultado;
        }

    }

    public static class Cryptography
    {
        /// <summary>
        /// Metodo de hasheo de una cadena de caracteres alfanumericos con MD5
        /// </summary>
        /// <param name="Source">La cadena de caracteres</param>
        /// <returns>Un array de bytes con el hash</returns>
        internal static String Hash(String source)
        {
            byte[] _data = System.Text.UTF8Encoding.ASCII.GetBytes(source);
            MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
            byte[] _hashbyte = _md5.ComputeHash(_data);
            return BitConverter.ToString(_hashbyte);
        }

        internal static string Encrypt(string textToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(textToEncrypt))
                throw new ArgumentException("The text must have valid value.", nameof(textToEncrypt));

            var buffer = Encoding.UTF8.GetBytes(textToEncrypt);
            var hash = SHA512.Create();
            var aesKey = new byte[24];
            Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using (var aes = Aes.Create())
            {
                if (aes == null)
                    throw new ArgumentException("Parameter must not be null.", nameof(aes));

                aes.Key = aesKey;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(buffer))
                    {
                        plainStream.CopyTo(aesStream);
                    }

                    var result = resultStream.ToArray();
                    var combined = new byte[aes.IV.Length + result.Length];
                    Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                    Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

                    return Convert.ToBase64String(combined);
                }
            }
        }
    }
}
