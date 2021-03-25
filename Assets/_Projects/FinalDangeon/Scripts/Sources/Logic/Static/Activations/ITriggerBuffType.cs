using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static.Activations
{
    public interface ITriggerBuffType : ITrigger
    {
        [SerializableId("buff_type")]
        int BuffType { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
