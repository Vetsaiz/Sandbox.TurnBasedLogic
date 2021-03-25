using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactPushOn : IImpact
    {
        [SerializableId("push_type")]
        int PushId { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("time")]
        IFormula TimeFormula { get; }
    }
}
