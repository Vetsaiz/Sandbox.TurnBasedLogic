using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IBuild
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("version")]
        string Version { get; }
        [SerializableId("impact")]
        IImpact Impact { get; }
        [SerializableId("size")]
        int Size { get; }
        [SerializableId("in_store")]
        bool InStore { get; }
        [SerializableId("confirm")]
        bool Confirm { get; }
        [SerializableId("strict")]
        bool Strict { get; }
        [SerializableId("description")]
        string Description { get; }
    }
}
