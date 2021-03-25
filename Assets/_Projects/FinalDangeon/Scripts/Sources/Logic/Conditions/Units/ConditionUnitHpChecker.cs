using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitHpChecker : ConditionChecker<IUnitConditionHp> {
        private readonly ContextLogic _context;
        private readonly FormulaController _logic;

        public ConditionUnitHpChecker(FormulaController logic, ContextLogic context) {
            _logic = logic;
            _context = context;
        }

        public override bool Check(IUnitConditionHp restictionData)
        {
            var current = _context.GetCurrentHp(_context.ContextCondition.CurrentTarget);
            var maxHp = _context.GetMaxHp(_context.ContextCondition.CurrentTarget, _logic);
            var currentHp = 100 * current / maxHp;
            var value = (int)_logic.Calculate(restictionData.Value);
            return restictionData.Operator.Check(currentHp, value);
        }

        public override ConditionType Id => ConditionType.CondUnitHp;
    }
}
