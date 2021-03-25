using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static.Activations;

namespace MetaLogic.Logic.EventTriggers
{
    internal class TriggerFamiliarSummonChecker : ITriggerChecker<ITriggerFamiliarSummon>
    {
        private BattleAccessor _battle;

        public TriggerFamiliarSummonChecker(BattleAccessor battle)
        {
            _battle = battle;
        }

        public bool CheckTrigger(TriggerUnitData triggerData, ITriggerFamiliarSummon data)
        {
            var member = _battle.GetMember(triggerData.TargetId);
            var result = member.TurnFamiliarSummoned;
            if (result)
            {
                member.TurnFamiliarSummoned = false;
            }
            return result;
        }

        public TriggerType Id => TriggerType.TriggerFamiliarSummon;
    }
}
