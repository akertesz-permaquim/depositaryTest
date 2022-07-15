using Microsoft.Reporting.WinForms;
using Permaquim.Depositary.UI.Desktop.Helpers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ReportController
    {
        public static void PrintReport(ReportTypeEnum report,
            List<ReportDataSource> dataSources, 
            List<ReportParameter> parameters = null)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Directory.GetCurrentDirectory()  + @"\Reports\" +
                Enum.GetName(report) + ".rdlc";

            foreach (var item in dataSources)
            {
                localReport.DataSources.Add(item);
            }

            PrintReportHelper.PrintToPrinter(localReport);

        }
    }
}
