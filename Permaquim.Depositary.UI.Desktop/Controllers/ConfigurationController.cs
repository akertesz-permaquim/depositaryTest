using Microsoft.Extensions.Configuration;
using Permaquim.Depositary.UI.Desktop.Model;
using Permaquim.Depositary.UI.Desktop.Security;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ConfigurationController
    {
        public static string GetDepositaryConfigurationItem(DepositaryConfigurationEnum key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entities = new();
            entities.Where.Add(Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, (long)key);
            if (entities.Items().Count > 0)
                returnValue = entities.Result.FirstOrDefault().Valor;

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
    }
}
