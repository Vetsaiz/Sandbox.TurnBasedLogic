using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionPlayerLevel : ICondition
    {
        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
