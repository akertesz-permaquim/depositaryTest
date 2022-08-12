using Permaquim.Depositary.Web.Administration.Entities;
using Permaquim.Depositary.Web.Administration.VisualizacionEntities;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class VisualizacionController
    {
        public static Depositary.Entities.Tables.Visualizacion.Perfil ObtenerPerfilVisualizacionPorUsuario(Int64 pUsuarioId)
        {
            Depositary.Entities.Tables.Visualizacion.Perfil resultado = new();

            Depositary.Business.Tables.Seguridad.Usuario oUsuario = new();
            oUsuario.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pUsuarioId);

            oUsuario.Items();

            if (oUsuario.Result.Count > 0)
            {
                Depositary.Business.Tables.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(Depositary.Business.Tables.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, oUsuario.Result.FirstOrDefault().PerfilId);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                    resultado = oPerfil.Result.FirstOrDefault();
            }

            return resultado;
        }

        public static List<PerfilReferencia> ObtenerReferenciasPerfilItem(Int64 pPerfilId)
        {
            List<PerfilReferencia> resultado = new();
            Depositary.Business.Relations.Visualizacion.Perfil oPerfil = new();
            oPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pPerfilId);

            string table = "";

            oPerfil.Items(pPerfilId);

            if (oPerfil.Result.Count > 0)
            {
                table = oPerfil.Result.FirstOrDefault().PerfilTipoId.Nombre;
                switch (table)
                {
                    case "Directorio.Grupo":
                        Depositary.Business.Tables.Directorio.Grupo oGrupo = new();
                        oGrupo.Where.Add(Depositary.Business.Tables.Directorio.Grupo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        oGrupo.Items();
                        foreach (var item in oGrupo.Result)
                        {
                            PerfilReferencia perfilReferencia = new();
                            perfilReferencia.Id = item.Id;
                            perfilReferencia.Nombre = item.Nombre;

                            resultado.Add(perfilReferencia);
                        }
                        break;
                    case "Directorio.Empresa":
                        Depositary.Business.Tables.Directorio.Empresa oEmpresa = new();
                        oEmpresa.Where.Add(Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        oEmpresa.Items();
                        foreach (var item in oEmpresa.Result)
                        {
                            PerfilReferencia perfilReferencia = new();
                            perfilReferencia.Id = item.Id;
                            perfilReferencia.Nombre = item.Nombre;

                            resultado.Add(perfilReferencia);
                        }
                        break;
                    case "Directorio.Sucursal":
                        Depositary.Business.Tables.Directorio.Sucursal oSucursal = new();
                        oSucursal.Where.Add(Depositary.Business.Tables.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        oSucursal.Items();
                        foreach (var item in oSucursal.Result)
                        {
                            PerfilReferencia perfilReferencia = new();
                            perfilReferencia.Id = item.Id;
                            perfilReferencia.Nombre = item.Nombre;

                            resultado.Add(perfilReferencia);
                        }
                        break;
                    case "Directorio.Sector":
                        Depositary.Business.Tables.Directorio.Sector oSector = new();
                        oSector.Where.Add(Depositary.Business.Tables.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        oSector.Items();
                        foreach (var item in oSector.Result)
                        {
                            PerfilReferencia perfilReferencia = new();
                            perfilReferencia.Id = item.Id;
                            perfilReferencia.Nombre = item.Nombre;

                            resultado.Add(perfilReferencia);
                        }
                        break;
                }
            }

            return resultado;
        }
    }
}
