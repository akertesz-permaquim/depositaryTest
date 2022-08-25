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
                if (TiposCuenta.Count > 0)
                {
                    Depositario.Business.Tables.Banca.TipoCuenta tipoCuenta = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Banca.TipoCuenta");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.TipoCuenta", item.Id);

                            //Guardo el id que venia del server.
                            Int64 origenId = item.Id;

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
                        foreach (var item in Bancos)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Banco", item.Id);

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
                        foreach (var item in Cuentas)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Cuenta", item.Id);

                            Int64? tipoCuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.TipoCuenta", item.TipoId);
                            Int64? empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);
                            Int64? bancoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Banco", item.BancoId);


                            if (bancoIdOrigen.HasValue && tipoCuentaIdOrigen.HasValue && empresaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoCuentaIdOrigen.Value;
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.BancoId = bancoIdOrigen.Value;

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
                        foreach (var item in UsuariosCuenta)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            Int64? idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.UsuarioCuenta", item.Id);

                            Int64? usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioId);
                            Int64? cuentaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Banca.Cuenta", item.CuentaId);


                            if (usuarioIdOrigen.HasValue && cuentaIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                Int64 origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.UsuarioId = usuarioIdOrigen.Value;
                                item.CuentaId = cuentaIdOrigen.Value;

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
