using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;
using UnityEngine;
using Logger = VetsEngine.MetaLogic.Core.Logger;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactHpExecutor : ImpactExecutor<IUnitImpactHp>
    {
        private readonly FormulaController _logic;
        private readonly BattleAccessor _battle;
        private readonly UnitsAccessor _units;
        private readonly ContextLogic _context;

        public UnitImpactHpExecutor(ContextLogic context, FormulaController logic, BattleAccessor battle, UnitsAccessor units)
        {
            _context = context;
            _logic = logic;
            _battle = battle;
            _units = units;
        }

        public override void Execute(IUnitImpactHp data)
        {
            var targetId = _context.ContextImpact.CurrentTarget;
            var value = (float)_logic.Calculate(data.Value);

            if (_context.BattleMode)
            {
                var member = _battle.GetMember(targetId);
                if (member == null)
                {
                    Logger.Error($"No member in battle CurrentTarget = {targetId} ", this);
                    return;
                }
                var oldHp = member.CurrentHp;

                if (value < 0)
                {
                    value = Mathf.Min(value, member.CurrentHp);
                    member.CurrentHp = member.CurrentHp + value;
                    if (member.CurrentHp <= 0)
                    {
                        member.Status = UnitBattleStatus.DeadInTernNoDropped;
                        if (member.MemberType == BattleMemberType.Unit)
                        {
                            _units.SetUnitReserve(member.StaticId, true);
                        }
                    }
                }
                else
                {
                    value = Mathf.Min(value, (float) member.HpMax.Value - member.CurrentHp);
                    member.CurrentHp = member.CurrentHp + value;
                }
                if (_units.Static.Abilities.TryGetValue(_context.CurrentAbility, out var ability))
                {

                    if (member.CurrentHp < oldHp)
                    {
                        if (ability.Influence.Values.Contains(InfluenceType.Attack))
                        {
                            member.TurnInfluence.Add(InfluenceTargetType.Attack);
                        }
                        if (ability.Influence.Values.Contains(InfluenceType.AttackDistance))
                        {
                            member.TurnInfluence.Add(InfluenceTargetType.AttackDistance);
                        }
                    }
                    if (member.CurrentHp > oldHp)
                    {
                        if (ability.Influence.Values.Contains(InfluenceType.Attack))
                        {
                            member.TurnInfluence.Add(InfluenceTargetType.Heal);
                        }
                    }
                }
            }
            else
            {
                var (member, unit) = _units.GetUnit(targetId);
                var max = _units.CalculateMaxHp(member, _logic);
                if (value < 0)
                {
                    value = Mathf.Min(value, member.CurrentHp);
                    member.CurrentHp = member.CurrentHp + value;
                    if (member.CurrentHp <= 0)
                    {
                        _units.SetUnitReserve(targetId, true);
                    }
                }
                else
                {
                    member.CurrentHp = Mathf.Min(member.CurrentHp + value, (float)max.Value);
                }
            }
        }

        public override ImpactType Id => ImpactType.UnitImpHp;
    }
}
