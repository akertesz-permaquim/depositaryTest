namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DepositarioController
    {
        public static List<Entities.DepositarioMonitor> ObtenerDepositarios(Int64 pUsuarioId)
        {
            //List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios> resultado = new List<DepositarioAdminWeb.Entities.Procedures.Dispositivo.ObtenerDepositarios>();
            //DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios oSP = new DepositarioAdminWeb.Business.Procedures.Dispositivo.ObtenerDepositarios();

            List<Entities.DepositarioMonitor> resultado = new();
            List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> depositariosAccesibles = new();

            //Obtengo el listado de depositarios que se pueden ver segun el perfil del usuario
            depositariosAccesibles = ObtenerListadoDepositariosPorPerfil(VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId).Id);

            foreach (var depositario in depositariosAccesibles)
            {
                Entities.Moneda? monedaPrincipal = ObtenerMonedaPrincipalDepositario(depositario.Id);

                List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> transaccion = new();
                transaccion = TransaccionController.ObtenerTransaccionesPorDepositario(depositario.Id, true, monedaPrincipal != null ? monedaPrincipal.Id : null);

                Entities.DepositarioMonitor depositarioMonitor = new();
                double totalEnBolsa = 0;

                depositarioMonitor.DepositarioId = depositario.Id;
                depositarioMonitor.Nombre = depositario.Nombre;
                depositarioMonitor.Descripcion = depositario.Descripcion;
                depositarioMonitor.Sector = depositario.SectorId.Nombre;
                depositarioMonitor.Sucursal = depositario.SectorId.SucursalId.Nombre;
                depositarioMonitor.Empresa = depositario.SectorId.SucursalId.EmpresaId.Nombre;
                depositarioMonitor.NumeroSerie = depositario.NumeroSerie;
                depositarioMonitor.CodigoExterno = depositario.CodigoExterno;
                depositarioMonitor.Modelo = depositario.ModeloId.Nombre;
                depositarioMonitor.Habilitado = depositario.Habilitado;
                depositarioMonitor.UsuarioCreacion = depositario.UsuarioCreacion.ToString(); //revisar: falta la fk
                depositarioMonitor.UsuarioModificacion = depositario.UsuarioModificacion.ToString(); //revisar: falta la fk
                depositarioMonitor.FechaCreacion = depositario.FechaCreacion;
                depositarioMonitor.FechaModificacion = depositario.FechaModificacion;
                depositarioMonitor.SemaforoAnomalia = "Rojo";
                depositarioMonitor.SemaforoOnline = "Verde";
                Int64? bolsaColocada = TransaccionController.ObtenerBolsaColocada(depositario.Id);
                if (bolsaColocada.HasValue)
                    depositarioMonitor.PorcentajeOcupacionbolsa = TransaccionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value);
                else
                    depositarioMonitor.PorcentajeOcupacionbolsa = 0;


                if (transaccion.Count > 0)
                {
                    totalEnBolsa = transaccion.Sum(x => x.TotalAValidar) + transaccion.Sum(x => x.TotalValidado);

                    depositarioMonitor.ValorTotalEnBolsa = ObtenerMonedaPrincipalDepositario(depositario.Id).Codigo + " " + totalEnBolsa.ToString();
                }
                else
                {
                    depositarioMonitor.ValorTotalEnBolsa = "0";
                }

                resultado.Add(depositarioMonitor);

            }

            //resultado = oSP.Items();

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

        public static Entities.Moneda? ObtenerMonedaPrincipalDepositario(Int64 pDepositarioId)
        {
            Entities.Moneda moneda = new();

            DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oDepositario.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pDepositarioId);

            oDepositario.Items();

            if (oDepositario.Result.Count > 0)
            {
                moneda = DirectorioController.ObtenerMonedaPrincipalSucursal(oDepositario.Result.FirstOrDefault().SectorId.SucursalId.Id);
            }
            else
                return null;

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

        #region Dashboard
        public static string ObtenerCantidadDepositariosConBolsaCasiLlena()
        {
            string resultado = "ERROR";
            int resultadoNumerico = 0;

            //En esta variable guardo el porcentaje a partir del cual se considera casi lleno el contenedor
            float porcentajeMinimoContenedorCasiLleno = 0;

            DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion oConfiguracion = new();
            oConfiguracion.Where.Add(DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, 2);
            oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, "PORCENTAJE_MINIMO_CONTENEDOR_CASI_LLENO");

            oConfiguracion.Items();

            if (oConfiguracion.Result.Count > 0)
            {
                if (float.TryParse(oConfiguracion.Result.FirstOrDefault().Valor, out porcentajeMinimoContenedorCasiLleno))
                {
                    DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario oDepositario = new();
                    oDepositario.Where.Add(DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                    oDepositario.Items();

                    if (oDepositario.Result.Count > 0)
                    {
                        foreach (var depositario in oDepositario.Result)
                        {
                            Int64? bolsaColocada = TransaccionController.ObtenerBolsaColocada(depositario.Id);

                            if (bolsaColocada.HasValue)
                            {
                                if (TransaccionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value) >= porcentajeMinimoContenedorCasiLleno)
                                    resultadoNumerico++;

                            }
                        }
                    }

                    resultado = resultadoNumerico.ToString();
                }
                else
                    resultado = "Error conversión";
            }
            else
                resultado = "Falta configuración";

            return resultado;
        }

        public static string ObtenerCantidadDepositariosEnLinea()
        {
            string resultado = "ERROR";
            int depositariosEnLinea = 0;

            //En esta variable guardo el tiempo en segundos de intervalo para determinar si esta offline
            int tiempoDepositarioEnLineaSegundos = 0;

            DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion oConfiguracion = new();
            oConfiguracion.Where.Add(DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, 2);
            oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oConfiguracion.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, "TIEMPO_DEPOSITARIO_EN_LINEA_SEGUNDOS");

            oConfiguracion.Items();

            if (oConfiguracion.Result.Count > 0)
            {
                if (int.TryParse(oConfiguracion.Result.FirstOrDefault().Valor, out tiempoDepositarioEnLineaSegundos))
                {
                    DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario oDepositario = new();
                    oDepositario.Where.Add(DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

                    oDepositario.Items();

                    if (oDepositario.Result.Count > 0)
                    {
                        depositariosEnLinea = oDepositario.Result.Count;
                        foreach (var depositario in oDepositario.Result)
                        {
                            DepositarioAdminWeb.Business.Tables.Operacion.Evento oEvento = new();
                            oEvento.Where.Add(DepositarioAdminWeb.Business.Tables.Operacion.Evento.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, depositario.Id);
                            oEvento.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Operacion.Evento.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Today.AddDays(-1));

                            oEvento.Items();

                            if (oEvento.Result.Count > 0)
                            {
                                //Me traigo el ultimo evento y verifico si pasaron mas segundos de lo parametrizado
                                DateTime fechaUltimoEvento = oEvento.Result.OrderByDescending(x => x.Fecha).FirstOrDefault().Fecha;
                                if ((int)(DateTime.Now - fechaUltimoEvento).TotalSeconds > tiempoDepositarioEnLineaSegundos)
                                    depositariosEnLinea--;
                            }
                            else
                                depositariosEnLinea--;

                        }
                    }

                    resultado = depositariosEnLinea.ToString();
                }
                else
                    resultado = "Error conversión";
            }
            else
                resultado = "Falta configuración";

            return resultado;
        }

        public static string ObtenerCantidadDepositariosFueraServicio()
        {
            int depositariosFueraServicio = 0;

            DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oDepositario.Items();

            if (oDepositario.Result.Count > 0)
            {
                foreach (var depositario in oDepositario.Result)
                {
                    DepositarioAdminWeb.Business.Tables.Operacion.Evento oEvento = new();
                    oEvento.Where.Add(DepositarioAdminWeb.Business.Tables.Operacion.Evento.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, depositario.Id);
                    oEvento.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Operacion.Evento.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Today.AddDays(-1));

                    oEvento.Items();

                    if (oEvento.Result.Count > 0)
                    {
                        //Me traigo el ultimo evento y verifico si es de tipo "Fuera de servicio"
                        if (oEvento.Result.OrderByDescending(x => x.Fecha).FirstOrDefault().TipoId == (Int64)TransaccionEntities.TipoEvento.FueraServicio)
                            depositariosFueraServicio++;
                    }

                }
            }

            return depositariosFueraServicio.ToString();
        }

        public static List<Entities.DepositarioCarga> ObtenerDepositariosConMayorCarga()
        {
            List<Entities.DepositarioCarga> resultado = new();

            DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(DepositarioAdminWeb.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);

            oDepositario.Items();

            if (oDepositario.Result.Count > 0)
            {
                foreach (var depositario in oDepositario.Result)
                {
                    var transacciones = TransaccionController.ObtenerTransaccionesPorDepositario(depositario.Id, true);
                    if (transacciones.Count > 0)
                    {
                        Entities.DepositarioCarga depositarioCarga = new();
                        depositarioCarga.CantidadTransacciones = transacciones.Count;
                        depositarioCarga.NombreDepositario = depositario.Nombre;
                        depositarioCarga.DepositarioId = depositario.Id;

                        resultado.Add(depositarioCarga);
                    }
                }
            }

            //return resultado.OrderByDescending(x => x.CantidadTransacciones).Take(5).ToList();

            return resultado;
        }

        #endregion
    }
}
