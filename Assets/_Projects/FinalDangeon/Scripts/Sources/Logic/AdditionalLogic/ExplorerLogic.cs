using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ExplorerLogic
    {
        public ScorersAccessor _scorers;
        public ExplorerAccessor _explorer;
        public UnitsAccessor _units;
        public FormulaController _formula;
        public ScorersLogic _scorersLogic;
        public ContextLogic _context;
        public DropLogic _drop;

        public ImpactController _impact;

        public void FinishExplorer(bool victory)
        {
            _units.State.Assist = null;
            if (victory)
            {
                var stage = _explorer.Stages[_explorer.State.StageId];
                _impact.ExecuteImpact(stage.ImpactFinish);
                _drop.UpdateUnitsDrop();
            }
            _explorer.ClearCurrentStage();
        }

        public void StartExplorer(int stageId)
        {
            var stageData = _explorer.GetStage(stageId);
            _explorer.SetCurrentStage(stageId);
            _explorer.State.PlayerBuffs.Clear();

            foreach (var id in stageData.ObjectAvailibility.Select(x=>x.Key).ToList())
            {
                var staticData = _explorer.Static.Objects[id];
                if (staticData.Revert)
                {
                    stageData.ObjectAvailibility.Remove(id);
                }
            }


            _scorersLogic.ClearTemporaryScorers();
            var maxStamina = 0;
            foreach (var unitId in _units.ExplorerUnits)
            {
                var (data, def) = _units.GetUnit(unitId);
                maxStamina += _units.CalculateMaxStamina(unitId);
                foreach (var perk in data.PerkStars)
                {
                    var charges = _units.CalculatePerkCharges(unitId, perk.Key);
                    data.PerkCharges[perk.Key] = charges;
                }
                //_context.SetContextFormula(unitId);
                //data.CurrentHp = (float)_units.CalculateMaxHp(data, _formula).Value;
            }
            foreach (var data in _units.State.Units)
            {
                if (data.Stars > 0)
                {
                    _context.SetContextFormula(data.Id);
                    data.CurrentHp = (float) _units.CalculateMaxHp(data, _formula).Value;
                }
            }

            _context.SetContextFormula(null);
            stageData.Values[_scorers.StaminaId] = maxStamina;
        }
    }
}
