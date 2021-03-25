using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IMovePortraitEvent : ICutSceneEvent
    {
        [SerializableId("slot_to")]
        int SlotTo { get; }

        [SerializableId("slot_from")]
        int SlotFrom { get; }

        [SerializableId("time")]
        float Time { get; }
    }
}
