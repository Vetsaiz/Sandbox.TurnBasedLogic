using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static.Formula;

namespace MetaLogic.Logic.Formula
{
    internal class FormulaIfCalculator : FormulaCalculator<IFormulaIf>
    {
        private ConditionController _condition;
        private FormulaController _formula;

        public FormulaIfCalculator(FormulaController formula, ConditionController condition)
        {
            _condition = condition;
            _formula = formula;
        }

        public override double Calculate(IFormulaIf formulaData)
        {
            if (_condition.Check(formulaData.If))
            {
                return _formula.Calculate(formulaData.Than);
            }
            return _formula.Calculate(formulaData.Else);
        }

        public override FormulaType Id => FormulaType.FormulaIf;
    }
}
