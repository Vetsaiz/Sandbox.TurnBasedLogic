using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IScorersState
    {
        [SerializableId("global_scorers")]
        ILogicDictionary<int, long> Values { get; }

        [SerializableId("battle_scorers")]
        ILogicDictionary<int, long> BattleValues { get; }

        [SerializableId("impact_scorers")]
        [SavedChanges]
        ILogicDictionary<int, long> ImpactValues { get;}
    }
}
