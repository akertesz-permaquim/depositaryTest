using System.Drawing.Printing;
using System.Management;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class PrinterController
    {

        public static string GetDefaultPrinterName()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return settings.PrinterName;
            }
            return string.Empty;
        }
        private static Dictionary<string, object> _printerStatus = new Dictionary<string, object>();    
        public static Dictionary<string, object> GetPrinterStatus(string printerName)
        {

            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            using (ManagementObjectCollection coll = searcher.Get())
            {
                try
                {
                    foreach (ManagementObject printer in coll)
                    {
                        foreach (PropertyData property in printer.Properties)
                        {
                            if (!_printerStatus.ContainsKey(property.Name))
                                _printerStatus.Add(property.Name, property.Value);
                        }
                    }
                }
                catch (ManagementException ex)
                {
                    return null;
                }

                return _printerStatus;
                
            }
        }

        public static List<String> GetPrintersList()
        {
            List<String> returnValue = new();

            ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
            objScope.Connect();

            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            foreach (ManagementObject mo in MOC)
            {
                returnValue.Add(mo["Name"].ToString());
            }

            return returnValue;
        }
        public static string GetCurrentPrinterstatus(string printerName)
        {
            string returnValue = string.Empty;

            if (GetPrintersList().Count == 0)
            {
                throw new Exception(MultilanguangeController.GetText(MultiLanguageEnum.SIN_IMPRESORAS_INSTALADAS));
            }
            else
            {
                if (GetDefaultPrinterName().Equals(String.Empty))
                {
                    throw new Exception(MultilanguangeController.GetText(MultiLanguageEnum.SIN_IMPRESORA_PREDETERMINADA));
                }
                else
                {
                    GetPrinterStatus(printerName);

                    if (_printerStatus.Count > 0)
                    {
                        if (_printerStatus.ContainsKey("PrinterState") && _printerStatus.ContainsKey("PrinterStatus"))
                        {
                            if (_printerStatus["PrinterState"].Equals("144") && _printerStatus["PrinterStatus"].Equals("2"))
                            {
                                returnValue = MultilanguangeController.GetText(MultiLanguageEnum.IMPRESORA_PUERTA_ABIERTA);
                            }
                            if (_printerStatus["PrinterState"].Equals("0") && _printerStatus["PrinterStatus"].Equals("2"))
                                returnValue = MultilanguangeController.GetText(MultiLanguageEnum.IMPRESORA_SIN_ALIMENTACION);
                            if (_printerStatus["PrinterState"].Equals("136") && _printerStatus["PrinterStatus"].Equals("2"))
                                returnValue = MultilanguangeController.GetText(MultiLanguageEnum.IMPRESORA_ATASCADA);
                        }
                        if (returnValue.Equals(string.Empty))
                            DeviceController.PrinterStatus = Global.Constants.NORMAL;
                        else
                            DeviceController.PrinterStatus = returnValue;
                    }
                }
                return returnValue;
            }
        }
    }
}


