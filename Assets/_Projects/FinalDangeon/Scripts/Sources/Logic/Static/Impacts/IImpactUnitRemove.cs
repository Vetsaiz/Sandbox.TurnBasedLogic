using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactUnitRemove : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }
    }
}
