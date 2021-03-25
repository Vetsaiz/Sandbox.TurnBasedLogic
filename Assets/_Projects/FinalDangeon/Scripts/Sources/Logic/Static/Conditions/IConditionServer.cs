using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionServer : ICondition
    {
        [SerializableId("platform_type")]
        IReadOnlyDictionary<int, ServerType> Servers { get; }
    }
}
