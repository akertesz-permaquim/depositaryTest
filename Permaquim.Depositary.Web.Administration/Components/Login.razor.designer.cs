using Microsoft.AspNetCore.Components;
using Radzen;

namespace Permaquim.Depositary.Web.Administration.Components
{
    public partial class LoginComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public class LoginForm
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [Inject]
        protected NotificationService NotificationService { get; set; }

    }
}
