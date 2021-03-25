using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionSlots : ICondition
    {
        [SerializableId("target")]
        TargetType Target { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
