using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactsStatic
    {
        [SerializableId("embed_impacts")]
        IReadOnlyDictionary<int, IEmbedImpact> EmbedImpacts { get; }
    }

    public interface IEmbedImpact
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("impact")]
        IImpact Impact { get; }
    }
}
