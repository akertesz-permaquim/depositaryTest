namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class TurnoController
    {
        public static List<TurnoEntities.GrupoTurno> ObtenerArbolTurnos()
        {
            List<TurnoEntities.GrupoTurno> resultado = new();

            //1°Obtenemos todas las empresas
            DepositarioAdminWeb.Business.Relations.Directorio.Grupo oGrupo = new();

            oGrupo.Items();

            if (oGrupo.Result.Count > 0)
            {
                //1° Obtenemos los grupos 
                foreach (var grupo in oGrupo.Result)
                {
                    TurnoEntities.GrupoTurno grupoTurno = new();
                    grupoTurno.GrupoId = grupo.Id;
                    grupoTurno.GrupoNombre = grupo.Nombre;
                    var empresas = grupo.ListOf_Empresa_GrupoId;
                    if (empresas != null)
                    {
                        foreach (var empresa in empresas)
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
                                        }
                                    }
                                    empresaTurno.Sucursales.Add(sucursalTurno);
                                }
                            }
                            grupoTurno.Empresas.Add(empresaTurno);

                        }
                    }
                    resultado.Add(grupoTurno);
                }
            }

            return resultado;
        }

        public static string GuardarAgenda(TurnoEntities.AgendaTurnoABM pAgendaTurnoABM)
        {
            string resultado = "";

            //Primero hay que ver cuantos detalles de esquema tiene el esquema seleccionado
            DepositarioAdminWeb.Business.Tables.Turno.EsquemaDetalleTurno oEsquemaDetalleTurno = new();
            oEsquemaDetalleTurno.Where.Add(DepositarioAdminWeb.Business.Tables.Turno.EsquemaDetalleTurno.ColumnEnum.EsquemaTurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pAgendaTurnoABM.EsquemaTurnoId);
            oEsquemaDetalleTurno.Items();

            if (oEsquemaDetalleTurno.Result.Count > 0)
            {
                foreach (var esquemaDetalle in oEsquemaDetalleTurno.Result)
                {
                    //Segundo tenemos que hacer un ingreso por cada sector seleccionado
                    foreach (var sector in pAgendaTurnoABM.Sectores)
                    {
                        DateTime auxFecha = pAgendaTurnoABM.FechaDesde;
                        //Tercero tenemos que hacer un insert por cada dia del periodo fecha desde - fecha hasta
                        for (int i = 0; auxFecha <= pAgendaTurnoABM.FechaHasta; auxFecha = auxFecha.AddDays(1))
                        {
                            DepositarioAdminWeb.Business.Tables.Turno.AgendaTurno oAgendaTurno = new();
                            oAgendaTurno.Where.Add(DepositarioAdminWeb.Business.Tables.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, esquemaDetalle.Id);
                            oAgendaTurno.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Turno.AgendaTurno.ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, auxFecha);
                            oAgendaTurno.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Turno.AgendaTurno.ColumnEnum.Secuencia, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, esquemaDetalle.Secuencia);
                            oAgendaTurno.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Tables.Turno.AgendaTurno.ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, sector.SectorId);
                            oAgendaTurno.Items();

                            //Solo agrego la agenda si no existia previamente una para esa fecha, ese sector, ese detalle y esa secuencia.
                            if (oAgendaTurno.Result.Count == 0)
                            {
                                try
                                {
                                    oAgendaTurno.Add(pAgendaTurnoABM.NombreAgenda, esquemaDetalle.Id, auxFecha, sector.SectorId, esquemaDetalle.Secuencia, pAgendaTurnoABM.UsuarioId, DateTime.Now, null, null, true);
                                }
                                catch (Exception ex)
                                {
                                    resultado = ex.Message;
                                }
                            }
                        }
                    }
                }
            }

            return resultado;
        }
    }
}
