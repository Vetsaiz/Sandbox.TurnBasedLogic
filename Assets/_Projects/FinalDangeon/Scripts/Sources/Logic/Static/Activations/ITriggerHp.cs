using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static.Activations
{
    public interface ITriggerHp : ITrigger
    {
        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
