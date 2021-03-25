using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface ISettingsState
    {
        [SerializableId("music_off")]
        bool MusicOff { get; set; }

        [SerializableId("sound_off")]
        bool SoundOff { get; set; }

        [SerializableId("reg_time")]
        long RegTime { get; }

        [SerializableId("login_time")]
        long LoginTime { get; }

        [SerializableId("sync_time")]
        long SyncTime { get; }

        [SerializableId("locale")]
        string Locale { get; set; }

        [SerializableId("server_type")]
        ServerType Server { get; set; }

        [SerializableId("current_version")]
        string CurrentVersion { get; set; }

        [SerializableId("build_id")]
        int Build { get; set; }

        [SerializableId("random_state")]
        int RandomState { get; set; }

        [SerializableId("push_status")]
        bool PushStatus { get; set; }


        //[SerializableId("build_id")]
        //string CurrentVersion { get; set; }
    }
}
