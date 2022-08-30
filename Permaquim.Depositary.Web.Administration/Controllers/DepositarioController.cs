namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DepositarioController
    {
        public static List<MonitorEntities.DepositarioMonitor> ObtenerDepositarios(Int64 pUsuarioId)
        {
            List<MonitorEntities.DepositarioMonitor> resultado = new();
            List<Depositary.Entities.Relations.Dispositivo.Depositario> depositariosAccesibles = new();

            //Obtengo el listado de depositarios que se pueden ver segun el perfil del usuario
            depositariosAccesibles = ObtenerListadoDepositariosPorPerfil(pUsuarioId);

            foreach (var depositario in depositariosAccesibles)
            {
                Entities.Moneda? monedaPrincipal = ObtenerMonedaPrincipalDepositario(depositario.Id);

                List<Depositary.Entities.Relations.Operacion.Transaccion> transaccion = new();

                List<Int64>? monedas;
                monedas = new();

                if (monedaPrincipal != null)
                {
                    monedas.Add(monedaPrincipal.Id);
                }

                transaccion = OperacionController.ObtenerTransaccionesPorDepositario(depositario.Id, true, monedas);

                MonitorEntities.DepositarioMonitor depositarioMonitor = new();
                double totalEnBolsa = 0;

                var sector = depositario.SectorId;
                var sucursal = sector.SucursalId;

                depositarioMonitor.DepositarioId = depositario.Id;
                depositarioMonitor.Nombre = depositario.Nombre;
                depositarioMonitor.Descripcion = depositario.Descripcion;
                depositarioMonitor.Sector = sector.Nombre;
                depositarioMonitor.Sucursal = sucursal.Nombre;
                depositarioMonitor.Empresa = sucursal.EmpresaId.Nombre;
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
                Int64? bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario.Id);
                if (bolsaColocada.HasValue)
                    depositarioMonitor.PorcentajeOcupacionbolsa = OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value);
                else
                    depositarioMonitor.PorcentajeOcupacionbolsa = 0;

                //Obtenemos la configuracion de porcentajes de bolsa de la empresa
                string parametroPorcentajeContenedorRojo = AplicacionController.ObtenerConfiguracionEmpresa("PORCENTAJE_CONTENEDOR_ROJO", sucursal._EmpresaId);
                string parametroPorcentajeContenedorAmarillo = AplicacionController.ObtenerConfiguracionEmpresa("PORCENTAJE_CONTENEDOR_AMARILLO", sucursal._EmpresaId);

                double porcentajeContenedorRojo;
                double porcentajeContenedorAmarillo;

                double.TryParse(parametroPorcentajeContenedorAmarillo, out porcentajeContenedorAmarillo);
                double.TryParse(parametroPorcentajeContenedorRojo, out porcentajeContenedorRojo);

                //En funcion del porcentaje de ocupacion de bolsa ponemos el semaforo en rojo, amarillo o verde.
                if (depositarioMonitor.PorcentajeOcupacionbolsa >= porcentajeContenedorRojo)
                {
                    depositarioMonitor.SemaforoOcupacionBolsa = "Rojo";
                }
                else if (depositarioMonitor.PorcentajeOcupacionbolsa >= porcentajeContenedorAmarillo)
                {
                    depositarioMonitor.SemaforoOcupacionBolsa = "Amarillo";
                }
                else
                    depositarioMonitor.SemaforoOcupacionBolsa = "Verde";


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

            return resultado;
        }

        public static List<Depositary.Entities.Relations.Dispositivo.Depositario> ObtenerListadoDepositariosPorPerfil(Int64 pUsuarioId)
        {
            List<Depositary.Entities.Relations.Dispositivo.Depositario> resultado = new();

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
                                    resultado = oDepositario.Items();
                                }
                            }
                            break;
                        case (Int64)VisualizacionEntities.TipoPerfil.Grupo://1=Grupo
                            resultado = oDepositario.Items();
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
                                                resultado.Add(depositario);
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
                                            resultado.Add(depositario);
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
                                        resultado.Add(depositario);
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            return resultado;
        }

        public static Entities.Moneda? ObtenerMonedaPrincipalDepositario(Int64 pDepositarioId)
        {
            Entities.Moneda moneda = new();

            Depositary.Business.Relations.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);

            oDepositario.Items();

            if (oDepositario.Result.Count > 0)
            {
                moneda = DirectorioController.ObtenerMonedaPrincipalSucursal(oDepositario.Result.FirstOrDefault().SectorId.SucursalId.Id);
            }
            else
                return null;

            return moneda;
        }

        public static MonitorEntities.InformacionDepositario ObtenerInformacionDepositario(Int64 pDepositarioId)
        {
            MonitorEntities.InformacionDepositario resultado = new();

            Depositary.Business.Relations.Dispositivo.Depositario oDepositario = new();
            oDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);

            oDepositario.Items();

            if (oDepositario.Result.Count > 0)
            {
                var depositario = oDepositario.Result.FirstOrDefault();

                resultado.DepositarioId = depositario.Id;
                resultado.ImagenModelo = depositario.ModeloId.Imagen;
                resultado.NumeroSerie = depositario.NumeroSerie;
                var sincronizacionesDepositario = depositario.ListOf_EntidadCabecera_DepositarioId;
                if (sincronizacionesDepositario != null)
                {
                    var ultimaSincronizacion = depositario.ListOf_EntidadCabecera_DepositarioId.OrderByDescending(x => x.Fechafin).FirstOrDefault();
                    if (ultimaSincronizacion != null)
                        resultado.FechaUltimaSincronizacion = ultimaSincronizacion.Fechainicio;
                }

                Int64? bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario.Id);

                if (bolsaColocada.HasValue)
                {
                    Depositary.Business.Relations.Operacion.Contenedor oContenedor = new();
                    oContenedor.Where.Add(Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oContenedor.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, bolsaColocada.Value);

                    oContenedor.Items();

                    if (oContenedor.Result.Count > 0)
                    {
                        var bolsa = oContenedor.Result.FirstOrDefault();
                        resultado.IdentificadorBolsa = bolsa.Identificador;
                        resultado.CapacidadBilletesBolsa = bolsa.TipoId.Capacidad;
                        resultado.PorcentajeOcupacionBolsa = OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsa.Id);
                        resultado.CantidadBilletesEnBolsa = (int)Math.Round(resultado.PorcentajeOcupacionBolsa * resultado.CapacidadBilletesBolsa / 100, MidpointRounding.AwayFromZero);
                    }
                }

                var turno = depositario.ListOf_Turno_DepositarioId.FirstOrDefault(x => x.FechaCierre == null && x.Habilitado == true);
                if (turno != null)
                {
                    resultado.Turno = turno.TurnoDepositarioId.Nombre;
                    resultado.FechaAperturaTurno = turno.FechaApertura;
                }

                //Obtenemos las monedas no default del depositario y verificamos si tiene transacciones en esas monedas.
                List<Int64>? monedasNoDefault = new();
                foreach (var monedaDisponible in depositario.SectorId.SucursalId.ListOf_RelacionMonedaSucursal_SucursalId.Where(x => x.EsDefault == false))
                {
                    monedasNoDefault.Add(monedaDisponible._MonedaId);
                }

                if (monedasNoDefault.Count > 0)
                {
                    var transaccionesMonedasNoDefault = OperacionController.ObtenerTransaccionesPorDepositario(depositario.Id, true, monedasNoDefault);
                    if (transaccionesMonedasNoDefault.Count > 0)
                        resultado.DepositoEnOtraMoneda = true;
                    else
                        resultado.DepositoEnOtraMoneda = false;
                }
                else
                    resultado.DepositoEnOtraMoneda = false;


                //Obtenemos la moneda principal y traemos todas las transacciones en esa moneda para calcular totales.
                var monedaPrincipal = ObtenerMonedaPrincipalDepositario(depositario.Id);

                double totalValidado = 0;
                double totalAValidar = 0;

                if (monedaPrincipal != null)
                {
                    resultado.CodigoMoneda = monedaPrincipal.Codigo;
                }
                var transaccionesEnBolsa = OperacionController.ObtenerTransaccionesPorDepositario(depositario.Id, true, monedaPrincipal != null ? new List<Int64> { monedaPrincipal.Id } : null);

                if (transaccionesEnBolsa != null)
                {
                    foreach (var transaccion in transaccionesEnBolsa)
                    {
                        totalValidado += transaccion.TotalValidado;
                        totalAValidar += transaccion.TotalAValidar;
                    }

                    resultado.TotalValidado = totalValidado;
                    resultado.TotalAValidar = totalAValidar;

                }
            }

            return resultado;
        }

        #region Dashboard
        public static string ObtenerCantidadDepositariosConBolsaCasiLlena(List<Int64> pEmpresasSeleccionadas, Int64 pEmpresaId)
        {
            string resultado = "ERROR";
            int resultadoNumerico = 0;

            //En esta variable guardo el porcentaje a partir del cual se considera casi lleno el contenedor
            float porcentajeMinimoContenedorCasiLleno = 0;

            string configuracionValor = AplicacionController.ObtenerConfiguracionEmpresa("PORCENTAJE_MINIMO_CONTENEDOR_CASI_LLENO", pEmpresaId);

            if (configuracionValor != "")
            {
                if (float.TryParse(configuracionValor, out porcentajeMinimoContenedorCasiLleno))
                {
                    var depositarios = ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

                    if (depositarios != null)
                    {
                        if (depositarios.Count > 0)
                        {
                            foreach (var depositario in depositarios)
                            {
                                Int64? bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario);

                                if (bolsaColocada.HasValue)
                                {
                                    if (OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value) >= porcentajeMinimoContenedorCasiLleno)
                                        resultadoNumerico++;

                                }
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

        public static string ObtenerCantidadDepositariosEnLinea(List<Int64> pEmpresasSeleccionadas, Int64 pEmpresaId)
        {
            string resultado = "ERROR";
            int depositariosEnLinea = 0;

            //En esta variable guardo el tiempo en segundos de intervalo para determinar si esta offline
            int tiempoDepositarioEnLineaSegundos = 0;

            string configuracionValor = AplicacionController.ObtenerConfiguracionEmpresa("TIEMPO_DEPOSITARIO_EN_LINEA_SEGUNDOS", pEmpresaId);

            if (configuracionValor != "")
            {
                if (int.TryParse(configuracionValor, out tiempoDepositarioEnLineaSegundos))
                {
                    var depositarios = ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

                    if (depositarios != null)
                    {
                        if (depositarios.Count > 0)
                        {
                            foreach (var depositario in depositarios)
                            {
                                Depositary.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacion = new();
                                oSincronizacion.Where.Add(Depositary.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, depositario);
                                oSincronizacion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechainicio, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Now.AddSeconds(-tiempoDepositarioEnLineaSegundos));

                                oSincronizacion.Items();

                                if (oSincronizacion.Result.Count > 0)
                                {
                                    depositariosEnLinea++;
                                }
                            }
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

        public static string ObtenerCantidadDepositariosFueraLinea(List<Int64> pEmpresasSeleccionadas, Int64 pEmpresaId)
        {
            string resultado = "ERROR";
            int depositarioFueraLinea = 0;

            //En esta variable guardo el tiempo en segundos de intervalo para determinar si esta offline
            int tiempoDepositarioEnLineaSegundos = 0;

            string configuracionValor = AplicacionController.ObtenerConfiguracionEmpresa("TIEMPO_DEPOSITARIO_EN_LINEA_SEGUNDOS", pEmpresaId);

            if (configuracionValor != "")
            {
                if (int.TryParse(configuracionValor, out tiempoDepositarioEnLineaSegundos))
                {
                    var depositarios = ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

                    if (depositarios != null)
                    {
                        if (depositarios.Count > 0)
                        {
                            foreach (var depositario in depositarios)
                            {
                                Depositary.Business.Tables.Sincronizacion.EntidadCabecera oSincronizacion = new();
                                oSincronizacion.Where.Add(Depositary.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, depositario);
                                oSincronizacion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechainicio, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Now.AddSeconds(-tiempoDepositarioEnLineaSegundos));

                                oSincronizacion.Items();

                                if (oSincronizacion.Result.Count < 1)
                                {
                                    depositarioFueraLinea++;
                                }
                            }

                        }
                    }

                    resultado = depositarioFueraLinea.ToString();
                }
                else
                    resultado = "Error conversión";
            }
            else
                resultado = "Falta configuración";

            return resultado;
        }

        public static string ObtenerCantidadDepositariosFueraServicio(List<Int64> pEmpresasSeleccionadas)
        {
            int depositariosFueraServicio = 0;

            var depositarios = ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

            if (depositarios != null)
            {
                if (depositarios.Count > 0)
                {
                    foreach (var depositario in depositarios)
                    {
                        Depositary.Business.Tables.Operacion.Evento oEvento = new();
                        oEvento.Where.Add(Depositary.Business.Tables.Operacion.Evento.ColumnEnum.DepositarioId, Depositary.sqlEnum.OperandEnum.Equal, depositario);
                        oEvento.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Operacion.Evento.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, DateTime.Today.AddDays(-1));

                        oEvento.Items();

                        if (oEvento.Result.Count > 0)
                        {
                            //Me traigo el ultimo evento y verifico si es de tipo "Fuera de servicio"
                            if (oEvento.Result.OrderByDescending(x => x.Fecha).FirstOrDefault().TipoId == (Int64)TransaccionEntities.TipoEvento.FueraServicio)
                                depositariosFueraServicio++;
                        }

                    }

                }
            }

            return depositariosFueraServicio.ToString();
        }

        public static List<List<Entities.DepositarioCarga>> ObtenerDepositariosConMayorCarga(List<Int64> pEmpresasSeleccionadas)
        {
            List<List<Entities.DepositarioCarga>> resultado = new();

            var depositarios = ObtenerListadoDepositariosPorEmpresa(pEmpresasSeleccionadas);

            if (depositarios != null)
            {
                if (depositarios.Count > 0)
                {
                    Depositary.Business.Tables.Dispositivo.Depositario oDepositario = new();
                    oDepositario.Where.Add(Depositary.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    oDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, depositarios);

                    oDepositario.Items();

                    if (oDepositario.Result.Count > 0)
                    {
                        foreach (var depositario in oDepositario.Result)
                        {
                            var transacciones = OperacionController.ObtenerTransaccionesPorDepositario(depositario.Id, false, null, null, DateTime.Today);
                            if (transacciones.Count > 0)
                            {
                                List<Entities.DepositarioCarga> ListaDepositarioCarga = new();
                                Entities.DepositarioCarga depositarioCarga = new();
                                depositarioCarga.NombreDepositario = depositario.Nombre;
                                depositarioCarga.CantidadTransacciones = transacciones.Count;
                                depositarioCarga.DepositarioId = depositario.Id;
                                ListaDepositarioCarga.Add(depositarioCarga);
                                resultado.Add(ListaDepositarioCarga);
                            }
                        }
                    }
                }
            }

            //return resultado.OrderByDescending(x => x.CantidadTransacciones).Take(5).ToList();

            return resultado;
        }

        public static List<Int64> ObtenerListadoDepositariosPorEmpresa(List<Int64> pEmpresas)
        {
            List<Int64> resultado = new();

            Depositary.Business.Relations.Directorio.Empresa oEmpresa = new();
            oEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            if (pEmpresas.Count > 0)
                oEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, pEmpresas);

            oEmpresa.Items();

            if (oEmpresa.Result.Count > 0)
            {
                foreach (var empresa in oEmpresa.Result)
                {
                    foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
                    {
                        foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                        {
                            foreach (var depositario in sector.ListOf_Depositario_SectorId.Where(x => x.Habilitado == true))
                            {
                                resultado.Add(depositario.Id);
                            }
                        }
                    }
                }
            }

            return resultado;
        }

        #endregion
    }
}
