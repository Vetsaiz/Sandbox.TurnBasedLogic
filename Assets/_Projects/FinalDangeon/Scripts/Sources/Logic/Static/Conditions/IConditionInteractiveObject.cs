using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionInteractiveObject : ICondition
    {
        [SerializableId("io_id")]
        int InteractiveId { get; }

        [SerializableId("availibility")]
        AvailibilityType Availibility { get; }
    }
}
