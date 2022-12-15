namespace Permaquim.Depositary.Web.Api.Model
{
    public class TransaccionModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public string CodigoExternoDepositario { get; set; }
        public List<NuevaSesion> Sesiones { get; set; }
        public List<NuevoCiereDiario> CierresDiarios { get; set; }
        public List<NuevoTurno> Turnos { get; set; }
        public List<NuevoContenedor> Contenedores { get; set; }
        public List<NuevaTransaccion> Transacciones { get; set; }
        public List<NuevaTransaccionDetalle> TransaccionesDetalles { get; set; }
        public List<NuevaTransaccionSobre> TransaccionesSobres { get; set; }
        public List<NuevaTransaccionSobreDetalle> TransaccionesSobresDetalles { get; set; }
    }

    public class NuevaSesion : DepositaryWebApi.Entities.Tables.Operacion.Sesion
    {
        public Int64? OrigenSesion_Id { get; set; }
    }
    public class NuevoCiereDiario : DepositaryWebApi.Entities.Tables.Operacion.CierreDiario
    {
        public Int64? OrigenCierreDiario_Id { get; set; }
    }
    public class NuevoTurno : DepositaryWebApi.Entities.Tables.Operacion.Turno
    {
        public Int64? OrigenTurno_Id { get; set; }
    }
    public class NuevoContenedor : DepositaryWebApi.Entities.Tables.Operacion.Contenedor
    {
        public Int64? OrigenContenedor_Id { get; set; }
    }
    public class NuevaTransaccion : DepositaryWebApi.Entities.Tables.Operacion.Transaccion
    {
        public Int64? OrigenTransaccion_Id { get; set; }
    }
    public class NuevaTransaccionDetalle : DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle
    {
        public Int64? OrigenTransaccionDetalle_Id { get; set; }
    }
    public class NuevaTransaccionSobre : DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobre
    {
        public Int64? OrigenTransaccionSobre_Id { get; set; }
    }
    public class NuevaTransaccionSobreDetalle : DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle
    {
        public Int64? OrigenTransaccionSobreDetalle_Id { get; set; }
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
}
