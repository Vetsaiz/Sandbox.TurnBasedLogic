using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitHaveChecker : ConditionChecker<IUnitConditionHave> {
        private readonly BattleAccessor _battle;
        private IFormulaLogic _formula;
        private UnitsAccessor _units;
        private ContextLogic _context;

        public ConditionUnitHaveChecker(BattleAccessor battle, ContextLogic context, IFormulaLogic formula, UnitsAccessor units) {
            _battle = battle;
            _context = context;
            _formula = formula;
            _units = units;
        }

        public override bool Check(IUnitConditionHave data)
        {
            var value = (int)_formula.Calculate(data.RarityValue);
            if (_context.BattleMode)
            {
                if (_context.ContextCondition.CurrentTarget != data.UnitId)
                {
                    return false;
                }
                var haveUnit = _battle.LiveAllies.Contains(data.UnitId);
                if (!haveUnit)
                {
                    return false;
                }
                return data.Operator.Check(_units.GetUnit(data.UnitId).data.Stars, value);
            }
            if (!_units.TryGetUnit(data.UnitId, false, out var unitData))
            {
                return false;
            }
            if (_context.ContextCondition != null && _context.ContextCondition.CurrentTarget > 0 && _context.ContextCondition.CurrentTarget != data.UnitId)
            {
                return false;
            }

            return data.Operator.Check(unitData.Stars, value);
        }

        public override ConditionType Id => ConditionType.CondUnitRarity;

    }
}
