using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactSummon : IImpact
    {
        [SerializableId("mob_id")]
        int MobId { get; }

        //[SerializableId("transform")]
        //bool Transform { get; }

        [SerializableId("slot")]
        int SlotId { get; }
    }
}
