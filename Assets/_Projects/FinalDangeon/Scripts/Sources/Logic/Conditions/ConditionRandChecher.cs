using System;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionRandChecker : ConditionChecker<IConditionRand>
    {
        private LogicData _data;
        private FormulaLogic _formula;

        public ConditionRandChecker(FormulaLogic formula, LogicData data)
        {
            _data = data;
            _formula = formula;
        }

        public override bool Check(IConditionRand data)
        {
            if (_data.IsEmulate)
            {
                return false;
            }
            var value = _formula.Calculate(data.Value);
            return new Random().NextDouble() <= value/ 100.0f;
        }

        public override ConditionType Id => ConditionType.CondRand;
    }
}