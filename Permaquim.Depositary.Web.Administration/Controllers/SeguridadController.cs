using System.Security.Cryptography;
using System.Text;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class SeguridadController
    {
        public static Depositary.Entities.Tables.Seguridad.Usuario? LoguearUsuario(string pUsername, string pPassword)
        {
            Depositary.Entities.Tables.Seguridad.Usuario? resultado = new();
            Depositary.Business.Tables.Seguridad.Usuario oTable = new Depositary.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                resultado = oTable.Result.FirstOrDefault();
                //Verificamos que el password coincida
                if (oTable.Result.FirstOrDefault().Password == Cryptography.Hash(pPassword))
                {
                    //Registramos fecha de ultimo login y reseteamos cantidad de logueos incorrectos
                    resultado.CantidadLogueosIncorrectos = 0;
                    resultado.FechaUltimoLogin = DateTime.Now;
                    oTable.Update(resultado);
                }
                else
                {
                    //Incrementamos la cantidad de logueos incorrectos
                    resultado.CantidadLogueosIncorrectos = resultado.CantidadLogueosIncorrectos + 1;

                    //Obtenemos el parametro (si existe) de cantidad maxima de logueos erroneos
                    int cantidadMaximaLogueosErroneos = ObtenerCantidadMaximaLogueosIncorrectos(resultado.EmpresaId);

                    if (resultado.CantidadLogueosIncorrectos >= cantidadMaximaLogueosErroneos)
                    {
                        //Si llego a la cantidad de logueos incorrectos de tope lo bloqueamos.
                        resultado.Bloqueado = true;
                    }

                    oTable.Update(resultado);
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
            Depositary.Business.Relations.Seguridad.Rol oRol = new();
            oRol.Where.Add(Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, true);
            oRol.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.AplicacionId, Depositary.sqlEnum.OperandEnum.Equal, SeguridadEntities.Aplicacion.AdministradorWeb);

            oRol.Items();

            //Si no hay roles para la aplicacion web devuelvo nada.
            if (oRol.Result.Count > 0)
            {
                foreach (var rol in oRol.Result)
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
            Depositary.Business.Relations.Seguridad.RolFuncion oRolFuncion = new();
            oRolFuncion.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oRolFuncion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, Depositary.sqlEnum.OperandEnum.Equal, pRolId);

            oRolFuncion.Items();

            if (oRolFuncion.Result.Count > 0)
            {
                foreach (var rolfuncion in oRolFuncion.Result)
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
            return resultado;
        }

        public static List<SeguridadEntities.FuncionRol> ObtenerFuncionesPorRol(Int64 pRolId)
        {
            List<SeguridadEntities.FuncionRol> resultado = new();

            Depositary.Business.Relations.Seguridad.RolFuncion oRolFuncion = new();
            oRolFuncion.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oRolFuncion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, Depositary.sqlEnum.OperandEnum.Equal, pRolId);

            oRolFuncion.Items();

            if (oRolFuncion.Result.Count > 0)
            {
                foreach (var rolfuncion in oRolFuncion.Result)
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
    }
}
