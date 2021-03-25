using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionFamiliarChecker : ConditionChecker<IConditionFamiliar> {
        readonly UnitsAccessor _units;

        public ConditionFamiliarChecker(UnitsAccessor units)
        {
            _units = units;
        }

        public override bool Check(IConditionFamiliar restictionData)
        {
            if (!_units.TryGetUnit(restictionData.UnitId, true, out var unit))
            {
                return false;
            }
            return unit.FamiliarUnlock;
        }

        public override ConditionType Id => ConditionType.CondFamiliar;
    }
}
