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
  
        private static Stopwatch _sw;
        private static bool _isTimeOut = false;
        private static long _timeOut { get; set; } = 0;
        private static bool _isActive= false;

        public static bool IsActive()
        {
            return _isActive;
        } 

        public static bool IsTimeOut()
        {
            return _isTimeOut;
        }

        public static long GetRemainingTime()
        {
            long returnValue = 0;
            if (_sw != null)
            {
                if ((_timeOut - _sw.ElapsedMilliseconds) / 1000 == 0)
                {
                    _sw.Stop();
                    _isTimeOut = true;
                }
                returnValue = (_timeOut - _sw.ElapsedMilliseconds) / 1000;
            }
            return returnValue;
        }
        public static void Reset()
        {
            _sw = new Stopwatch();
            _sw.Start();
            _isTimeOut = false;
            _timeOut = DatabaseController.TimeoutGeneral;
            _isActive = true;
        }
        public static void Stop()
        {
            _isActive = false;
            _sw.Stop();
        }
    }
}
