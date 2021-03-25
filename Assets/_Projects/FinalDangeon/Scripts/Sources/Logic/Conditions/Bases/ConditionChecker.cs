using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionChecker : ConditionChecker<IConditionBase> {
        private ConditionController _logic;
        private ContextLogic _context;
        private BattleAccessor _battle;

        public ConditionChecker(ConditionController logic, ContextLogic context, BattleAccessor battle) {
            _logic = logic;
            _context = context;
            _battle = battle;
        }

        public override bool Check(IConditionBase restictionData)
        {
            if (_context.BattleMode)
            {
                var context = _context.CurrentContext;
                var unit = _battle.State.Data.Allies.FirstOrDefault().Key;
                _context.SetContextCondition(unit, unit, false);
                var result = _logic.Check(restictionData.Condition);
                _context.SetContextCondition(context.OwnerId, context.CurrentTarget, context.IsEnemy);
                return result;
            }
            return _logic.Check(restictionData.Condition);
        }

        public override ConditionType Id => ConditionType.CondCheck;
    }
}
