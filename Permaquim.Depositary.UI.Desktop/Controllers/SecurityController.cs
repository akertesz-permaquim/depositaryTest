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
        public static bool IsFunctionenabled(long functionId)
        {
            return DatabaseController.IsFuntionEnabled(functionId);
        }
        public static bool IsFunctionenabled(FunctionEnum function)
        {
            return IsFunctionenabled((long)function);
        }
    }
}
