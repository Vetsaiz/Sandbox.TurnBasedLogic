using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IConstant
    {
        [SerializableId("title")]
        string Title { get; }

        [SerializableId("value")]
        IFormula Formula { get; }
    }
}
