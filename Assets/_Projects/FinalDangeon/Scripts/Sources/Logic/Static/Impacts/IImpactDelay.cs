using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactDelay : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
