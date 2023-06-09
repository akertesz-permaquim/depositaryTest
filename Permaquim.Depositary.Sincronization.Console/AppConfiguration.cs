using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Permaquim.Depositary.Sincronization.Console
{
    internal class AppConfiguration
    {

        internal static String ConnectionString
        {
            get { return getConfiguration("ConnectionString"); }
        }
        internal static String WebApiUrl
        {
            get { return getConfiguration("WebApiUrl"); }
        }
        private static string getConfiguration(string configurationEntry)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == null ? String.Empty :
                 Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".";
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings." + env + "json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetSection("AppSettings").GetSection(configurationEntry).Value.ToString();
        }
        public static List<WorkerTask> GetWorkerTasks()
        {
            string str = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Tasks.Json");
            return JsonConvert.DeserializeObject<List<WorkerTask>>(str);

        }
    }

}