using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUnitConditionMostHp : ICondition
    {
        [SerializableId("hp_type")]
        HpType HpType { get; }
    }
}
