using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IBuffType
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
    }
}
