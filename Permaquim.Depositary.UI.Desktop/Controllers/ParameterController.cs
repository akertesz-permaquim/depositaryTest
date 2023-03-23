
namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ParameterController
    {
        public static bool UsesShutter
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("USA_SHUTTER"), out parseResult);
                return parseResult;
            }
        }

        public static bool UsesBankAccount
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("USA_CUENTA_BANCARIA"), out parseResult);
                return parseResult;
            }

        }
        public static bool UsesValueOrigin
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("USA_ORIGEN_VALOR"), out parseResult);
                return parseResult;
            }
        }
        public static int RedStatusIndicator
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_ROJO"), out parseResult);
                return parseResult;
            }
        }
        public static int YellowStatusIndicator
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_AMARILLO"), out parseResult);
                return parseResult;
            }
        }
        public static int GreenStatusIndicator
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_VERDE"), out parseResult);
                return parseResult;
            }
        }
        public static bool RequiresContainerIdentifier
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("REQUIERE_IDENTIFICADOR_BOLSA"), out parseResult);
                return parseResult;
            }
        }
        public static bool RequiresEnvelopeIdentifier
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("REQUIERE_IDENTIFICADOR_SOBRE"), out parseResult);
                return parseResult;
            }
        }
        public static bool TurnAutoClose
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("CIERRE_TURNO_AUTOMATICO"), out parseResult);
                return parseResult;
            }

        }

        public static bool PrintsBillDeposit
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_BILLETE"), out parseResult);
                return parseResult;
            }

        }

        public static bool PrintsDailyClosing
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CIERRE_DIARIO"), out parseResult);
                return parseResult;
            }
        }
        public static bool PrintsTurnChange
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CAMBIO_TURNO"), out parseResult);
                return parseResult;
            }
        }
        public static bool PrintsBagExtraction
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CAMBIO_BOLSA"), out parseResult);
                return parseResult;
            }
        }
        public static int PrintTurnChangeQuantity
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CAMBIO_TURNO"), out parseResult);
                return parseResult;
            }
        }
        public static int PrintBagExtractionQuantity
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CAMBIO_BOLSA"), out parseResult);
                return parseResult;
            }
        }
        public static int PrintDailyClosingQuantity
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CIERRE_DIARIO"), out parseResult);
                return parseResult;
            }
        }
        public static int PrintBillDepositQuantity
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_DEPOSITO_BILLETE"), out parseResult);
                return parseResult;
            }
        }
        public static int PrintEnvelopeDepositQuantity
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_DEPOSITO_SOBRE"), out parseResult);
                return parseResult;
            }
        }
        public static bool PrintsEnvelopeDeposit
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_SOBRE"), out parseResult);
                return parseResult;
            }
        }
        public static bool PrintsCoinDeposit
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_MONEDA"), out parseResult);
                return parseResult;
            }
        }

        public static decimal RedBagPercent
        {
            get
            {
                decimal parseResult = 0;
                decimal.TryParse(DatabaseController.GetEnterpriseParameterValue("PORCENTAJE_CONTENEDOR_ROJO"), out parseResult);
                return parseResult;
            }
        }
        public static int BagSensorBehaviour
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("COMPORTAMIENTO_SENSORES_CONTENEDOR"), out parseResult);
                return parseResult;
            }
        }
        public static int BagMaxPercentage
        {
            get
            {
                int parseResult = 0;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("PORCENTAJE_CONTENEDOR_ROJO"), out parseResult);
                return parseResult;
            }
        }
        public static int EventEvaluationSeconds
        {
            get
            {
                int parseResult = 10;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("EVALUACION_EVENTOS_SEGUNDOS"), out parseResult);
                return parseResult;

            }

        }
        /// <summary>
        /// Cantidad de espera de ciclos en el caso de pérdida de conectividad
        /// entre el soft y la contadora
        /// </summary>
        public static int CounterReconnectRetrials
        {
            get
            {
                int parseResult = 100;
                int.TryParse(DatabaseController.GetEnterpriseParameterValue("REINTENTOS_RECONEXION_CONTADORA"), out parseResult);
                if (parseResult == 0)
                    parseResult = 100;
                return parseResult;

            }

        }

        public static bool ValidatesBagInplace
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetDepositaryParameterValue("VALIDA_EXISTENCIA_BOLSA"), out parseResult);
                return parseResult;
            }

        }
        public static bool ForcedValueExtractionNeedsAuthorization
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetDepositaryParameterValue("EXTRACCION_BOLSA_REQUIERE_AUTORIZACION"), out parseResult);
                return parseResult;
            }

        }
        public static bool DeviceLogEnabled
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("LOG_DISPOSITIVO_HABILITADO"), out parseResult);
                return parseResult;
            }
        }
        /// <summary>
        ///  Exception,Information,Navigation
        /// </summary>

        public static bool LogsExceptions
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("LOGUEA_EXCEPCIONES"), out parseResult);
                return parseResult;
            }
        }
        /// <summary>
        ///  Exception,Information,Navigation
        /// </summary>

        public static bool LogsInformations
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("LOGUEA_INFORMACIONES"), out parseResult);
                return parseResult;
            }
        }
        public static bool LogsNavigations
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("LOGUEA_NAVEGACIONES"), out parseResult);
                return parseResult;
            }
        }
        public static string PrinterName
        {
            get
            {
                string returnValue = DatabaseController.GetDepositaryParameterValue("IMPRESORA_DEPOSITARIO");
                return returnValue.Equals(string.Empty) ? "NII Printer_DS" : returnValue;
            }
        }
        public static bool ShowsAbnormalDevice
        {
            get
            {
                bool parseResult = true;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("MUESTRA_ERROR_ABNORMAL_DEVICE"), out parseResult);
                return parseResult;
            }
        }
        public static bool ShowsJamming
        {
            get
            {
                bool parseResult = true;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("MUESTRA_ERROR_JAMMING"), out parseResult);
                return parseResult;
            }
        }

        public static bool ShowsAbnormalStorage
        {
            get
            {
                bool parseResult = true;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("MUESTRA_ERROR_ABNORMALSTORAGE"), out parseResult);
                return parseResult;
            }
        }

        public static bool ShowsCountingError
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("MUESTRA_ERROR_COUNTING_ERROR"), out parseResult);
                return parseResult;
            }
        }
     
       public static bool ShowsCassetteFull
        {
            get
            {
                bool parseResult = false;
                bool.TryParse(DatabaseController.GetApplicationParameterValue("MUESTRA_ERROR_CASSETTE_FULL"), out parseResult);
                return parseResult;
            }
        }
    }
}
