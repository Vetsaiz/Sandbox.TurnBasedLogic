using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionRand : ICondition
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
