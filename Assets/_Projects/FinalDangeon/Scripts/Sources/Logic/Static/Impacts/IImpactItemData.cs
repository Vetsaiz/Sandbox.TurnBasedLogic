using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IImpactItemData : IImpact
    {
        [SerializableId("item_id")]
        int ItemId { get; }

        [SerializableId("operator")]
        OperationType Operator { get; }

        [SerializableId("inventory")]
        bool IsExplorer { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
