using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaFloat : IFormula
    {
        [SerializableId("value")]
        float ConstValue { get; }
    }
}
