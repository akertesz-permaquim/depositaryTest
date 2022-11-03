namespace Permaquim.Depositary.UI.Desktop.Global
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
            None = 0,
            BillDeposit,
            EnvelopeDepositFirstReport,
            EnvelopeDepositSecondReport,
            ValueExtraction,
            DailyClosing,
            TurnChange,
            CoinDeposit

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
            PortError,
            CounterCommunicationError,
            IoBoardCommunicationError,
            ContainerMaxVolumeReached,
            DoorWasOpened,
            CurrentContainerIsClosed,
            DepositaryDisabled,
            ContainerError,
            PrinterError
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
            TITULO_LOGIN,
            INGRESE_CRDENCIALES_AUTORIZACION,
            PLACEHOLDER_TEXTO_USUARIO,
            PLACEHOLDER_TEXTO_PASSWORD,
            FALTA_USUARIO_PASSWORD,
            USUARIO_NO_REGISTRADO,
            USUARIO_NO_HABILITADO_EN_SECTOR,
            SIN_TURNO,
            EXISTEN_TURNOS_ABIERTOS,
            EXISTEN_TURNOS_PREVIOS_A_LA_FECHA,
            SIN_BOLSA,
            SIN_BOLSA_ACTIVA,
            LIMITE_CONTENEDOR_ALCANZADO,
            CONTENEDOR_CERRADO,
            ERROR_GENERICO,
            VOLVER,
            PUERTA_ABIERTA,
            ERROR_OPERACION_PREVIA,
            RETIRE_VALORES_ESCROW,
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
            DEPOSITARIO_NO_INICIALIZADO,
            SUB_TOTAL,
            ENVELOPE_TEXTBOX_PLACEHOLDER,
            ABRIR_PUERTA,
            BOTON_ACEPTAR_OPERACION,
            INGRESE_CODIGO_CONTENEDOR,
            IMPRIMIR,
            BOTON_CANCELAR_OPERACION,
            BOTON_SALIR,
            DENOMINACION,
            CONTENIDO_DEL_SOBRE,
            DESCRIPCION,
            ID,
            IMAGEN,
            CANTIDAD,
            USUARIOCUENTA,
            CUENTA_BANCARIA,
            ORIGEN_VALOR,
            USUARIO,
            SIN_USUARIO,
            TURNO,
            TOTAL,
            TOTAL_VALIDADO,
            TOTAL_A_VALIDAR,
            TIPOVALOR,
            TIPOID,
            TIPO,
            SOPORTE,
            RESET,
            CIERREDIARIO,
            BILLETE,
            BILLETES,
            MONEDA,
            MONEDAS_SIN_ASOCIAR_EN_SUCURSAL,
            MONEDA_NO_EXISTENTE_EN_DEPOSITARIO,
            MONEDA_SIN_DENOMINACIONES,
            MONEDA_SIN_RELACION_MONEDA_TIPO_VALOR,
            TIEMPO_DE_ENCUESTA_NO_PUEDE_SER_CERO,
            TIEMPO_DE_ESPERA_NO_PUEDE_SER_CERO,
            DEBECAMBIARPASSWORD,
            CUENTA_USUARIO_EXPIRADA,
            NO_POSEE_PERMISOS,
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
            FECHA_APERTURA,
            FECHA_CIERRE,
            FECHA_DESDE,
            FECHA_HASTA,
            ESCROW_LLENO,
            CANCELAR_DEPOSITO,
            EMPRESA,
            CUENTA_BANCARIA_OBLIGATORIA,
            ORIGEN_VALOR_OBLIGATORIO,
            DISPOSITIVO,
            BOTON_CONTINUAR,
            CONTENEDOR,
            CONTANDO,
            CONTINUAR_INGRESANDO_BILLETES,
            ACEPTAR_O_CANCELAR_DEPOSITO,
            ELIMINAR_ERRORES,
            CANTIDADUNIDADES,
            TRANSACCIONES_TURNO,
            CONFIRMA_CIERRE_TURNO,
            CONFIRMA_CIERRE_ULTIMO_TURNO,
            CONFIRMA_CIERRE_DIARIO,
            CIERRE_DIARIO_REALIZADO,
            CIERRE_DIARIO,
            CANTIDADDECLARADA,
            CAMBIO_TURNO,
            REPORTES,
            CONTENIDO_BOLSA,
            HISTORICO_BOLSA,
            HISTORICO_TURNO,
            HISTORICO_CIERRE_DIARIO,
            CANTIDADOPERACIONES,
            SUCURSAL,
            SECTOR,
            DEPOSITARIO,
            CODIGO,
            SOLICITAR_MAS_TIEMPO,
            REQUIERE_IDENTIFICADOR_SOBRE,
            EJECUTAR,
            PLACEHOLDER_TEXTBOX_NUMERICO,
            PLACEHOLDER_TEXTBOX_ALFANUMERICO,
            PLACEHOLDER_CODIGO_CONTENEDOR,
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
            SYSTEMBLOCKINGDIALOG,
            TURNCHANGEFORM,
            ERROR_FALTA_DATO,
            ERROR_DATO,
            ERROR_PUERTO,
            ERROR_COMUNICACION_CONTADORA,
            ERROR_COMUNICACION_PLACA,
            TOQUE_PANTALLA_PARA_INICIAR,
            TICKET_NO_CONFIGURADO,
            FECHA_APERTURA_DESDE,
            FECHA_APERTURA_HASTA,
            FECHA_CIERRE_DESDE,
            FECHA_CIERRE_HASTA,
            IDENTIFICADOR,
            IMPRESION_ORIGINAL,
            IMPRESION_COPIA,
            FORMATO_FECHA,
            FORMATO_FECHA_HORA_COMPLETA,
            FORMATO_TRES_COLUMNAS,
            FORMATO_CUATRO_COLUMNAS,
            IMPRESORA_PUERTA_ABIERTA,
            IMPRESORA_SIN_ALIMENTACION,
            IMPRESORA_ATASCADA
        }

        public enum FunctionEnum
        {
            DepositoDeBilletes,
            DepositoDeMonedas,
            DepositoDeSobres,
            OtrasOperaciones,
            ContenidoDeBolsa,
            ExtraccionDeValores,
            CierreDiario,
            HistoricoTransacciones,
            Soporte,
            CambioDeTurno,
            VerEventos,
            Reportes,
            HistoricoDeBolsas,
            HistoricoDeTurnos ,
            HistoricoDeCierreDiario,
            Reset

        }

        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }

        public enum EventTypeEnum
        {
            Normal,
            Cambio_de_Contenedor,
            Alarma_de_Contenedor_Mal_Ubicado,
            Alarma_De_Exclusa,
            Estado_Fuera_De_Servicio,
            Error_De_Comunicacion,
            Apertura_de_Puerta,
            Cambio_de_Contenedor_Sin_usuario
        }

        public enum ContainerChangeEventEnum
        {
            WhenDoorIsOpened,
            WhenBagIsExtracted
        }

    }
}
