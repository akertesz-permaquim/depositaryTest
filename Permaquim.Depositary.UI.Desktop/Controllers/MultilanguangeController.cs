﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class MultilanguangeController
    {

        private static List<Permaquim.Depositario.Entities.Tables.Regionalizacion.LenguajeItem> _languageItems = new();

        public static List<Permaquim.Depositario.Entities.Tables.Regionalizacion.LenguajeItem> LanguageItems
        {
            get
            {
                if (_languageItems.Count == 0)
                {
                    Permaquim.Depositario.Business.Tables.Regionalizacion.LenguajeItem entities = new();
                    entities.Where.Add(Depositario.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId,
                        Depositario.sqlEnum.OperandEnum.Equal,
                       DatabaseController.CurrentUser== null ? 1 : DatabaseController.CurrentUser.LenguajeId.Id);
                    _languageItems = entities.Items();

                    return entities.Result;
                }

                return _languageItems;
            }
        }
        public static string GetText(string key)
        {
            var ret = LanguageItems.FirstOrDefault(s => s.Clave.StartsWith(key));

            return ret == null ? "***" : ret.Texto;
        }
        public static string GetTextFromDatabase(string key)
        {
            string returnValue = string.Empty;

            Permaquim.Depositario.Business.Tables.Regionalizacion.LenguajeItem entities = new();
            entities.Where.Add(Depositario.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId,
                Depositario.sqlEnum.OperandEnum.Equal,
               DatabaseController.CurrentUser == null ? 1 : DatabaseController.CurrentUser.LenguajeId.Id);
            entities.Where.Add(Depositario.sqlEnum.ConjunctionEnum.AND,
                Depositario.Business.Tables.Regionalizacion.LenguajeItem.ColumnEnum.Clave,
                       Depositario.sqlEnum.OperandEnum.Equal, key);
            entities.Items();
            if(entities.Result.Count > 0)
                returnValue = entities.Result.FirstOrDefault().Texto;

            return returnValue.Equals(string.Empty) ? "***" : returnValue;
        }
        public static string GetText(MultiLanguageEnum key)
        {
            var ret = LanguageItems.FirstOrDefault(s => s.Clave.Equals(Enum.GetName(key)));

            return ret == null ? "***" : ret.Texto;
        }
        public static void ResetLanguage()
        {
            _languageItems = new();
        }
    }
}
