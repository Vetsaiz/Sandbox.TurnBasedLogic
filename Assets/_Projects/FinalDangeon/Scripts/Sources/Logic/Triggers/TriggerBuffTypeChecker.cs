using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static.Activations;
using System.Linq;
using MetaLogic.Logic.Accessors;

namespace MetaLogic.Logic.EventTriggers
{
    internal class TriggerBuffTypeChecker : ITriggerChecker<ITriggerBuffType>
    {
        private FormulaLogic _formula;
        private BattleAccessor _battle;

        public TriggerBuffTypeChecker(FormulaLogic formula, BattleAccessor battle)
        {
            _battle = battle;
            _formula = formula;
        }

        public bool CheckTrigger(TriggerUnitData triggerData, ITriggerBuffType data)
        {
            var member = _battle.GetMember(triggerData.TargetId);
            var all = member.TurnBuffTypes.Count(x => x == data.BuffType);
            var value = _formula.Calculate(data.Value);
            var result = data.Operator.Check(all, value);
            member.TurnBuffTypes.Clear();
            return result;
        }

        public TriggerType Id => TriggerType.TriggerBuffType;
    }
}
