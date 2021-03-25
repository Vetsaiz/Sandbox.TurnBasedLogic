using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitSlotChecker : ConditionChecker<IUnitConditionSlots> {
        private readonly BattleAccessor _battle;
        private readonly FormulaLogic _formula;
        private ContextLogic _context;

        public ConditionUnitSlotChecker(ContextLogic context, FormulaLogic formula, BattleAccessor battle) {
            _battle = battle;
            _context = context;
            _formula = formula;
        }

        public override bool Check(IUnitConditionSlots restictionData)
        {
            var members = (restictionData.Target == TargetType.Owner && !_context.ContextTurn.IsEnemy ? _battle.LiveAllies : _battle.LiveEnemies);
            var count = HardCodeIds.MaxBattleSlots - members.Count();
            var value = (int)_formula.Calculate(restictionData.Value);
            return restictionData.Operator.Check(count, value);
        }

        public override ConditionType Id => ConditionType.CondUnitSlot;
    }
}
