using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactCondition : IImpact
    {
        [SerializableId("impact")]
        IImpact Impact { get; }
    }
}
