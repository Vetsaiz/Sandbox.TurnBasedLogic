using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactUnitShard : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("shards")]
        IFormula Shards { get; }
    }
}
