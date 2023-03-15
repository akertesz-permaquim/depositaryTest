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
        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;


        void IModel.Process()
        {
            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoAplicacion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion).Replace("_", "."), fechaSincroTipoAplicacion);

            DateTime fechaSincroAplicacion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_Aplicacion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_Aplicacion).Replace("_", "."), fechaSincroAplicacion);

            DateTime fechaSincroAplicacionParametro = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro).Replace("_", "."), fechaSincroAplicacionParametro);

            DateTime fechaSincroAplicacionParametroValor = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_AplicacionParametroValor);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_AplicacionParametroValor).Replace("_", "."), fechaSincroAplicacionParametroValor);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoFuncion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_TipoFuncion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_TipoFuncion).Replace("_", "."), fechaSincroTipoFuncion);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoIdentificador = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador).Replace("_", "."), fechaSincroTipoIdentificador);

            //Obtenemos la fecha de ultima sincronizacion de la entidad
            DateTime fechaSincroTipoMenu = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_TipoMenu);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_TipoMenu).Replace("_", "."), fechaSincroTipoMenu);

            DateTime fechaSincroUsuario = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_Usuario);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_Usuario).Replace("_", "."), fechaSincroUsuario);

            DateTime fechaSincroFuncion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_Funcion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_Funcion).Replace("_", "."), fechaSincroFuncion);

            DateTime fechaSincroIdentificadorUsuario = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_IdentificadorUsuario);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_IdentificadorUsuario).Replace("_", "."), fechaSincroIdentificadorUsuario);

            DateTime fechaSincroRol = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_Rol);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_Rol).Replace("_", "."), fechaSincroRol);

            DateTime fechaSincroUsuarioRol = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_UsuarioRol);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_UsuarioRol).Replace("_", "."), fechaSincroUsuarioRol);

            DateTime fechaSincroUsuarioSector = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_UsuarioSector);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_UsuarioSector).Replace("_", "."), fechaSincroUsuarioSector);

            DateTime fechaSincroMenu = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_Menu);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_Menu).Replace("_", "."), fechaSincroMenu);

            DateTime fechaSincroRolFuncion = SynchronizationController.GetLastSincronizationDate(Enumerations.EntitiesEnum.Seguridad_RolFuncion);

            SincroDates.Add(Enum.GetName(Enumerations.EntitiesEnum.Seguridad_RolFuncion).Replace("_", "."), fechaSincroRolFuncion);

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

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposAplicaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion, item.Id);
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
                                    tipoAplicacion.Update(item);
                                }
                                else
                                {
                                    tipoAplicacion.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Aplicaciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Aplicacion aplicacion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Aplicacion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in Aplicaciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            Int64? tipoAplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoAplicacion, item.TipoId);

                            if (tipoAplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.TipoId = tipoAplicacionIdOrigen.Value;
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
                                    aplicacion.Update(item);
                                }
                                else
                                {
                                    aplicacion.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (AplicacionesParametros.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.AplicacionParametro aplicacionParametro = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        foreach (var item in AplicacionesParametros)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {
                                //Guardo el id que venia del server.
                                origenId = item.Id;

                                //Reemplazo los id de FK por id propio.
                                item.AplicacionId = aplicacionIdOrigen.Value;
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
                                    aplicacionParametro.Update(item);
                                }
                                else
                                {
                                    aplicacionParametro.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (AplicacionesParametrosValores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.AplicacionParametroValor aplicacionParametroValor = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_AplicacionParametroValor, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? aplicacionParametroIdOrigen;
                        foreach (var item in AplicacionesParametrosValores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_AplicacionParametroValor, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            aplicacionParametroIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_AplicacionParametro, item.ParametroId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposFunciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoFuncion tipoFuncion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoFuncion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposFunciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoFuncion, item.Id);
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
                                    tipoFuncion.Update(item);
                                }
                                else
                                {
                                    tipoFuncion.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposIdentificadores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoIdentificador tipoIdentificador = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposIdentificadores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador, item.Id);
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
                                    tipoIdentificador.Update(item);
                                }
                                else
                                {
                                    tipoIdentificador.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (TiposMenues.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.TipoMenu tipoMenu = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_TipoMenu, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        foreach (var item in TiposMenues)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoMenu, item.Id);
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
                                    tipoMenu.Update(item);
                                }
                                else
                                {
                                    tipoMenu.Add(item);
                                }

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Usuarios.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Usuario usuario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Usuario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? empresaIdOrigen;
                        Int64? lenguajelIdOrigen;
                        Int64? perfilIdOrigen;
                        foreach (var item in Usuarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            empresaIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Empresa, item.EmpresaId);
                            lenguajelIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Regionalizacion_Lenguaje, item.LenguajeId);
                            perfilIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Visualizacion_Perfil, item.PerfilId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Funciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Funcion funcion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Funcion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? tipoFuncionIdOrigen;
                        foreach (var item in Funciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Funcion, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);
                            tipoFuncionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoFuncion, item.TipoId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (IdentificadoresUsuarios.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.IdentificadorUsuario identificadorUsuario = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_IdentificadorUsuario, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? tipoIdentificadorIdOrigen;
                        foreach (var item in IdentificadoresUsuarios)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_IdentificadorUsuario, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            tipoIdentificadorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoIdentificador, item.TipoId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Roles.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Rol rol = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Rol, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? aplicacionIdOrigen;
                        Int64? dependeDeOrigen;
                        foreach (var item in Roles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Rol, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            aplicacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Aplicacion, item.AplicacionId);

                            if (aplicacionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {

                                //Guardo el id que venia del server.
                                origenId = item.Id;
                                item.AplicacionId = aplicacionIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                if (item.DependeDe.HasValue)
                                {
                                    dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Rol, item.DependeDe.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosRoles.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.UsuarioRol usuarioRol = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_UsuarioRol, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? rolIdOrigen;
                        foreach (var item in UsuariosRoles)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_UsuarioRol, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Rol, item.RolId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (UsuariosSectores.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.UsuarioSector usuarioSector = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_UsuarioSector, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? usuarioIdOrigen;
                        Int64? sectorIdOrigen;
                        foreach (var item in UsuariosSectores)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_UsuarioSector, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            usuarioIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioId);
                            sectorIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Directorio_Sector, item.SectorId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (Menues.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.Menu menu = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_Menu, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? tipoIdOrigen;
                        Int64? funcionIdOrigen;
                        Int64? dependeDeOrigen;

                        foreach (var item in Menues)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Rol, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            tipoIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_TipoMenu, item.TipoId);
                            funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId);

                            if (tipoIdOrigen.HasValue && funcionIdOrigen.HasValue && usuarioCreacionIdOrigen.HasValue)
                            {

                                item.TipoId = tipoIdOrigen.Value;
                                item.FuncionId = funcionIdOrigen.Value;
                                item.UsuarioCreacion = usuarioCreacionIdOrigen.Value;

                                if (item.UsuarioModificacion.HasValue)
                                {
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
                                    item.UsuarioModificacion = usuarioModificacionIdOrigen.Value;
                                }

                                if (item.DependeDe.HasValue)
                                {
                                    dependeDeOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Menu, item.DependeDe.Value);
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

                                SynchronizationController.SaveEntitySynchronizationDetail(sincronizacionCabeceraId.Value, origenId, item.Id);
                            }
                        }
                        SynchronizationController.FinishEntitySynchronization(sincronizacionCabeceraId.Value);
                    }
                }

                if (RolesFunciones.Count > 0)
                {
                    Depositario.Business.Tables.Seguridad.RolFuncion rolFuncion = new();

                    Int64? sincronizacionCabeceraId = null;

                    sincronizacionCabeceraId = SynchronizationController.InitializeEntitySynchronization(Enumerations.EntitiesEnum.Seguridad_RolFuncion, DateTime.Now);

                    if (sincronizacionCabeceraId.HasValue)
                    {
                        Int64? funcionIdOrigen;
                        Int64? rolIdOrigen;
                        foreach (var item in RolesFunciones)
                        {
                            //Verifico si este registro se sincronizo anteriormente
                            idDestino = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_RolFuncion, item.Id);
                            usuarioCreacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioCreacion);
                            funcionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Funcion, item.FuncionId);
                            rolIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Rol, item.RolId);

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
                                    usuarioModificacionIdOrigen = SynchronizationController.ObtenerIdDestinoDetalleSincronizacion(Enumerations.EntitiesEnum.Seguridad_Usuario, item.UsuarioModificacion.Value);
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
