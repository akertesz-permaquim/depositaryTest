using Microsoft.AspNetCore.Components;
using Radzen;

namespace Permaquim.Depositary.Web.Administration.Components
{
    public partial class CambioPasswordComponent : ComponentBase
    {
        public class PasswordChangeForm
        {
            public string ActualPassword { get; set; }
            public string NewPassword { get; set; }
            public string NewPasswordCopy { get; set; }
        }

        [Inject]
        protected NotificationService NotificationService { get; set; }
    }
}
