using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionBuff : ICondition
    {
        [SerializableId("buff_id")]
        int BuffId { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
