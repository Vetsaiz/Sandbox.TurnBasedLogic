using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitTargetChecker : ConditionChecker<IUnitConditionTarget> {
        private readonly ContextLogic _context;

        public ConditionUnitTargetChecker(ContextLogic context) {
            _context = context;
        }

        public override bool Check(IUnitConditionTarget restictionData)
        {
            if (_context.BattleMode)
            {
                return false;
            }
            return _context.ContextTurn.InterfaceTargetId.HasValue && _context.ContextTurn.InterfaceTargetId == _context.ContextCondition.CurrentTarget;
        }

        public override ConditionType Id => ConditionType.CondUnitTarget;
    }
}
