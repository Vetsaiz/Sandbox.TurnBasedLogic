using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionMob : ICondition
    {
        [SerializableId("mob_id")]
        int MobId { get; }
    }
}
