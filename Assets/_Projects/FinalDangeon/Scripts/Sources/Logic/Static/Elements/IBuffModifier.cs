using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IBuffModifier
    {
        [SerializableId("mod")]
        int ModId { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
