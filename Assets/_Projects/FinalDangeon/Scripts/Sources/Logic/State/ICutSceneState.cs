using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface ICutSceneState
    {
        ILogicDictionary<int, bool> CompletedCutScene { get; }
    }
}
