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
            Cabecera = 1,
            Contenido = 2,
            Pie = 3,
            FuentePrincipal = 4,
            FuenteContraste = 5,
            BotonEstandar = 6,
            BotonAceptar = 7,
            BotonCancelar = 8,
            BotonContinuar = 9,
            BotonAlerta = 10,
            BotonSalir = 11,
            BotonAlternativo = 12,
            TextoInformacion = 13,
            TextoAlerta = 14,
            TextoError = 15

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
    }
}
