using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaConstantCalculator : FormulaCalculator<IFormulaConst>
    {
        private ScorersAccessor _scorer;
        private FormulaLogic _logic;

        public FormulaConstantCalculator(FormulaLogic logic, ScorersAccessor scorer)
        {
            _logic = logic;
            _scorer = scorer;
        }

        public override double Calculate(IFormulaConst formulaData)
        {
            return _logic.Calculate(_scorer.Static.Consts[formulaData.ConstId].Formula);
        }

        public override FormulaType Id => FormulaType.FormulaConst;
    }
}
