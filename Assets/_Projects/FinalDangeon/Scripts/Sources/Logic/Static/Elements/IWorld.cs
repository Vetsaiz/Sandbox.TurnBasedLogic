using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IWorld
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("description")]
        string Description { get; }
        //[SerializableId("buff_description")]
        //IBuff Buff { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
