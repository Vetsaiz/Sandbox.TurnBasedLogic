using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IImpactChangeMoney : IImpact
    {
        [SerializableId("money_type_id")]
        int MoneyTypeId { get; }

        [SerializableId("operator")]
        OperationType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
