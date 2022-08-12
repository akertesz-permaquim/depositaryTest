using Permaquim.Depositary.Sincronization.Console.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class LoginModel : IModel
    {
        private const string WEBAPI_USER = "WEBAPI_USER";
        private const string WEBAPI_PASSWORD = "WEBAPI_PASSWORD";

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "DepositaryCode is required")]
        public string DepositaryCode { get; set; }
        public LoginModel()
        {
            DatabaseController DatabaseController = new();
            this.UserName = DatabaseController.GetApplicationParameterValue(WEBAPI_USER);
            this.Password = DatabaseController.GetApplicationParameterValue(WEBAPI_PASSWORD);
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public void Persist()
        {
            throw new NotImplementedException();
        }


    }


}
