using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionMove : ICondition
    {
        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("move_type")]
        MoveType MoveType { get; }
    }
}
