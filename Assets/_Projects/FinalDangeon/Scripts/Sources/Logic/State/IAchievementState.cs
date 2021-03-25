using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IAchievementState
    {
        [SerializableId("achievements")]
        ILogicDictionary<int, IAchievementData> Achievements { get; }
    }


    internal interface IAchievementData
    {
        [SerializableId("refresh_number")]
        int RefreshNumber { get; set; }

        [SerializableId("refresh_time")]
        long FinishTime { get; set; }

        [SerializableId("complete")]
        bool Complete { get; set; }
    }
}
