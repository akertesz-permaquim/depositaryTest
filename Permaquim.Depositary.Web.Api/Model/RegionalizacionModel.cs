namespace Permaquim.Depositary.Web.Api.Model
{
    public class RegionalizacionModel
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> Lenguajes { get; set; }

        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> LenguajeItems { get; set; }

    }
    public class RegionalizacionLenguajeModel
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje> Lenguajes { get; set; } = new();
    }
    public class RegionalizacionLenguajeItemModel
    {
        public List<DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem> LenguajesItems { get; set; } = new();
    }
}
