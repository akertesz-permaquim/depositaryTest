using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{

    internal static class DeviceController
    {
      public static int GetPollingInterval()
        {
            
            int returnValue = Int32.Parse( ConfigurationController.
                GetDepositaryConfigurationItem(Global.Enumerations.DepositaryConfigurationEnum.POLLTIME));
            return returnValue;
        }
        public static int GetSleepInterval()
        {

            int returnValue = Int32.Parse(ConfigurationController.
                GetDepositaryConfigurationItem(Global.Enumerations.DepositaryConfigurationEnum.SLEEPTIME));
            return returnValue;
        }
    }
}
