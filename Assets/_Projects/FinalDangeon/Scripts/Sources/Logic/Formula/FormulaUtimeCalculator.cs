using System;
using MetaLogic.Data;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaUtimeCalculator : FormulaCalculator<IFormulaUtime>
    {
        public override double Calculate(IFormulaUtime formulaData)
        {
            var data = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return data;
        }

        public override FormulaType Id => FormulaType.FormulaUtime;
    }
}
