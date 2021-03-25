using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IPlayerState
    {
        [SerializableId("level")]
        int Level { get; set; }

        [SerializableId("exp")]
        int Exp { get; set; }

        [SerializableId("reg_time")]
        string RegisterTime { get; set; }

        [SerializableId("login_time")]
        string LastLoginTime { get; set; }

        [SerializableId("sync_time")]
        string SyncTime { get; set; }
    }
}
