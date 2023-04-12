
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Permaquim.Depositary.Web.Api.Model
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User NickName is required")]
        [FromHeader]
        public string UserNickName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [FromHeader]
        public string Password { get; set; }
    }

}
