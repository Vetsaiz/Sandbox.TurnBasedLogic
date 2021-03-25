using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IInventoryItem
    {
        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string IconUnityId { get; }

        [SerializableId("back_unity_id")]
        string BackUnityId { get; }

        [SerializableId("stack")]
        string Stack { get; }

        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("type")]
        string ItemType { get; }
    }
}
