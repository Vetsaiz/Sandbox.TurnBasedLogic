using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IOffer
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("good_id")]
        int GoodId { get; }

        [SerializableId("promo")]
        bool IsLobby { get; }

        [SerializableId("common")]
        bool IsCommon { get; }
    }
}
