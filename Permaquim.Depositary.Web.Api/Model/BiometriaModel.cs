namespace Permaquim.Depositary.Web.Api.Model
{
    public class BiometriaHuellaDactilarModel
    {
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> HuellasDactilares { get; set; } = new();
    }
}
