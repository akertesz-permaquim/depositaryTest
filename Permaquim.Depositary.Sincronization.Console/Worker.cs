using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Permaquim.Depositary.Sincronization.Console.Controllers;
using Permaquim.Depositary.Sincronization.Console.Interfaces;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class Worker : BackgroundService
    {
        DatabaseController DatabaseController = new();
        private const string MEDIATYPE_JSON = "application/json";
        private const string WEBAPI_BASE_URL = "WEBAPI_BASE_URL";
        private const string SINCRONIZATION_DELAY = "SINCRONIZATION_DELAY";
        private const string SECURITY_SCHEME = "Bearer";
        private const string WEBAPIURL = "WebApiUrl";
        private readonly ILogger<Worker> _logger;
        private HttpClient _httpClient = new();
        private JwtTokenModel _jwToken;
        private List<WorkerTask> _workerTasks = new();

        private string _baseUrl = String.Empty;
        private string _delaytime = String.Empty;

        IModel model = null;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;


            _baseUrl = ConfigurationController.GetConfiguration(WEBAPIURL);
            _delaytime = DatabaseController.GetApplicationParameterValue(SINCRONIZATION_DELAY) == String.Empty ? "10000" : DatabaseController.GetApplicationParameterValue(SINCRONIZATION_DELAY);

        }
    public override Task StartAsync(CancellationToken cancellationToken)
        {
            _workerTasks = AppConfiguration.GetWorkerTasks();
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.Log(LogLevel.Information, "Starting sincronization...");

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var item in _workerTasks)
                {
                    _logger.Log(LogLevel.Information, "Api endpoint is " + _baseUrl + item.Endpoint);

                    switch (item.WorkerTaskType)
                    {
                        case WorkerTask.WorkerTaskTypeEnum.None:
                            break;
                        case WorkerTask.WorkerTaskTypeEnum.GetToken:
                            await GetToken(item);
                            break;
                        case WorkerTask.WorkerTaskTypeEnum.Receive:
                             await ReceiveData(item);
                            break;
                        case WorkerTask.WorkerTaskTypeEnum.Send:
                            await SendData(item);
                            break;
                        default:
                            break;
                    }

                    model = null;

                    

                    await Task.Delay(5000, stoppingToken);

                    GC.Collect();

                }
                
                await Task.Delay(Convert.ToInt32(_delaytime), stoppingToken);
            }
        }

        private async Task ReceiveData(WorkerTask item)
        {

            if (_jwToken != null)
            {
                _logger.Log(LogLevel.Information, "Receiving data: " + item.Entity);

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, _jwToken.Token);

                try
                {


                    var getResponse = await _httpClient.GetStringAsync(_baseUrl + item.Endpoint);

                    string getRresult = getResponse.ToString();

                    var model = (IModel)Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, item.Entity).Unwrap();

                    var ret = JsonConvert.DeserializeObject(getRresult, model.GetType());

                    ((IModel)ret).Process();

  
                }
                catch (Exception ex)
                {
                    Log(ex);
                }
            }
            else
            {
                _logger.Log(LogLevel.Information, "JwToken is null, GET was cancelled!");
            }
        }
        private async Task SendData(WorkerTask item)
        {
            model = (IModel)Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,item.Entity).Unwrap();

            model.Process();

            _logger.Log(LogLevel.Information, "Sending data: " + item.Entity);

            try
            {
                if (_jwToken != null)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MEDIATYPE_JSON);
                    string jsonToSend = JsonConvert.SerializeObject(model);

                    _logger.Log(LogLevel.Information, "Sending content: " + jsonToSend);

                    if (item.Log)
                        Log(jsonToSend);

                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, _jwToken.Token);

                    var postResponse = _httpClient.PostAsync(_baseUrl + item.Endpoint, content);
                    var postResult = postResponse.Result;

                    _logger.LogInformation(postResult.ToString() + " At endpoint: " + _httpClient.BaseAddress);



                    if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        model.Persist();
                    }

                    else
                    {
                        if (postResponse.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            _logger.LogInformation("Unauthorized received. token was set to null.");
                            _jwToken = null;
                        }
                        else
                        {
                            throw new Exception(postResult.ToString());
                        }
                    }

                }
                else
                {
                    _logger.Log(LogLevel.Information, "JwToken is null, POST was cancelled!");
                }
            }
            catch (Exception ex)
            {

                Log(ex);
            }
        }
        private async Task GetToken(WorkerTask item)
        {

            if (_jwToken == null || DateTime.Now >= _jwToken.Expiration)
            {
                try
                {
                    _logger.Log(LogLevel.Information, "Getting token..");

                    LoginModel loginModel = new LoginModel();

                    var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, MEDIATYPE_JSON);
                    var postResponse = _httpClient.PostAsync(_baseUrl + item.Endpoint, content);
                    var postResult = postResponse.Result;
                    var jsonResult = await postResult.Content.ReadAsStringAsync();
                    if(postResult.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        _logger.Log(LogLevel.Information, "Received: InternalServerError");
                    }

                    _jwToken = JsonConvert.DeserializeObject<JwtTokenModel>(jsonResult);

                }
                catch (Exception ex)
                {
                    Log(ex);
                }
             }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _httpClient.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }
        private void Log(Exception ex)
        {
            string logDirectory = System.IO.Directory.GetCurrentDirectory() + @"\Logs\";
            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);

            string filename = logDirectory + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss") + ".Exception.log";

            System.IO.StreamWriter file = new(filename, true);
            file.WriteLine("Message : " + ex.Message + Environment.NewLine 
                + "StackTrace :" + ex.StackTrace); ;
            file.Close();
        }
            private void Log(string message)
        {
            string logDirectory = System.IO.Directory.GetCurrentDirectory() + @"\Logs\";
            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);

            string filename = logDirectory + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss") + ".log";

            System.IO.StreamWriter file = new(filename, true);
            file.WriteLine(message);
            file.Close();

            file.Flush();
            file = null;
        }
    }
}