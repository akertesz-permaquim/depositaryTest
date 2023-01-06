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
        void IModel.Process()
        {

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroBanco = SynchronizationController.obtenerFechaUltimaSincronizacion("Banca.Banco");

            SincroDates.Add("Banca.Banco", fechaSincroBanco);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroCuenta = SynchronizationController.obtenerFechaUltimaSincronizacion("Banca.Cuenta");

            SincroDates.Add("Banca.Cuenta", fechaSincroCuenta);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoCuenta = SynchronizationController.obtenerFechaUltimaSincronizacion("Banca.TipoCuenta");

            SincroDates.Add("Banca.TipoCuenta", fechaSincroTipoCuenta);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroUsuarioCuenta = SynchronizationController.obtenerFechaUltimaSincronizacion("Banca.UsuarioCuenta");

            SincroDates.Add("Banca.UsuarioCuenta", fechaSincroUsuarioCuenta);

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

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Banca.TipoCuenta");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? monedaIdOrigen;
                        foreach (var item in TiposCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.TipoCuenta", item.Id);
                            monedaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Valor.Moneda", item.MonedaId);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (monedaIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                item.MonedaId = monedaIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Bancos.Count > 0)
                {
                    Depositario.Business.Tables.Banca.Banco banco = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Banca.Banco");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? paisIdOrigen;
                        foreach (var item in Bancos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Banco", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            paisIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Geografia.Pais", item.PaisId);

                            if (paisIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.PaisId = paisIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Cuentas.Count > 0)
                {
                    Depositario.Business.Tables.Banca.Cuenta cuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Banca.Cuenta");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoCuentaIdOrigen;
                        Int64? empresaIdOrigen;
                        Int64? bancoIdOrigen;
                        foreach (var item in Cuentas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Cuenta", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            tipoCuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.TipoCuenta", item.TipoId);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);
                            bancoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Banco", item.BancoId);


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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
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

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosCuenta.Count > 0)
                {
                    Depositario.Business.Tables.Banca.UsuarioCuenta usuarioCuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Banca.UsuarioCuenta");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? cuentaIdOrigen;
                        foreach (var item in UsuariosCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.UsuarioCuenta", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioId);
                            cuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Cuenta", item.CuentaId);


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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
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
