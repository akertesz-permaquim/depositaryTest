using Permaquim.Depositary.Web.Administration.Entities;
using Permaquim.Depositary.Web.Administration.VisualizacionEntities;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class VisualizacionController
    {
        public static Depositary.Entities.Tables.Visualizacion.Perfil ObtenerPerfilVisualizacionPorUsuario(Int64 pUsuarioId)
        {
            Depositary.Entities.Tables.Visualizacion.Perfil resultado = new();

            using (Depositary.Business.Tables.Seguridad.Usuario bTablesUsuario = new())
            {
                bTablesUsuario.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                bTablesUsuario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pUsuarioId);

                bTablesUsuario.Items();

                if (bTablesUsuario.Result.Count > 0)
                {
                    using (Depositary.Business.Tables.Visualizacion.Perfil bTablesPerfil = new())
                    {

                        bTablesPerfil.Where.Add(Depositary.Business.Tables.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        bTablesPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, bTablesUsuario.Result.FirstOrDefault().PerfilId);

                        bTablesPerfil.Items();

                        if (bTablesPerfil.Result.Count > 0)
                            resultado = bTablesPerfil.Result.FirstOrDefault();
                    }
                }
            }

            return resultado;
        }

        public static List<PerfilReferencia> ObtenerReferenciasPerfilItem(Int64 pPerfilId)
        {
            List<PerfilReferencia> resultado = new();
            using (Depositary.Business.Relations.Visualizacion.Perfil bRelationsPerfil = new())
            {
                bRelationsPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                bRelationsPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pPerfilId);

                string table = "";

                bRelationsPerfil.Items(pPerfilId);

                if (bRelationsPerfil.Result.Count > 0)
                {
                    table = bRelationsPerfil.Result.FirstOrDefault().PerfilTipoId.Nombre;
                    switch (table)
                    {
                        case "Directorio.Grupo":
                            using (Depositary.Business.Tables.Directorio.Grupo bTablesGrupo = new())
                            {
                                bTablesGrupo.Where.Add(Depositary.Business.Tables.Directorio.Grupo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                bTablesGrupo.Items();
                                foreach (var item in bTablesGrupo.Result)
                                {
                                    PerfilReferencia perfilReferencia = new();
                                    perfilReferencia.Id = item.Id;
                                    perfilReferencia.Nombre = item.Nombre;

                                    resultado.Add(perfilReferencia);
                                }
                            }
                            break;
                        case "Directorio.Empresa":
                            using (Depositary.Business.Tables.Directorio.Empresa bTablesEmpresa = new())
                            {
                                bTablesEmpresa.Where.Add(Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                bTablesEmpresa.Items();
                                foreach (var item in bTablesEmpresa.Result)
                                {
                                    PerfilReferencia perfilReferencia = new();
                                    perfilReferencia.Id = item.Id;
                                    perfilReferencia.Nombre = item.Nombre;

                                    resultado.Add(perfilReferencia);
                                }
                            }
                            break;
                        case "Directorio.Sucursal":
                            using (Depositary.Business.Tables.Directorio.Sucursal bTablesSucursal = new())
                            {
                                bTablesSucursal.Where.Add(Depositary.Business.Tables.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                bTablesSucursal.Items();
                                foreach (var item in bTablesSucursal.Result)
                                {
                                    PerfilReferencia perfilReferencia = new();
                                    perfilReferencia.Id = item.Id;
                                    perfilReferencia.Nombre = item.Nombre;

                                    resultado.Add(perfilReferencia);
                                }
                            }
                            break;
                        case "Directorio.Sector":
                            using (Depositary.Business.Tables.Directorio.Sector bTablesSector = new())
                            {
                                bTablesSector.Where.Add(Depositary.Business.Tables.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                bTablesSector.Items();
                                foreach (var item in bTablesSector.Result)
                                {
                                    PerfilReferencia perfilReferencia = new();
                                    perfilReferencia.Id = item.Id;
                                    perfilReferencia.Nombre = item.Nombre;

                                    resultado.Add(perfilReferencia);
                                }
                            }
                            break;
                    }
                }
            }
            return resultado;
        }
    }
}
