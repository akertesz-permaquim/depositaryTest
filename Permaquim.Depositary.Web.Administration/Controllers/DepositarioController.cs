namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DepositarioController
    {
        private static List<Depositary.Entities.Relations.Dispositivo.Depositario> _depositariosAccesibles = new();
        private static List<Depositary.Entities.Relations.Operacion.Transaccion> _eListRelationsTransaccion = new();

        public static List<MonitorEntities.DepositarioMonitor> ObtenerDepositarios(Int64 pUsuarioId, Int64? pDepositarioId = null)
        {
            List<MonitorEntities.DepositarioMonitor> _listadoDepositariosMonitor = new();
            _depositariosAccesibles.Clear();
            MonitorEntities.DepositarioMonitor _depositarioMonitor;

            //Si se especifico un depositario se trae la info de ese solo.
            if (pDepositarioId.HasValue)
            {
                using (Depositary.Business.Relations.Dispositivo.Depositario bRelationsDepositario = new())
                {
                    bRelationsDepositario.Items(pDepositarioId.Value);

                    if (bRelationsDepositario.Result.Count > 0)
                        _depositariosAccesibles.Add(bRelationsDepositario.Result.FirstOrDefault());
                }
            }
            else
            {
                //Obtengo el listado de depositarios que se pueden ver segun el perfil del usuario
                _depositariosAccesibles = ObtenerListadoDepositariosPorPerfil(pUsuarioId);
            }

            foreach (var depositario in _depositariosAccesibles)
            {
                _depositarioMonitor = new();

                Entities.Moneda? monedaPrincipal = ObtenerMonedaPrincipalDepositario(depositario.Id);

                List<Int64>? monedas;
                monedas = new();

                if (monedaPrincipal != null)
                {
                    monedas.Add(monedaPrincipal.Id);
                }

                _eListRelationsTransaccion.Clear();
                _eListRelationsTransaccion = OperacionController.ObtenerTransaccionesPorDepositario(depositario.Id, true, monedas);

                double totalEnBolsa = 0;

                var sector = depositario.SectorId;
                var sucursal = sector.SucursalId;

                _depositarioMonitor.DepositarioId = depositario.Id;
                _depositarioMonitor.Nombre = depositario.Nombre;
                _depositarioMonitor.Descripcion = depositario.Descripcion;
                _depositarioMonitor.Sector = sector.Nombre;
                _depositarioMonitor.Sucursal = sucursal.Nombre;
                _depositarioMonitor.Empresa = sucursal.EmpresaId.Nombre;
                _depositarioMonitor.EmpresaId = sucursal._EmpresaId;
                _depositarioMonitor.NumeroSerie = depositario.NumeroSerie;
                _depositarioMonitor.CodigoExterno = depositario.CodigoExterno;
                _depositarioMonitor.Modelo = depositario.ModeloId.Nombre;
                _depositarioMonitor.Habilitado = depositario.Habilitado;
                _depositarioMonitor.UsuarioCreacion = depositario.UsuarioCreacion.ToString(); //revisar: falta la fk
                _depositarioMonitor.UsuarioModificacion = depositario.UsuarioModificacion.ToString(); //revisar: falta la fk
                _depositarioMonitor.FechaCreacion = depositario.FechaCreacion;
                _depositarioMonitor.FechaModificacion = depositario.FechaModificacion;
                _depositarioMonitor.SemaforoAnomalia = VerificarDepositarioBloqueado(depositario.Id) == true ? "Rojo" : "Verde";
                _depositarioMonitor.SemaforoOnline = VerificarDepositarioEnLinea(depositario.Id, sucursal._EmpresaId);
                Int64? bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario.Id);
                if (bolsaColocada.HasValue)
                    _depositarioMonitor.PorcentajeOcupacionbolsa = OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value, depositario.Id);
                else
                    _depositarioMonitor.PorcentajeOcupacionbolsa = 0;

                //Obtenemos la configuracion de porcentajes de bolsa de la empresa
                string parametroPorcentajeContenedorRojo = AplicacionController.ObtenerConfiguracionEmpresa("PORCENTAJE_CONTENEDOR_ROJO", sucursal._EmpresaId);
                string parametroPorcentajeContenedorAmarillo = AplicacionController.ObtenerConfiguracionEmpresa("PORCENTAJE_CONTENEDOR_AMARILLO", sucursal._EmpresaId);

                double porcentajeContenedorRojo;
                double porcentajeContenedorAmarillo;

                double.TryParse(parametroPorcentajeContenedorAmarillo, out porcentajeContenedorAmarillo);
                double.TryParse(parametroPorcentajeContenedorRojo, out porcentajeContenedorRojo);

                //En funcion del porcentaje de ocupacion de bolsa ponemos el semaforo en rojo, amarillo o verde.
                if (_depositarioMonitor.PorcentajeOcupacionbolsa >= porcentajeContenedorRojo)
                {
                    _depositarioMonitor.SemaforoOcupacionBolsa = "Rojo";
                }
                else if (_depositarioMonitor.PorcentajeOcupacionbolsa >= porcentajeContenedorAmarillo)
                {
                    _depositarioMonitor.SemaforoOcupacionBolsa = "Amarillo";
                }
                else
                    _depositarioMonitor.SemaforoOcupacionBolsa = "Verde";


                if (_eListRelationsTransaccion.Count > 0)
                {
                    totalEnBolsa = _eListRelationsTransaccion.Sum(x => x.TotalAValidar) + _eListRelationsTransaccion.Sum(x => x.TotalValidado);

                    _depositarioMonitor.ValorTotalEnBolsa = ObtenerMonedaPrincipalDepositario(depositario.Id).Codigo + " " + totalEnBolsa.ToString();
                }
                else
                {
                    _depositarioMonitor.ValorTotalEnBolsa = ObtenerMonedaPrincipalDepositario(depositario.Id).Codigo + " 0";
                }

                _listadoDepositariosMonitor.Add(_depositarioMonitor);

            }

            return _listadoDepositariosMonitor;
        }

        public static List<Depositary.Entities.Relations.Dispositivo.Depositario> ObtenerListadoDepositariosPorPerfil(Int64 pUsuarioId)
        {
            List<Depositary.Entities.Relations.Dispositivo.Depositario> _eListRelationsDepositario = new();

            var perfilVisualizacion = VisualizacionController.ObtenerPerfilVisualizacionPorUsuario(pUsuarioId);

            if (perfilVisualizacion != null)
            {
                Int64 tipoPerfilId = new();
                //Verificamos si es un perfil de admin, grupo, empresa, sucursal o sector
                using (Depositary.Business.Relations.Visualizacion.Perfil bRelationsPerfil = new())
                {
                    bRelationsPerfil.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                    bRelationsPerfil.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                    bRelationsPerfil.Items();

                    if (bRelationsPerfil.Result.Count > 0)
                    {
                        tipoPerfilId = bRelationsPerfil.Result.FirstOrDefault()._PerfilTipoId;
                        using (Depositary.Business.Relations.Dispositivo.Depositario bRelationsDepositario = new())
                        {
                            bRelationsDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

                            using (Depositary.Business.Tables.Visualizacion.PerfilTipo bTablesPerfilTipo = new())
                            {
                                bTablesPerfilTipo.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                bTablesPerfilTipo.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, tipoPerfilId);

                                using (Depositary.Business.Tables.Visualizacion.PerfilItem bTablesPerfilItem = new())
                                {
                                    bTablesPerfilItem.Where.Add(Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    bTablesPerfilItem.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, perfilVisualizacion.Id);

                                    switch (tipoPerfilId)
                                    {
                                        case (Int64)VisualizacionEntities.TipoPerfil.NoEspecificado: //0=No especificado
                                            bTablesPerfilTipo.OrderBy.Add(Depositary.Business.Tables.Visualizacion.PerfilTipo.ColumnEnum.EsAdministrador, Depositary.sqlEnum.DirEnum.DESC);
                                            bTablesPerfilTipo.Items();

                                            if (bTablesPerfilTipo.Result.Count > 0)
                                            {
                                                if (bTablesPerfilTipo.Result.FirstOrDefault().EsAdministrador)
                                                {
                                                    _eListRelationsDepositario = bRelationsDepositario.Items();
                                                }
                                            }
                                            break;
                                        case (Int64)VisualizacionEntities.TipoPerfil.Grupo://1=Grupo
                                            _eListRelationsDepositario = bRelationsDepositario.Items();
                                            break;
                                        case (Int64)VisualizacionEntities.TipoPerfil.Empresa://2=Empresa
                                            List<Int64> listadoEmpresasId = new();
                                            bTablesPerfilItem.Items();
                                            foreach (var perfilItem in bTablesPerfilItem.Result)
                                            {
                                                listadoEmpresasId.Add(perfilItem.IdTablaReferencia);
                                            }

                                            if (listadoEmpresasId.Count > 0)
                                            {
                                                using (Depositary.Business.Relations.Directorio.Empresa bRelationsEmpresa = new())
                                                {
                                                    bRelationsEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                                    bRelationsEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoEmpresasId);
                                                    bRelationsEmpresa.Items();
                                                    foreach (var empresa in bRelationsEmpresa.Result)
                                                    {
                                                        foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
                                                        {
                                                            foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                                                            {
                                                                foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                                                {
                                                                    _eListRelationsDepositario.Add(depositario);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case (Int64)VisualizacionEntities.TipoPerfil.Sucursal://3=Sucursal
                                            List<Int64> listadoSucursalesId = new();
                                            bTablesPerfilItem.Items();
                                            foreach (var perfilItem in bTablesPerfilItem.Result)
                                            {
                                                listadoSucursalesId.Add(perfilItem.IdTablaReferencia);
                                            }
                                            if (listadoSucursalesId.Count > 0)
                                            {
                                                using (Depositary.Business.Relations.Directorio.Sucursal bRelationsSucursal = new())
                                                {
                                                    bRelationsSucursal.Where.Add(Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                                    bRelationsSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSucursalesId);
                                                    bRelationsSucursal.Items();
                                                    foreach (var sucursal in bRelationsSucursal.Result)
                                                    {
                                                        foreach (var sector in sucursal.ListOf_Sector_SucursalId)
                                                        {
                                                            foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                                            {
                                                                _eListRelationsDepositario.Add(depositario);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case (Int64)VisualizacionEntities.TipoPerfil.Sector://4=Sector
                                            List<Int64> listadoSectoresId = new();
                                            bTablesPerfilItem.Items();
                                            foreach (var perfilItem in bTablesPerfilItem.Result)
                                            {
                                                listadoSectoresId.Add(perfilItem.IdTablaReferencia);
                                            }
                                            if (listadoSectoresId.Count > 0)
                                            {
                                                using (Depositary.Business.Relations.Directorio.Sector bRelationsSector = new())
                                                {
                                                    bRelationsSector.Where.Add(Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                                    bRelationsSector.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Sector.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, listadoSectoresId);
                                                    bRelationsSector.Items();
                                                    foreach (var sector in bRelationsSector.Result)
                                                    {
                                                        foreach (var depositario in sector.ListOf_Depositario_SectorId)
                                                        {
                                                            _eListRelationsDepositario.Add(depositario);
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return _eListRelationsDepositario;
        }

        public static Entities.Moneda? ObtenerMonedaPrincipalDepositario(Int64 pDepositarioId)
        {
            Entities.Moneda moneda = new();

            using (Depositary.Business.Relations.Dispositivo.Depositario bRelationsDepositario = new())
            {
                bRelationsDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                bRelationsDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);

                bRelationsDepositario.Items();

                if (bRelationsDepositario.Result.Count > 0)
                {
                    moneda = DirectorioController.ObtenerMonedaPrincipalSucursal(bRelationsDepositario.Result.FirstOrDefault().SectorId.SucursalId.Id);
                }
                else
                    return null;
            }

            return moneda;
        }

        public static MonitorEntities.InformacionDepositario ObtenerInformacionDepositario(Int64 pDepositarioId)
        {
            MonitorEntities.InformacionDepositario resultado = new();

            using (Depositary.Business.Relations.Dispositivo.Depositario bRelationsDepositario = new())
            {
                bRelationsDepositario.Where.Add(Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                bRelationsDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);

                bRelationsDepositario.Items();

                if (bRelationsDepositario.Result.Count > 0)
                {
                    var depositario = bRelationsDepositario.Result.FirstOrDefault();

                    resultado.DepositarioId = depositario.Id;
                    resultado.ImagenModelo = depositario.ModeloId.Imagen;
                    resultado.NumeroSerie = depositario.NumeroSerie;

                    resultado.FechaUltimaSincronizacion = ObtenerFechaUltimaSincronizacion(depositario.Id);

                    Int64? bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario.Id);

                    if (bolsaColocada.HasValue)
                    {
                        using (Depositary.Business.Relations.Operacion.Contenedor bRelationsContenedor = new())
                        {
                            bRelationsContenedor.Where.Add(Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                            bRelationsContenedor.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, bolsaColocada.Value);

                            bRelationsContenedor.Items();

                            if (bRelationsContenedor.Result.Count > 0)
                            {
                                var bolsa = bRelationsContenedor.Result.FirstOrDefault();
                                resultado.IdentificadorBolsa = bolsa.Identificador == "" ? bolsa.Nombre : bolsa.Identificador;
                                resultado.CapacidadBilletesBolsa = bolsa.TipoId.Capacidad;
                                resultado.PorcentajeOcupacionBolsa = OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsa.Id, pDepositarioId);
                                resultado.CantidadBilletesEnBolsa = (int)Math.Round(resultado.PorcentajeOcupacionBolsa * resultado.CapacidadBilletesBolsa / 100, MidpointRounding.AwayFromZero);
                            }
                        }
                    }

                    var turno = depositario.ListOf_Turno_DepositarioId.FirstOrDefault(x => x.FechaCierre == null && x.Habilitado == true);
                    if (turno != null)
                    {
                        resultado.Turno = turno.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre;
                        resultado.FechaAperturaTurno = turno.TurnoDepositarioId.Fecha.ToString("dd'/'MM'/'yyyy");
                    }
                    else
                    {
                        resultado.Turno = "-";
                        resultado.FechaAperturaTurno = "-";
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
                            Int64? bolsaColocada = null;
                            foreach (var depositario in depositarios)
                            {
                                bolsaColocada = OperacionController.ObtenerBolsaColocada(depositario);

                                if (bolsaColocada.HasValue)
                                {
                                    if (OperacionController.ObtenerPorcentajeOcupacionBolsa(bolsaColocada.Value, depositario) >= porcentajeMinimoContenedorCasiLleno)
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
                            DateTime? fechaUltimaSincronizacion = null;
                            foreach (var depositario in depositarios)
                            {
                                fechaUltimaSincronizacion = ObtenerFechaUltimaSincronizacion(depositario);

                                if (fechaUltimaSincronizacion.HasValue)
                                {
                                    if ((DateTime.Now - fechaUltimaSincronizacion.Value).TotalSeconds <= tiempoDepositarioEnLineaSegundos)
                                    {
                                        depositariosEnLinea++;
                                    }
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

        public static string VerificarDepositarioEnLinea(Int64 DepositarioId, Int64 EmpresaId)
        {
            string resultado = "Rojo";

            //En esta variable guardo el tiempo en segundos de intervalo para determinar si esta offline
            int tiempoDepositarioEnLineaSegundos = 0;

            string configuracionValor = AplicacionController.ObtenerConfiguracionEmpresa("TIEMPO_DEPOSITARIO_EN_LINEA_SEGUNDOS", EmpresaId);

            if (configuracionValor != "")
            {
                if (int.TryParse(configuracionValor, out tiempoDepositarioEnLineaSegundos))
                {
                    DateTime? fechaUltimaSincronizacion = ObtenerFechaUltimaSincronizacion(DepositarioId);

                    if (fechaUltimaSincronizacion.HasValue)
                    {
                        if ((DateTime.Now - fechaUltimaSincronizacion.Value).TotalSeconds <= tiempoDepositarioEnLineaSegundos)
                        {
                            resultado = "Verde";
                        }
                    }
                }
            }

            return resultado;
        }

        public static bool VerificarDepositarioBloqueado(Int64 DepositarioId)
        {
            bool resultado = false;

            using (Depositary.Business.Tables.Dispositivo.DepositarioEstado bTablesDepositarioEstado = new())
            {
                bTablesDepositarioEstado.Where.Add(Business.Tables.Dispositivo.DepositarioEstado.ColumnEnum.DepositarioId, sqlEnum.OperandEnum.Equal, DepositarioId);
                bTablesDepositarioEstado.TopQuantity = 1;
                bTablesDepositarioEstado.Items();

                if (bTablesDepositarioEstado.Result.Count > 0)
                {
                    var estadoDepositario = bTablesDepositarioEstado.Result.FirstOrDefault();

                    if (estadoDepositario.FueraDeServicio)
                        resultado = true;

                }

                bTablesDepositarioEstado.Dispose();
            }

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
                            DateTime? fechaUltimaSincronizacion = null;
                            foreach (var depositario in depositarios)
                            {
                                fechaUltimaSincronizacion = ObtenerFechaUltimaSincronizacion(depositario);

                                if (fechaUltimaSincronizacion.HasValue)
                                {
                                    if ((DateTime.Now - fechaUltimaSincronizacion.Value).TotalSeconds > tiempoDepositarioEnLineaSegundos)
                                    {
                                        depositarioFueraLinea++;
                                    }
                                }
                                else
                                    depositarioFueraLinea++;
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
                        if (VerificarDepositarioBloqueado(depositario))
                            depositariosFueraServicio++;

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
                    using (Depositary.Business.Tables.Dispositivo.Depositario _bTablesDepositario = new())
                    {

                        _bTablesDepositario.Where.Clear();
                        _bTablesDepositario.Where.Add(Depositary.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                        _bTablesDepositario.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Dispositivo.Depositario.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, depositarios);

                        _bTablesDepositario.Items();

                        if (_bTablesDepositario.Result.Count > 0)
                        {
                            foreach (var depositario in _bTablesDepositario.Result)
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

                        _bTablesDepositario.Dispose();
                    }
                }
            }

            return resultado;
        }

        public static List<Int64> ObtenerListadoDepositariosPorEmpresa(List<Int64> pEmpresas)
        {
            List<Int64> resultado = new();

            using (Depositary.Business.Tables.Directorio.Empresa bTablesEmpresa = new())
            {

                bTablesEmpresa.Where.Add(Business.Tables.Directorio.Empresa.ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, true);
                if (pEmpresas.Count > 0)
                    bTablesEmpresa.Where.Add(sqlEnum.ConjunctionEnum.AND, Business.Tables.Directorio.Empresa.ColumnEnum.Id, sqlEnum.OperandEnum.In, pEmpresas);

                bTablesEmpresa.Items();

                if (bTablesEmpresa.Result.Count > 0)
                {
                    using (Depositary.Business.Tables.Directorio.Sucursal bTablesSucursal = new())
                    {

                        foreach (var empresa in bTablesEmpresa.Result)
                        {
                            bTablesSucursal.Where.Clear();
                            bTablesSucursal.Where.Add(Business.Tables.Directorio.Sucursal.ColumnEnum.EmpresaId, sqlEnum.OperandEnum.Equal, empresa.Id);
                            bTablesSucursal.Items();

                            if (bTablesSucursal.Result.Count > 0)
                            {
                                using (Depositary.Business.Tables.Directorio.Sector bTablesSector = new())
                                {

                                    foreach (var sucursal in bTablesSucursal.Result)
                                    {
                                        bTablesSector.Where.Clear();
                                        bTablesSector.Where.Add(Business.Tables.Directorio.Sector.ColumnEnum.SucursalId, sqlEnum.OperandEnum.Equal, sucursal.Id);
                                        bTablesSector.Items();

                                        if (bTablesSector.Result.Count > 0)
                                        {
                                            using (Depositary.Business.Tables.Dispositivo.Depositario bTablesDepositario = new())
                                            {

                                                foreach (var sector in bTablesSector.Result)
                                                {
                                                    bTablesDepositario.Where.Clear();
                                                    bTablesDepositario.Where.Add(Business.Tables.Dispositivo.Depositario.ColumnEnum.SectorId, sqlEnum.OperandEnum.Equal, sector.Id);

                                                    bTablesDepositario.Items();

                                                    if (bTablesDepositario.Result.Count > 0)
                                                    {
                                                        foreach (var depositario in bTablesDepositario.Result)
                                                            resultado.Add(depositario.Id);
                                                    }
                                                }

                                                bTablesDepositario.Dispose();
                                            }
                                        }
                                    }
                                    bTablesSector.Dispose();
                                }
                            }
                        }
                        bTablesSucursal.Dispose();
                    }
                }

                bTablesEmpresa.Dispose();
            }


            //Depositary.Business.Relations.Directorio.Empresa bRelationsEmpresa = new();
            //bRelationsEmpresa.Where.Add(Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            //if (pEmpresas.Count > 0)
            //    bRelationsEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.In, pEmpresas);

            //bRelationsEmpresa.Items();

            //if (bRelationsEmpresa.Result.Count > 0)
            //{
            //    foreach (var empresa in bRelationsEmpresa.Result)
            //    {
            //        foreach (var sucursal in empresa.ListOf_Sucursal_EmpresaId)
            //        {
            //            foreach (var sector in sucursal.ListOf_Sector_SucursalId)
            //            {
            //                foreach (var depositario in sector.ListOf_Depositario_SectorId.Where(x => x.Habilitado == true))
            //                {
            //                    resultado.Add(depositario.Id);
            //                }
            //            }
            //        }
            //    }
            //}
            return resultado;

        }

        #endregion

        #region Validaciones

        public static string ObtenerValidacionesDepositarioABM(Int64 pDepositarioId, List<Entities.TextoLenguaje> pDataTextos)
        {
            //Por defecto pasa todas las validaciones
            string resultado = "";

            using (Depositary.Business.Relations.Dispositivo.Depositario bRelationsDepositario = new())
            {
                bRelationsDepositario.Where.Add(Business.Relations.Dispositivo.Depositario.ColumnEnum.Id, sqlEnum.OperandEnum.Equal, pDepositarioId);
                bRelationsDepositario.Items();

                if (bRelationsDepositario.Result.Count > 0)
                {
                    if (ObtenerMonedasSucursal(bRelationsDepositario.Result.FirstOrDefault().SectorId._SucursalId).Count == 0)
                    {
                        resultado += MultilenguajeController.ObtenerTextoPorClave("MONEDAS_SIN_ASOCIAR_EN_SUCURSAL", pDataTextos);
                        resultado += "; ";
                    }

                    if (ObtenerMonedasDepositario(pDepositarioId).Count == 0)
                    {
                        resultado += MultilenguajeController.ObtenerTextoPorClave("MONEDAS_SIN_ASOCIAR_EN_DEPOSITARIO", pDataTextos);
                        resultado += ";";
                    }

                    var contadoraDepositario = ObtenerContadoraDepositario(pDepositarioId);

                    if (contadoraDepositario != null)
                    {
                        if (contadoraDepositario.PollTime <= 0)
                        {
                            resultado += MultilenguajeController.ObtenerTextoPorClave("TIEMPO_DE_ENCUESTA_NO_PUEDE_SER_CERO", pDataTextos);
                            resultado += "; ";
                        }

                        if (contadoraDepositario.Sleeptime <= 0)
                        {
                            resultado += MultilenguajeController.ObtenerTextoPorClave("TIEMPO_DE_ESPERA_NO_PUEDE_SER_CERO", pDataTextos);
                            resultado += "; ";
                        }
                    }
                    else
                    {
                        resultado += MultilenguajeController.ObtenerTextoPorClave("FALTA_ASOCIAR_CONTADORA", pDataTextos);
                        resultado += "; ";
                    }

                    var placaDepositario = ObtenerPlacaDepositario(pDepositarioId);

                    if (placaDepositario == null)
                    {
                        resultado += MultilenguajeController.ObtenerTextoPorClave("FALTA_ASOCIAR_PLACA", pDataTextos);
                        resultado += "; ";
                    }

                    //Si existe algun tipo de configuración en la plantilla y que el depositario no tenga habilitada doy error.
                    string validacionConfiguracionesTemplate = "";
                    validacionConfiguracionesTemplate = CompararConfiguracionesTemplateConDepositario(pDepositarioId);

                    if (validacionConfiguracionesTemplate != "")
                    {
                        resultado += MultilenguajeController.ObtenerTextoPorClave("FALTA_ASOCIAR_CONFIGURACIONES_DEPOSITARIO", pDataTextos);
                        resultado += validacionConfiguracionesTemplate;
                        resultado += "; ";
                    }
                }
            }

            return resultado;
        }

        public static string CompararConfiguracionesTemplateConDepositario(Int64 DepositarioId)
        {
            string resultado = "";

            //Evaluamos si todas las configuraciones que estan habilitadas en el template dispuesto por la
            //Tabla Dispositivo.TipoConfiguracionDepositario estan en la tabla Dispositivo.ConfiguracionDepositario

            using (Depositary.Business.Tables.Dispositivo.TipoConfiguracionDepositario bTablesTipoConfiguracionDepositario = new())
            {
                bTablesTipoConfiguracionDepositario.Where.Add(Business.Tables.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, true);
                bTablesTipoConfiguracionDepositario.Items();

                if (bTablesTipoConfiguracionDepositario.Result.Count > 0)
                {
                    foreach (var configuracionTemplate in bTablesTipoConfiguracionDepositario.Result)
                    {
                        using (Depositary.Business.Tables.Dispositivo.ConfiguracionDepositario bTablesConfiguracionDepositario = new())
                        {
                            bTablesConfiguracionDepositario.Where.Add(Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId, sqlEnum.OperandEnum.Equal, DepositarioId);
                            bTablesConfiguracionDepositario.Where.Add(sqlEnum.ConjunctionEnum.AND, Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, configuracionTemplate.Id);
                            bTablesConfiguracionDepositario.Items();

                            //Si no se encuentra la configuracion indicamos el nombre de la misma.
                            if (bTablesConfiguracionDepositario.Result.Count == 0)
                                resultado += configuracionTemplate.Nombre + ", ";
                        }

                    }
                }
            }

            return resultado;
        }

        public static Depositary.Entities.Tables.Dispositivo.DepositarioContadora? ObtenerContadoraDepositario(Int64 pDepositarioId)
        {
            Depositary.Entities.Tables.Dispositivo.DepositarioContadora? resultado = null;

            using (Depositary.Business.Tables.Dispositivo.DepositarioContadora bTablesDepositarioContadora = new())
            {
                bTablesDepositarioContadora.Where.Add(Depositary.Business.Tables.Dispositivo.DepositarioContadora.ColumnEnum.DepositarioId,
                    Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);
                bTablesDepositarioContadora.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,
                    Depositary.Business.Tables.Dispositivo.DepositarioContadora.ColumnEnum.Habilitado,
                  Depositary.sqlEnum.OperandEnum.Equal, true);

                bTablesDepositarioContadora.Items();

                if (bTablesDepositarioContadora.Result.Count > 0)
                {
                    resultado = bTablesDepositarioContadora.Result.FirstOrDefault();
                }
            }

            return resultado;
        }

        public static Depositary.Entities.Tables.Dispositivo.DepositarioPlaca? ObtenerPlacaDepositario(Int64 pDepositarioId)
        {
            Depositary.Entities.Tables.Dispositivo.DepositarioPlaca? resultado = null;

            using (Depositary.Business.Tables.Dispositivo.DepositarioPlaca bTablesDepositarioPlaca = new())
            {
                bTablesDepositarioPlaca.Where.Add(Depositary.Business.Tables.Dispositivo.DepositarioPlaca.ColumnEnum.DepositarioId,
                    Depositary.sqlEnum.OperandEnum.Equal, pDepositarioId);
                bTablesDepositarioPlaca.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,
                    Depositary.Business.Tables.Dispositivo.DepositarioPlaca.ColumnEnum.Habilitado,
                  Depositary.sqlEnum.OperandEnum.Equal, true);

                bTablesDepositarioPlaca.Items();

                if (bTablesDepositarioPlaca.Result.Count > 0)
                {
                    resultado = bTablesDepositarioPlaca.Result.FirstOrDefault();
                }
            }

            return resultado;
        }

        public static List<Depositary.Entities.Tables.Directorio.RelacionMonedaSucursal> ObtenerMonedasSucursal(Int64 pSucursalId, bool SoloHabilitadas = true)
        {
            List<Depositary.Entities.Tables.Directorio.RelacionMonedaSucursal> returnValue = new();

            using (Depositary.Business.Tables.Directorio.RelacionMonedaSucursal _bTablesRelacionMonedaSucursal = new())
            {
                _bTablesRelacionMonedaSucursal.Where.Add(Depositary.Business.Tables.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId,
                    Depositary.sqlEnum.OperandEnum.Equal, pSucursalId);
                if (SoloHabilitadas)
                    _bTablesRelacionMonedaSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,
                        Depositary.Business.Tables.Directorio.RelacionMonedaSucursal.ColumnEnum.Habilitado,
                        Depositary.sqlEnum.OperandEnum.Equal, true);

                _bTablesRelacionMonedaSucursal.Items();

                returnValue = _bTablesRelacionMonedaSucursal.Result;
            }

            return returnValue;

        }

        public static List<Depositary.Entities.Tables.Dispositivo.DepositarioMoneda> ObtenerMonedasDepositario(Int64 DepositarioId)
        {
            List<Depositary.Entities.Tables.Dispositivo.DepositarioMoneda> resultado = new();

            using (Depositary.Business.Tables.Dispositivo.DepositarioMoneda bTablesDepositarioMoneda = new())
            {

                bTablesDepositarioMoneda.Where.Add(Depositary.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.DepositarioId,
                    Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                bTablesDepositarioMoneda.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,
                    Depositary.Business.Tables.Dispositivo.DepositarioMoneda.ColumnEnum.Habilitado,
                    Depositary.sqlEnum.OperandEnum.Equal, true);

                bTablesDepositarioMoneda.Items();

                resultado = bTablesDepositarioMoneda.Result;

            }
            return resultado;
        }

        public static DateTime? ObtenerFechaUltimaSincronizacion(Int64 DepositarioId)
        {
            DateTime? returnValue = null;

            using (Depositary.Business.Tables.Sincronizacion.Ejecucion bTEjecucion = new())
            {
                bTEjecucion.Where.Add(Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.DepositarioId, sqlEnum.OperandEnum.Equal, DepositarioId);
                bTEjecucion.Where.Add(sqlEnum.ConjunctionEnum.AND, Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.Finalizada, sqlEnum.OperandEnum.Equal, true);
                bTEjecucion.OrderBy.Add(Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.FechaInicio, sqlEnum.DirEnum.DESC);
                bTEjecucion.TopQuantity = 1;

                bTEjecucion.Items();

                if (bTEjecucion.Result.Count > 0)
                {
                    returnValue = bTEjecucion.Result.FirstOrDefault().FechaInicio;

                }

                bTEjecucion.Dispose();
            }

            return returnValue;
        }

        public static string GenerarNuevoDepositario(Depositary.Entities.Tables.Dispositivo.Depositario NuevoDepositario)
        {
            string resultado = "";

            //Cargamos el nuevo depositario
            Depositary.Business.Tables.Dispositivo.Depositario depositario = new();
            depositario.BeginTransaction();

            try
            {
                depositario.Add(NuevoDepositario, (long)SeguridadEntities.Aplicacion.AdministradorWeb);

                //Generamos las monedas de la sucursal al depositario
                //Obtenemos la sucursal del nuevo depositario
                Depositary.Business.Tables.Directorio.Sector sector = new();
                sector.Where.Add(Business.Tables.Directorio.Sector.ColumnEnum.Id, sqlEnum.OperandEnum.Equal, NuevoDepositario.SectorId);

                sector.Items();

                if (sector.Result.Count > 0)
                {
                    List<Depositary.Entities.Tables.Directorio.RelacionMonedaSucursal> monedasSucursal;

                    //Obtenemos las monedas de la sucursal del depositario
                    monedasSucursal = ObtenerMonedasSucursal(sector.Result.FirstOrDefault().SucursalId, false);

                    //Si hay monedas en la sucursal..
                    if (monedasSucursal.Count > 0)
                    {
                        Depositary.Business.Tables.Dispositivo.DepositarioMoneda depositarioMoneda = new(depositario);

                        //Las ingresamos en la tabla de monedas para el depositario
                        Depositary.Entities.Tables.Dispositivo.DepositarioMoneda monedaNueva = new();
                        monedaNueva.DepositarioId = NuevoDepositario.Id;
                        monedaNueva.FechaCreacion = DateTime.Now;
                        monedaNueva.UsuarioCreacion = NuevoDepositario.UsuarioCreacion;
                        monedaNueva.IndiceEnContadora = 0; //TODO: Revisar este dato, parece que no se usa.
                        foreach (var moneda in monedasSucursal)
                        {
                            monedaNueva.MonedaId = moneda.MonedaId;
                            monedaNueva.Habilitado = moneda.Habilitado;
                            depositarioMoneda.Add(monedaNueva, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                        }

                    }

                }

                //Generamos las configuraciones para el depositario
                Depositary.Business.Tables.Dispositivo.TipoConfiguracionDepositario tipoConfiguracionDepositario = new();
                tipoConfiguracionDepositario.Items();

                if (tipoConfiguracionDepositario.Result.Count > 0)
                {
                    Depositary.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new(depositario);
                    Depositary.Entities.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositarioNuevo = new();
                    configuracionDepositarioNuevo.DepositarioId = NuevoDepositario.Id;
                    configuracionDepositarioNuevo.FechaCreacion = DateTime.Now;
                    configuracionDepositarioNuevo.UsuarioCreacion = NuevoDepositario.UsuarioCreacion;
                    foreach (var configuracion in tipoConfiguracionDepositario.Result)
                    {
                        configuracionDepositarioNuevo.Valor = configuracion.Valor;
                        configuracionDepositarioNuevo.TipoId = configuracion.Id;
                        configuracionDepositarioNuevo.Habilitado = configuracion.Habilitado;

                        configuracionDepositario.Add(configuracionDepositarioNuevo, (long)SeguridadEntities.Aplicacion.AdministradorWeb);
                    }

                }

                depositario.EndTransaction(true);
            }
            catch (Exception ex)
            {
                depositario.EndTransaction(false);
                AuditController.Log(ex, NuevoDepositario.UsuarioCreacion);
                resultado = ex.Message;
            }

            return resultado;
        }

        #endregion
    }
}
