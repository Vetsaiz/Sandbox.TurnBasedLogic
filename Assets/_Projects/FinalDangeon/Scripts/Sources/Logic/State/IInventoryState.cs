using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IInventoryState
    {
        [SerializableId("storage")]
        ILogicDictionary<int, int> Items { get; }

        [SerializableId("gacha")]
        ILogicDictionary<int, long> Gacha { get; }
    }
}
