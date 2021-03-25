using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUIText
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("label")]
        string Label { get; }
        [SerializableId("ui")]
        int UnlockLevel { get; }
        [SerializableId("text")]
        string Text { get; }
        [SerializableId("font")]
        string Font { get; }
    }
}
