using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static.Activations;

namespace MetaLogic.Logic.EventTriggers
{
    internal class TriggerBuffChecker : ITriggerChecker<ITriggerBuff>
    {
        private FormulaLogic _formula;
        private BattleAccessor _battle;

        public TriggerBuffChecker(FormulaLogic formula, BattleAccessor battle)
        {
            _battle = battle;
            _formula = formula;
        }

        public bool CheckTrigger(TriggerUnitData triggerData, ITriggerBuff data)
        {
            var member = _battle.GetMember(triggerData.TargetId);
            var all = member.TurnBuffs.Count(x => x == data.BuffId);
            var value = _formula.Calculate(data.Value);
            var result = data.Operator.Check(all, value);
            member.TurnBuffs.Clear();
            return result;
        }

        public TriggerType Id => TriggerType.TriggerBuff;
    }
}
