using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;
using Logger = VetsEngine.MetaLogic.Core.Logger;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactLeaveExecutor : ImpactExecutor<IUnitImpactLeave>
    {
        private readonly BattleAccessor _battle;
        private readonly ContextLogic _context;

        public UnitImpactLeaveExecutor(ContextLogic context, BattleAccessor battle)
        {
            _context = context;
            _battle = battle;
        }

        public override void Execute(IUnitImpactLeave data)
        {
            if (_context.BattleMode)
            {
                var targetId = _context.ContextImpact.CurrentTarget;
                var member = _battle.GetMember(targetId);
                if (member == null)
                {
                    Logger.Error($"No member in battle CurrentTarget = {targetId} ", this);
                    return;
                }
                member.Status = UnitBattleStatus.Leave;
                member.CurrentHp = 0;
                member.Status = UnitBattleStatus.DeadInTernNoDropped;
            }
            else
            {
                Logger.Error($"No leave unit in no battle", this);
            }
        }

        public override ImpactType Id => ImpactType.UnitImpactEscape;
    }
}
