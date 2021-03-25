using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IZone
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("ui_title_full")]
        string TitleFull { get; }
        [SerializableId("world_id")]
        int WorldId { get; }
        [SerializableId("zone_numbler")]
        int Number { get; }
        [SerializableId("portal")]
        bool Portal { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
