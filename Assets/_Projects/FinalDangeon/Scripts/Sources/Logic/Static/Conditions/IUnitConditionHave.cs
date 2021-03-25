using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionHave : ICondition
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("rarity")]
        IFormula RarityValue { get; }
    }
}
