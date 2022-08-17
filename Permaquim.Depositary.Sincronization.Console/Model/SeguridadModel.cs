using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console.Model
{
    internal class SeguridadModel : IModel
    {
        public List<Depositario.Entities.Tables.Seguridad.TipoAplicacion> TiposAplicaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Aplicacion> Aplicaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametro> AplicacionesParametros { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametroValor> AplicacionesParametrosValores { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoFuncion> TiposFunciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoMenu> TiposMenues { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Rol> Roles { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Funcion> Funciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.RolFuncion> RolesFunciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Menu> Menues { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Usuario> Usuarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioRol> UsuariosRoles { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioSector> UsuariosSectores { get; set; } = new();
        public DateTime? SincroDate { get; set; }

        public void Persist()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            Depositario.Business.Tables.Seguridad.TipoAplicacion applicationType = new();
            foreach (var item in TiposAplicaciones)
            {
                applicationType.Where.Clear();
                applicationType.Where.Add(Depositario.Business.Tables.Seguridad.TipoAplicacion.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                applicationType.Items();

                if (applicationType.Result.Count == 0)
                    applicationType.Add(item);
                else
                    applicationType.Update(item);
            }

            Depositario.Business.Tables.Seguridad.Aplicacion application = new();
            foreach (var item in Aplicaciones)
            {
                application.Where.Clear();
                application.Where.Add(Depositario.Business.Tables.Seguridad.Aplicacion.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                application.Items();

                if (application.Result.Count == 0)
                    application.Add(item);
                else
                    application.Update(item);
            }

            Depositario.Business.Tables.Seguridad.AplicacionParametro applicationParameter = new();
            foreach (var item in AplicacionesParametros)
            {
                applicationParameter.Where.Clear();
                applicationParameter.Where.Add(Depositario.Business.Tables.Seguridad.AplicacionParametro.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Nombre);
                applicationParameter.Items();

                if (applicationParameter.Result.Count == 0)
                    applicationParameter.Add(item);
                else
                    applicationParameter.Update(item);
            }

            Depositario.Business.Tables.Seguridad.AplicacionParametroValor applicationParameterValue = new();
            foreach (var item in AplicacionesParametrosValores)
            {
                applicationParameterValue.Where.Clear();
                applicationParameterValue.Where.Add(Depositario.Business.Tables.Seguridad.AplicacionParametroValor.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                applicationParameterValue.Items();

                if (applicationParameterValue.Result.Count == 0)
                    applicationParameterValue.Add(item);
                else
                    applicationParameterValue.Update(item);
            }

            Depositario.Business.Tables.Seguridad.TipoFuncion functionType = new();
            foreach (var item in TiposFunciones)
            {
                functionType.Where.Clear();
                functionType.Where.Add(Depositario.Business.Tables.Seguridad.TipoFuncion.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                functionType.Items();

                if (functionType.Result.Count == 0)
                    functionType.Add(item);
                else
                    functionType.Update(item);
            }

            Depositario.Business.Tables.Seguridad.Rol role = new();
            foreach (var item in Roles)
            {
                role.Where.Clear();
                role.Where.Add(Depositario.Business.Tables.Seguridad.Rol.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                role.Items();

                if (role.Result.Count == 0)
                    role.Add(item);
                else
                    role.Update(item);
            }

            Depositario.Business.Tables.Seguridad.Funcion function = new();
            foreach (var item in Funciones)
            {
                function.Where.Clear();
                function.Where.Add(Depositario.Business.Tables.Seguridad.Funcion.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                function.Items();

                if (function.Result.Count == 0)
                    function.Add(item);
                else
                    function.Update(item);
            }

            Depositario.Business.Tables.Seguridad.RolFuncion functionRole = new();
            foreach (var item in RolesFunciones)
            {
                functionRole.Where.Clear();
                functionRole.Where.Add(Depositario.Business.Tables.Seguridad.RolFuncion.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                functionRole.Items();

                if (functionRole.Result.Count == 0)
                    functionRole.Add(item);
                else
                    functionRole.Update(item);
            }

            Depositario.Business.Tables.Seguridad.Menu menu = new();
            foreach (var item in Menues)
            {
                menu.Where.Clear();
                menu.Where.Add(Depositario.Business.Tables.Seguridad.Menu.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                menu.Items();

                if (menu.Result.Count == 0)
                    menu.Add(item);
                else
                    menu.Update(item);
            }


            Depositario.Business.Tables.Seguridad.Usuario user = new();
            foreach (var item in Usuarios)
            {
                user.Where.Clear();
                user.Where.Add(Depositario.Business.Tables.Seguridad.Usuario.ColumnEnum.Nombre,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                user.Items();

                if (user.Result.Count == 0)
                    user.Add(item);
                else
                    user.Update(item);
            }

            Depositario.Business.Tables.Seguridad.UsuarioRol userRole = new();
            foreach (var item in UsuariosRoles)
            {
                userRole.Where.Clear();
                userRole.Where.Add(Depositario.Business.Tables.Seguridad.UsuarioRol.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                userRole.Items();

                if (userRole.Result.Count == 0)
                    userRole.Add(item);
                else
                    userRole.Update(item);
            }

            Depositario.Business.Tables.Seguridad.UsuarioSector userSector = new();
            foreach (var item in UsuariosSectores)
            {
                userSector.Where.Clear();
                userSector.Where.Add(Depositario.Business.Tables.Seguridad.UsuarioSector.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.Equal, item.Id);
                userSector.Items();

                if (userSector.Result.Count == 0)
                    userSector.Add(item);
                else
                    userSector.Update(item);
            }
            this.SincroDate = DateTime.Now;

        }

     }
}
