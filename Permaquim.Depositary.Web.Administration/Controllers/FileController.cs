using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public class FileController
    {

        //public async Task<IActionResult> DescargarArchivo(string jsonData, string fileName)
        //{
        //    byte[] byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(jsonData);

        //    return File(byteArray, "application/force-download", fileName);
        //}

        //public ActionResult DescargarArchivo(string jsonData, string fileName)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(jsonData);

        //    var stream = new MemoryStream(bytes);

        //    var result = new FileStreamResult(stream, "text/json");
        //    result.FileDownloadName = fileName;
        //    return result;
        //}
    }
}
