using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ConditionUnitChecker : ConditionChecker<IUnitConditionCheck>
    {
        private ConditionController _logic;
        private ContextLogic _contextLogic;
        private BattleAccessor _battle;
        private UnitsAccessor _units;

        public ConditionUnitChecker(ConditionController logic, ContextLogic contextLogic, BattleAccessor battle, UnitsAccessor units)
        {
            _contextLogic = contextLogic;
            _units = units;
            _battle = battle;
            _logic = logic;
        }

        public override bool Check(IUnitConditionCheck data)
        {
            IList<int> list;
            if (_contextLogic.BattleMode)
            {
                list = _contextLogic.FindContextTarget(data.ContextTarget, _contextLogic.ContextCondition);
            }
            else
            {
                list = _contextLogic.FindExplorerTarget(data.ContextTarget);
                if (list.Count == 0)
                {
                    return false;
                }
                var first = list.First();
                _contextLogic.SetContextCondition(first, first, true);
            }
            var result = true;
            switch (data.ConditionType)
            {
                case ContextConditionType.AllTargets:
                    foreach (var unit in list)
                    {
                        _contextLogic.SetContextCondition(_contextLogic.ContextCondition.OwnerId, unit, _contextLogic.ContextCondition.IsEnemy);
                        result &= _logic.Check(data.Condition);
                    }
                    break;
                case ContextConditionType.FirstTarget:
                    result = false;
                    foreach (var unit in list)
                    {
                        _contextLogic.SetContextCondition(_contextLogic.ContextCondition.OwnerId, unit, _contextLogic.ContextCondition.IsEnemy);
                        if (_logic.Check(data.Condition))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case ContextConditionType.RandomTarget:
                    
                    var index = new Random().Next(list.Count);
                    _contextLogic.SetContextCondition(_contextLogic.ContextCondition.OwnerId, list[index], _contextLogic.ContextCondition.IsEnemy);
                    result = _logic.Check(data.Condition);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _contextLogic.SetContextCondition(_contextLogic.ContextCondition.OwnerId, _contextLogic.ContextCondition.OwnerId, _contextLogic.ContextCondition.IsEnemy);
            return result;
        }

        public override ConditionType Id => ConditionType.ConditionUnitCheck;

    }
}
