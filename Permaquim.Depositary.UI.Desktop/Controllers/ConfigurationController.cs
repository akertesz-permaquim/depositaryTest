using Permaquim.Depositary.UI.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ConfigurationController
    {
        public static string GetDepositaryConfigurationItem(DepositaryConfigurationEnum key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario entities = new();
            entities.Where.Add(Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId,
                Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentDepositary.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.Habilitado,
                Depositario.sqlEnum.OperandEnum.Equal, true);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId,
                Depositario.sqlEnum.OperandEnum.Equal, (long)key);
            if (entities.Items().Count > 0)
                returnValue = entities.Result.FirstOrDefault().Valor;

            return returnValue;
        }
        public static SettingsModel SettingsModel()
        {
            SettingsModel model = new SettingsModel();
            return model;
        }
    }
}
