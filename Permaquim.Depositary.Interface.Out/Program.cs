// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using Permaquim.Depositary.UI.Desktop.Controllers;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Runner runner = new(ConfigurationController.GetAppSettings()["OutputPath"].Value<string>(), ConfigurationController.GetAppSettings()["Interface"].Value<string>());
        runner.ProcessInterface() ;
    }
}