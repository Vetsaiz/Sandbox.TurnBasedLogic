using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactFamiliarUnlock : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }
    }
}
