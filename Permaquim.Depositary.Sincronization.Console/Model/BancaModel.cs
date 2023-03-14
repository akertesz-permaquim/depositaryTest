using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class BancaModel : IModel
    {
        public List<Depositario.Entities.Tables.Banca.TipoCuenta> TiposCuenta { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Banco> Bancos { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.Cuenta> Cuentas { get; set; } = new();
        public List<Depositario.Entities.Tables.Banca.UsuarioCuenta> UsuariosCuenta { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroBanco = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Banca_Banco);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Banca_Banco).Replace("_", "."), fechaSincroBanco);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroCuenta = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Banca_Cuenta);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Banca_Cuenta).Replace("_", "."), fechaSincroCuenta);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoCuenta = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Banca_TipoCuenta);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Banca_TipoCuenta).Replace("_", "."), fechaSincroTipoCuenta);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroUsuarioCuenta = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Banca_UsuarioCuenta);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Banca_UsuarioCuenta).Replace("_", "."), fechaSincroUsuarioCuenta);

        }
        public void Persist()
        {
            try
            {
                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposCuenta.Count > 0)
                {
                    Depositario.Business.Tables.Banca.TipoCuenta tipoCuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_TipoCuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? monedaIdOrigen;
                        foreach (var item in TiposCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_TipoCuenta, item.Id);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Valor_Moneda, item.MonedaId);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);

                            if (monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

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
                                    tipoCuenta.Update(item);
                                }
                                else
                                {
                                    tipoCuenta.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Bancos.Count > 0)
                {
                    Depositario.Business.Tables.Banca.Banco banco = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_Banco, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? paisIdOrigen;
                        foreach (var item in Bancos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_Banco, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Geografia_Pais, item.PaisId);

                            if (paisIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
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
                                    banco.Update(item);
                                }
                                else
                                {
                                    banco.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Cuentas.Count > 0)
                {
                    Depositario.Business.Tables.Banca.Cuenta cuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_Cuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoCuentaIdOrigen;
                        Int64? empresaIdOrigen;
                        Int64? bancoIdOrigen;
                        foreach (var item in Cuentas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_Cuenta, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoCuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_TipoCuenta, item.TipoId);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            bancoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_Banco, item.BancoId);


                            if (bancoIdOrigen.HasValue && tipoCuentaIdOrigen.HasValue && empresaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoCuentaIdOrigen.Value;
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.BancoId = bancoIdOrigen.Value;
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
                                    cuenta.Update(item);
                                }
                                else
                                {
                                    cuenta.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosCuenta.Count > 0)
                {
                    Depositario.Business.Tables.Banca.UsuarioCuenta usuarioCuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Banca_UsuarioCuenta, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? cuentaIdOrigen;
                        foreach (var item in UsuariosCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_UsuarioCuenta, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            cuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Banca_Cuenta, item.CuentaId);


                            if (usuarioIdOrigen.HasValue && cuentaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.UsuarioId = usuarioIdOrigen.Value;
                                item.CuentaId = cuentaIdOrigen.Value;
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
                                    usuarioCuenta.Update(item);
                                }
                                else
                                {
                                    usuarioCuenta.Add(item);
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
