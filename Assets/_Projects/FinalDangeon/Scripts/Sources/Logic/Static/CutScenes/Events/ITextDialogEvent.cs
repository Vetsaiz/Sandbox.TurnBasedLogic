using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ITextDialogEvent : ICutSceneEvent
    {
        [SerializableId("phrase")]
        string Phrase { get; }

        [SerializableId("slot_id")]
        int SlotId { get; }

        //[SerializableId("speaker")]
        //string Speaker { get; }

        [SerializableId("speed")]
        float Speed { get; }

        [SerializableId("anim_unity_id")]
        string AnimUnityId { get; }

        [SerializableId("sound_unity_id")]
        string SoundId { get; }
    }
}
