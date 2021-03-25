using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static.Conditions
{
    public interface IConditionStage : ICondition
    {
        [SerializableId("stage_id")]
        int StageId { get; }
    }
}
