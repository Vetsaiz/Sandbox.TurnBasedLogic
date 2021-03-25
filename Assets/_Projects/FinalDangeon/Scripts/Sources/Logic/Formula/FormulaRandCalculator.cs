using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaRandCalculator : FormulaCalculator<IFormulaRand>
    {
        private FormulaController _logic;
        LogicData _data;

        public FormulaRandCalculator(FormulaController logic, LogicData data)
        {
            _data = data;
            _logic = logic;
        }

        public override double Calculate(IFormulaRand formulaData)
        {
            var max = _logic.Calculate(formulaData.Max);
            var min = _logic.Calculate(formulaData.Min);
            if (!_data.IsEmulate)
            {
                return min + (float) new System.Random().NextDouble() * (max - min);
            }
            else
            {
                return min;
            }

        }

        public override FormulaType Id => FormulaType.FormulaRand;
    }
}
