using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IImpactScorerData : IImpact
    {
        [SerializableId("parameter")]
        int Id { get; }

        [SerializableId("operator")]
        OperationType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("stage_id")]
        int StageId { get; }
    }

}
