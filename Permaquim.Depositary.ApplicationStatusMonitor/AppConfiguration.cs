using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Permaquim.Depositary.ApplicationStatusMonitor
{
    internal class AppConfiguration
    {

        /*internal static String ConnectionString
        {
            get { return getConfiguration("ConnectionString"); }
        }*/

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
        public static List<WorkerTask> GetWorkerTasks(string tasksJson) => JsonConvert.DeserializeObject<List<WorkerTask>>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\" + tasksJson));
    }

}