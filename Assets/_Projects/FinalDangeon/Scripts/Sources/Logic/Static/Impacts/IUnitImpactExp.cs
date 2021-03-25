using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactExp : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
