namespace Permaquim.Depositary.Web.Api.Model
{
    public class GeografiaPaisModel
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Pais> Paises { get; set; } = new();
    }
    public class GeografiaProvinciaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> Provincias { get; set; } = new();
    }
    public class GeografiaCiudadModel
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> Ciudades { get; set; } = new();
    }
    public class GeografiaZonaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.Zona> Zonas { get; set; } = new();
    }
    public class GeografiaCodigoPostalModel
    {
        public List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> CodigosPostales { get; set; } = new();
    }
}
