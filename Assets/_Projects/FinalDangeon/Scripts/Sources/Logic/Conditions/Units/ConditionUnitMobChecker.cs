using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitMobChecker : ConditionChecker<IUnitConditionMob> {
        private readonly BattleAccessor _battle;
        private readonly ContextLogic _context;

        public ConditionUnitMobChecker(ContextLogic context, BattleAccessor battle) {
            _battle = battle;
            _context = context;
        }

        public override bool Check(IUnitConditionMob restictionData)
        {
            if (!_context.BattleMode)
            {
                throw new Exception($"It is impossible to check the presence of a mob not in combat. mobId = {restictionData.MobId}");
            }
            var member = _battle.GetMember(_context.ContextCondition.CurrentTarget);
            if (member == null)
            {
                return true;
            }
            var haveUnit = member.StaticId == restictionData.MobId;
            return haveUnit;
        }

        public override ConditionType Id => ConditionType.CondUnitMob;
    }
}
