using MetaLogic.Data;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaFloatCalculator : FormulaCalculator<IFormulaFloat>
    {
        public override double Calculate(IFormulaFloat formulaData)
        {
            return formulaData.ConstValue;
        }

        public override FormulaType Id => FormulaType.FormulaFloat;
    }
}
