using System;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaDiffCalculator : FormulaCalculator<IFormulaDiff>
    {
        private FormulaController _logic;

        public FormulaDiffCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaDiff formulaData)
        {
            if (formulaData.ArgsDiff == null || formulaData.ArgsDiff.Count == 0)
            {
                return 0;
            }
            var result = _logic.Calculate(formulaData.ArgsDiff[0]);
            if (formulaData.ArgsDiff.Count == 1)
                return result;

            for (var i = 1; i < formulaData.ArgsDiff.Count; i++)
            {
                result = result - _logic.Calculate(formulaData.ArgsDiff[i]);
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaDiff;
    }
}
