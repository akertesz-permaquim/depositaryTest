using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ValorModel : IModel
    {
        public List<Depositario.Entities.Tables.Valor.Moneda> Monedas { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Denominacion> Denominaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.Tipo> Tipos { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.RelacionMonedaTipoValor> RelacionesMonedasTiposValores { get; set; } = new();
        public List<Depositario.Entities.Tables.Valor.OrigenValor> OrigenesValores { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;


        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipo = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Valor_Tipo);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Valor_Tipo).Replace("_", "."), fechaSincroTipo);

            DateTime fechaSincroMoneda = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Valor_Moneda);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Valor_Moneda).Replace("_", "."), fechaSincroMoneda);

            DateTime fechaSincroDenominacion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Valor_Denominacion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Valor_Denominacion).Replace("_", "."), fechaSincroDenominacion);

            DateTime fechaSincroRelacionMonedaTipoValor = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor).Replace("_", "."), fechaSincroRelacionMonedaTipoValor);

            DateTime fechaSincroOrigenValor = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Valor_OrigenValor);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Valor_OrigenValor).Replace("_", "."), fechaSincroOrigenValor);

        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (Tipos.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Tipo tipo = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Tipo, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Tipos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Tipo, item.Id);
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
                                    tipo.Update(item);
                                }
                                else
                                {
                                    tipo.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (OrigenesValores.Count > 0)
                {
                    Depositario.Business.Tables.Valor.OrigenValor origenValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_OrigenValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? empresaIdOrigen;
                        foreach (var item in OrigenesValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_OrigenValor, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);

                            if (empresaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.EmpresaId = empresaIdOrigen.Value;
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
                                    origenValor.Update(item);
                                }
                                else
                                {
                                    origenValor.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Monedas.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Moneda moneda = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Moneda, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? paisIdOrigen;
                        foreach (var item in Monedas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Geografia_Pais, item.PaisId);

                            if (paisIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PaisId = paisIdOrigen.Value;
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
                                    moneda.Update(item);
                                }
                                else
                                {
                                    moneda.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Denominaciones.Count > 0)
                {
                    Depositario.Business.Tables.Valor.Denominacion denominacion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_Denominacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoValorIdOrigen;
                        Int64? monedaIdOrigen;
                        foreach (var item in Denominaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Denominacion, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Tipo, item.TipoValorId);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (tipoValorIdOrigen.HasValue && monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoValorId = tipoValorIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;
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
                                    denominacion.Update(item);
                                }
                                else
                                {
                                    denominacion.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (RelacionesMonedasTiposValores.Count > 0)
                {
                    Depositario.Business.Tables.Valor.RelacionMonedaTipoValor relacionMonedaTipoValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoValorIdOrigen;
                        Int64? monedaIdOrigen;
                        foreach (var item in RelacionesMonedasTiposValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_RelacionMonedaTipoValor, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoValorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Tipo, item.TipoValorId);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);

                            if (tipoValorIdOrigen.HasValue && monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoValorId = tipoValorIdOrigen.Value;
                                item.MonedaId = monedaIdOrigen.Value;
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
                                    relacionMonedaTipoValor.Update(item);
                                }
                                else
                                {
                                    relacionMonedaTipoValor.Add(item);
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
