namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DirectorioController
    {
        public static Entities.Moneda ObtenerMonedaPrincipalSucursal(Int64 pSucursalId)
        {
            Entities.Moneda moneda = new();

            DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal oRelacionMonedaSucursal = new();
            oRelacionMonedaSucursal.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oRelacionMonedaSucursal.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pSucursalId);
            oRelacionMonedaSucursal.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.EsDefault, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            oRelacionMonedaSucursal.Items();

            if (oRelacionMonedaSucursal.Result.Count > 0)
            {
                var entidadMoneda = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId;
                moneda.Id = entidadMoneda.Id;
                moneda.Nombre = entidadMoneda.Nombre;
                moneda.Simbolo = entidadMoneda.Simbolo;
                moneda.Codigo = entidadMoneda.Codigo;
                moneda.Habilitado = entidadMoneda.Habilitado;
                moneda.IndiceEnContadora = entidadMoneda.IndiceEnContadora;
                moneda.PaisId = entidadMoneda.PaisId;
                //TODO revisar FK usuario
                moneda.UsuarioCreacion = entidadMoneda.UsuarioCreacion.ToString();
                moneda.UsuarioModificacion = entidadMoneda.UsuarioModificacion.ToString();
                moneda.FechaModificacion = entidadMoneda.FechaModificacion;
                moneda.FechaCreacion = entidadMoneda.FechaCreacion;
            }

            return moneda;
        }

        public static List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> ObtenerListadoDepositariosPorPerfil(Int64 pPerfilId)
        {
            List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> resultado = new();
            Int64 tipoPerfilId = new();

            //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
            DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil oPerfil = new();
            oPerfil.Where.Add(DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oPerfil.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pPerfilId);

            oPerfil.Items();

            if (oPerfil.Result.Count > 0)
            {
                tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;
                DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario oDepositario = new();
                oDepositario.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                oPerfilTipo.Where.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oPerfilTipo.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                oPerfilItem.Where.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oPerfilItem.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pPerfilId);

                switch (tipoPerfilId)
                {
                    case 0: //0=No especificado
                        oPerfilTipo.OrderBy.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);
                        oPerfilTipo.Items();

                        if (oPerfilTipo.Result.Count > 0)
                        {
                            if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                            {
                                resultado = oDepositario.Items();
                            }
                        }
                        break;
                    case 1://1=Grupo
                        resultado = oDepositario.Items();
                        break;
                    case 2://2=Empresa
                        List<Int64> listadoEmpresasId = new();
                        oPerfilItem.Items();
                        foreach (var perfilItem in oPerfilItem.Result)
                        {
                            listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                        }
                        DepositarioAdminWeb.Business.Relations.Directorio.Empresa oEmpresa = new();
                        oEmpresa.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                        oEmpresa.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoEmpresasId);
                        oEmpresa.Items();
                        foreach (var empresa in oEmpresa.Result)
                        {
                            foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
                            {
                                foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                                {
                                    foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                    {
                                        resultado.Add(depositario);
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
                        DepositarioAdminWeb.Business.Relations.Directorio.Sucursal oSucursal = new();
                        oSucursal.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                        oSucursal.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoSucursalesId);
                        oSucursal.Items();
                        foreach (var sucursal in oSucursal.Result)
                        {
                            foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                            {
                                foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                {
                                    resultado.Add(depositario);
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
                        DepositarioAdminWeb.Business.Relations.Directorio.Sector oSector = new();
                        oSector.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                        oSector.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Sector.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoSectoresId);
                        oSector.Items();
                        foreach (var sector in oSector.Result)
                        {
                            foreach (var depositario in sector.ListOf_Depositario_SectorId)
                            {
                                resultado.Add(depositario);
                            }
                        }
                        break;
                }

            }

            return resultado;
        }

        public static List<Entities.Empresa> ObtenerEmpresasAccesibles(Int64 pUsuarioId)
        {
            List<Entities.Empresa> resultado = new();

            List<DepositarioAdminWeb.Entities.Relations.Directorio.Empresa> empresas = new();

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();

                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil oPerfil = new();
                oPerfil.Where.Add(DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                oPerfil.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                oPerfil.Items();

                if (oPerfil.Result.Count > 0)
                {
                    tipoPerfilId = oPerfil.Result.FirstOrDefault()._PerfilTipoId;

                    DepositarioAdminWeb.Business.Relations.Directorio.Empresa oEmpresa = new();
                    oEmpresa.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                    DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo oPerfilTipo = new();
                    oPerfilTipo.Where.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                    oPerfilTipo.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                    DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem oPerfilItem = new();
                    oPerfilItem.Where.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                    oPerfilItem.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                    switch (tipoPerfilId)
                    {
                        case 0: //0=No especificado
                            oPerfilTipo.OrderBy.Add(DepositarioAdminWeb.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);
                            oPerfilTipo.Items();

                            if (oPerfilTipo.Result.Count > 0)
                            {
                                if (oPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                {
                                    empresas = oEmpresa.Items();
                                }
                            }
                            break;
                        case 1://1=Grupo
                            empresas = oEmpresa.Items();
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
                                oEmpresa.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                                oEmpresa.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoEmpresasId);
                                oEmpresa.Items();

                                empresas = oEmpresa.Result;
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
                                DepositarioAdminWeb.Business.Relations.Directorio.Sucursal oSucursal = new();
                                oSucursal.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                                oSucursal.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                oSucursal.Items();
                                foreach (var sucursal in oSucursal.Result)
                                {
                                    empresas.Add(sucursal.EmpresaId);
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
                                DepositarioAdminWeb.Business.Relations.Directorio.Sector oSector = new();
                                oSector.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
                                oSector.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.Sector.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.In, listadoSectoresId);
                                oSector.Items();
                                foreach (var sector in oSector.Result)
                                {
                                    empresas.Add(sector.SucursalId.EmpresaId);
                                }
                            }
                            break;
                    }

                }

            }

            if (empresas.Count > 0)
            {
                foreach (var empresaRegistro in empresas)
                {
                    Entities.Empresa empresa = new();
                    empresa.EmpresaId = empresaRegistro.Id;
                    empresa.Nombre = empresaRegistro.Nombre;

                    resultado.Add(empresa);
                }
            }

            return resultado;
        }
    }
}
