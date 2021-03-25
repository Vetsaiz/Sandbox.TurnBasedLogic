using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitFamiliarChecker : ConditionChecker<IUnitConditionFamiliar> {
        readonly UnitsAccessor _units;
        readonly ContextLogic _context;

        public ConditionUnitFamiliarChecker(ContextLogic context, UnitsAccessor units)
        {
            _context = context;
            _units = units;
        }

        public override bool Check(IUnitConditionFamiliar restictionData)
        {
            if (_context.ContextCondition.IsEnemy)
            {
                return false;
            }
            if (!_units.TryGetUnit(_context.ContextCondition.CurrentTarget, true, out var unit))
            {
                return false;
            }
            return unit.FamiliarUnlock;
        }

        public override ConditionType Id => ConditionType.CondUnitFamiliar;
    }
}
