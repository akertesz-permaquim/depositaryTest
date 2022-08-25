using Microsoft.Extensions.Configuration;
using Permaquim.Depositary.Sincronization.Console.Security;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class ConfigurationController
    {
        private static Int64? _depositaryId;

        public static string GetCurrentDepositaryCode()
        {
            return Cryptography.Decrypt(
                ConfigurationController.GetConfiguration("CodigoDepositario"),
                ConfigurationController.GetConfiguration("PasswordKey"));
        }

        public static Int64 GetCurrentDepositaryId()
        {
            if(!_depositaryId.HasValue)
            {
                Depositario.Business.Tables.Dispositivo.Depositario oDepositario = new();
                oDepositario.Where.Add(Depositario.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno, Depositario.sqlEnum.OperandEnum.Equal, GetCurrentDepositaryCode());
                oDepositario.Items();

                if (oDepositario.Result.Count > 0)
                    _depositaryId = oDepositario.Result[0].Id;
            }

            return _depositaryId.Value;
        }

        public static string GetConfiguration(string configurationEntry)
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
