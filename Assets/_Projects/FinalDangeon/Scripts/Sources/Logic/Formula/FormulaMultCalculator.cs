using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaMultCalculator : FormulaCalculator<IFormulaMult>
    {
        private FormulaController _logic;

        public FormulaMultCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaMult formulaData)
        {
            var result = 1.0;
            foreach (var temp in formulaData.ArgsMult.Values)
            {
                result *= _logic.Calculate(temp);
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaMult;
    }
}
