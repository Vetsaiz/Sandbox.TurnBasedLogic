using System;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaDivCalculator : FormulaCalculator<IFormulaDiv>
    {
        private FormulaController _logic;

        public FormulaDivCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaDiv formulaData)
        {
            if (formulaData.ArgsDiv== null || formulaData.ArgsDiv.Count == 0)
            {
                return 0;
            }
            var result = _logic.Calculate(formulaData.ArgsDiv[0]);
            if (formulaData.ArgsDiv.Count == 1)
                return result;

            for (var i = 1; i < formulaData.ArgsDiv.Count; i++)
            {
                result = result / _logic.Calculate(formulaData.ArgsDiv[i]);
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaDiv;
    }
}
