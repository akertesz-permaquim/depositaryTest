namespace Permaquim.Depositary.Web.Administration.TransaccionEntities
{
    public enum TipoTransaccion
    {
        NoEspecificado = 0,
        DepositoBillete = 1,
        DepositoMoneda = 2,
        RetiroValores = 3,
        DepositoSobre = 4
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
