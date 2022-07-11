
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        [FromHeader(Name = "UserName")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        [FromHeader]
        public string Password { get; set; }
    }

}
