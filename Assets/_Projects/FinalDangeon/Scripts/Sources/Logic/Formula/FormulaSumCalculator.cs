using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaSumCalculator : FormulaCalculator<IFormulaSum>
    {
        private FormulaController _logic;

        public FormulaSumCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaSum formulaData)
        {
            var result = 0.0;
            if (formulaData.ArgsSum != null)
            {
                foreach (var temp in formulaData.ArgsSum.Values)
                {
                    result += _logic.Calculate(temp);
                }
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaSum;
    }
}
