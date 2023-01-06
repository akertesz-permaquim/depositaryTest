using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class DatabaseController
    {
        private static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario _currentDepositary = null;
        public static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario CurrentDepositary
        {
            get
            {
                if (_currentDepositary == null)
                {
                    Permaquim.Depositario.Business.Relations.Dispositivo.Depositario entity = new();
                    entity.Where.Add(Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id,
                        Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado,
                      Depositario.sqlEnum.OperandEnum.Equal, true);
                    entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                        Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                      Depositario.sqlEnum.OperandEnum.Equal, ConfigurationController.GetCurrentDepositaryCode());

                    _currentDepositary = entity.Items().FirstOrDefault();
                }

                return _currentDepositary;

            }
        }
        public static void EndinitialSincro()
        {
            long? depositaryId = ConfigurationController.GetCurrentDepositaryId();

            if (depositaryId.HasValue)
            {
                //Finalmente ejecutamos la SP que termina de modelar la base de datos
                Depositario.Business.Procedures.dbo.FinalizarPrimeraSincronizacion oSP = new();
                oSP.Items(ConfigurationController.GetCurrentDepositaryId());
            }
        }
    }
}
