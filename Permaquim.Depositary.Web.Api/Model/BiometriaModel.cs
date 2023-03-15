namespace Permaquim.Depositary.Web.Api.Model
{
    public class BiometriaModel
    {
        public Int64? SynchronizationExecutionId { get; set; }
        public List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> HuellasDactilares { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
    }

    public class BiometriaHuellaDactilarModel
    {
        public Int64? SynchronizationExecutionId { get; set; }

        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> HuellasDactilares { get; set; } = new();
    }
}
