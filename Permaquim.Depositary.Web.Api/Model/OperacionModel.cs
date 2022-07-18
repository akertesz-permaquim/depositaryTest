namespace Permaquim.Depositary.Web.Api.Model
{
    public class TransaccionModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Sesion> Sesion { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.CierreDiario> CierreDiario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Turno> Turno { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Contenedor> Contenedor { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Transaccion> Transaccion { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle> TransaccionDetalle { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobre> TransaccionSobre { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle> TransaccionSobreDetalle { get; set; }
    }
    public class EventoModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Evento> Evento { get; set; }
    }
    public class ContenedorModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Contenedor> Contenedor { get; set; }
    }
    public class CierreDiarioModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.CierreDiario> CierreDiario { get; set; }
    }
    public class SesionModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Sesion> Sesion { get; set; }
    }
    public class OperacionTurnoModel
    {
        public string CodigoExternoDepositario { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.Turno> Turno { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Operacion.TurnoUsuario> TurnoUsuario { get; set; }

    }
    public class OperacionTipoContenedorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor> TiposContenedores { get; set; } = new();
    }
    public class OperacionTipoEventoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoEvento> TiposEventos { get; set; } = new();
    }
    public class OperacionTipoTransaccionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion> TiposTransacciones { get; set; } = new();
    }
}
