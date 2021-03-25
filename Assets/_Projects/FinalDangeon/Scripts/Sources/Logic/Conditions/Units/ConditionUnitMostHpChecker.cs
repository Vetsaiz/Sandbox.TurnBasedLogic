using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitMostHpChecker : ConditionChecker<IUnitConditionMostHp> {
        private readonly BattleAccessor _battle;
        private readonly ContextLogic _logic;
        private UnitsAccessor _units;
        private FormulaController _formula;

        public ConditionUnitMostHpChecker(ContextLogic logic, FormulaController formula, BattleAccessor battle, UnitsAccessor units) {
            _battle = battle;
            _units = units;
            _formula = formula;
            _logic = logic;
        }

        public override bool Check(IUnitConditionMostHp restictionData)
        {
            if (_logic.BattleMode)
            {
                var list = new List<int>();
                if (_logic.ConditionTarget != null)
                {
                    list = _logic.FindContextTarget(_logic.ConditionTarget.Value, _logic.ContextImpact);
                }
                else
                {
                    list = _battle.LiveAllies.ToList();
                    list.AddRange(_battle.LiveEnemies.ToList());
                }

                list = list.OrderByDescending(x => _battle.GetMember(x).CurrentHp / _battle.GetMember(x).HpMax.Value).ToList();
                switch (restictionData.HpType)
                {
                    case HpType.Healthy:
                        return list.First() == _logic.ContextCondition.CurrentTarget;
                    case HpType.Wounded:
                        return list.Last() == _logic.ContextCondition.CurrentTarget;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                var members = _units.ExplorerUnits.Select(x => _units.GetUnit(x).data);
                members = members.OrderByDescending(x => x.CurrentHp / _units.CalculateMaxHp(x, _formula).Value).ToList();
                switch (restictionData.HpType)
                {
                    case HpType.Healthy:
                        return members.First().Id == _logic.ContextCondition.CurrentTarget;
                    case HpType.Wounded:
                        return members.Last().Id == _logic.ContextCondition.CurrentTarget;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override ConditionType Id => ConditionType.CondUnitMostHp;
    }
}
