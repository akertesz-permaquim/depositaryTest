namespace Permaquim.Depositary.Web.Api.Model
{
    public class TransaccionDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Transaccion> Transaccion { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle> TransaccionDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobre { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobreDetalle { get; set; }
    }
    public class EventoDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Evento> Evento { get; set; }
    }
    public class ContenedorDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Contenedor> Contenedor { get; set; }
    }
    public class CierreDiarioDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.CierreDiario> CierreDiario { get; set; }
    }
    public class SesionDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Sesion> Sesion { get; set; }
    }
    public class TurnoDTO
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Turno> Turno { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TurnoUsuario> TurnoUsuario { get; set; }

    }
    public class OperacionTipoContenedorDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> TiposContenedores { get; set; } = new();
    }
    public class OperacionTipoEventoDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> TiposEventos { get; set; } = new();
    }
    public class OperacionTipoTransaccionDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> TiposTransacciones { get; set; } = new();
    }
}
