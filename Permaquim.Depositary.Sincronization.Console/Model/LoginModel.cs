using Permaquim.Depositary.Sincronization.Console.Interfaces;
using System.ComponentModel.DataAnnotations;
using Permaquim.Depositary.Sincronization.Console.Controllers;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class LoginModel : IModel
    {
        private const string CODIGODEPOSITARIO = "CodigoDepositario";


        [Required(ErrorMessage = "DepositaryCode is required")]
        public string DepositaryCode { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public LoginModel()
        {
            //this.UserName = DatabaseController.GetApplicationParameterValue(WEBAPI_USER);
            //this.Password = DatabaseController.GetApplicationParameterValue(WEBAPI_PASSWORD);
            this.DepositaryCode = ConfigurationController.GetConfiguration(CODIGODEPOSITARIO);
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
