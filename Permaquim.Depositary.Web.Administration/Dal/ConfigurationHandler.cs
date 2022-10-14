using Microsoft.Extensions.Configuration;
internal class ConfigurationHandler
{
     internal static String PasswordKey
     {
         get { return getConfiguration(Constants.PASSWORDKEY); }
     }
     internal static String ConnectionString
     {
         get { return getConfiguration(Constants.CONNECTIONSTRING); }
     }
     internal static String AdoNetAssemblyName
     {
         get { return getConfiguration(Constants.ADONETASSEMBLYNAME); }
    }
     internal static String AdoNetConnectionTypeName
     {
         get { return getConfiguration(Constants.ADONETCONNECTIONTYPENAME); }
    }
     internal static Int32 AdoNetCommandTimeout
     {
         get { return Convert.ToInt32(getConfiguration(Constants.ADONETCOMMANDTIMEOUT)); }
    }
     internal static String ParameterPrefix
     {
         get { return getConfiguration(Constants.PARAMETERPREFIX); }
    }
     internal static String PkFunction
     {
         get { return getConfiguration(Constants.PKFUNCTION); }
    }

    private static string getConfiguration(string configurationEntry)
    {

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")== null? String.Empty: 
             Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".";
        var builder = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile( "appsettings." + env + "json", optional: false, reloadOnChange: true);
        

        IConfigurationRoot configuration = builder.Build();

        return configuration.GetSection("AppSettings").GetSection(configurationEntry).Value.ToString();
    }
}

