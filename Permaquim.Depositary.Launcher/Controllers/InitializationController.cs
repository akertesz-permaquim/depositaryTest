using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Permaquim.Depositary.Launcher.Model;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Permaquim.Depositary.Launcher.Controllers
{
    internal static class InitializationController
    {
        private const string MEDIATYPE_JSON = "application/json";
        private const string WEBAPI_BASE_URL = "WEBAPI_BASE_URL";
        private const string SINCRONIZATION_DELAY = "SINCRONIZATION_DELAY";
        private const string TOKEN_ENDPOINT = "inicializacion/ObtenerTokenInicializacion";
        private const string SINCRO_ENDPOINT = "inicializacion/obtenerdatosiniciales";
        private const string SECURITY_SCHEME = "Bearer";
        private static JwtTokenModel _jwToken;
        private static HttpClient _httpClient = new();

        private static string _webapiUrl = string.Empty;

        public static async void InitializeDepositary()
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
                ReceiveData(webapiUrl);
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
                        MessageBox.Show(postResult.ReasonPhrase);
                    }

                    _jwToken = JsonConvert.DeserializeObject<JwtTokenModel>(jsonResult);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    var getResponse = await _httpClient.GetStringAsync(baseUrl + SINCRO_ENDPOINT);
                    string getRresult = getResponse.ToString();
                    InicializacionModel model = new();
                    model = JsonConvert.DeserializeObject<InicializacionModel>(getRresult);
                    //Persistimos los metodos en la base de datos.
                    model.Persist();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private static Task SendData(string baseUrl)
        {
            var model = new InicializacionModel();
            model.CodigoExternoDepositario = GetConfiguration("CodigoDepositario");

            try
            {
                if (_jwToken != null)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MEDIATYPE_JSON);
                    string jsonToSend = JsonConvert.SerializeObject(model);

                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, _jwToken.Token);

                    var postResponse = _httpClient.PostAsync(baseUrl + SINCRO_ENDPOINT, content);
                    var postResult = postResponse.Result;

                    if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        model.Persist();
                    }
                    else
                    {
                        if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            _jwToken = null;
                        }
                        else
                        {
                            throw new Exception(postResult.ToString());
                        }
                    }

                }

            }
            catch (Exception ex)
            {


            }

            return Task.CompletedTask;
        }

        private static string GetConfiguration(string configurationEntry)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == null ? String.Empty :
                 Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".";
            var builder = new ConfigurationBuilder()
                            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings." + env + "json", optional: false, reloadOnChange: true);


            IConfigurationRoot configuration = builder.Build();

            return configuration.GetSection("AppSettings").GetSection(configurationEntry).Value.ToString();
        }
    }
}
