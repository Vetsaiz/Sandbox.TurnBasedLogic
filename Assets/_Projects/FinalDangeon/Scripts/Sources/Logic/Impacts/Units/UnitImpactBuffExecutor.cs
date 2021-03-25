using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactBuffExecutor : ImpactExecutor<IUnitImpactBuff>
    {
        private readonly ContextLogic _context;
        private readonly FormulaLogic _logic;
        private readonly BattleAccessor _battle;
        private readonly BuffLogic _buffs;
        readonly ImpactController _impact;

        public UnitImpactBuffExecutor(ImpactController impact, ContextLogic context, FormulaLogic logic, BuffLogic buffs, BattleAccessor battle)
        {
            _impact = impact;
            _context = context;
            _buffs = buffs;
            _logic = logic;
            _battle = battle;
        }

        public override void Execute(IUnitImpactBuff data)
        {
            var contextImpact = _context.ContextImpact;
            var value = (int)_logic.Calculate(data.Value);
            var member = _battle.GetMember(_context.ContextImpact.CurrentTarget);

            if (!member.Buffs.TryGetValue(data.BuffId, out var buffData))
            {
                if (value < 0)
                {
                    return;
                }
                var buff = _battle.Static.Buffs[data.BuffId];
                _impact.ExecuteImpact(buff.ImpactInit);
                buffData =_battle.Factory.CreateBuff(contextImpact.OwnerId, false);
                if (contextImpact.OwnerId == contextImpact.CurrentTarget && 
                    (_context.TurnType == BattleTurnResultType.ActiveAbility || _context.TurnType == BattleTurnResultType.StartTurn))
                {
                    buffData.NeededRemove = true;
                }
                _buffs.ChangeBuff(member, buffData, data.BuffId, value);
                member.Buffs[data.BuffId] = buffData;
            }
            else
            {
                if (!_buffs.ChangeBuff(member, buffData, data.BuffId, value))
                {
                    _impact.ExecuteImpact(_battle.Static.Buffs[data.BuffId].ImpactTakeOff);
                }
            }
        }

        public override ImpactType Id => ImpactType.UnitImpBuff;
    }
}
