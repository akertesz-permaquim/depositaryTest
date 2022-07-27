using ermaquim.Depositary.UI.Desktop;
using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class InitializationController
    {
        private const string MEDIATYPE_JSON = "application/json";
        private const string WEBAPI_BASE_URL = "WEBAPI_BASE_URL";
        private const string SINCRONIZATION_DELAY = "SINCRONIZATION_DELAY";
        private const string TOKEN_ENDPOINT = "autenticacion/obtenertoken";
        private const string SINCRO_ENDPOINT = "autenticacion/obtenerdatosiniciales";
        private const string SECURITY_SCHEME = "Bearer";
        private static JwtTokenModel _jwToken;
        private static HttpClient _httpClient = new();

        private static string _webapiUrl  =string.Empty;

        public static void InitializeDepositary(LoginModel loginModel,string webapiUrl)
        {
            GetToken(loginModel,);
        }


        private static async Task GetToken(LoginModel loginModel, string webapiUrl)
        {

            if (_jwToken == null || DateTime.Now >= _jwToken.Expiration)
            {
                try
                {
 
                    var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, MEDIATYPE_JSON);
                    var postResponse = _httpClient.PostAsync(_webapiUrl + TOKEN_ENDPOINT, content);
                    var postResult = postResponse.Result;
                    var jsonResult = await postResult.Content.ReadAsStringAsync();
                    if (postResult.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        MessageBox.Show(postResult.ReasonPhrase);
                    }

                    _jwToken = JsonConvert.DeserializeObject<JwtTokenModel>(jsonResult);

                    ReceiveData(webapiUrl);

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

                    //var ret = JsonConvert.DeserializeObject(getRresult, model.GetType());


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("JwToken = null!");
            }
        }
    }
}
