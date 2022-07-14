namespace Permaquim.Depositary.Web.Administration.TransaccionEntities
{
    public enum TipoTransaccion
    {
        NoEspecificado = 0,
        DepositoBillete = 1,
        DepositoMoneda = 2,
        DepositoSobre = 3,
        RetiroValores = 4
    }
    public enum TipoEvento
    {
        AperturaPuerta = 0,
        CambioContenedor = 1,
        AlarmaContenedorMalUbicado = 5,
        AlarmaExclusa = 6,
        FueraServicio = 7
    }

    public class Contenedor
    {
        public Int64 ContenedorId { get; set; }
        public string Identificador { get; set; }
    }
}
