using Microsoft.Extensions.Configuration;
using Permaquim.Depositary.Sincronization.Console.Security;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class ConfigurationController
    {

        public static string GetCurrentDepositaryCode()
        {
            return Cryptography.Decrypt(
                ConfigurationController.GetConfiguration("CodigoDepositario"),
                ConfigurationController.GetConfiguration("PasswordKey"));
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
