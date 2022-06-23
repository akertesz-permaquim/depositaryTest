namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class DepositarioMonitor
    {
        public Int64 DepositarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Sector { get; set; }
        public string Sucursal { get; set; }
        public string Empresa { get; set; }
        public string NumeroSerie { get; set; }
        public string CodigoExterno { get; set; }
        public string Modelo { get; set; }
        public bool Habilitado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ValorTotalEnBolsa { get; set; }
        public string SemaforoOnline { get; set; }
        public string SemaforoAnomalia { get; set; }
        public string SemaforoOcupacionBolsa
        {
            get
            {
                if (PorcentajeOcupacionbolsa < 70)
                    return "Verde";
                else if (PorcentajeOcupacionbolsa >= 70 && PorcentajeOcupacionbolsa < 90)
                    return "Amarillo";
                else
                    return "Rojo";
            }
        }
        public double PorcentajeOcupacionbolsa { get; set; }
    }

    public class TransaccionValidadaMonitor
    {
        public Int64 TransaccionId { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public string UsuarioTransaccion { get; set; }
        public string UsuarioCuenta { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public string Contenedor { get; set; }
        public string TotalValidado { get; set; }
        public Int64 DepositarioId { get; set; }
    }

    public class DetalleTransaccionValidadaMonitor
    {
        public Int64 TransaccionId { get; set; }
        public Int64 TransaccionDetalleId { get; set; }
        public DateTime FechaTransaccionDetalle { get; set; }
        public string Denominacion { get; set; }
        public string ImagenDenominacion { get; set; }
        public string Moneda { get; set; }
        public Int64 CantidadUnidades { get; set; }
    }

    public class TransaccionAValidarMonitor
    {
        public Int64 TransaccionId { get; set; }
        public Int64 TransaccionSobreId { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public DateTime FechaTransaccionSobre { get; set; }
        public string TipoTransaccion { get; set; }
        public string UsuarioTransaccion { get; set; }
        public string UsuarioCuenta { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public string Contenedor { get; set; }
        public string CodigoSobre { get; set; }
        public string TotalAValidar { get; set; }
        public Int64 DepositarioId { get; set; }
    }
    public class DetalleTransaccionAValidarMonitor
    {
        public Int64 TransaccionSobreDetalleId { get; set; }
        public DateTime FechaTransaccionSobreDetalle { get; set; }
        public Int64 CantidadDeclarada { get; set; }
        public Int64 TransaccionSobreId { get; set; }
        public string Moneda { get; set; }
        public string TipoValor { get; set; }
    }

    public class ExistenciaValidada
    {
        public Int64 DepositarioId { get; set; }
        public Int64 DenominacionId { get; set; }
        public string Denominacion { get; set; }
        public Int64 CantidadValidada { get; set; }
        public string ImagenDenominacion { get; set; }
        public Int64 MonedaId { get; set; }
        public string Moneda { get; set; }
    }

    public class ExistenciaAValidar
    {
        public Int64 DepositarioId { get; set; }
        public Int64 DenominacionId { get; set; }
        public string Denominacion { get; set; }
        public Int64 CantidadValidada { get; set; }
        public string ImagenDenominacion { get; set; }
        public Int64 MonedaId { get; set; }
        public string Moneda { get; set; }
    }
    public class TotalGeneral
    {
        public Int64 DepositarioId { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }
        public double Total
        {
            get
            {
                return TotalValidado + TotalAValidar;
            }
        }
        public Int64 MonedaId { get; set; }
        public string Moneda { get; set; }
    }

    public class Evento
    {
        public Int64 DepositarioId { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Mensaje { get; set; }
        public string Valor { get; set; }
        public string TipoEvento { get; set; }
    }
}
