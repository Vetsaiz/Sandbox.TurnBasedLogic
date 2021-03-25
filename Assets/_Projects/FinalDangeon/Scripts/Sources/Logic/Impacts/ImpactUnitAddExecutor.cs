using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactUnitAddExecutor : ImpactExecutor<IImpactUnitAdd>
    {
        private UnitsAccessor _units;
        private SettingsAccessor _settings;
        BattleAccessor _battle;
        BattleLogic _logic;
        private ContextLogic _context;
        private FormulaController _formula;
        private ExplorerAccessor _explorer;
        private ImpactController _impact;

        public ImpactUnitAddExecutor(ImpactController impact, ContextLogic context, BattleLogic logic, FormulaController formula, UnitsAccessor units, ExplorerAccessor explorer, SettingsAccessor settings, BattleAccessor battle)
        {
            _impact = impact;
            _context = context;
            _formula = formula;
            _settings = settings;
            _explorer = explorer;
            _units = units;
            _battle = battle;
            _logic = logic;
        }

        public override void Execute(IImpactUnitAdd impactData)
        {
            if (impactData.Unit.Assist)
            {
                if (_units.State.Assist != null)
                {
                    Logger.Error($"The helper has already been added. Existing unit id = {_units.State.Assist.Id}", this);
                    return;
                }
                if (_units.TryGetUnit(impactData.Unit.Id, false, out var find))
                {
                    Logger.Error($"A helper cannot be added because such a unit is already in the state. id = {impactData.Unit.Id}", this);
                    return;
                }
                var unit = _units.CreateUnit(impactData.Unit);
                //_impact.ExecuteImpact(_units.Units[unit.Id].ImpactInit);
                unit.ExplorerPosition = HardCodeIds.BattleAssistSlot;
                _units.State.Assist = unit;
                if (_context.BattleMode)
                {
                    var battleUnit = _logic.CreateBattleUnit(unit, true);
                    _battle.State.Data.Allies[unit.Id] = battleUnit;
                    battleUnit.CurrentHp = (float) battleUnit.HpMax.Value;
                    unit.CurrentHp = battleUnit.CurrentHp;
                }
                else
                {
                    _context.SetContextFormula(unit.Id);
                    unit.CurrentHp = (int)_units.CalculateMaxHp(unit, _formula).Value;
                    _context.SetContextFormula(null);
                }
            }
            else
            {
                //var addedCommand = _explorer.State.LastTeam.Count < 3;

                if (!_units.AddUnit(impactData.Unit))
                {
                    _units.AddUnitShard(impactData.Unit.Id, _settings.Settings.PlayerSettings.UnitDuplicateCost);
                }
                else
                {
                    _impact.ExecuteImpact(_units.Units[impactData.Unit.Id].ImpactInit);
                    var data = _units.GetUnit(impactData.Unit.Id).data;
                    _context.SetContextFormula(data.Id);
                    data.CurrentHp = (int)_units.CalculateMaxHp(data, _formula).Value;
                    _context.SetContextFormula(null);
                }
                _units.UpdateLastTeamSlots();

                //var free = _explorer.GetFreeSlot();
                //if (impactData.Unit.SlotExplorer > 0 && !_units.State.LastTeam.Select(x => x.Value).Contains(impactData.Unit.SlotExplorer))
                //{
                //    _units.State.LastTeam[impactData.Unit.Id] = impactData.Unit.SlotExplorer;
                //}
                //else if (free != null)
                //{
                //    _units.State.LastTeam[impactData.Unit.Id] = free.Value;
                //}
            }
            LogicLog.UnitAdd(impactData.Unit.Id, impactData.Unit.Assist);
        }

        public override ImpactType Id => ImpactType.ImpUnitAdd;
    }
}
