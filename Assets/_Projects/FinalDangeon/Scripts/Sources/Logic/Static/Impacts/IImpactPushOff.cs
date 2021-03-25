using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactPushOff : IImpact
    {
        [SerializableId("push_types")]
        IReadOnlyDictionary<int, int> PushIds { get; }
    }
}
