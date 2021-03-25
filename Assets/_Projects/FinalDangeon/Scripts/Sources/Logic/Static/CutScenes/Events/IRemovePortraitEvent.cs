using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IRemovePortraitEvent : ICutSceneEvent
    {
        [SerializableId("slot")]
        int SlotId { get; }

        [SerializableId("anim_type_remove")]
        DisableSlotEffect DisableSlot { get; }
    }
}
