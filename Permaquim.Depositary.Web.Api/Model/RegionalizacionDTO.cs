namespace Permaquim.Depositary.Web.Api.Model
{
    public class RegionalizacionLenguajeDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> Lenguajes { get; set; } = new();
    }
    public class RegionalizacionLenguajeItemDTO
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> LenguajesItems { get; set; } = new();
    }
}
