using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class SecurityController
    {
        public static bool IsFunctionEnabled(long functionId)
        {
            return DatabaseController.IsFuntionEnabled(functionId);
        }
        public static bool IsFunctionEnabled(FunctionEnum function)
        {
            return DatabaseController.IsFuntionEnabled(Enum.GetName(function));
        }
        public static bool IsOperationEnabled(long functionId)
        {
            return IsFunctionEnabled(functionId);
        }

    }
}
