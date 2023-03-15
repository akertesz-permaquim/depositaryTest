using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static Permaquim.Depositary.Sincronization.Console.Enumerations;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class SynchronizationController
    {
        private static Depositario.Business.Tables.Sincronizacion.Ejecucion _bTEjecucion = new();
        private static Depositario.Business.Tables.Sincronizacion.EntidadCabecera _bTSincronizacionEntidadCabecera = new();
        public static Depositario.Entities.Tables.Sincronizacion.Ejecucion? currentExecution = null;
        public static Depositario.Business.Tables.Sincronizacion.Ejecucion executionController { get; set; }

        private static bool _isInitialized = false;
        private const string MEDIATYPE_JSON = "application/json";
        private const string SINCRO_ENDPOINT_INICIO_EJECUCION = "Sincronizacion/IniciarEjecucion";
        private const string SINCRO_ENDPOINT_FIN_EJECUCION = "Sincronizacion/FinalizarEjecucion";

        private const string SECURITY_SCHEME = "Bearer";
        private static HttpClient _httpClient = new();

        public static Int64? CurrentSynchronizationExecutionId
        {
            get
            {
                if (currentExecution != null)
                {
                    return currentExecution.Id;
                }

                return null;
            }
        }

        public static bool IsInitialized()
        {
            if (_isInitialized == false && DatabaseController.CurrentDepositaryId.HasValue)
            {
                _bTEjecucion.Where.Clear();
                _bTEjecucion.Where.Add(Depositario.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.DepositarioId, Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositaryId.Value);
                _bTEjecucion.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.Finalizada, Depositario.sqlEnum.OperandEnum.Equal, true);
                _bTEjecucion.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.Ejecucion.ColumnEnum.EsPrimeraSincronizacion, Depositario.sqlEnum.OperandEnum.Equal, true);

                _bTEjecucion.Items();

                if (_bTEjecucion.Result.Count > 0)
                    _isInitialized = true;
                else
                    _isInitialized = false;
            }

            return _isInitialized;
        }

        public static bool HasOpenedExecution()
        {
            if (currentExecution == null)
                return false;
            else
                return true;
        }

        public static async Task InitializeFirstSynchronizationExecution(JwtTokenModel jwtToken)
        {
            //Solo inicializo la sincro si no se inicializo antes.
            if (currentExecution == null)
            {
                Depositario.Entities.Tables.Sincronizacion.Ejecucion nuevaEjecucion = new();
                try
                {
                    _bTEjecucion = new();

                    _bTEjecucion.BeginTransaction();

                    nuevaEjecucion = _bTEjecucion.Add(DatabaseController.CurrentDepositaryId, DateTime.Now, null, false, !IsInitialized());

                    EjecucionModel ejecucionModel = new EjecucionModel();

                    ejecucionModel.Ejecucion = nuevaEjecucion;

                    SendData(jwtToken, ejecucionModel);

                    //_bTEjecucion.EndTransaction(true);
                }
                catch (Exception ex)
                {
                    _bTEjecucion.EndTransaction(false);
                    AuditController.LogToFile(ex);
                    throw (ex); //Salimos de la aplicacion porque no se pudo iniciar registro de sincro.
                }
            }
        }

        public static async Task FinishFirstSynchronizationExecution(JwtTokenModel jwtToken)
        {
            //Solo finalizo la sincro si se inicializo antes.
            if (currentExecution != null)
            {
                try
                {
                    _bTEjecucion = new(); //Genero una nueva instancia para abrir otra conexion.

                    _bTEjecucion.BeginTransaction();

                    currentExecution.Finalizada = true;
                    currentExecution.DepositarioId = DatabaseController.CurrentDepositaryId;
                    currentExecution.FechaFin = DateTime.Now;

                    _bTEjecucion.Update(currentExecution);

                    EjecucionModel ejecucionModel = new EjecucionModel();

                    ejecucionModel.Ejecucion = currentExecution;

                    SendData(jwtToken, ejecucionModel);

                    //_bTEjecucion.EndTransaction(true);
                }
                catch (Exception ex)
                {
                    _bTEjecucion.EndTransaction(false);
                    AuditController.LogToFile(ex);
                    throw (ex); //Salimos de la aplicacion porque no se pudo iniciar registro de sincro.
                }
            }
        }

        //public static void InitializeSynchronizationExecution()
        //{
        //    //Solo se puede procesar si no hay una ejecucion en curso
        //    if(!HasOpenedExecution())
        //    {
        //        currentExecution = new();
        //        currentExecution.Finalizada = false;
        //        currentExecution.EsPrimeraSincronizacion = false;
        //        currentExecution.DepositarioId = DatabaseController.CurrentDepositaryId;
        //        currentExecution.FechaInicio = DateTime.Now;
        //        currentExecution.FechaFin = null;
        //    }
        //}

        private static async Task SendData(JwtTokenModel jwtToken, EjecucionModel ejecucionModel)
        {
            try
            {
                if (jwtToken != null)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(ejecucionModel), Encoding.UTF8, MEDIATYPE_JSON);
                    string jsonToSend = JsonConvert.SerializeObject(ejecucionModel);

                    //if (item.Log)
                    //    AuditController.LogToFile(jsonToSend);

                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, jwtToken.Token);

                    var postResponse = _httpClient.PostAsync(GetConfiguration("WebApiUrl") + (ejecucionModel.Ejecucion.FechaFin.HasValue ? SINCRO_ENDPOINT_FIN_EJECUCION : SINCRO_ENDPOINT_INICIO_EJECUCION), content);
                    var postResult = postResponse.Result;

                    if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        _bTEjecucion.EndTransaction(true);
                        currentExecution = ejecucionModel.Ejecucion;
                        //ejecucionModel.Persist();
                    }
                    else
                    {
                        _bTEjecucion.EndTransaction(false);
                        if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            jwtToken = null;
                        }
                        else
                        {
                            throw new Exception(postResult.ToString());
                        }
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                AuditController.LogToFile(ex);
            }
        }

        public static Int64? InitializeEntitySynchronization(EntitiesEnum entity, DateTime FechaInicio, DateTime? FechaFin = null)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre, Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                var entidadSincronizacion = oSincronizacionEntidad.Result.FirstOrDefault();
                //Generamos el registro de cabecera para la sincronizacion de la entidad, con fecha de inicio y sin fecha de fin.
                Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionEntidadCabecera = new();

                eSincronizacionEntidadCabecera.EntidadId = entidadSincronizacion.Id;
                eSincronizacionEntidadCabecera.Fechainicio = FechaInicio;
                eSincronizacionEntidadCabecera.Valor = entidadSincronizacion.Nombre;
                eSincronizacionEntidadCabecera.EjecucionId = currentExecution.Id;
                eSincronizacionEntidadCabecera.Fechafin = FechaFin;

                try
                {
                    Depositario.Entities.Tables.Sincronizacion.EntidadCabecera eSincronizacionNuevaEntidadCabecera = new();

                    eSincronizacionNuevaEntidadCabecera = _bTSincronizacionEntidadCabecera.Add(eSincronizacionEntidadCabecera);

                    resultado = eSincronizacionNuevaEntidadCabecera.Id;
                }
                catch (Exception ex)
                {
                    AuditController.LogToFile(ex);
                }
            }

            return resultado;
        }

        public static bool FinishEntitySynchronization(Int64 pCabeceraSincronizacionId)
        {
            //Por defecto no se pudo registrar el cierre de la sincronizacion para la entidad.
            bool resultado = false;
            //Buscamos el registro en funcion del id recibido
            _bTSincronizacionEntidadCabecera.Where.Clear();
            _bTSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, Depositario.sqlEnum.OperandEnum.Equal, pCabeceraSincronizacionId);

            _bTSincronizacionEntidadCabecera.Items();

            if (_bTSincronizacionEntidadCabecera.Result.Count > 0)
            {
                var entidadSincronizacionCabecera = _bTSincronizacionEntidadCabecera.Result.FirstOrDefault();

                //Actualizamos la fecha de cierre y hacemos el update.
                entidadSincronizacionCabecera.Fechafin = DateTime.Now;

                try
                {
                    _bTSincronizacionEntidadCabecera.Update(entidadSincronizacionCabecera);
                    resultado = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return resultado;
        }

        public static DateTime GetLastSincronizationDate(EntitiesEnum entity)
        {
            DateTime returnValue = new DateTime(1999, 11, 11, 9, 0, 0, 0); // Hasar!

            Depositario.Business.Tables.Sincronizacion.Entidad entities = new();
            entities.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            entities.Items();

            if (entities.Result.Count > 0)
            {
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera headerEntities = new();
                headerEntities.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId,
                    Depositario.sqlEnum.OperandEnum.Equal, entities.Result.FirstOrDefault().Id);

                //Filtramos solo procesos que concluyeron OK.
                headerEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin,
                    Depositario.sqlEnum.OperandEnum.IsNotNull, true);

                //Ordeno todo DESC para obtener la ultima sincronizacion correcta de la entidad.
                headerEntities.OrderBy.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id,
                    Depositario.sqlEnum.DirEnum.DESC);

                headerEntities.TopQuantity = 1;

                headerEntities.Items();

                if (headerEntities.Result.Count > 0)
                {
                    returnValue = headerEntities.Result.FirstOrDefault().Fechainicio;
                }
            }
            return returnValue;
        }

        public static void SaveEntitySincronizationDate(EntitiesEnum entity, DateTime startDate, DateTime endDate)
        {
            Depositario.Business.Tables.Sincronizacion.Entidad entities = new();
            entities.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
                Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));
            entities.Items();

            //var depositarioId = _currentDepositary;

            if (entities.Result.Count > 0)
            {
                Depositario.Business.Tables.Sincronizacion.EntidadCabecera headerEntities = new();
                headerEntities.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId,
                    Depositario.sqlEnum.OperandEnum.Equal, entities.Result.FirstOrDefault().Id);
                headerEntities.Add(new Depositario.Entities.Tables.Sincronizacion.EntidadCabecera()
                {
                    EntidadId = entities.Result.FirstOrDefault().Id,
                    Fechafin = endDate,
                    Fechainicio = startDate,
                    Valor = entities.Result.FirstOrDefault().Nombre
                });

            }
        }

        public static bool InitializeFirstSynchronization()
        {
            bool resultado = false;
            //Verificamos que la base no este inicializada. 
            if (!IsInitialized())
            {
                try
                {
                    //Ejecutamos la SP que elimina las FK y reinicia los identity y elimina los datos que puedan existir.
                    Depositario.Business.Procedures.dbo.IniciarPrimeraSincronizacion oSP = new();
                    oSP.Items();

                    if (oSP.MappedResultSet.Result.Count > 0)
                        if (oSP.MappedResultSet.Result.FirstOrDefault().Resultado == "")
                            resultado = true;
                        else
                            AuditController.LogToFile(oSP.MappedResultSet.Result.FirstOrDefault().Resultado);
                }
                catch (Exception ex)
                {
                    //Se loguea en archivo porque se considera que a esta altura no se termino de generar la BD.
                    AuditController.LogToFile(ex);
                }
            }

            return resultado;
        }

        public static bool FinishInitialSynchronization()
        {
            bool resultado = false;
            //Finalizamos la sincro inicial ejecutando un SP.
            if (DatabaseController.CurrentDepositaryId.HasValue)
            {
                try
                {
                    //Finalmente ejecutamos la SP que termina de modelar la base de datos
                    Depositario.Business.Procedures.dbo.FinalizarPrimeraSincronizacion oSP = new();
                    oSP.Items(DatabaseController.CurrentDepositaryId.Value);

                    if (oSP.MappedResultSet.Result.Count > 0)
                        if (oSP.MappedResultSet.Result.FirstOrDefault().Resultado == "")
                            resultado = true;
                        else
                            AuditController.LogToFile(oSP.MappedResultSet.Result.FirstOrDefault().Resultado);

                }
                catch (Exception ex)
                {
                    //Se loguea en archivo porque se considera que a esta altura no se termino de generar la BD.
                    AuditController.LogToFile(ex);
                }
            }

            return resultado;
        }

        public static Int64? SaveEntitySynchronizationDetail(Int64 pEntidadCabeceraId, Int64 pOrigenId, Int64 pDestinoId)
        {
            Int64? resultado = null;
            //En funcion del nombre recibido buscamos la entidad y obtenemos el id
            Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
            Depositario.Entities.Tables.Sincronizacion.EntidadDetalle eSincronizacionEntidadDetalle = new();
            Depositario.Entities.Tables.Sincronizacion.EntidadDetalle eNuevaSincronizacionEntidadDetalle = new();

            eSincronizacionEntidadDetalle.EntidadCabeceraId = pEntidadCabeceraId;
            eSincronizacionEntidadDetalle.FechaCreacion = DateTime.Now;
            eSincronizacionEntidadDetalle.OrigenId = pOrigenId;
            eSincronizacionEntidadDetalle.DestinoId = pDestinoId;

            try
            {
                eNuevaSincronizacionEntidadDetalle = oSincronizacionEntidadDetalle.Add(eSincronizacionEntidadDetalle);

                resultado = eNuevaSincronizacionEntidadDetalle.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Int64? ObtenerIdDestinoDetalleSincronizacion(EntitiesEnum entity, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
            Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));

            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                Int64 pEntidadId = oSincronizacionEntidad.Result.FirstOrDefault().Id;

                _bTSincronizacionEntidadCabecera.Where.Clear();
                _bTSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, pEntidadId);
                _bTSincronizacionEntidadCabecera.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Fechafin, Depositario.sqlEnum.OperandEnum.IsNotNull, null);

                _bTSincronizacionEntidadCabecera.OrderBy.Clear();
                _bTSincronizacionEntidadCabecera.OrderBy.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, Depositario.sqlEnum.DirEnum.DESC);

                _bTSincronizacionEntidadCabecera.Items();

                if (_bTSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    foreach (var entidadCabecera in _bTSincronizacionEntidadCabecera.Result)
                    {
                        Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, Depositario.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, Depositario.sqlEnum.OperandEnum.Equal, pIdOrigen);

                        oSincronizacionEntidadDetalle.Items();

                        if (oSincronizacionEntidadDetalle.Result.Count > 0)
                            return oSincronizacionEntidadDetalle.Result.FirstOrDefault().DestinoId;
                    }
                }
            }

            return resultado;
        }

        public static Int64? ObtenerIdOrigenDetalleSincronizacion(EntitiesEnum entity, Int64 pIdDestino)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            Depositario.Business.Procedures.Sincronizacion.ObtenerIdOrigen obtenerIdOrigen = new();

            try
            {
                obtenerIdOrigen.Items(Enum.GetName(entity).Replace("_", "."), pIdDestino);

                if (obtenerIdOrigen.Resultset.Count > 0)
                {
                    return obtenerIdOrigen.Resultset.FirstOrDefault().OrigenId;
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
            }

            return resultado;
        }

        public static Int64? ObtenerIdDestinoDetalleSincronizacionInicial(EntitiesEnum entity, Int64 pIdOrigen)
        {
            Int64? resultado = null;

            //En funcion del nombre recibido buscamos la entidad y obtenemos el id con el que se guardo
            Depositario.Business.Tables.Sincronizacion.Entidad oSincronizacionEntidad = new();
            oSincronizacionEntidad.Where.Add(Depositario.Business.Tables.Sincronizacion.Entidad.ColumnEnum.Nombre,
            Depositario.sqlEnum.OperandEnum.Equal, Enum.GetName(entity).Replace("_", "."));

            oSincronizacionEntidad.Items();

            if (oSincronizacionEntidad.Result.Count > 0)
            {
                Int64 pEntidadId = oSincronizacionEntidad.Result.FirstOrDefault().Id;

                _bTSincronizacionEntidadCabecera.Where.Clear();
                _bTSincronizacionEntidadCabecera.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Depositario.sqlEnum.OperandEnum.Equal, pEntidadId);
                _bTSincronizacionEntidadCabecera.OrderBy.Clear();
                _bTSincronizacionEntidadCabecera.OrderBy.Add(Depositario.Business.Tables.Sincronizacion.EntidadCabecera.ColumnEnum.Id, Depositario.sqlEnum.DirEnum.DESC);
                _bTSincronizacionEntidadCabecera.TopQuantity = 1;

                _bTSincronizacionEntidadCabecera.Items();

                if (_bTSincronizacionEntidadCabecera.Result.Count > 0)
                {
                    foreach (var entidadCabecera in _bTSincronizacionEntidadCabecera.Result)
                    {
                        Depositario.Business.Tables.Sincronizacion.EntidadDetalle oSincronizacionEntidadDetalle = new();
                        oSincronizacionEntidadDetalle.Where.Clear();
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, Depositario.sqlEnum.OperandEnum.Equal, entidadCabecera.Id);
                        oSincronizacionEntidadDetalle.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND, Depositario.Business.Tables.Sincronizacion.EntidadDetalle.ColumnEnum.OrigenId, Depositario.sqlEnum.OperandEnum.Equal, pIdOrigen);

                        oSincronizacionEntidadDetalle.Items();

                        if (oSincronizacionEntidadDetalle.Result.Count > 0)
                            return oSincronizacionEntidadDetalle.Result.FirstOrDefault().DestinoId;
                    }
                }
            }

            return resultado;
        }

        private static string GetConfiguration(string configurationEntry)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == null ? String.Empty :
                 Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".";
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings." + env + "json", optional: false, reloadOnChange: true);


            IConfigurationRoot configuration = builder.Build();

            return configuration.GetSection("AppSettings").GetSection(configurationEntry).Value.ToString();
        }
    }
}
