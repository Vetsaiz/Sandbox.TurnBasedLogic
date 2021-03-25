using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IBuilding
    {
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("unlock_level")]
        int UnlockLevel { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("resource")]
        int Resource { get; }
        [SerializableId("hide")]
        bool Hide { get; }
    }
}
