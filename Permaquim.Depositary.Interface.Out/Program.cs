// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using Permaquim.Depositary.UI.Desktop.Controllers;

InterfaceProcessing processing = new(ConfigurationController.GetAppSettings()["OutputPath"].Value<string>());
processing.Process();
