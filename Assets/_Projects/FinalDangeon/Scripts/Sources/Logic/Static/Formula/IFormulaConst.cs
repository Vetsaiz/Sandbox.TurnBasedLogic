using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaConst : IFormula
    {
        [SerializableId("const_id")]
        int ConstId { get; }
    }
}
