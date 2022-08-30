﻿using Permaquim.Depositary.Sincronization.Console.Interfaces;
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

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroGrupo = SynchronizationController.obtenerFechaUltimaSincronizacion("Directorio.Grupo");

            SincroDates.Add("Directorio.Grupo", fechaSincroGrupo);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroEmpresa = SynchronizationController.obtenerFechaUltimaSincronizacion("Directorio.Empresa");

            SincroDates.Add("Directorio.Empresa", fechaSincroEmpresa);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroSucursal = SynchronizationController.obtenerFechaUltimaSincronizacion("Directorio.Sucursal");

            SincroDates.Add("Directorio.Sucursal", fechaSincroSucursal);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroSector = SynchronizationController.obtenerFechaUltimaSincronizacion("Directorio.Sector");

            SincroDates.Add("Directorio.Sector", fechaSincroSector);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroRelacionMonedaSucursal = SynchronizationController.obtenerFechaUltimaSincronizacion("Directorio.RelacionMonedaSucursal");

            SincroDates.Add("Directorio.RelacionMonedaSucursal", fechaSincroRelacionMonedaSucursal);
        }

        public void Persist()
        {
            try
            {
                if (Grupos.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Grupo grupo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Directorio.Grupo");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Grupos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Grupo", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

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

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Empresas.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Empresa empresa = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Directorio.Empresa");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Empresas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.Id);

                            Int64? grupoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Grupo", item.GrupoId);
                            Int64? estiloEsquemaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Estilo.Esquema", item.EstiloEsquemaId);
                            Int64? lenguajeIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Regionalizacion.Lenguaje", item.LenguajeId);

                            if (grupoIdOrigen.HasValue && estiloEsquemaIdOrigen.HasValue && lenguajeIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.GrupoId = grupoIdOrigen.Value;
                                item.EstiloEsquemaId = estiloEsquemaIdOrigen.Value;
                                item.LenguajeId = lenguajeIdOrigen.Value;

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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Sucursales.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Sucursal sucursal = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Directorio.Sucursal");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Sucursales)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sucursal", item.Id);

                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);
                            Int64? codigoPostalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.CodigoPostal", item.CodigoPostalId);
                            Int64? zonaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Zona", item.ZonaId);

                            if (empresaIdOrigen.HasValue && codigoPostalIdOrigen.HasValue && zonaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.CodigoPostalId = codigoPostalIdOrigen.Value;
                                item.ZonaId = zonaIdOrigen.Value;

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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Sectores.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.Sector sector = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Directorio.Sector");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Sectores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sector", item.Id);

                            Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sucursal", item.SucursalId);

                            if (sucursalIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.SucursalId = sucursalIdOrigen.Value;

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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (RelacionesMonedasSucursales.Count > 0)
                {
                    Depositario.Business.Tables.Directorio.RelacionMonedaSucursal relacionMonedaSucursal = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Directorio.RelacionMonedaSucursal");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in RelacionesMonedasSucursales)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.RelacionMonedaSucursal", item.Id);

                            Int64? monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);
                            Int64? sucursalIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sucursal", item.SucursalId);

                            if (monedaIdOrigen.HasValue && sucursalIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.MonedaId = monedaIdOrigen.Value;
                                item.SucursalId = sucursalIdOrigen.Value;

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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
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