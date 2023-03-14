using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class InitializationController
    {
        private const string MEDIATYPE_JSON = "application/json";
        private const string TOKEN_ENDPOINT = "inicializacion/ObtenerTokenInicializacion";
        private const string SINCRO_ENDPOINT = "inicializacion/obtenerdatosiniciales";
        private const string SECURITY_SCHEME = "Bearer";
        private static JwtTokenModel _jwToken;
        private static HttpClient _httpClient = new();

        private static string _webapiUrl = string.Empty;

        public static async Task InitializeDepositary()
        {
            string webapiUrl = GetConfiguration("WebApiUrl");

            InicializacionModel model = new()
            {
                CodigoExternoDepositario = GetConfiguration("CodigoDepositario")
            };
            await GetinitializationToken(model, webapiUrl);

            //Si obtenemos un token valido empezamos a consultar los metodos get y a llenar las tablas
            if (_jwToken != null && DateTime.Now <= _jwToken.Expiration)
            {
                await ReceiveData(webapiUrl);
            }
            else
            {
                AuditController.LogToFile("Invalid token");
            }
        }

        private static async Task GetinitializationToken(InicializacionModel inicializacionModel, string webapiUrl)
        {
            _webapiUrl = webapiUrl;

            if (_jwToken == null || DateTime.Now >= _jwToken.Expiration)
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(inicializacionModel), Encoding.UTF8, MEDIATYPE_JSON);
                    var postResponse = _httpClient.PostAsync(_webapiUrl + TOKEN_ENDPOINT, content);
                    var postResult = postResponse.Result;
                    var jsonResult = await postResult.Content.ReadAsStringAsync();
                    if (postResult.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        AuditController.Log(new Exception(postResult.ReasonPhrase));
                    }

                    _jwToken = JsonConvert.DeserializeObject<JwtTokenModel>(jsonResult);

                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                }
            }
        }
        private static async Task ReceiveData(string baseUrl)
        {
            if (_jwToken != null)
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, _jwToken.Token);
                try
                {
                    await SynchronizationController.InitializeFirstSynchronizationExecution(_jwToken);

                    if (SynchronizationController.HasOpenedExecution())
                    {
                        if (SynchronizationController.InitializeFirstSynchronization())
                        {
                            //Hacemos la solicitud de datos al servidor.
                            InicializacionModel model = new();

                            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MEDIATYPE_JSON);

                            var postResponse = _httpClient.PostAsync(baseUrl + SINCRO_ENDPOINT, content);
                            var postResult = postResponse.Result;

                            if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var jsonResult = await postResult.Content.ReadAsStringAsync();

                                model = JsonConvert.DeserializeObject<InicializacionModel>(jsonResult);

                                //Persistimos los metodos en la base de datos.
                                if (model.Persist())
                                {
                                    if (SynchronizationController.FinishInitialSynchronization())
                                    {
                                        await SynchronizationController.FinishFirstSynchronizationExecution(_jwToken);
                                    }
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    AuditController.LogToFile(ex);
                }

            }
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
