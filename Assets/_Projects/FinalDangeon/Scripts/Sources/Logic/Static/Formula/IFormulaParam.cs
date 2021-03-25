using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaParam : IFormula
    {
        [SerializableId("param")]
        int ParamId { get; }

        [SerializableId("target")]
        TargetType Target { get; }
    }
}
