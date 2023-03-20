using Permaquim.Depositary.Web.Administration.TurnoEntities;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class TurnoController
    {
        public static List<TurnoEntities.GrupoTurno> ObtenerArbolTurnos(bool OperaSinTurno)
        {
            List<TurnoEntities.GrupoTurno> resultado = new();

            bool generacionSectores = false;

            //1°Obtenemos todas las empresas
            Depositary.Business.Relations.Directorio.Grupo oGrupo = new();

            oGrupo.Items();

            if (oGrupo.Result.Count > 0)
            {
                //1° Obtenemos los grupos 
                foreach (var grupo in oGrupo.Result)
                {
                    TurnoEntities.GrupoTurno grupoTurno = new();
                    grupoTurno.GrupoId = grupo.Id;
                    grupoTurno.GrupoNombre = grupo.Nombre;
                    //Tomamos las empresas segun si se pide que operen con o sin turno.
                    var empresas = grupo.ListOf_Empresa_GrupoId;
                    if (empresas != null)
                    {
                        //En funcion del parametro, me quedo con las que trabajan con o sin turno.

                        foreach (var empresa in empresas)
                        {
                            var parametroOperarSinTurno = empresa.ListOf_ConfiguracionEmpresa_EmpresaId.FirstOrDefault(x => x.Clave == "OPERA_SIN_TURNO");

                            if (parametroOperarSinTurno != null)
                            {
                                bool conversionParametro;
                                if (bool.TryParse(parametroOperarSinTurno.Valor, out conversionParametro))
                                {
                                    if (conversionParametro == OperaSinTurno)
                                    {
                                        //2° Obtenemos para cada grupo sus empresas
                                        TurnoEntities.EmpresaTurno empresaTurno = new();
                                        empresaTurno.EmpresaNombre = empresa.Nombre;
                                        empresaTurno.EmpresaId = empresa.Id;
                                        var sucursales = empresa.ListOf_Sucursal_EmpresaId;
                                        if (sucursales != null)
                                        {
                                            foreach (var sucursal in sucursales)
                                            {
                                                //3° Obtenemos para cada empresa sus sucursales
                                                TurnoEntities.SucursalTurno sucursalTurno = new();
                                                sucursalTurno.SucursalNombre = sucursal.Nombre;
                                                sucursalTurno.SucursalId = sucursal.Id;

                                                var sectores = sucursal.ListOf_Sector_SucursalId;

                                                if (sectores != null)
                                                {
                                                    foreach (var sector in sectores)
                                                    {
                                                        //4° Obtenemos para cada sucursal sus sectores
                                                        TurnoEntities.SectorTurno sectorTurno = new();
                                                        sectorTurno.SectorNombre = sector.Nombre;
                                                        sectorTurno.SectorId = sector.Id;
                                                        sucursalTurno.Sectores.Add(sectorTurno);
                                                        if (!generacionSectores)
                                                            generacionSectores = true;
                                                    }
                                                }
                                                empresaTurno.Sucursales.Add(sucursalTurno);
                                            }
                                        }
                                        grupoTurno.Empresas.Add(empresaTurno);
                                    }
                                }
                            }
                        }
                    }
                    resultado.Add(grupoTurno);
                }


                //Si no se agregaron sectores, limpiamos el dataset ya que se necesitan sectores para operar.
                if (!generacionSectores)
                    resultado.Clear();
            }


            return resultado;
        }

        public static bool ValidarExistenciaTurnos(TurnoEntities.AgendaTurnoABM pAgendaTurnoABM)
        {
            DateTime fechaDesdeFormateada = new DateTime(pAgendaTurnoABM.FechaDesde.Year, pAgendaTurnoABM.FechaDesde.Month, pAgendaTurnoABM.FechaDesde.Day, 0, 0, 0);
            DateTime fechaHastaFormateada = new DateTime(pAgendaTurnoABM.FechaDesde.Year, pAgendaTurnoABM.FechaDesde.Month, pAgendaTurnoABM.FechaDesde.Day, 23, 59, 59);

            //Verificamos sector por sector de los seleccionados.
            foreach (var sector in pAgendaTurnoABM.Sectores)
            {
                Depositary.Business.Tables.Turno.AgendaTurno oAgendaTurno = new();
                oAgendaTurno.Where.Add(Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Between, fechaDesdeFormateada, fechaHastaFormateada);
                oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, Depositary.sqlEnum.OperandEnum.Equal, sector.SectorId);

                oAgendaTurno.Items();

                if (oAgendaTurno.Result.Count > 0)
                {
                    return true;
                }
            }

            return false; //Si se llega hasta aca no existen turnos.
        }

        public static bool ValidarExistenciaTurnos(Int64 sectorId, DateTime fecha)
        {
            DateTime fechaDesdeFormateada = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime fechaHastaFormateada = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);


            Depositary.Business.Tables.Turno.AgendaTurno oAgendaTurno = new();
            oAgendaTurno.Where.Add(Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Between, fechaDesdeFormateada, fechaHastaFormateada);
            oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, Depositary.sqlEnum.OperandEnum.Equal, sectorId);

            oAgendaTurno.Items();

            if (oAgendaTurno.Result.Count > 0)
            {
                return true;
            }

            return false; //Si se llega hasta aca no existen turnos.
        }

        public static async Task<string> GuardarAgenda(TurnoEntities.AgendaTurnoABM pAgendaTurnoABM, bool diasCorridos)
        {
            string resultado = "";

            //Primero hay que ver cuantos detalles de esquema tiene el esquema seleccionado
            Depositary.Business.Tables.Turno.EsquemaDetalleTurno oEsquemaDetalleTurno = new();
            oEsquemaDetalleTurno.Where.Add(Depositary.Business.Tables.Turno.EsquemaDetalleTurno.ColumnEnum.EsquemaTurnoId, Depositary.sqlEnum.OperandEnum.Equal, pAgendaTurnoABM.EsquemaTurnoId);
            oEsquemaDetalleTurno.Items();

            if (oEsquemaDetalleTurno.Result.Count > 0)
            {
                Depositary.Business.Tables.Turno.AgendaTurno oAgendaTurno = new();
                try
                {
                    oAgendaTurno.BeginTransaction();
                    foreach (var esquemaDetalle in oEsquemaDetalleTurno.Result)
                    {
                        //Segundo tenemos que hacer un ingreso por cada sector seleccionado
                        foreach (var sector in pAgendaTurnoABM.Sectores)
                        {
                            DateTime auxFecha = pAgendaTurnoABM.FechaDesde;
                            //Tercero tenemos que hacer un insert por cada dia del periodo fecha desde - fecha hasta
                            for (int i = 0; auxFecha <= pAgendaTurnoABM.FechaHasta; auxFecha = auxFecha.AddDays(1))
                            {
                                //Si se indica solo dias corridos se insertan valores para todos los dias, caso contrario se insertan solo lun-vier.
                                if (diasCorridos == true || (diasCorridos == false && auxFecha.DayOfWeek != DayOfWeek.Saturday && auxFecha.DayOfWeek != DayOfWeek.Sunday))
                                {
                                    oAgendaTurno.Where.Clear();
                                    oAgendaTurno.Where.Add(Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId, Depositary.sqlEnum.OperandEnum.Equal, esquemaDetalle.Id);
                                    oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                                    oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, auxFecha);
                                    oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.Secuencia, Depositary.sqlEnum.OperandEnum.Equal, esquemaDetalle.Secuencia);
                                    oAgendaTurno.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, Depositary.sqlEnum.OperandEnum.Equal, sector.SectorId);
                                    oAgendaTurno.Items();

                                    //Solo agrego la agenda si no existia previamente una para esa fecha, ese sector, ese detalle y esa secuencia.
                                    if (oAgendaTurno.Result.Count == 0)
                                    {
                                        DateTime fechaTurno = new(auxFecha.Year, auxFecha.Month, auxFecha.Day, 0, 0, 0);
                                        string nombreAgenda = pAgendaTurnoABM.NombreAgenda + " - " + fechaTurno.Date.ToString("dd/MM/yyyy") + " - " + esquemaDetalle.Nombre;
                                        oAgendaTurno.Add(nombreAgenda, esquemaDetalle.Id, fechaTurno, sector.SectorId, esquemaDetalle.Secuencia, pAgendaTurnoABM.UsuarioId, DateTime.Now, null, null, true);
                                    }
                                }
                            }
                        }
                    }

                    oAgendaTurno.EndTransaction(true);
                }
                catch (Exception ex)
                {
                    oAgendaTurno.EndTransaction(false);
                    AuditController.Log(ex, pAgendaTurnoABM.UsuarioId);
                    resultado = ex.Message;
                }
            }

            return resultado;
        }

        public static bool ValidarDeshabilitadoTurno(Int64 sectorId, DateTime fechaTurno)
        {
            bool resultado = false;

            //Verificamos que el turno que se quiere deshabilitar no sea anterior o de la misma fecha respecto del turno abierto o del ultimo turno procesado.
            Depositary.Business.Tables.Operacion.Turno oTurno = new();
            oTurno.Where.Add(Depositary.Business.Tables.Operacion.Turno.ColumnEnum.SectorId, Depositary.sqlEnum.OperandEnum.Equal, sectorId);
            oTurno.Where.Add(sqlEnum.ConjunctionEnum.AND,Depositary.Business.Tables.Operacion.Turno.ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaTurno);
            oTurno.Items();

            if (oTurno.Result.Count == 0)
                resultado = true;

            return resultado;
        }
    }
}
