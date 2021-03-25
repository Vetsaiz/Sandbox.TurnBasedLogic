using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitBuffChecker : ConditionChecker<IUnitConditionBuff> {
        private readonly FormulaLogic _formula;
        private readonly ContextLogic _contextLogic;

        public ConditionUnitBuffChecker(ContextLogic contextLogic, FormulaLogic formula)
        {
            _contextLogic = contextLogic;
            _formula = formula;
        }

        public override bool Check(IUnitConditionBuff data)
        {
            var membler = _contextLogic.CurrentTarget;
            var count = 0;
            if (membler.Buffs.TryGetValue(data.BuffId, out var buffData))
            {
                count = buffData.CountStack;
            }
            var value = (int)_formula.Calculate(data.Value);
            return data.Operator.Check(count, value);
        }

        public override ConditionType Id => ConditionType.CondUnitBuff;
    }
}
