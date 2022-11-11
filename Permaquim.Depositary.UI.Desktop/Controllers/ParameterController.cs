using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ParameterController
    {
        public static bool UsesShutter
        {
            get
            {
                return true;// Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("USA_SHUTTER"));
            }

        }

        public static bool UsesBankAccount
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("USA_CUENTA_BANCARIA"));
            }
                
        }
        public static bool UsesValueOrigin
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("USA_ORIGEN_VALOR"));
            }

        }
        public static int RedStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_ROJO"));
            }

        }
        public static int YellowStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_AMARILLO"));
            }

        }
        public static int GreenStatusIndicator
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("TIMEOUT_VERDE"));
            }

        }
        public static bool RequiresContainerIdentifier
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("REQUIERE_IDENTIFICADOR_BOLSA"));
            }

        }
        public static bool RequiresEnvelopeIdentifier
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("REQUIERE_IDENTIFICADOR_SOBRE"));
            }

        }

        public static bool PrintsBillDeposit
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_BILLETE"));
            }

        }

        public static bool PrintsDailyClosing
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CIERRE_DIARIO"));
            }

        }
        public static bool PrintsTurnChange
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CAMBIO_TURNO"));
            }

        }
        public static bool PrintsBagExtraction
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_CAMBIO_BOLSA"));
            }

        }
        public static int PrintTurnChangeQuantity
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CAMBIO_TURNO"));
            }

        }
        public static int PrintBagExtractionQuantity
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CAMBIO_BOLSA"));
            }

        }
        public static int PrintDailyClosingQuantity
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_CIERRE_DIARIO"));
            }

        }
        public static int PrintBillDepositQuantity
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_DEPOSITO_BILLETE"));
            }

        }
        public static int PrintEnvelopeDepositQuantity
        {
            get
            {
                return Convert.ToInt32(DatabaseController.GetEnterpriseParameterValue("CANTIDAD_TICKET_DEPOSITO_SOBRE"));
            }

        }
        public static bool PrintsEnvelopeDeposit
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_SOBRE"));
            }

        }
        public static bool PrintsCoinDeposit
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetEnterpriseParameterValue("IMPRIME_TICKET_DEPOSITO_MONEDA"));
            }

        }

        public static decimal RedBagPercent
        {
            get
            {
                return Convert.ToDecimal(DatabaseController.GetEnterpriseParameterValue("PORCENTAJE_CONTENEDOR_ROJO"));
            }

        }
        public static int BagSensorBehaviour
        {
            get
            {
                return Convert.ToInt16(DatabaseController.GetEnterpriseParameterValue("COMPORTAMIENTO_SENSORES_CONTENEDOR"));
            }

        }
        public static int BagMaxPercentage
        {
            get
            {
                return Convert.ToInt16(DatabaseController.GetEnterpriseParameterValue("PORCENTAJE_CONTENEDOR_ROJO"));

            }

        }

        public static bool ValidatesBagInplace
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetDepositaryParameterValue("VALIDA_EXISTENCIA_BOLSA"));
            }

        }
        public static bool ForcedValueExtractionNeedsAuthorization
        {
            get
            {
                return Convert.ToBoolean(DatabaseController.GetDepositaryParameterValue("EXTRACCION_BOLSA_REQUIERE_AUTORIZACION"));
            }

        }
        public static bool DeviceLogEnabled
        {
            get
            {
                bool returnValue = false;
                try
                {

                    returnValue = Convert.ToBoolean(DatabaseController.GetApplicationParameterValue("LOG_DISPOSITIVO_HABILITADO"));
                }
                catch (Exception)
                {

                    returnValue = false;
                }
                return returnValue;
            }
        }
    }
}
