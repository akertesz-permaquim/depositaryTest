using Microsoft.Extensions.Configuration;
using Permaquim.Depositary.UI.Desktop.Model;
using Permaquim.Depositary.UI.Desktop.Security;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ConfigurationController
    {
        private const string CODIGODEPOSITARIO = "CodigoDepositario";
        private const string PASSWORDKEY = "PasswordKey";
        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        private const string DEVELOPMENT = "DEVELOPMENT";
        private static Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario _depositaryConfiguratioEntities = new();
        public static string GetDepositaryConfigurationItem(DepositaryConfigurationEnum key)
        {
            string returnValue = string.Empty;

            _depositaryConfiguratioEntities.Where.Clear(); 
            _depositaryConfiguratioEntities.Where.Add(Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary.Id);
            _depositaryConfiguratioEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            _depositaryConfiguratioEntities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, (long)key);
            if (_depositaryConfiguratioEntities.Items().Count > 0)
                returnValue = _depositaryConfiguratioEntities.Result.FirstOrDefault().Valor;

            return returnValue;
        }
        public static SettingsModel SettingsModel()
        {
            SettingsModel model = new SettingsModel();
            return model;
        }


        public static string GetCurrentDepositaryCode()
        {
            return Cryptography.Decrypt(
                ConfigurationController.GetConfiguration(CODIGODEPOSITARIO), 
                ConfigurationController.GetConfiguration(PASSWORDKEY));
        }
  
        private static string GetConfiguration(string configurationEntry)
        {

            var env = Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) == null ? String.Empty :
                 Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) + ".";
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory + @"\")
                            .AddJsonFile("appsettings." + env + "json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetSection("AppSettings").GetSection(configurationEntry).Value.ToString();
        }

        public static bool IsDevelopment()
        {
            try
            {
                string? env = Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT);

                return env == null? false: Convert.ToBoolean(env.Equals(DEVELOPMENT));
            }
            catch (Exception)
            {

                return false;
            }

            
        }
    }
}
