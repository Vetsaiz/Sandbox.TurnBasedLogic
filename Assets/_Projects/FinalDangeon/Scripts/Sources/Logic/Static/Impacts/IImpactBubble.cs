using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactBubble : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("phrase")]
        string Phrase { get; }
    }
}
