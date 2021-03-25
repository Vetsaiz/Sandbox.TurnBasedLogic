using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactExpExecutor : ImpactExecutor<IUnitImpactExp>
    {
        private UnitsAccessor _units;
        private ImpactController _logic;
        private FormulaController _formula;
        private PlayerAccessor _player;
        private ContextLogic _context;
        private BattleAccessor _battle;

        public UnitImpactExpExecutor(ImpactController logic, FormulaController formula, ContextLogic context, UnitsAccessor units, PlayerAccessor player, BattleAccessor battle)
        {
            _formula = formula;
            _logic = logic;
            _units = units;
            _context = context;
            _battle = battle;
            _player = player;
        }

        public override void Execute(IUnitImpactExp impactData)
        {
            int currentTarget = _context.ContextImpact.CurrentTarget;
            if (_context.BattleMode)
            {
                if (_context.ContextImpact.IsEnemy)
                {
                    Logger.Error($"The enemy cannot receive exp target = {_context.ContextImpact.CurrentTarget}", this);
                    return;
                }
            }
            var (data, unit) = _units.GetUnit(currentTarget);

            var oldLevel = data.Level;
            var exp = (int) _formula.Calculate(impactData.Value);
            if (exp < 1)
            {
                return;
            }
            var newLevel = _units.UpgradeUnitLevel(data.Id, exp, _player.State.Level);

            var updateLevel = oldLevel != newLevel;
            while (oldLevel != newLevel)
            {
                oldLevel++;
                var levelData = _units.Static.UnitLevels.Values.FirstOrDefault(x => x.Level == oldLevel);
                _logic.ExecuteImpact(levelData?.Impact);
                _logic.ExecuteImpact(unit.ImpactUpdrade);
            }

            if (updateLevel && _context.BattleMode)
            {
                _context.SetContextFormula(unit.Id);
                _context.NeedExploreParam = true;

                var member = _battle.GetMember(currentTarget);
                member.HpMax = _units.CalculateMaxHp(data, _formula);
                member.Strength = _units.CalculateStrength(data, _formula);
                member.Initiative = _units.CalculateInitiative(data, _formula);
                
                _context.SetContextFormula(null);
                _context.NeedExploreParam = false;
            }
        }

        public override ImpactType Id => ImpactType.UnitImpExp;
    }
}
