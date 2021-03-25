using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitClassChecker : ConditionChecker<IUnitConditionUnitClass> {
        private readonly ContextLogic _battle;
        private readonly UnitsAccessor _units;

        public ConditionUnitClassChecker(UnitsAccessor units, ContextLogic battle) {
            _battle = battle;
            _units = units;
        }

        public override bool Check(IUnitConditionUnitClass restictionData)
        {
            if (_battle.ContextCondition.IsEnemy)
            {
                return false;
            }
            var unit = _units.GetUnit(_battle.ContextCondition.CurrentTarget);
            return unit.unit?.ClassId == restictionData.ClassId;
        }

        public override ConditionType Id => ConditionType.CondUnitClass;
    }
}
