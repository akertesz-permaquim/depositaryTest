using System.ComponentModel.DataAnnotations;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class RequestModel
    {
        [Required(ErrorMessage = "ClientDate is required")]
        public DateTime ClientDate { get; set; }

        [Required(ErrorMessage = "LastSincronizationDate is required")]
        public DateTime LastSincronizationDate { get; set; }
        [Required(ErrorMessage = "DeviceNumber is required")]
        public string Poronga { get; set; }
    }
}
