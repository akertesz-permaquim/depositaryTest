namespace Permaquim.Depositary.Web.Administration.MonitorEntities
{
    public class DepositarioMonitor
    {
        public Int64 DepositarioId { get; set; }
        public Int64 EmpresaId { get; set; }
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
        public string SemaforoOcupacionBolsa { get; set; }
        public double PorcentajeOcupacionbolsa { get; set; }
    }

    public class InformacionDepositario
    {
        public Int64 DepositarioId { get; set; }
        public string NumeroSerie { get; set; }
        public string ImagenModelo { get; set; }
        public DateTime? FechaUltimaSincronizacion { get; set; }
        public float PorcentajeOcupacionBolsa { get; set; }
        public string IdentificadorBolsa { get; set; }
        public Double TotalValidado { get; set; }
        public Double TotalAValidar { get; set; }
        public Double Total
        {
            get
            {
                return TotalValidado + TotalAValidar;
            }
        }
        public string CodigoMoneda { get; set; }
        public int CantidadBilletesEnBolsa { get; set; }
        public int CapacidadBilletesBolsa { get; set; }
        public string Turno { get; set; }
        public DateTime? FechaAperturaTurno { get; set; }
        public bool DepositoEnOtraMoneda { get; set; }
    }

    public class TransaccionValidadaMonitor
    {
        public Int64 TransaccionId { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string CodigoOperacion { get; set; }
        public string TipoTransaccion { get; set; }
        public string Moneda { get; set; }
        public string OrigenValor { get; set; }
        public string UsuarioTransaccion { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public string TotalValidado { get; set; }
        public Int64 DepositarioId { get; set; }
    }

    public class DetalleTransaccionValidadaMonitor
    {
        public Int64 TransaccionId { get; set; }
        public Int64 TransaccionDetalleId { get; set; }
        public DateTime FechaTransaccionDetalle { get; set; }
        public Int64 DenominacionId { get; set; }
        public string Denominacion { get; set; }
        public string ImagenDenominacion { get; set; }
        public string CodigoMoneda { get; set; }
        public double TotalValidado { get; set; }
        public string TotalValidadoFormateado
        {
            get
            {
                return CodigoMoneda + " " + TotalValidado.ToString();
            }
        }
        public Int64 CantidadUnidades { get; set; }
    }

    public class TransaccionAValidarMonitor
    {
        public Int64 TransaccionId { get; set; }
        public Int64 TransaccionSobreId { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public DateTime FechaTransaccionSobre { get; set; }
        public string CodigoOperacion { get; set; }
        public string TipoTransaccion { get; set; }
        public string UsuarioTransaccion { get; set; }
        public string OrigenValor { get; set; }
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public string CodigoSobre { get; set; }
        public string TotalAValidar { get; set; }
        public string Moneda { get; set; }
        public Int64 DepositarioId { get; set; }
    }
    public class DetalleTransaccionAValidarMonitor
    {
        public Int64 TransaccionSobreDetalleId { get; set; }
        public DateTime FechaTransaccionSobreDetalle { get; set; }
        public Int64 CantidadDeclarada { get; set; }
        public double ValorDeclarado { get; set; }
        public Int64 TransaccionSobreId { get; set; }
        public string CodigoMoneda { get; set; }
        public string ValorDeclaradoFormateado
        {
            get
            {
                return CodigoMoneda + " " + ValorDeclarado.ToString();
            }
        }
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
        public string Moneda { get; set; }
        public Int64 MonedaId { get; set; }
        public Int64 TipoValorId { get; set; }
        public string TipoValor { get; set; }
        public string ImagenTipoValor { get; set; }
        public Int64 Cantidad { get; set; }
    }
    public class TotalGeneral
    {
        public Int64 DepositarioId { get; set; }
        public double TotalValidado { get; set; }
        public double TotalAValidar { get; set; }
        public string TotalValidadoFormateado
        {
            get
            {
                return CodigoMoneda + " " + TotalValidado.ToString();
            }
        }
        public string TotalAValidarFormateado
        {
            get
            {
                return CodigoMoneda + " " + TotalAValidar.ToString();
            }
        }
        public string Total
        {
            get
            {
                return CodigoMoneda + " " + (TotalValidado + TotalAValidar).ToString();
            }
        }
        public Int64 MonedaId { get; set; }
        public string CodigoMoneda { get; set; }
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
