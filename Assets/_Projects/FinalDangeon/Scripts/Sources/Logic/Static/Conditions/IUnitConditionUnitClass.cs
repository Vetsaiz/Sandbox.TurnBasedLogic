using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionUnitClass : ICondition
    {
        [SerializableId("class_id")]
        int ClassId { get; }
    }
}
