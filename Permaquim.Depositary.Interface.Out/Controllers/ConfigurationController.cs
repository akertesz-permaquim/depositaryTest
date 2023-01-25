using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ConfigurationController
    {
        private const string APP_SETTINGS_NAME = "appsettings.json";
        public static JObject GetAppSettings()
        {

            var domain = AppDomain.CurrentDomain.BaseDirectory +"\\"+APP_SETTINGS_NAME;
            JObject appSettings = GetJsonFromFile(domain);
            return appSettings;
        }

        public static bool IsDevelopment()
        {
            try
            {
                string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                return env == null? false: Convert.ToBoolean(env.Equals("DEVELOPMENT"));
            }
            catch (Exception)
            {

                return false;
            }

        }

        public static JObject GetJsonFromFile(string path)
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                JObject json = JObject.Parse(text);
                return json;
            }
            return null;
        }
    }
}
