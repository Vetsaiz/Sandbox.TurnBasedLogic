using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionPlayerLevelChecker : ConditionChecker<IConditionPlayerLevel> {
        private PlayerAccessor _player;
        private FormulaLogic _logic;

        public ConditionPlayerLevelChecker(FormulaLogic logic, PlayerAccessor player) {
            _player = player;
            _logic = logic;
        }

        public override bool Check(IConditionPlayerLevel restictionData)
        {
            var level = (int)_logic.Calculate(restictionData.Value);
            var currentLevel = _player.State.Level;
            return restictionData.Operator.Check(currentLevel, level);
        }

        public override ConditionType Id => ConditionType.CondPlayerLevel;
    }
}