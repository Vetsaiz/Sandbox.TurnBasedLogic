using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IScorer
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("title")]
        string Title { get; }

        [SerializableId("label")]
        string Label { get; }

        [SerializableId("temporary")]
        bool Temporary { get; }

        [SerializableId("domain")]
        ScorerType Domain { get; }

        [SerializableId("log")]
        bool Log { get; }
    }

}
