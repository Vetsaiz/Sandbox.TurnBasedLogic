using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface ILogState
    {
        [SerializableId("log")]
        ILogicDictionary<int, LogData> Log { get; }
    }
}
