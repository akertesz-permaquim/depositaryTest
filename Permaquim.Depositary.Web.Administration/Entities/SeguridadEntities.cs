﻿namespace Permaquim.Depositary.Web.Administration.SeguridadEntities
{
    public enum TipoAplicacion
    {
        NoEspecificado = 0,
        Desktop = 1,
        Web = 2,
        Webapi = 3,
        ServiceWorker = 4
    }
    public enum Aplicacion
    {
        NoEspecificado = 0,
        Depositario = 1,
        AdministradorWeb = 2,
        Webapi = 3,
        ServiceWorker = 4
    }
    public enum TipoMenu
    {
        NoEspecificado = 0,
        Carpeta = 1,
        Pagina = 2
    }

    public enum TipoFuncion
    {
        NoEspecificado = 0,
        Formulario = 1,
        PaginaWeb = 2,
        Reporte = 3,
        Menu = 4
    }

    public class RolUsuario
    {
        public string Rol { get; set; }
        public string DependeDe { get; set; }
        public string Aplicacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }

    public class FuncionRol
    {
        public Int64 FuncionId { get; set; }
        public Int64 RolId { get; set; }
        public string FuncionNombre { get; set; }
        public bool PuedeVisualizar { get; set; }
        public bool PuedeAgregar { get; set; }
        public bool PuedeModificar { get; set; }
        public bool PuedeEliminar { get; set; }
    }
    public class Menu
    {
        public Int64 MenuId { get; set; }
        public Int64? DependeDe { get; set; }
        public Int64 TipoMenuId { get; set; }
        public int Orden { get; set; }
        public string MenuNombre { get; set; }
        public string MenuDescripcion { get; set; }
        public string Imagen { get; set; }
        public string Referencia { get; set; }
        public bool Accesible { get; set; } = false;
    }

    public class FuncionMenu
    {
        public Int64 FuncionId { get; set; }
        public Int64? MenuId { get; set; }
        public Int64? DependeDe { get; set; }
        public string ImagenMenu { get; set; }
        public string FuncionNombre { get; set; }
        public string MenuNombre { get; set; }
        public string MenuDescripcion { get; set; }
        public Int64 TipoMenuId { get; set; }
        public bool PuedeVisualizar { get; set; }
        public bool PuedeAgregar { get; set; }
        public bool PuedeModificar { get; set; }
        public bool PuedeEliminar { get; set; }
        public string Referencia { get; set; }
    }

    public class Usuario
    {
        public Int64 UsuarioId { get; set; }
        public string Nickname { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public string NombreyApellido
        {
            get
            {
                return UsuarioNombre + " " + UsuarioApellido;
            }
        }

    }

    public class AplicacionCombo
    {
        public Int64 AplicacionId { get; set; }
        public string AplicacionNombre { get; set; }

    }

    public class Rol
    {
        public Int64 RolId { get; set; }
        public string RolNombre { get; set; }

    }

}
