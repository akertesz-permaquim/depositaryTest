namespace Permaquim.Depositary.Web.Api.Model
{
    public class RegionalizacionLenguajeModel
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> Lenguajes { get; set; } = new();
    }
    public class RegionalizacionLenguajeItemModel
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> LenguajesItems { get; set; } = new();
    }
}
