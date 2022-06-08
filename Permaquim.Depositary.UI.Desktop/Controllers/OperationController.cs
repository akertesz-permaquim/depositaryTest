using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class OperationController
    {
        public enum OperationTypeEnum
        {
            Ninguno = 0,
            DepositoBillete = 1,
            DepositoMoneda = 2,
            Depositosobre = 3,
            RetirodeValores = 4
        }
        public static OperationTypeEnum OperationType { get; set; }
    }
}
