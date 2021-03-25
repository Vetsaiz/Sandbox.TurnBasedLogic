using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionScorer : ICondition
    {
        [SerializableId("scorer")]
        int Scorer { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("stage_id")]
        int StageId { get; }
    }
}
