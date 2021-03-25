using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionFormula : ICondition
    {
        [SerializableId("formula_1")]
        IFormula FormulaValue1 { get; }

        [SerializableId("operator")]
        OperatorType Operator { get; }

        [SerializableId("formula_2")]
        IFormula FormulaValue2 { get; }

    }
}
