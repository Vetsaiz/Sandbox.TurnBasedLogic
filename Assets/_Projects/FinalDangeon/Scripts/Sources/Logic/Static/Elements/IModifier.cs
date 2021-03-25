using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IModifier
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("title")]
        string Title { get; }
        [SerializableId("type")]
        ModifierType Type { get; }
    }
}
