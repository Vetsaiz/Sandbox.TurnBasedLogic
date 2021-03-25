using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactSetTargetExecutor : ImpactExecutor<IImpactSetTarget>
    {
        private readonly ApplyChangeLogic _logic;
        ContextLogic _context;
        private BattleAccessor _accessor;

        public ImpactSetTargetExecutor(ApplyChangeLogic logic, ContextLogic context, BattleAccessor accessor)
        {
            _accessor = accessor;
            _logic = logic;
            _context = context;
        }

        public override void Execute(IImpactSetTarget data)
        {
            var target = _context.ContextImpact.CurrentTarget;
            //if (target == HardCodeIds.BattleAssist)
            //{
            //    target = _accessor.GetMember(target).StaticId;
            //}

            _logic.SetAbilityTarget(target);
        }

        public override ImpactType Id => ImpactType.ImpSetTarget;
    }
}
