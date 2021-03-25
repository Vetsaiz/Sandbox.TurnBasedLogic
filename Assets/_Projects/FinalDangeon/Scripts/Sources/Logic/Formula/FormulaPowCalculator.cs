using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;
using UnityEngine;

namespace MetaLogic.Logic.Formula
{
    class FormulaPowCalculator : FormulaCalculator<IFormulaPow>
    {
        private readonly FormulaController _logic;

        public FormulaPowCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaPow formulaData)
        {
            var result = 0.0;
            if (formulaData.Root != null)
            {
                var f = (float)_logic.Calculate(formulaData.Root);
                result = Mathf.Pow(f, formulaData.Power);
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaPow;
    }
}
