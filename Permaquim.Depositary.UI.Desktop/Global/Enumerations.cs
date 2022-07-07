namespace Permaquim.Depositary.UI.Desktop.Global
{
    public static class Enumerations
    {

        public enum LogTypeEnum
        {
            Excepction = 0,
            Information = 1
        }
        public enum OperationTypeEnum
        {
            None = 0,
            BillDeposit = 1,
            CoinDeposit = 2,
            EnvelopeDeposit = 3,
            ValueExtraction = 4
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
            FondoControl,
            CabeceraGrilla,
            PieGrilla,
            FondoGrilla,
            FondoFilasGrilla,
            TextoFilasGrilla,
            SegundaCabeceraGrilla

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
            NoTurn = 1
        }
        public enum DepositaryConfiguratoinEnum
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
            //SALIR,
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
            ID,
            IMAGEN,
            CANTIDAD,
            USUARIOCUENTA,
            USUARIO,
            TURNO,
            TOTAL,
            TOTALVALIDADO,
            TOTALAVALIDAR,
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
            CONFIRMA_CIERRE_TURNO,
            CONFIRMA_CIERRE_DIARIO,
            CIERRE_DIARIO,
            CANTIDADDECLARADA,
            CAMBIO_TURNO,
            REPORTES,
            CONTENIDO_BOLSA
        }
    }
}
