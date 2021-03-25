using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactPushRequest : IImpact
    {
        [SerializableId("description")]
        string Description { get; }
    }
}
