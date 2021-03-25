using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactUnitSetSlot : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("slot")]
        int SlotId { get; }

        [SerializableId("replace")]
        bool Replace { get; }
    }
}
