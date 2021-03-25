using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactExecutor : ImpactExecutor<IUnitImpactExecute>
    {
        private ContextLogic _contextLogic;
        private ImpactController _logic;
        private UnitsAccessor _units;
        private ConditionController _condition;

        public UnitImpactExecutor(ContextLogic contextLogic, ImpactController logic, ConditionController condition, UnitsAccessor units)
        {
            _condition = condition;
            _contextLogic = contextLogic;
            _units = units;
            _logic = logic;
        }

        public override void Execute(IUnitImpactExecute data)
        {
            IList<int> list;
            if (_contextLogic.BattleMode)
            {
                list = _contextLogic.FindContextTarget(data.Target, _contextLogic.ContextImpact);
            }
            else
            {
                list = _contextLogic.FindExplorerTarget(data.Target);
                var first = list.First();
                _contextLogic.SetContextImpact(first, first, false);
            }
            var oldTargetFormula = _contextLogic.ContextFormula;
            var oldImpact = _contextLogic.ContextImpact;

            _contextLogic.ConditionTarget = data.Target;
            list = list.Where(unit => {
                _contextLogic.SetContextFormula(unit);
                _contextLogic.SetContextCondition(_contextLogic.ContextImpact.OwnerId, unit, _contextLogic.ContextImpact.IsEnemy);
                var r = data.ImpactUnit.Condition == null || _condition.Check(data.ImpactUnit.Condition);
                return r;
            }).ToList();
            _contextLogic.ConditionTarget = null;

            var result = _contextLogic.GetContextList(list, data.ConditionType);
            foreach (var unit in result)
            {
                _contextLogic.SetContextFormula(unit);
                _contextLogic.SetContextCondition(_contextLogic.ContextImpact.OwnerId, unit, _contextLogic.ContextImpact.IsEnemy);
                _contextLogic.SetContextImpact(_contextLogic.ContextImpact.OwnerId, unit, _contextLogic.ContextImpact.IsEnemy);
                _logic.ExecuteImpact(data.ImpactUnit, false);
            }
            _contextLogic.SetContextImpact(oldImpact.OwnerId, oldImpact.CurrentTarget, oldImpact.IsEnemy);
            _contextLogic.SetContextCondition(oldImpact.OwnerId, oldImpact.CurrentTarget, oldImpact.IsEnemy);
            _contextLogic.SetContextFormula(oldTargetFormula);
        }

        public override ImpactType Id => ImpactType.UnitImpExecute;
    }
}
