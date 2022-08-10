using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Launcher.Controllers
{
    internal static class DatabaseController
    {
        public static Permaquim.Depositario.Entities.Relations.Dispositivo.Depositario CurrentDepositary
        {
            get
            {
                Permaquim.Depositario.Business.Relations.Dispositivo.Depositario entity = new();
                entity.Where.Add(Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Id,
                    Depositario.sqlEnum.OperandEnum.NotEqual, 0);
                entity.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                    Depositario.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado,
                  Depositario.sqlEnum.OperandEnum.Equal, true);
                return entity.Items().FirstOrDefault();
            }
        }
    }
}
