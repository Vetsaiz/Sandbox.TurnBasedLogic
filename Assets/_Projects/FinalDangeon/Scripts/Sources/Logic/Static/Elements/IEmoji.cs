using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IEmoji
    {
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
