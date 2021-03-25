using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactChangeMana : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("oversize")]
        bool Oversize { get; }
    }
}
