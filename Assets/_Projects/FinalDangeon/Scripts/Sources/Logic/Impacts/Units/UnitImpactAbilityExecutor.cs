using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactAbilityExecutor : ImpactExecutor<IUnitImpactAbility>
    {
        private readonly ImpactController _impact;

        private readonly UnitsAccessor _units;
        private readonly ContextLogic _context;
        private ApplyChangeLogic _apply;

        public UnitImpactAbilityExecutor(ImpactController impact, ApplyChangeLogic apply, ContextLogic context, UnitsAccessor units)
        {
            _apply = apply;
            _context = context;
            _impact = impact;
            _units = units;
        }

        public override void Execute(IUnitImpactAbility data)
        {
            if (_context.TurnType == BattleTurnResultType.ActiveAbility || _context.TurnType == BattleTurnResultType.PassiveAbility)
            {
                _apply.BatchAbilityInFrame();
            }
            else
            {
                _apply.BatchBattle();
            }
            _context.TurnType = BattleTurnResultType.ActiveAbility;
            _context.InternalAbility = data.AbilityId;
            var ability = _units.Static.Abilities[data.AbilityId];
            _context.CurrentAbility = data.AbilityId;
            _impact.ExecuteImpact(ability.Impact);
            _context.CurrentAbility = 0;
        }

        public override ImpactType Id => ImpactType.UnitImpAbility;
    }
}
