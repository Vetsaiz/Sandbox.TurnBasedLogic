using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaBaseCalculator : FormulaCalculator<IFormulaBase>
    {
        private FormulaController _logic;

        public FormulaBaseCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaBase formulaData)
        {
            return _logic.Calculate(formulaData.Formula);
        }

        public override FormulaType Id => FormulaType.Formula;
    }
}
