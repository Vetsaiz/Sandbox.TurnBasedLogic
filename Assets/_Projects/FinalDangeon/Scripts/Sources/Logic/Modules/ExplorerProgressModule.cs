using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class ExplorerProgressModule
    {
        public ExplorerAccessor _explorer;
        public InventoryAccessor _inventory;
        public UnitsAccessor _units;
        public SettingsAccessor _settings;
        public ScorersAccessor _scorers;
        public BattleAccessor _battle;

        public ExplorerLogic _explorerLogic;

        public FormulaLogic _formula;
        public ImpactController _impactLogic;

        [Command]
        public void SetUnitExplorer(int unitId, int slotExplorer)
        {
            var oldUnit = 0;
            foreach (var unit in _units.State.LastTeam)
            {
                if (unit.Value == slotExplorer)
                {
                    oldUnit = unit.Key;
                    _units.GetUnit(oldUnit).data.ExplorerPosition = -1;
                    break;
                }
            }
            _units.State.LastTeam.Remove(oldUnit);

            if (unitId != 0)
            {
                _units.State.LastTeam[unitId] = slotExplorer;
            }
        }

        [Command]
        public void MoveToExplorer(int stage)
        {
            _units.UpdateLastTeamSlots();
            StartExplorer(stage);
        }

        [Command]
        public void StartExplorer(int stage)
        {
            var stageData = _explorer.GetStage(stage);
            var staticData = _explorer.Stages[stage];

            //UpdateExplorerSlots();
            foreach (var temp in _units.State.LastTeam)
            {
                var data = _units.GetUnit(temp.Key).data;
                data.ExplorerPosition = temp.Value;
                data.Reserve = false;
            }

            if (_units.ExplorerUnits.Length == 0)
            {
                throw new Exception("The number of selected units in exploration should be: 0 < count < 3");
            }
            if (!stageData.IsUnlock)
            {
                throw new Exception($"Stage is locked. stage_id = {stage}");
            }
            if (stageData.DailyNumber <= 0)
            {
                throw new Exception($"Ended up trying for today. stage_id = {stage}.");
            }
            if (!staticData.NoExit)
            {
                stageData.DailyNumber--;
            }
            _scorers.Spend(staticData.Price, _formula);
            _explorerLogic.StartExplorer(stage);
            LogicLog.SetExplorer(stage, LogExplorerType.Start);
        }

        [Command]
        public void RefreshDaily(int stageId)
        {
            var stage = _explorer.GetStage(stageId);
            stage.DailyNumber = _settings.Settings.PlayerSettings.StageDailyNumber;
            _scorers.Spend(_settings.GetPriceRefresh(stage.RefreshNumber), _formula);
            stage.RefreshNumber++;
        }


        [Command]
        public void RefreshStamina()
        {
            if (!_explorer.State.IsRun)
            {
                Logger.Error($"Attempting to record stamina for stage outside of explorer", this);
                return;
            }
            _explorer.GetStage(_explorer.CurrentStage).Values[_scorers.StaminaId] += _settings.Settings.PlayerSettings.BuyStamina;
            _scorers.Spend(_settings.GetPriceStamina(_explorer.State.RefreshNumber), _formula);
            _explorer.State.RefreshNumber++;
            LogicLog.ExploreRenew(_explorer.State.StageId, _explorer.State.RefreshNumber);
            LogicLog.SetExplorer(_explorer.CurrentStage, LogExplorerType.BuyStamina);
        }

        [Command]
        public void RefreshAllDaily()
        {
            foreach (var stage in _explorer.State.Stages)
            {
                stage.Value.DailyNumber = _settings.Settings.PlayerSettings.StageDailyNumber;
                stage.Value.RefreshNumber = 0;
            }
            _explorer.State.RefreshNumber = 0;
        }

        [Command]
        public void EndExplorer(int[] inventoryIds, LogExplorerType result)
        {
            if (result == LogExplorerType.Start)
            {
                throw new Exception("Invalid exploration end state");
            }
            if (result == LogExplorerType.FinishImpact)
            {
                if (inventoryIds.Length > 10)
                {
                    throw new Exception("The number of selected items must not exceed 100");
                }
                foreach (var id in inventoryIds)
                {
                    _inventory.AddItem(id, _explorer.State.Inventory[id]);
                }
            }
            _battle.State.Data = null;
            LogicLog.SetExplorer(_explorer.State.StageId, result);
            _explorerLogic.FinishExplorer(result == LogExplorerType.FinishImpact);
        }
    }
}
