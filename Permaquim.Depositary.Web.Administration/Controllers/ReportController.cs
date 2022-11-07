namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class ReportController
    {

        private static List<Depositary.Entities.Relations.Directorio.Sucursal> sucursales = new();

        #region Entidades Directorio
        public static List<DirectorioEntities.Empresa> ObtenerListadoEmpresasPorPerfil(Int64 pUsuarioId, bool filtroAscendente = false)
        {
            List<DirectorioEntities.Empresa> resultado = new();

            List<Depositary.Entities.Relations.Directorio.Empresa> empresas = new();

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();

                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                Depositary.Business.Relations.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                {
                    tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;

                    Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
                    oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                    Depositary.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                    oPerfilTipo.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilTipo.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                    Depositary.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                    oPerfilItem.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilItem.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);
                    if (filtroAscendente)
                    {
                        switch (tipoPerfilId)
                        {
                            case (Int64)VisualizacionEntities.TipoPerfil.NoEspecificado:
                                oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                                oPerfilTipo.Items();

                                if (oPerfilTipo.Result.Count > 0)
                                {
                                    if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                    {
                                        empresas = oEmpresa.Items();
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Grupo:
                                empresas = oEmpresa.Items();
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Empresa:
                                List<Int64> listadoEmpresasId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoEmpresasId.Count > 0)
                                {
                                    if(oEmpresa.Where.Count>0)
                                        oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    else
                                        oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);
                                    oEmpresa.Items();

                                    empresas = oEmpresa.Result;
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Sucursal:
                                List<Int64> listadoSucursalesId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoSucursalesId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Sucursal oSucursal = new();
                                    oSucursal.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                    oSucursal.Items();
                                    foreach (var sucursal in oSucursal.Result)
                                    {
                                        empresas.Add(sucursal.EmpresaId);
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Sector:
                                List<Int64> listadoSectoresId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoSectoresId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoSectoresId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Sector oSector = new();
                                    oSector.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oSector.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSectoresId);
                                    oSector.Items();
                                    foreach (var sector in oSector.Result)
                                    {
                                        empresas.Add(sector.SucursalId.EmpresaId);
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoPerfilId)
                        {
                            case (Int64)VisualizacionEntities.TipoPerfil.NoEspecificado:
                                oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                                oPerfilTipo.Items();

                                if (oPerfilTipo.Result.Count > 0)
                                {
                                    if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                    {
                                        empresas = oEmpresa.Items();
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Grupo:
                                empresas = oEmpresa.Items();
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Empresa:
                                List<Int64> listadoEmpresasId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoEmpresasId.Count > 0)
                                {
                                    oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);
                                    oEmpresa.Items();

                                    empresas = oEmpresa.Result;
                                }
                                break;
                        }
                    }
                }
            }

            if (empresas.Count > 0)
            {
                foreach (var empresaRegistro in empresas)
                {
                    DirectorioEntities.Empresa empresa = new();
                    empresa.EmpresaId = empresaRegistro.Id;
                    empresa.EmpresaNombre = empresaRegistro.Nombre;

                    resultado.Add(empresa);
                }
            }
            return resultado;
        }

        public static List<DirectorioEntities.Sucursal> ObtenerListadoSucursalesPorPerfil(Int64 pUsuarioId, bool filtroAscendente = false)
        {
            List<DirectorioEntities.Sucursal> resultado = new();

            

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();

                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                Depositary.Business.Relations.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                {
                    tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;

                    Depositary.Business.Relations.Directorio.Sucursal oSucursal = new();
                    oSucursal.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                    Depositary.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                    oPerfilTipo.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilTipo.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                    Depositary.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                    oPerfilItem.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilItem.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                    if (filtroAscendente)
                    {
                        switch (tipoPerfilId)
                        {
                            case (Int64)VisualizacionEntities.TipoPerfil.NoEspecificado:
                                oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                                oPerfilTipo.Items();

                                if (oPerfilTipo.Result.Count > 0)
                                {
                                    if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                    {
                                        sucursales = oSucursal.Items();
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Grupo:
                                sucursales = oSucursal.Items();
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Empresa:
                                List<Int64> listadoEmpresasId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoEmpresasId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
                                    oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);

                                    oEmpresa.Items();

                                    if (oEmpresa.Result.Count > 0)
                                    {
                                        foreach (var empresa in oEmpresa.Result)
                                        {
                                            sucursales.AddRange(empresa.ListOf_Sucursal_EmpresaId);
                                        }
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Sucursal:
                                List<Int64> listadoSucursalesId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoSucursalesId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Sucursal oSucursalListado = new();
                                    oSucursalListado.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oSucursalListado.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                    oSucursalListado.Items();

                                    if (oSucursalListado.Result.Count > 0)
                                    {
                                        sucursales.AddRange(oSucursalListado.Result);
                                    }
                                }
                                break;
                            case (Int64)VisualizacionEntities.TipoPerfil.Sector:
                                List<Int64> listadoSectoresId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoSectoresId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoSectoresId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Sector oSector = new();
                                    oSector.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oSector.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSectoresId);
                                    oSector.Items();
                                    foreach (var sector in oSector.Result)
                                    {
                                        sucursales.Add(sector.SucursalId);
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoPerfilId)
                        {
                            case 0: //0=No especificado
                                oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                                oPerfilTipo.Items();

                                if (oPerfilTipo.Result.Count > 0)
                                {
                                    if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                    {
                                        sucursales = oSucursal.Items();
                                    }
                                }
                                break;
                            case 1://1=Grupo
                                sucursales = oSucursal.Items();
                                break;
                            case 2://2=Empresa
                                List<Int64> listadoEmpresasId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoEmpresasId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
                                    oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);

                                    oEmpresa.Items();

                                    if (oEmpresa.Result.Count > 0)
                                    {
                                        foreach (var empresa in oEmpresa.Result)
                                        {
                                            sucursales.AddRange(empresa.ListOf_Sucursal_EmpresaId);
                                        }
                                    }
                                }
                                break;
                            case 3://3=Sucursal
                                List<Int64> listadoSucursalesId = new();
                                oPerfilItem.Items();
                                foreach (var perfilItem in oPerfilItem.Result)
                                {
                                    listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                                }
                                if (listadoSucursalesId.Count > 0)
                                {
                                    Depositary.Business.Relations.Directorio.Sucursal oSucursalListado = new();
                                    oSucursalListado.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oSucursalListado.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                    oSucursalListado.Items();

                                    if (oSucursalListado.Result.Count > 0)
                                    {
                                        sucursales.AddRange(oSucursalListado.Result);
                                    }
                                }
                                break;
                        }
                    }

                }

            }

            if (sucursales.Count > 0)
            {
                foreach (var sucursalRegistro in sucursales)
                {
                    DirectorioEntities.Sucursal sucursal = new();
                    sucursal.SucursalId = sucursalRegistro.Id;
                    sucursal.SucursalNombre = sucursalRegistro.Nombre;
                    sucursal.EmpresaId = sucursalRegistro._EmpresaId;

                    resultado.Add(sucursal);
                }
            }

            return resultado;
        }

        public static List<DirectorioEntities.Sector> ObtenerListadoSectoresPorPerfil(Int64 pUsuarioId)
        {
            List<DirectorioEntities.Sector> resultado = new();

            List<Depositary.Entities.Relations.Directorio.Sector> sectores = new();

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();

                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                Depositary.Business.Relations.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                {
                    tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;

                    Depositary.Business.Relations.Directorio.Sector oSector = new();
                    oSector.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                    Depositary.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                    oPerfilTipo.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilTipo.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                    Depositary.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                    oPerfilItem.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilItem.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                    switch (tipoPerfilId)
                    {
                        case 0: //0=No especificado
                            oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                            oPerfilTipo.Items();

                            if (oPerfilTipo.Result.Count > 0)
                            {
                                if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                {
                                    sectores = oSector.Items();
                                }
                            }
                            break;
                        case 1://1=Grupo
                            sectores = oSector.Items();
                            break;
                        case 2://2=Empresa
                            List<Int64> listadoEmpresasId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                            }
                            if (listadoEmpresasId.Count > 0)
                            {
                                Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
                                oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);

                                oEmpresa.Items();

                                if (oEmpresa.Result.Count > 0)
                                {
                                    foreach (var empresa in oEmpresa.Result)
                                    {
                                        foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
                                        {
                                            sectores.AddRange(sucursal.ListOf_Sector_SucursalId);
                                        }
                                    }
                                }
                            }
                            break;
                        case 3://3=Sucursal
                            List<Int64> listadoSucursalesId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                            }
                            if (listadoSucursalesId.Count > 0)
                            {
                                Depositary.Business.Relations.Directorio.Sucursal oSucursal = new();
                                oSucursal.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                oSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                oSucursal.Items();

                                if (oSucursal.Result.Count > 0)
                                {
                                    foreach (var sucursal in oSucursal.Result)
                                    {
                                        sectores.AddRange(sucursal.ListOf_Sector_SucursalId);
                                    }
                                }
                            }
                            break;
                        case 4://4=Sector
                            List<Int64> listadoSectoresId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoSectoresId.Add(perfilItem.IdTablaReferencia);
                            }
                            if (listadoSectoresId.Count > 0)
                            {
                                Depositary.Business.Relations.Directorio.Sector oSectorPerfil = new();
                                oSectorPerfil.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                oSectorPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSectoresId);
                                oSectorPerfil.Items();

                                if (oSectorPerfil.Result.Count > 0)
                                {
                                    foreach (var sector in oSectorPerfil.Result)
                                    {
                                        sectores.Add(sector);
                                    }
                                }
                            }
                            break;
                    }

                }

            }

            if (sectores.Count > 0)
            {
                foreach (var sectorRegistro in sectores)
                {
                    DirectorioEntities.Sector sector = new();
                    sector.SectorId = sectorRegistro.Id;
                    sector.SectorNombre = sectorRegistro.Nombre;
                    sector.SucursalId = sectorRegistro._SucursalId;

                    resultado.Add(sector);
                }
            }

            return resultado;
        }
        #endregion

        #region Entidades Seguridad

        public static List<SeguridadEntities.Usuario> ObtenerUsuarios(bool obtenerSoloHabilitados = true)
        {
            List<SeguridadEntities.Usuario> resultado = new();

            Depositary.Business.Tables.Seguridad.Usuario oUsuario = new();
            if (obtenerSoloHabilitados)
                oUsuario.Where.Add(Depositary.Business.Tables.Seguridad.Usuario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

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

        #endregion

        #region Entidades Operacion

        public static List<TransaccionEntities.Contenedor> ObtenerContenedores(bool obtenerSoloHabilitados = true)
        {
            List<TransaccionEntities.Contenedor> resultado = new();

            Depositary.Business.Tables.Operacion.Contenedor oContenedor = new();
            if (obtenerSoloHabilitados)
                oContenedor.Where.Add(Depositary.Business.Tables.Operacion.Contenedor.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oContenedor.Items();

            if (oContenedor.Result.Count > 0)
            {
                foreach (var contenedor in oContenedor.Result)
                {
                    TransaccionEntities.Contenedor contenedorEntitie = new();
                    contenedorEntitie.ContenedorId = contenedor.Id;
                    contenedorEntitie.Nombre = contenedor.Nombre;
                    contenedorEntitie.Identificador = contenedor.Identificador;

                    resultado.Add(contenedorEntitie);
                }
            }

            return resultado;
        }

        #endregion

        #region Entidades Turno

        public static List<TurnoEntities.TurnoComboReporte> ObtenerTurnos()
        {
            List<TurnoEntities.TurnoComboReporte> resultado = new();

            Depositary.Business.Relations.Turno.EsquemaTurno oEsquemaTurno = new();

            oEsquemaTurno.Items();

            if (oEsquemaTurno.Result.Count > 0)
            {
                foreach (var esquema in oEsquemaTurno.Result)
                {
                    foreach (var esquemaDetalle in esquema.ListOf_EsquemaDetalleTurno_EsquemaTurnoId)
                    {
                        TurnoEntities.TurnoComboReporte turnoComboReporte = new();
                        turnoComboReporte.NombreEsquema = esquema.Nombre;
                        turnoComboReporte.NombreEsquemaDetalle = esquemaDetalle.Nombre;
                        turnoComboReporte.TurnoEsquemaDetalleId = esquemaDetalle.Id;

                        resultado.Add(turnoComboReporte);
                    }
                }
            }

            return resultado;
        }

        #endregion

        #region Entidades Valor

        public static List<Entities.Origen> ObtenerOrigenes(bool obtenerSoloHabilitados = true)
        {
            List<Entities.Origen> resultado = new();

            Depositary.Business.Tables.Valor.OrigenValor oOrigenValor = new();
            if (obtenerSoloHabilitados)
                oOrigenValor.Where.Add(Depositary.Business.Tables.Valor.OrigenValor.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oOrigenValor.Items();

            if (oOrigenValor.Result.Count > 0)
            {
                foreach (var origen in oOrigenValor.Result)
                {
                    Entities.Origen origenEntitie = new();

                    origenEntitie.OrigenId = origen.Id;
                    origenEntitie.OrigenNombre = origen.Nombre;

                    resultado.Add(origenEntitie);
                }
            }

            return resultado;
        }

        #endregion

        #region Entidades Dispositivo

        public static List<DispositivoEntities.Depositario> ObtenerListadoDepositariosPorPerfil(Int64 pUsuarioId)
        {
            List<DispositivoEntities.Depositario> resultado = new();

            List<Depositary.Entities.Relations.Dispositivo.Depositario> depositarios = new();

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();
                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                Depositary.Business.Relations.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                {
                    tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;
                    Depositary.Business.Relations.Dispositivo.Depositario oDepositario = new();
                    oDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                    Depositary.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                    oPerfilTipo.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilTipo.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                    Depositary.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                    oPerfilItem.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oPerfilItem.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                    switch (tipoPerfilId)
                    {
                        case (Int64)VisualizacionEntities.TipoPerfil.NoEspecificado: //0=No especificado
                            oPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                            oPerfilTipo.Items();

                            if (oPerfilTipo.Result.Count > 0)
                            {
                                if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                {
                                    depositarios = oDepositario.Items();
                                }
                            }
                            break;
                        case (Int64)VisualizacionEntities.TipoPerfil.Grupo://1=Grupo
                            depositarios = oDepositario.Items();
                            break;
                        case (Int64)VisualizacionEntities.TipoPerfil.Empresa://2=Empresa
                            List<Int64> listadoEmpresasId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                            }
                            Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
                            if (listadoEmpresasId.Count > 0)
                            {
                                oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                                oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);
                                oEmpresa.Items();
                                foreach (var empresa in oEmpresa.Result)
                                {
                                    foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
                                    {
                                        foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                                        {
                                            foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                            {
                                                depositarios.Add(depositario);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case (Int64)VisualizacionEntities.TipoPerfil.Sucursal://3=Sucursal
                            List<Int64> listadoSucursalesId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                            }
                            Depositary.Business.Relations.Directorio.Sucursal oSucursal = new();
                            if (listadoSucursalesId.Count > 0)
                            {
                                oSucursal.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                oSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                oSucursal.Items();
                                foreach (var sucursal in oSucursal.Result)
                                {
                                    foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                                    {
                                        foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                        {
                                            depositarios.Add(depositario);
                                        }
                                    }
                                }
                            }
                            break;
                        case (Int64)VisualizacionEntities.TipoPerfil.Sector://4=Sector
                            List<Int64> listadoSectoresId = new();
                            oPerfilItem.Items();
                            foreach (var perfilItem in oPerfilItem.Result)
                            {
                                listadoSectoresId.Add(perfilItem.IdTablaReferencia);
                            }
                            Depositary.Business.Relations.Directorio.Sector oSector = new();
                            if (listadoSectoresId.Count > 0)
                            {
                                oSector.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                oSector.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSectoresId);
                                oSector.Items();
                                foreach (var sector in oSector.Result)
                                {
                                    foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                    {
                                        depositarios.Add(depositario);
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            if (depositarios.Count > 0)
            {
                foreach (var depositarioRegistro in depositarios)
                {
                    DispositivoEntities.Depositario depositario = new();
                    var sucursal = depositarioRegistro.SectorId.SucursalId;
                    depositario.SectorId = depositarioRegistro._SectorId;
                    depositario.SucursalId = sucursal.Id;
                    depositario.EmpresaId = sucursal._EmpresaId;
                    depositario.DepositarioId = depositarioRegistro.Id;
                    depositario.DepositarioNombre = depositarioRegistro.Nombre;

                    resultado.Add(depositario);
                }
            }
            return resultado;
        }

        #endregion

       
    }
}

