﻿namespace Permaquim.Depositary.UI.Desktop.Global
{
    public static class Enumerations
    {

        public enum CounterCommandEnum
        {
            DeviceReset,
            RemoteCancel,
            OpenEscrow,
            CloseEscrow,
            DepositMode,
            ManualDepositMode,
            NormalErrorRecoveryMode,
            StoringErrorRecoveryMode,
            CollectMode,
            StopCounting,
            StoringStart,
            BatchDataTransmission,
            Sense,
            CountingDataRequest,
            DenominationDataRequest,
            SwitchCurrency
        }
        public enum IoboardCommandEnum
        {
            Open,
            Close,
            UnLock,
            Status,
            Empty,
            Approve
        }

        public enum InformationTypeEnum
        {
            None,
            Information,
            Alert,
            Error,
            Event
        }

        public enum OperationTypeEnum
        {
            None = 0,
            BillDeposit = 1,
            CoinDeposit = 2,
            EnvelopeDeposit = 3,
            ValueExtraction = 4
        }
        public enum ReportTypeEnum
        {
            None,
            BillDeposit,
            CoinDeposit,
            EnvelopeDeposit,
            ValueExtraction,
            DailyClosing,
            TurnChange

        }
        public enum ColorNameEnum
        {
            Ninguno = 0,
            CabeceraAplicacion,
            FondoFormulario,
            PieAplicacion,
            FuentePrincipal,
            FuenteContraste,
            BotonEstandar,
            BotonAceptar,
            BotonCancelar,
            BotonContinuar,
            BotonAlerta,
            BotonSalir,
            BotonAlternativo,
            TextoInformacion,
            TextoAlerta,
            TextoError,
            TextoEvento,
            FondoControl,
            CabeceraGrilla,
            PieGrilla,
            FondoGrilla,
            FondoFilasGrilla,
            TextoFilasGrilla,
            ColorBordesCeldasGrilla,
            SegundaCabeceraGrilla,
            Breadcrumb

        }
        public enum BagExtractionProcessEnum
        {
            BagError = -1,
            None = 0,
            GateWaitingToRelease,
            GateUnlocked,
            GateReleased,
            BagExtracting,
            BagExtracted,
            BagPuttingStart,
            IdentifierPending,
            ProcessFinished
        }
        public enum SelectedEditElementEnum
        {
            None = 0,
            Cell = 1,
            EnvelopeCode = 2
        }
        public enum OperationblockingReasonEnum
        {
            None = 0,
            NoTurn,
            NoBag,
            PortError
        }
        public enum DepositaryConfigurationEnum
        {
            NOESP,
            BILLDEP,
            SBRDEP,
            MONDEP,
            BILLNTF,
            ENVNTF,
            COINDEP,
            TRN,
            TMR,
            RIC,
            RIS,
            CNTCPTCK,
            BLOQFALT,
            ERRNTF,
            SISERR,
            PAPELNTF,
            CONTCAPNTF,
            COMCONTNTF,
            COMIOBOARDNTF,
            ACEPTAMULTIMONEDA,
            ACEPTAUSLOC,
            TEMPLATEMONCOMPLETO,
            CNTCPDEPOSITO,
            POLLTIME,
            SLEEPTIME
        }
        public enum MultiLanguageEnum
        {
            LOGIN_TITLE,
            USERTEXTBOXPLACEHOLDER,
            PASSWORDTEXTBOXPLACEHOLDER,
            FALTA_USUARIO_PASSWORD,
            USUARIO_NO_REGISTRADO,
            SIN_TURNO,
            EXISTEN_TURNOS_ABIERTOS,
            SIN_BOLSA,
            SIN_BOLSA_ACTIVA,
            VOLVER,
            PUERTA_ABIERTA,
            ERROR_POSICION_BOLSA,
            PRESIONAR_BOTON_INICIAR,
            ESPERANDO_APERTURA_PUERTA,
            PUERTA_LIBERADA,
            PUEDE_RETIRAR_BOLSA,
            EXTRAYENDO_BOLSA,
            BOLSA_EXTRAIDA,
            INGRESANDO_BOLSA,
            PROCESO_BOLSA_FINALIZADO,
            INDICAR_CODIGO_BOLSA,
            TIEMPO_RESTANTE,
            SUB_TOTAL,
            ENVELOPE_TEXTBOX_PLACEHOLDER,
            ABRIR_PUERTA,
            ACCEPT_BUTTON,
            INGRESE_CODIGO_CONTENEDOR,
            CANCEL_BUTTON,
            EXIT_BUTTON,
            DENOMINACION,
            DESCRIPCION,
            ID,
            IMAGEN,
            CANTIDAD,
            USUARIOCUENTA,
            USUARIO,
            TURNO,
            TOTAL,
            TOTAL_VALIDADO,
            TOTAL_A_VALIDAR,
            TIPOVALOR,
            TIPOID,
            TIPO,
            SOPORTE,
            CIERREDIARIO,
            BILLETE,
            BILLETES,
            MONEDA,
            SOBRE,
            SOBRES,
            RETIRAR_SOBRE,
            INGRESAR_VALORES_SOBRE,
            RETIRAR_BILLETES_RECHAZADOS,
            IMPORTE,
            AGUARDE_DEPOSITO,
            OTRAS_OPERACIONES,
            INGRESAR_BILLETES,
            HISTORICO_OPERACIONES,
            FINALIZADA,
            FECHA,
            ESCROW_LLENO,
            CANCELAR_DEPOSITO,
            EMPRESA,
            DISPOSITIVO,
            CONTINUE_BUTTON,
            CONTENEDOR,
            CONTANDO,
            CONTINUAR_INGRESANDO_BILLETES,
            ACEPTAR_O_CANCELAR_DEPOSITO,
            CANTIDADUNIDADES,
            TRANSACCIONES_TURNO,
            CONFIRMA_CIERRE_TURNO,
            CONFIRMA_CIERRE_ULTIMO_TURNO,
            CONFIRMA_CIERRE_DIARIO,
            CIERRE_DIARIO,
            CANTIDADDECLARADA,
            CAMBIO_TURNO,
            REPORTES,
            CONTENIDO_BOLSA,
            HISTORICO_BOLSA,
            CANTIDADOPERACIONES,
            SUCURSAL,
            SECTOR,
            DEPOSITARIO,
            CODIGO,
            SOLICITAR_MAS_TIEMPO,
            REQUIERE_IDENTIFICADOR_SOBRE,
            EJECUTAR,
            NUMERIC_TEXTBOX_PLACEHOLDER,
            ALPHANUMERIC_TEXTBOX_PLACEHOLDER,
            BAG_CODE_PLACEHOLDER,
            FIN_DEPOSITO,
            CURRENCYSELECTORFORM,
            DAILYCLOSINGFORM,
            ENVELOPEDEPOSITFORM,
            INPUTBOXFORM,
            KEYBOARDINPUTFORM,
            MAINFORM,
            NUMERICINPUTBOXFORM,
            OPERATIONBLOCKINGFORM,
            OPERATIONFORM,
            OPERATIONSHISTORYFORM,
            OTHEROPERATIONSFORM,
            PREFERENCESFORM,
            REPORTSFORM,
            SUPPORTFORM,
            SYSTEMBLOCKI, NGDIALOG,
            TURNCHANGEFORM,
            ERROR_FALTA_DATO,
            ERROR_PUERTO,
            TOQUE_PANTALLA_PARA_INICIAR
        }

        public enum FunctionEnum
        {
            BillDeposit = 99,
            CoinDeposit = 100,
            EnvelopeDeposit = 101,
            OtherOperations = 102,
            BagContent = 103,
            BagExtraction = 104,
            DailyClosing = 105,
            Transactions = 106,
            Support = 107,
            TurnChange = 108,
            ViewEvents = 109,
            Reports = 110,
            BagHistory = 111 
        }

        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }
    }
}
