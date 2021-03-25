using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactAnimState : IImpact
    {
        [SerializableId("state")]
        float Numbler { get; }
    }
}
