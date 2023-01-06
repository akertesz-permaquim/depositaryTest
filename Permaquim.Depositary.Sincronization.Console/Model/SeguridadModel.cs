using Permaquim.Depositary.Sincronization.Console.Interfaces;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class SeguridadModel : IModel
    {
        public List<Depositario.Entities.Tables.Seguridad.TipoAplicacion> TiposAplicaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Aplicacion> Aplicaciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametro> AplicacionesParametros { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.AplicacionParametroValor> AplicacionesParametrosValores { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoFuncion> TiposFunciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoMenu> TiposMenues { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Rol> Roles { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Funcion> Funciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.RolFuncion> RolesFunciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Menu> Menues { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.Usuario> Usuarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioRol> UsuariosRoles { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.UsuarioSector> UsuariosSectores { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.IdentificadorUsuario> IdentificadoresUsuarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Seguridad.TipoIdentificador> TiposIdentificadores { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoAplicacion = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.TipoAplicacion");

            SincroDates.Add("Seguridad.TipoAplicacion", fechaSincroTipoAplicacion);

            DateTime fechaSincroAplicacion = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.Aplicacion");

            SincroDates.Add("Seguridad.Aplicacion", fechaSincroAplicacion);

            DateTime fechaSincroAplicacionParametro = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.AplicacionParametro");

            SincroDates.Add("Seguridad.AplicacionParametro", fechaSincroAplicacionParametro);

            DateTime fechaSincroAplicacionParametroValor = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.AplicacionParametroValor");

            SincroDates.Add("Seguridad.AplicacionParametroValor", fechaSincroAplicacionParametroValor);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoFuncion = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.TipoFuncion");

            SincroDates.Add("Seguridad.TipoFuncion", fechaSincroTipoFuncion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoIdentificador = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.TipoIdentificador");

            SincroDates.Add("Seguridad.TipoIdentificador", fechaSincroTipoIdentificador);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoMenu = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.TipoMenu");

            SincroDates.Add("Seguridad.TipoMenu", fechaSincroTipoMenu);

            DateTime fechaSincroUsuario = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.Usuario");

            SincroDates.Add("Seguridad.Usuario", fechaSincroUsuario);

            DateTime fechaSincroFuncion = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.Funcion");

            SincroDates.Add("Seguridad.Funcion", fechaSincroFuncion);

            DateTime fechaSincroIdentificadorUsuario = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.IdentificadorUsuario");

            SincroDates.Add("Seguridad.IdentificadorUsuario", fechaSincroIdentificadorUsuario);

            DateTime fechaSincroRol = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.Rol");

            SincroDates.Add("Seguridad.Rol", fechaSincroRol);

            DateTime fechaSincroUsuarioRol = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.UsuarioRol");

            SincroDates.Add("Seguridad.UsuarioRol", fechaSincroUsuarioRol);

            DateTime fechaSincroUsuarioSector = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.UsuarioSector");

            SincroDates.Add("Seguridad.UsuarioSector", fechaSincroUsuarioSector);

            DateTime fechaSincroMenu = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.Menu");

            SincroDates.Add("Seguridad.Menu", fechaSincroMenu);

            DateTime fechaSincroRolFuncion = SynchronizationController.obtenerFechaUltimaSincronizacion("Seguridad.RolFuncion");

            SincroDates.Add("Seguridad.RolFuncion", fechaSincroRolFuncion);

        }

        public void Persist()
        {
            try
            {

                Int64? idDestino;
                Int64? usuarioCreacionIdOrigen;
                Int64? usuarioModificacionIdOrigen;
                Int64 origenId;

                if (TiposAplicaciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoAplicacion tipoAplicacion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.TipoAplicacion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposAplicaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoAplicacion", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

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
                                    tipoAplicacion.Update(item);
                                }
                                else
                                {
                                    tipoAplicacion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Aplicaciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Aplicacion aplicacion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.Aplicacion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Aplicaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            Int64? tipoAplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoAplicacion", item.TipoId);

                            if (tipoAplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoAplicacionIdOrigen.Value;
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
                                    aplicacion.Update(item);
                                }
                                else
                                {
                                    aplicacion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (AplicacionesParametros.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.AplicacionParametro aplicacionParametro = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.AplicacionParametro");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        foreach (var item in AplicacionesParametros)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.AplicacionParametro", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
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
                                    aplicacionParametro.Update(item);
                                }
                                else
                                {
                                    aplicacionParametro.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (AplicacionesParametrosValores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.AplicacionParametroValor aplicacionParametroValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.AplicacionParametroValor");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? aplicacionParametroIdOrigen;
                        foreach (var item in AplicacionesParametrosValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.AplicacionParametroValor", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.AplicacionId);
                            aplicacionParametroIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.AplicacionParametro", item.ParametroId);

                            if (aplicacionIdOrigen.HasValue && aplicacionParametroIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.ParametroId = aplicacionParametroIdOrigen.Value;
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
                                    aplicacionParametroValor.Update(item);
                                }
                                else
                                {
                                    aplicacionParametroValor.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposFunciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoFuncion tipoFuncion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.TipoFuncion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposFunciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoFuncion", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

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
                                    tipoFuncion.Update(item);
                                }
                                else
                                {
                                    tipoFuncion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposIdentificadores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoIdentificador tipoIdentificador = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.TipoIdentificador");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposIdentificadores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoIdentificador", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

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
                                    tipoIdentificador.Update(item);
                                }
                                else
                                {
                                    tipoIdentificador.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposMenues.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoMenu tipoMenu = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.TipoMenu");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposMenues)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoMenu", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);

                            if (usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

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
                                    tipoMenu.Update(item);
                                }
                                else
                                {
                                    tipoMenu.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Usuarios.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Usuario usuario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.Usuario");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? empresaIdOrigen;
                        Int64? lenguajelIdOrigen;
                        Int64? perfilIdOrigen;
                        foreach (var item in Usuarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Empresa", item.EmpresaId);
                            lenguajelIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Regionalizacion.Lenguaje", item.LenguajeId);
                            perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Visualizacion.Perfil", item.PerfilId);

                            if (empresaIdOrigen.HasValue && lenguajelIdOrigen.HasValue && perfilIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {

                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.EmpresaId = empresaIdOrigen.Value;
                                item.LenguajeId = lenguajelIdOrigen.Value;
                                item.PerfilId = perfilIdOrigen.Value;
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
                                    usuario.Update(item);
                                }
                                else
                                {
                                    usuario.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Funciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Funcion funcion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.Funcion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? tipoFuncionIdOrigen;
                        foreach (var item in Funciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.AplicacionId);
                            tipoFuncionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoFuncion", item.TipoId);

                            if (aplicacionIdOrigen.HasValue && tipoFuncionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.TipoId = tipoFuncionIdOrigen.Value;
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
                                    funcion.Update(item);
                                }
                                else
                                {
                                    funcion.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (IdentificadoresUsuarios.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.IdentificadorUsuario identificadorUsuario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.IdentificadorUsuario");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? tipoIdentificadorIdOrigen;
                        foreach (var item in IdentificadoresUsuarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.IdentificadorUsuario", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioId);
                            tipoIdentificadorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoIdentificador", item.TipoId);

                            if (usuarioIdOrigen.HasValue && tipoIdentificadorIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.UsuarioId = usuarioIdOrigen.Value;
                                item.TipoId = tipoIdentificadorIdOrigen.Value;
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
                                    identificadorUsuario.Update(item);
                                }
                                else
                                {
                                    identificadorUsuario.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Roles.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Rol rol = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.Rol");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? dependeDeOrigen;
                        foreach (var item in Roles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Rol", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Aplicacion", item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {

                                //Guardo el id que venia del server.
                                origenId = item.Id;
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                if (item.DependeDe.HasValue)
                                {
                                    dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Rol", item.DependeDe.Value);
                                    item.DependeDe = dependeDeOrigen;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    rol.Update(item);
                                }
                                else
                                {
                                    rol.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosRoles.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.UsuarioRol usuarioRol = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.UsuarioRol");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? rolIdOrigen;
                        foreach (var item in UsuariosRoles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.UsuarioRol", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioId);
                            rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Rol", item.RolId);

                            if (usuarioIdOrigen.HasValue && rolIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.UsuarioId = usuarioIdOrigen.Value;
                                item.RolId = rolIdOrigen.Value;
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
                                    usuarioRol.Update(item);
                                }
                                else
                                {
                                    usuarioRol.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosSectores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.UsuarioSector usuarioSector = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.UsuarioSector");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? sectorIdOrigen;
                        foreach (var item in UsuariosSectores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.UsuarioSector", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioId);
                            sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Sector", item.SectorId);

                            if (usuarioIdOrigen.HasValue && sectorIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.SectorId = sectorIdOrigen.Value;
                                item.UsuarioId = usuarioIdOrigen.Value;
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
                                    usuarioSector.Update(item);
                                }
                                else
                                {
                                    usuarioSector.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (Menues.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Menu menu = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.Menu");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoIdOrigen;
                        Int64? funcionIdOrigen;
                        Int64? dependeDeOrigen;

                        foreach (var item in Menues)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Rol", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.TipoMenu", item.TipoId);
                            funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Directorio.Funcion", item.FuncionId);

                            if (tipoIdOrigen.HasValue && funcionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {

                                item.TipoId = tipoIdOrigen.Value;
                                item.FuncionId = funcionIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                if (item.DependeDe.HasValue)
                                {
                                    dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Menu", item.DependeDe.Value);
                                    item.DependeDe = dependeDeOrigen;
                                }

                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = idDestino.Value;
                                    menu.Update(item);
                                }
                                else
                                {
                                    menu.Add(item);
                                }

                                SynchronizationController.GuardarDetalleSincronizacion(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinalizarCabeceraSincronizacion(sincronizacionCabeceraId.Value);
                    }
                }

                if (RolesFunciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.RolFuncion rolFuncion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.IniciarCabeceraSincronizacion("Seguridad.RolFuncion");

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? funcionIdOrigen;
                        Int64? rolIdOrigen;
                        foreach (var item in RolesFunciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.RolFuncion", item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioCreacion);
                            funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Funcion", item.FuncionId);
                            rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Rol", item.RolId);

                            if (funcionIdOrigen.HasValue && rolIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.FuncionId = funcionIdOrigen.Value;
                                item.RolId = rolIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion("Seguridad.Usuario", item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                //Si se sincronizo antes entonces hago un update con el id propio.
                                if (idDestino.HasValue)
                                {
                                    item.Id = (short)idDestino.Value;
                                    rolFuncion.Update(item);
                                }
                                else
                                {
                                    rolFuncion.Add(item);
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
