﻿using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class GeografiaModel : IModel
    {
        public List<Depositario.Entities.Tables.Geografia.Pais> Paises { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Provincia> Provincias { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Ciudad> Ciudades { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.CodigoPostal> CodigosPostales { get; set; } = new();
        public List<Depositario.Entities.Tables.Geografia.Zona> Zonas { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroPais = SynchronizationController.obtenerFechaUltimaSincronizacion("Geografia.Pais");

            SincroDates.Add("Geografia.Pais", fechaSincroPais);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroProvincia = SynchronizationController.obtenerFechaUltimaSincronizacion("Geografia.Provincia");

            SincroDates.Add("Geografia.Provincia", fechaSincroProvincia);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroCiudad = SynchronizationController.obtenerFechaUltimaSincronizacion("Geografia.Ciudad");

            SincroDates.Add("Geografia.Ciudad", fechaSincroCiudad);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroCodigoPostal = SynchronizationController.obtenerFechaUltimaSincronizacion("Geografia.CodigoPostal");

            SincroDates.Add("Geografia.CodigoPostal", fechaSincroCodigoPostal);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroZona = SynchronizationController.obtenerFechaUltimaSincronizacion("Geografia.Zona");

            SincroDates.Add("Geografia.Zona", fechaSincroZona);

        }

        public void Persist()
        {
            try
            {
                if (Paises.Count > 0)
                {
                    Depositario.Business.Tables.Geografia.Pais pais = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Geografia.Pais");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Paises)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Pais", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                pais.Update(item);
                            }
                            else
                            {
                                pais.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }


                if (Provincias.Count > 0)
                {
                    Depositario.Business.Tables.Geografia.Provincia provincia = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Geografia.Provincia");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Provincias)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Provincia", item.Id);

                            Int64? paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Pais", item.PaisId);

                            if (paisIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PaisId = paisIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    provincia.Update(item);
                                }
                                else
                                {
                                    provincia.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Ciudades.Count > 0)
                {
                    Depositario.Business.Tables.Geografia.Ciudad ciudad = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Geografia.Ciudad");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Ciudades)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Ciudad", item.Id);

                            Int64? provinciaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Provincia", item.ProvinciaId);

                            if (provinciaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.ProvinciaId = provinciaIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    ciudad.Update(item);
                                }
                                else
                                {
                                    ciudad.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (CodigosPostales.Count > 0)
                {
                    Depositario.Business.Tables.Geografia.Ciudad ciudad = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Geografia.CodigoPostal");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in CodigosPostales)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.CodigoPostal", item.Id);

                            Int64? ciudadIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Ciudad", item.CiudadId);

                            if (ciudadIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.CiudadId = ciudadIdOrigen.Value;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    ciudad.Update(item);
                                }
                                else
                                {
                                    ciudad.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Zonas.Count > 0)
                {
                    Depositario.Business.Tables.Geografia.Pais pais = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Geografia.Zona");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Zonas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Zona", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

                            //Si se sincronizo antes entonces hago un update con el id propio.
                            if (idDestino.HasValue)
                            {
                                item.Id = idDestino.Value;
                                pais.Update(item);
                            }
                            else
                            {
                                pais.Add(item);
                            }

                            SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
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