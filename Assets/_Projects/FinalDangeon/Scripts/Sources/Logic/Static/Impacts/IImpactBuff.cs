using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactBuff : IImpact
    {
        [SerializableId("buff_id")]
        int BuffId { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
