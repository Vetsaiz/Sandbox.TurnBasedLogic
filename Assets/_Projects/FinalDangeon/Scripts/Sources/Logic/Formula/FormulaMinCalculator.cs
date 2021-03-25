using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaMinCalculator : FormulaCalculator<IFormulaMin>
    {
        private FormulaController _logic;

        public FormulaMinCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaMin formulaData)
        {
            return formulaData.ArgsMin.Values.Select(x => _logic.Calculate(x)).Min(y => y);
        }

        public override FormulaType Id => FormulaType.FormulaMin;
    }
}
