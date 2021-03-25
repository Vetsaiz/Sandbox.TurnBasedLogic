using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IBattleParam
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("label")]
        string Label { get; }
        [SerializableId("owner")]
        OwnerType Owner { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("icon_unity_id")]
        string UnityId { get; }
    }
}
