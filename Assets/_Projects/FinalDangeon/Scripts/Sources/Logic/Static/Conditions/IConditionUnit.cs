using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionUnit : ICondition
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("in_party")]
        bool InExplorer { get; }

        [SerializableId("is_active")]
        bool InActive { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("rarity")]
        IFormula RarityValue { get; }

    }
}
