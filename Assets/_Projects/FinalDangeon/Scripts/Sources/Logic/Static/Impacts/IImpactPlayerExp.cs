using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactPlayerExp : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
