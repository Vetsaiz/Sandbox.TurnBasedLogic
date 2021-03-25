using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactChangeStamina : IImpact
    {
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
