using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IPauseEvent : ICutSceneEvent
    {
        [SerializableId("timeout")]
        float Timeout { get; }

        [SerializableId("tap")]
        int NeededTap { get; }
    }
}
