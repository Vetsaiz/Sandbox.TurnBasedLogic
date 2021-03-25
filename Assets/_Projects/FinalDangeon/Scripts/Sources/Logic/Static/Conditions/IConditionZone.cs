using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static.Conditions
{
    public interface IConditionZone : ICondition
    {
        [SerializableId("zone_id")]
        int ZoneId { get; }
    }
}
