using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IConditionFamiliar : ICondition
    {
        [SerializableId("unit_id")]
        int UnitId { get; }
    }
}
