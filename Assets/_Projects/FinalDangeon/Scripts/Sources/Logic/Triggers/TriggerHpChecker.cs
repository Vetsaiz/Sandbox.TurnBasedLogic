using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static.Activations;

namespace MetaLogic.Logic.EventTriggers
{
    internal class TriggerHpChecker : ITriggerChecker<ITriggerHp>
    {
        private readonly FormulaLogic _formula;
        private readonly BattleAccessor _accessor;

        public TriggerHpChecker(FormulaLogic formula, BattleAccessor accessor)
        {
            _formula = formula;
            _accessor = accessor;
        }

        public bool CheckTrigger(TriggerUnitData context, ITriggerHp data)
        {
            var state = _accessor.GetMember(context.TargetId);
            var value = _formula.Calculate(data.Value) / 100.0f;
            var currentProcent = state.CurrentHp / state.HpMax.Value;
            return data.Operator.Check(currentProcent, value);
        }

        public TriggerType Id => TriggerType.TriggerHp;
    }
}
