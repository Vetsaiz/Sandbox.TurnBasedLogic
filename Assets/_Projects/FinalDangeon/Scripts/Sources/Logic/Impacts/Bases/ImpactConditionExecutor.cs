using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactConditionExecutor : ImpactExecutor<IImpactCondition>
    {
        private ImpactController _logic;
        private ConditionController _controller;
        private ContextLogic _context;
        private BattleAccessor _battle;

        public ImpactConditionExecutor(ImpactController logic, ConditionController controller, ContextLogic context, BattleAccessor battle, ImpactType type)
        {
            _battle = battle;
            _controller = controller;
            _context = context;
            _logic = logic;
            Id = type;
        }

        public override void Execute(IImpactCondition data)
        {
            var result = false;
            if (Id == ImpactType.ImpCondition && _context.BattleMode)
            {
                var context = _context.CurrentContext;
                var unit = _battle.State.Data.Allies.FirstOrDefault().Key;
                _context.SetContextCondition(unit, unit, false);
                result = _controller.Check(data.Condition);
                _context.SetContextCondition(context.OwnerId, context.CurrentTarget, context.IsEnemy);
            }
            else
            {
                result = _controller.Check(data.Condition);
            }
            if (result)
            {
                _logic.ExecuteImpact(data.Impact);
            }
        }

        public override ImpactType Id { get; }
    }
}
