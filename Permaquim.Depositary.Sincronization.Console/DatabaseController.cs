using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Sincronization.Console
{
    internal static class DatabaseController
    {
        public static string GetApplicationParameterValue(string key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Aplicacion.Configuracion entities = new();
            entities.Where.Add(Depositario.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave,
                Depositario.sqlEnum.OperandEnum.Equal, key);
            entities.Items();
            if (entities.Result.Count > 0)
                return entities.Result.FirstOrDefault().Valor;

            return returnValue;
        }
    }
}
