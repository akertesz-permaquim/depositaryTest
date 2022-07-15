using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Permaquim.Depositary.Sincronization.Console.Interfaces;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class Worker : BackgroundService
    {
        private const string MEDIATYPE_JSON = "application/json";
        private const string WEBAPI_BASE_URL = "WEBAPI_BASE_URL";
        private const string SECURITY_SCHEME = "Bearer";
        private readonly ILogger<Worker> _logger;
        private HttpClient _httpClient = new();
        private JwtTokenModel _jwToken;
        private List<WorkerTask> _workerTasks = new();

        private string _baseUrl = DatabaseController.GetApplicationParameterValue(WEBAPI_BASE_URL);
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _workerTasks = AppConfiguration.GetWorkerTasks();
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var item in _workerTasks)
                {
                    item.Endpoint = _baseUrl + item.Endpoint;

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

                    _httpClient = new();
                }
                
                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task ReceiveData(WorkerTask item)
        {
            _httpClient.BaseAddress = new Uri(item.Endpoint);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIATYPE_JSON));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SECURITY_SCHEME, _jwToken.Token);
            try
            {
                var getResponse = await _httpClient.GetStringAsync(item.Endpoint);
                string getRresult = getResponse.ToString();

                var model = (IModel)Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,                        item.Entity).Unwrap();

                 var ret = JsonConvert.DeserializeObject(getRresult, model.GetType());
                ((IModel)ret).Process();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task SendData(WorkerTask item)
        {
            IModel model = (IModel)Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,item.Entity).Unwrap();

            model.Process();

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MEDIATYPE_JSON);
                var postResponse = _httpClient.PostAsync(item.Endpoint, content);
                var postResult = postResponse.Result;

            
        }
        private async Task GetToken(WorkerTask item)
        {
            if (_jwToken == null || DateTime.Now >= _jwToken.Expiration)
            {
                LoginModel loginModel = new LoginModel();

                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, MEDIATYPE_JSON);
                var postResponse = _httpClient.PostAsync(item.Endpoint, content);
                var postResult = postResponse.Result;
                var jsonResult = await postResult.Content.ReadAsStringAsync();
                _jwToken = JsonConvert.DeserializeObject<JwtTokenModel>(jsonResult);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _httpClient.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }
    }
}