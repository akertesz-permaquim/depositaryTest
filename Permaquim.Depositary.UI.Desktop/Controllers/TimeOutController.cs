using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
     public static class TimeOutController
    {
        private const string TIMEOUT_GENERAL = "TIMEOUT_GENERAL";
        private static DateTime referenceTime;


        private static Stopwatch sw;
        private static bool _isTimeOut = false;
        private static long _timeOut { get; set; } = 0;


        public static bool IsTimeOut()
        {
            return _isTimeOut;
        }

        public static long GetRemainingtime()
        {
            long returnValue = 0;
            if (sw != null)
            {
                if ((_timeOut - sw.ElapsedMilliseconds) / 1000 == 0)
                { 
                    sw.Stop(); 
                    _isTimeOut = true;
                }
                returnValue = (_timeOut - sw.ElapsedMilliseconds) / 1000;
            }
            return returnValue;
        }
        public static void Reset()
        {
            sw = new Stopwatch();
            sw.Start();
            _isTimeOut = false;
            _timeOut = Convert.ToInt64(DatabaseController.GetApplicationParameterValue(TIMEOUT_GENERAL));
        }
        
    }
}
