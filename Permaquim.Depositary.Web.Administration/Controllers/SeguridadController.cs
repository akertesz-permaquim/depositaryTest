namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class SeguridadController
    {
        public static DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario? ObtenerUsuario(string pUsername, string pPassword)
        {
            DepositarioAdminWeb.Entities.Tables.Seguridad.Usuario? resultado = new();
            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oTable = new DepositarioAdminWeb.Business.Tables.Seguridad.Usuario();
            oTable.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsername);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Password, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pPassword);
            oTable.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oTable.Items();

            if (oTable.Result.Count > 0)
            {
                resultado = oTable.Result.FirstOrDefault();
                return resultado;
            }
            else
                return null;
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

        public static List<Entities.FuncionMenu> ObtenerFuncionesMenues(Int64 pRolId)
        {
            List<Entities.FuncionMenu> resultado = new();

            DepositarioAdminWeb.Business.Tables.Seguridad.RolFuncion oRolFuncion = new();
            oRolFuncion.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.RolFuncion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oRolFuncion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.RolFuncion.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pRolId);

            oRolFuncion.Items();

            if (oRolFuncion.Result.Count > 0)
            {
                foreach (var rolfuncion in oRolFuncion.Result)
                {
                    //var funcion = rolfuncion.FuncionId;

                    DepositarioAdminWeb.Business.Tables.Seguridad.Funcion oFuncion = new();
                    oFuncion.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Funcion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                    oFuncion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Funcion.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, rolfuncion.FuncionId);

                    oFuncion.Items();

                    if (oFuncion.Result.Count > 0)
                    {
                        foreach (var funcion in oFuncion.Result)
                        {
                            DepositarioAdminWeb.Business.Tables.Seguridad.Menu oMenu = new();
                            oMenu.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Menu.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                            oMenu.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Menu.ColumnEnum.FuncionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, funcion.Id);

                            oMenu.Items();

                            if (oMenu.Result.Count > 0)
                            {
                                foreach (var menu in oMenu.Result)
                                {
                                    Entities.FuncionMenu funcionMenu = new();
                                    funcionMenu.PuedeModificar = rolfuncion.PuedeModificar;
                                    funcionMenu.PuedeAgregar = rolfuncion.PuedeAgregar;
                                    funcionMenu.PuedeEliminar = rolfuncion.PuedeEliminar;
                                    funcionMenu.PuedeVisualizar = rolfuncion.PuedeVisualizar;
                                    funcionMenu.FuncionId = funcion.Id;
                                    funcionMenu.FuncionNombre = funcion.Nombre;
                                    funcionMenu.DependeDe = menu.DependeDe == 0 ? null : menu.DependeDe;
                                    funcionMenu.Referencia = funcion.Referencia;
                                    funcionMenu.MenuNombre = menu.Nombre;
                                    funcionMenu.MenuId = menu.Id;

                                    resultado.Add(funcionMenu);
                                }
                            }
                        }

                    }


                }
            }

            return resultado;

        }

        public static bool VerificarPermisoMenu(string pMenu, List<Entities.FuncionMenu> pDataFuncionesMenues)
        {
            bool resultado = false;

            if (pDataFuncionesMenues.Count > 0)
            {
                if (pDataFuncionesMenues.Exists(x => x.MenuNombre == pMenu))
                    resultado = true;
            }

            return resultado;
        }

        public static bool VerificarRolFuncion(string pMenu, List<Entities.FuncionMenu> pDataFuncionesMenues, string pAccion)
        {
            bool resultado = false;
            object? variable = null;

            if (pDataFuncionesMenues != null)
            {
                if (pDataFuncionesMenues.Count > 0)
                {
                    var item = pDataFuncionesMenues.FirstOrDefault(x => x.MenuNombre == pMenu);

                    if (item != null)
                    {
                        bool valorPermiso;
                        var propiedadPermiso = item.GetType().GetProperty(pAccion);
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

        //public static List<Entities.RolUsuario> ObtenerRolesPorUsuario(Int64 pUsuarioId)
        //{
        //    List<Entities.RolUsuario> resultado = new();

        //    DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol oUsuarioRol = new();
        //    oUsuarioRol.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
        //    oUsuarioRol.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsuarioId);

        //    oUsuarioRol.Items();

        //    foreach (var rolUsuario in oUsuarioRol.Result)
        //    {
        //        if (rolUsuario.RolId.Habilitado && rolUsuario.UsuarioId.Habilitado)
        //        {
        //            Entities.RolUsuario rolUsuarioNodo = new();
        //            rolUsuarioNodo.UsuarioModificacion = "1";
        //            rolUsuarioNodo.FechaCreacion = rolUsuario.FechaCreacion;
        //            rolUsuarioNodo.FechaModificacion = rolUsuario.FechaModificacion;
        //            rolUsuarioNodo.UsuarioCreacion = "1";
        //            rolUsuarioNodo.Aplicacion = rolUsuario.AplicacionId.Nombre;
        //            rolUsuarioNodo.DependeDe = rolUsuario.RolId.DependeDe.Nombre;
        //            rolUsuarioNodo.Rol = rolUsuario.RolId.Nombre;
        //            resultado.Add(rolUsuarioNodo);
        //        }
        //    }

        //    return resultado;
        //}

    }
}
