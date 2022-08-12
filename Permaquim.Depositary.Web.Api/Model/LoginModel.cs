
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "DepositaryCode is required")]
        [FromHeader]
        public string DepositaryCode { get; set; }
    }

}
