namespace Permaquim.Depositary.UI.Desktop.Global
{
    public static class Enumerations
    {
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
    }
}
