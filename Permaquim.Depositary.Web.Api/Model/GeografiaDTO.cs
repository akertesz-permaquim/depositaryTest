namespace Permaquim.Depositary.Web.Api.Model
{
    public class GeografiaPaisDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Pais> Paises { get; set; } = new();
    }
    public class GeografiaProvinciaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> Provincias { get; set; } = new();
    }
    public class GeografiaCiudadDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> Ciudades { get; set; } = new();
    }
    public class GeografiaZonaDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Zona> Zonas { get; set; } = new();
    }
    public class GeografiaCodigoPostalDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> CodigosPostales { get; set; } = new();
    }
}
