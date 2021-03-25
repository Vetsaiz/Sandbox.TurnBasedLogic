using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactAssistUncommon : IImpact
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("emoji")]
        string Emoji { get; }

        [SerializableId("phrase")]
        string Phrase { get; }
    }
}
