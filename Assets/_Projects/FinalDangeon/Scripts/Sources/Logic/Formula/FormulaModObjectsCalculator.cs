using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaModObjectsCalculator : FormulaCalculator<IFormulaModObjects>
    {
        private readonly FormulaController _logic;

        private const long Val = 1000000;

        public FormulaModObjectsCalculator(FormulaController formula)
        {
            _logic = formula;
        }

        public override double Calculate(IFormulaModObjects formulaData)
        {
            if (formulaData.ArgsMod == null || formulaData.ArgsMod.Count == 0)
            {
                return 0;
            }
            long result =(long)(_logic.Calculate(formulaData.ArgsMod[0]) * Val);
            if (formulaData.ArgsMod.Count == 1)
                return result;

            for (var i = 1; i < formulaData.ArgsMod.Count; i++)
            {
                result = result % (long)(_logic.Calculate(formulaData.ArgsMod[i]) * Val);
            }
            return (float)result / Val;
        }

        public override FormulaType Id => FormulaType.FormulaModObjects;
    }
}
