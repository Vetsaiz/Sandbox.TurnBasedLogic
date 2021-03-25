using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IRoom
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("stage_id")]
        int StageId { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
        [SerializableId("impact_init")]
        IImpact Impact { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("description")]
        string Description { get; }

        [SerializableId("hidden")]
        bool Hidden { get; }

    }
}
