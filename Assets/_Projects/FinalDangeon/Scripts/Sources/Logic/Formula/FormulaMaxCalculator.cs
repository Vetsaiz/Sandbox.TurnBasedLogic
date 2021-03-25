using System.Linq;
using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaMaxCalculator : FormulaCalculator<IFormulaMax>
    {
        private FormulaController _logic;

        public FormulaMaxCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaMax formulaData)
        {
            return formulaData.ArgsMax.Values.Select(x => _logic.Calculate(x)).Max(y => y);
        }

        public override FormulaType Id => FormulaType.FormulaMax;
    }
}
