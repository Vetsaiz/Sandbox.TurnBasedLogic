using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitBuffTypeChecker : ConditionChecker<IUnitConditionBuffType> {
        private readonly BattleAccessor _battle;
        private readonly FormulaLogic _formula;
        private readonly ContextLogic _context;

        public ConditionUnitBuffTypeChecker(ContextLogic context, FormulaLogic formula, BattleAccessor battle) {
            _battle = battle;
            _context = context;
            _formula = formula;
        }

        public override bool Check(IUnitConditionBuffType data)
        {
            var membler = _battle.GetMember(_context.ContextImpact.CurrentTarget);
            var count = membler.Buffs.Count(x => _battle.Static.Buffs[x.Key].BuffType.Values.Contains(data.BuffTypeId));
            var value = (int)_formula.Calculate(data.Value);
            return data.Operator.Check(count, value);
        }

        public override ConditionType Id => ConditionType.CondUnitBuffType;
    }
}
