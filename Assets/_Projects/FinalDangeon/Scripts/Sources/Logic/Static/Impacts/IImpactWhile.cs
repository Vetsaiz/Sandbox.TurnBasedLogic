using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactWhile : IImpact
    {
        [SerializableId("impact")]
        IImpact Impact { get; }
    }
}
