using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactBubbleIntObject : IImpact
    {
        [SerializableId("interactive_object_id")]
        int InteractiveObjectId { get; }

        [SerializableId("phrase")]
        string Phrase { get; }
    }
}
