using Permaquim.Depositary.Web.Administration.Entities;


namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class VisualizacionController
    {
        public static DepositarioAdminWeb.Entities.Tables.Visualizacion.Perfil ObtenerPerfilVisualizacionPorUsuario(Int64 pUsuarioId)
        {
            DepositarioAdminWeb.Entities.Tables.Visualizacion.Perfil resultado = new();

            DepositarioAdminWeb.Business.Tables.Seguridad.Usuario oUsuario = new();
            oUsuario.Where.Add(DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oUsuario.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Seguridad.Usuario.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pUsuarioId);

            oUsuario.Items();

            if (oUsuario.Result.Count > 0)
            {
                DepositarioAdminWeb.Business.Tables.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.Perfil.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Visualizacion.Perfil.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, oUsuario.Result.FirstOrDefault().PerfilId);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                    resultado = oPerfil.Result.FirstOrDefault();
            }

            return resultado;
        }

        public static List<PerfilReferencia> ObtenerReferenciasPerfilItem(Int64 pPerfilId)
        {
            List<PerfilReferencia> resultado = new();
            DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil oPerfil = new();
            oPerfil.Where.Add(DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oPerfil.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pPerfilId);

            string table = "";

            oPerfil.Items(pPerfilId);

            if (oPerfil.Result.Count > 0)
            {
                table = oPerfil.Result.FirstOrDefault().PerfilTipoId.Nombre;
                switch (table)
                {
                    case "Directorio.Grupo":
                        DepositarioAdminWeb.Business.Tables.Directorio.Grupo oGrupo = new();
                        oGrupo.Where.Add(DepositarioAdminWeb.Business.Tables.Directorio.Grupo.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
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
                        DepositarioAdminWeb.Business.Tables.Directorio.Empresa oEmpresa = new();
                        oEmpresa.Where.Add(DepositarioAdminWeb.Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
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
                        DepositarioAdminWeb.Business.Tables.Directorio.Sucursal oSucursal = new();
                        oSucursal.Where.Add(DepositarioAdminWeb.Business.Tables.Directorio.Sucursal.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
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
                        DepositarioAdminWeb.Business.Tables.Directorio.Sector oSector = new();
                        oSector.Where.Add(DepositarioAdminWeb.Business.Tables.Directorio.Sector.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
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
