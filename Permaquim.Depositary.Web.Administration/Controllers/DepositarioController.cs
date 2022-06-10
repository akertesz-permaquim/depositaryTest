namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DepositarioController
    {
        public static List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios> ObtenerDepositarios(Int64 pUsuarioId)
        {
            List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios>();
            DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios oSP = new DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios();

            //List<Entities.DepositarioMonitor> resultado = new();
            //List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> depositariosAccesibles = new();

            ////Obtengo el listado de depositarios que se pueden ver segun el perfil del usuario
            //depositariosAccesibles = ObtenerListadoDepositariosPorPerfil(VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId).Id);

            //foreach(var depositario in depositariosAccesibles)
            //{
            //    Entities.DepositarioMonitor depositarioMonitor = new();

            //    depositarioMonitor.DepositarioId = depositario.Id;
            //    depositarioMonitor.Nombre = depositario.Nombre;
            //    depositarioMonitor.Descripcion = depositario.Descripcion;
            //    depositarioMonitor.Sector = depositario.SectorId.Nombre;
            //    depositarioMonitor.Sucursal = depositario.SectorId.SucursalId.Nombre;
            //    depositarioMonitor.Empresa = depositario.SectorId.SucursalId.EmpresaId.Nombre;
            //    depositarioMonitor.NumeroSerie = depositario.NumeroSerie;
            //    depositarioMonitor.CodigoExterno = depositario.CodigoExterno;
            //    depositarioMonitor.Modelo = depositario.ModeloId.Nombre;
            //    depositarioMonitor.Habilitado = depositario.Habilitado;
            //    depositarioMonitor.UsuarioCreacion = depositario.UsuarioCreacion.ToString(); //revisar: falta la fk
            //    depositarioMonitor.UsuarioModificacion = depositario.UsuarioModificacion.ToString(); //revisar: falta la fk
            //    depositarioMonitor.FechaCreacion = depositario.FechaCreacion;
            //    depositarioMonitor.FechaModificacion = depositario.FechaModificacion;
            //    //depositarioMonitor.ValorTotalEnBolsa  =
            //}

            resultado = oSP.Items();

            return resultado;
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


            return resultado;
        }

        public static Entities.Moneda ObtenerMonedaPrincipalDepositario(Int64 pDepositarioId)
        {
            Entities.Moneda moneda = new();

            DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oDepositario.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND,DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pDepositarioId);

            oDepositario.Items();

            if(oDepositario.Result.Count>0)
            {
                moneda = DirectorioController.ObtenerMonedaPrincipalSucursal(oDepositario.Result.FirstOrDefault().SectorId.SucursalId.Id);
            }

            return moneda;
        }

        public static DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado ObtenerInformacionDepositario(Int64 pDepositarioId)
        {
            DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado resultado = new DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado();
            DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerInformacionDepositario oSP = new DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerInformacionDepositario();

            oSP.Items(pDepositarioId);

            resultado = oSP.MappedResultSet.Resultado.FirstOrDefault();

            return resultado;
        }
    }
}
