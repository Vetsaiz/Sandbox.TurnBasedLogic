using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IChangePortraitEvent : ICutSceneEvent
    {
        [SerializableId("slot")]
        int SlotId { get; }

        [SerializableId("unity_id")]
        string IconId { get;}

        [SerializableId("anim_type")]
        EnableSlotEffect EnableSlot { get; }

        [SerializableId("priority")]
        int Priority { get; }

        //[SerializableId("fade")]
        //bool FadePortrait { get; }

        [SerializableId("title")]
        string Speaker { get; }

        [SerializableId("direction")]
        SlotDirection Direction { get; }
    }
}
