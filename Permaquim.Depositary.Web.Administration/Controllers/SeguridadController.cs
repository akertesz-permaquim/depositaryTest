using System.Security.Cryptography;
using System.Text;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class SeguridadController
    {
        public static DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario? LoguearUsuario(string pUsername, string pPassword)
        {
            DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario? resultado = new();
            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oTable = new DepositarioAdminWeb.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

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
                    string valorParametroMaxLogueosErroneos = AplicacionController.ObtenerConfiguracion("CANTIDAD_MAXIMA_LOGUEOS_ERRONEOS");
                    int cantidadMaximaLogueosErroneos;

                    if (int.TryParse(valorParametroMaxLogueosErroneos, out cantidadMaximaLogueosErroneos))
                    {
                        if (resultado.CantidadLogueosIncorrectos >= cantidadMaximaLogueosErroneos)
                        {
                            //Si llego a la cantidad de logueos incorrectos de tope lo bloqueamos.
                            resultado.Bloqueado = true;
                        }
                    }

                    oTable.Update(resultado);
                }
                return resultado;
            }
            else
                return null;
        }

        public static string ModificarPasswordUsuario(string pUsername, string pNewPassword)
        {
            string resultado = "";

            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oTable = new DepositarioAdminWeb.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario oUsuario = new();
                oUsuario = oTable.Result.FirstOrDefault();
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

        public static DepositarioAdminWeb.Entities.Tables.Seguridad.Rol? ObtenerRolesPorUsuario(Int64 pUsuarioId)
        {
            DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol oUsuarioRol = new();

            oUsuarioRol.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsuarioId);
            oUsuarioRol.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, 2);
            oUsuarioRol.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oUsuarioRol.Items();

            if (oUsuarioRol.Result.Count > 0)
            {
                DepositarioAdminWeb.Entities.Tables.Seguridad.Rol resultado = new();
                var rol = oUsuarioRol.Result.FirstOrDefault().RolId;
                resultado.Id = rol.Id;
                resultado.DependeDe = rol._DependeDe;
                resultado.Descripcion = rol.Descripcion;
                resultado.FechaCreacion = rol.FechaCreacion;
                resultado.FechaModificacion = rol.FechaModificacion;
                resultado.Nombre = rol.Nombre;
                resultado.Habilitado = rol.Habilitado;
                resultado.UsuarioCreacion = rol._UsuarioCreacion;
                resultado.UsuarioModificacion = rol._UsuarioModificacion;
                return resultado;
            }
            else
                return null;

        }
        //public static List<Entities.FuncionMenu> ObtenerFuncionesMenues(Int64 pRolId)
        //{
        //    List<Entities.FuncionMenu> resultado = new();

        //    DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion oRolFuncion = new();
        //    oRolFuncion.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
        //    oRolFuncion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pRolId);

        //    oRolFuncion.Items();

        //    if (oRolFuncion.Result.Count > 0)
        //    {
        //        foreach (var rolfuncion in oRolFuncion.Result)
        //        {
        //            var funcion = rolfuncion.FuncionId;

        //            foreach (var menu in funcion.ListOf_Menu_FuncionId)
        //            {
        //                Entities.FuncionMenu funcionMenu = new();
        //                funcionMenu.PuedeModificar = rolfuncion.PuedeModificar;
        //                funcionMenu.PuedeAgregar = rolfuncion.PuedeAgregar;
        //                funcionMenu.PuedeEliminar = rolfuncion.PuedeEliminar;
        //                funcionMenu.PuedeVisualizar = rolfuncion.PuedeVisualizar;
        //                funcionMenu.FuncionId = funcion.Id;
        //                funcionMenu.FuncionNombre = funcion.Nombre;
        //                funcionMenu.DependeDe = menu._DependeDe == 0 ? null : menu._DependeDe;
        //                funcionMenu.Referencia = funcion.Referencia;
        //                funcionMenu.MenuNombre = menu.Nombre;
        //                funcionMenu.MenuId = menu.Id;

        //                resultado.Add(funcionMenu);
        //            }
        //        }
        //    }

        //    return resultado;

        //}
        public static List<SeguridadEntities.Menu> ObtenerMenuesPorRol(Int64 pRolId)
        {
            List<SeguridadEntities.Menu> resultado = new();

            //Obtengo las funciones a las que puede acceder el rol.
            DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion oRolFuncion = new();
            oRolFuncion.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oRolFuncion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pRolId);

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

            DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion oRolFuncion = new();
            oRolFuncion.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oRolFuncion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pRolId);

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

        //public static bool VerificarPermisoMenu(string pMenu, List<Entities.FuncionMenu> pDataFuncionesMenues)
        //{
        //    bool resultado = false;

        //    if (pDataFuncionesMenues.Count > 0)
        //    {
        //        if (pDataFuncionesMenues.Exists(x => x.MenuNombre == pMenu))
        //            resultado = true;
        //    }

        //    return resultado;
        //}

        //public static bool VerificarRolFuncion(string pMenu, List<Entities.FuncionMenu> pDataFuncionesMenues, string pAccion)
        //{
        //    bool resultado = false;
        //    object? variable = null;

        //    if (pDataFuncionesMenues != null)
        //    {
        //        if (pDataFuncionesMenues.Count > 0)
        //        {
        //            var item = pDataFuncionesMenues.FirstOrDefault(x => x.MenuNombre == pMenu);

        //            if (item != null)
        //            {
        //                bool valorPermiso;
        //                var propiedadPermiso = item.GetType().GetProperty(pAccion);
        //                if (propiedadPermiso != null)
        //                {
        //                    try
        //                    {
        //                        valorPermiso = (bool)propiedadPermiso.GetValue(item, null);
        //                        resultado = valorPermiso;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        resultado = false;
        //                        //throw (ex);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return resultado;
        //}

        public static List<SeguridadEntities.Usuario> ObtenerUsuarios(bool obtenerSoloHabilitados = true)
        {
            List<SeguridadEntities.Usuario> resultado = new();

            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oUsuario = new();
            if (obtenerSoloHabilitados)
                oUsuario.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oUsuario.Items();

            if (oUsuario.Result.Count > 0)
            {
                foreach (var usuario in oUsuario.Result)
                {
                    SeguridadEntities.Usuario usuarioEntitie = new();
                    usuarioEntitie.UsuarioId = usuario.Id;
                    usuarioEntitie.Nickname = usuario.NickName;
                    usuarioEntitie.UsuarioNombre = usuario.Nombre;
                    usuarioEntitie.UsuarioApellido = usuario.Apellido;

                    resultado.Add(usuarioEntitie);
                }
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
