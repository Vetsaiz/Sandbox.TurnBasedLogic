using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaMod : IFormula
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("owner")]
        TargetType Owner { get; }

        [SerializableId("mod")]
        int ModId { get; }
    }
}
