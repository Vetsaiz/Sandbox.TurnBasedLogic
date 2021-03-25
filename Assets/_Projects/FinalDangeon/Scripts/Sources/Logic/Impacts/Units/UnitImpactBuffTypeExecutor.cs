using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactBuffTypeExecutor : ImpactExecutor<IUnitImpactBuffType>
    {
        private readonly FormulaLogic _logic;
        private readonly BattleAccessor _battle;
        private readonly BuffLogic _buffs;
        private readonly ContextLogic _context;
        private ImpactController _impacts;

        public UnitImpactBuffTypeExecutor(ImpactController impacts, ContextLogic context, FormulaLogic logic, BuffLogic buffs, BattleAccessor battle)
        {
            _impacts = impacts;
            _context = context;
            _buffs = buffs;
            _logic = logic;
            _battle = battle;
        }

        public override void Execute(IUnitImpactBuffType data)
        {
            var targetId = _context.ContextImpact.CurrentTarget;
            var member = _battle.GetMember(targetId);
            if (member == null)
            {
                Logger.Error($"No member in battle CurrentTarget = {targetId} ", this);
                return;
            }
            var buffs = member.Buffs
                //.Where(x => _battle.Static.Buffs[x.Key].BuffType.Values.Contains(data.BuffTypeId))
                .Select(x => x.Key).ToArray();

            var value = (int) _logic.Calculate(data.Value);
            foreach (var id in buffs)
            {
                var buffTypeValues = _battle.Static.Buffs[id].BuffType.Values;

                var contains = false;
                foreach (var buffType in buffTypeValues)
                {
                    if (data.BuffTypeIds.Values.Contains(buffType))
                    {
                        contains = true;
                        break;
                    }
                }
                if (contains)
                {
                    if (!_buffs.ChangeBuff(member, member.Buffs[id], id, value))
                    {
                        _impacts.ExecuteImpact(_battle.Static.Buffs[id].ImpactTakeOff);
                    }
                }
            }
        }

        public override ImpactType Id => ImpactType.UnitImpBuffType;
    }
}