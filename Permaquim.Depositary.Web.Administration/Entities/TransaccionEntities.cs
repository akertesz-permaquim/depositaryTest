namespace Permaquim.Depositary.Web.Administration.TransaccionEntities
{
    public enum TipoTransaccion
    {
        DepositoBillete = 1,
        DepositoMoneda = 2,
        DepositoSobre = 3,
        RetiroValores = 7
    }
    public enum TipoEvento
    {
        AperturaPuerta = 0,
        CambioContenedor = 1,
        AlarmaContenedorMalUbicado = 5,
        AlarmaExclusa = 6,
        FueraServicio = 7
    }
}
