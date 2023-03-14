using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class DirectorioModel : IModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Grupo> Grupos { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Empresa> Empresas { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sucursal> Sucursales { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.Sector> Sectores { get; set; } = new();
        public List<Depositario.Entities.Tables.Directorio.RelacionMonedaSucursal> RelacionesMonedasSucursales { get; set; } = new();
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroGrupo = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Directorio_Grupo);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Directorio_Grupo).Replace("_", "."), fechaSincroGrupo);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEmpresa = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Directorio_Empresa);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Directorio_Empresa).Replace("_", "."), fechaSincroEmpresa);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroSucursal = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Directorio_Sucursal);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Directorio_Sucursal).Replace("_", "."), fechaSincroSucursal);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroSector = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Directorio_Sector);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Directorio_Sector).Replace("_", "."), fechaSincroSector);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroRelacionMonedaSucursal = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Directorio_RelacionMonedaSucursal);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Directorio_RelacionMonedaSucursal).Replace("_", "."), fechaSincroRelacionMonedaSucursal);
        }

        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (Grupos.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Grupo grupo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Grupo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Grupos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Grupo, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    grupo.Update(item);
                                }
                                else
                                {
                                    grupo.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Empresas.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Empresa empresa = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Empresa, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? grupoIdOrigen;
                        Int64? estiloEsquemaIdOrigen;
                        Int64? lenguajeIdOrigen;
                        Int64? codigoPostalIdOrigen;
                        foreach (var item in Empresas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            grupoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Grupo, item.GrupoId);
                            estiloEsquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Estilo_Esquema, item.EstiloEsquemaId);
                            lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);
                            codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Geografia_CodigoPostal, item.CodigoPostalId);

                            if (grupoIdOrigen.HasValue && estiloEsquemaIdOrigen.HasValue && lenguajeIdOrigen.HasValue && codigoPostalIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.GrupoId = grupoIdOrigen.Value;
                                item.EstiloEsquemaId = estiloEsquemaIdOrigen.Value;
                                item.LenguajeId = lenguajeIdOrigen.Value;
                                item.CodigoPostalId = codigoPostalIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    empresa.Update(item);
                                }
                                else
                                {
                                    empresa.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Sucursales.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Sucursal sucursal = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Sucursal, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? empresaIdOrigen;
                        Int64? codigoPostalIdOrigen;
                        Int64? zonaIdOrigen;
                        foreach (var item in Sucursales)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sucursal, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Geografia_CodigoPostal, item.CodigoPostalId);
                            zonaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Geografia_Zona, item.ZonaId);

                            if (empresaIdOrigen.HasValue && codigoPostalIdOrigen.HasValue && zonaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.CodigoPostalId = codigoPostalIdOrigen.Value;
                                item.ZonaId = zonaIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    sucursal.Update(item);
                                }
                                else
                                {
                                    sucursal.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Sectores.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Sector sector = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_Sector, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? sucursalIdOrigen;
                        foreach (var item in Sectores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sucursal, item.SucursalId);

                            if (sucursalIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.SucursalId = sucursalIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    sector.Update(item);
                                }
                                else
                                {
                                    sector.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (RelacionesMonedasSucursales.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.RelacionMonedaSucursal relacionMonedaSucursal = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Directorio_RelacionMonedaSucursal, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? monedaIdOrigen;
                        Int64? sucursalIdOrigen;
                        foreach (var item in RelacionesMonedasSucursales)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_RelacionMonedaSucursal, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);
                            sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sucursal, item.SucursalId);

                            if (monedaIdOrigen.HasValue && sucursalIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.MonedaId = monedaIdOrigen.Value;
                                item.SucursalId = sucursalIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    relacionMonedaSucursal.Update(item);
                                }
                                else
                                {
                                    relacionMonedaSucursal.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
