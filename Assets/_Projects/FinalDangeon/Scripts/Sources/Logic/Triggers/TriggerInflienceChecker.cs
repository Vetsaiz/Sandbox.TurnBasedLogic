using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static.Activations;

namespace MetaLogic.Logic.EventTriggers
{
    class TriggerInflienceChecker : ITriggerChecker<ITriggerInfluence>
    {
        private BattleAccessor _accessor;

        public TriggerInflienceChecker(BattleAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool CheckTrigger(TriggerUnitData context, ITriggerInfluence data)
        {
            var state = _accessor.GetMember(context.TargetId);
            return state.TurnInfluence.Remove(data.InfluenceType);
        }

        public TriggerType Id => TriggerType.TriggerInfluence;
    }
}
