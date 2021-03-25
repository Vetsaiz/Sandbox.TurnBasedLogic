using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitWorldChecker : ConditionChecker<IUnitConditionWorld> {
        private readonly ContextLogic _battle;
        private readonly UnitsAccessor _units;

        public ConditionUnitWorldChecker(UnitsAccessor units, ContextLogic battle) {
            _battle = battle;
            _units = units;
        }

        public override bool Check(IUnitConditionWorld restictionData)
        {
            if (_battle.ContextCondition.IsEnemy)
            {
                return false;
            }
            var unit = _units.GetUnit(_battle.ContextCondition.CurrentTarget);
            return unit.unit?.WorldId == restictionData.WorldId;
        }

        public override ConditionType Id => ConditionType.CondUnitWorld;
    }
}
