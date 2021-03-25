using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactHp : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
