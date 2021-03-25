using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaUnitsParam : IFormula
    {
        [SerializableId("target")]
        TargetType TargetType { get; }

        [SerializableId("param")]
        int Param { get; }
    }
}
