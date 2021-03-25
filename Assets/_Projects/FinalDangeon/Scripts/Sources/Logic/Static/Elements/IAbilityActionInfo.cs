using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IAbilityActionInfo
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
