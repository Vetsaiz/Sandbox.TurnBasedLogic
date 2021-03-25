using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{

    public interface IConditionAvailability : ICondition
    {
        [SerializableId("item_id")]
        int ItemId { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("inventory")]
        bool Inventory { get; }
    }
}
