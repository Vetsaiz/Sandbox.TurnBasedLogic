using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class ConditionFormulaChecker : ConditionChecker<IConditionFormula>
    {
        private FormulaController _logic;

        public ConditionFormulaChecker(FormulaController logic)
        {
            _logic = logic;
        }
        
        public override bool Check(IConditionFormula data)
        {
            var value1 = _logic.Calculate(data.FormulaValue1);
            var value2 = _logic.Calculate(data.FormulaValue2);
            return data.Operator.Check(value1, value2);
        }

        public override ConditionType Id => ConditionType.CondFormula;
    }
}
