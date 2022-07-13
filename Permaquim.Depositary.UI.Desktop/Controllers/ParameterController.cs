using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ParameterController
    {
        public static bool UsesBankAccount
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetApplicationParameterValue("USA_CUENTA_BANCARIA"));
            }
                
        }
        public static int RedStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetApplicationParameterValue("TIMEOUT_ROJO"));
            }

        }
        public static int YellowStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetApplicationParameterValue("TIMEOUT_AMARILLO"));
            }

        }
        public static int GreenStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetApplicationParameterValue("TIMEOUT_VERDE"));
            }

        }
        public static bool RequiresContainerIdentifier
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetApplicationParameterValue("REQUIERE_IDENTIFICADOR_BOLSA"));
            }

        }
        public static bool RequiresEnvelopeIdentifier
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetApplicationParameterValue("REQUIERE_IDENTIFICADOR_SOBRE"));
            }

        }
    }
}
