using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionWorld : ICondition
    {
        [SerializableId("world_id")]
        int WorldId { get; }
    }
}
