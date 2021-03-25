using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Module)]
    internal partial class CheatModule
    {
        public UnitsAccessor _units;
        public ScorersAccessor _scorers;
        public BattleAccessor _battle;
        public InventoryAccessor _inventory;
        public PlayerAccessor _player;
        public ExplorerAccessor _explorer;
        public LogAccessor _accessor;
        public SettingsAccessor _settings;

        public ExplorerLogic _explorerLogic;
        public BattleLogic _battleLogic;
        public ContextLogic _contextLogic;

        public ImpactController _logic;
        public DropLogic _drop;
        public ScorersLogic _scorerLogic;

        [Command]
        public void SetScorerValue(int scorerId, int value)
        {
            var values = _scorerLogic.GetScrorerMap(scorerId, _explorer.CurrentStage);
            values[scorerId] = value;
        }

        [Command]
        public void SetHp(int unitId, bool hp)
        {
            if (_contextLogic.BattleMode)
            {
                return;
            }
            var member = _battle.GetMember(unitId);
            if (hp)
            {
                member.CurrentHp = (float)member.HpMax.Value;
            }
            else
            {
                member.CurrentHp = 1;
            }
        }

        [Command]
        public void SetBattleUnit(int unitId, int slotId)
        {
            //_scorers.State.Values[scorerId] = value;

            if (!_contextLogic.BattleMode)
            {
                return;
            }

            var unit = -1;

            foreach (var temp in _battle.State.Data.Allies)
            {
                if (temp.Value.Position == slotId)
                {
                    unit = temp.Key;
                }
            }
            if (unit != -1)
            {
                if (_units.TryGetUnit(unit, true, out var data1))
                {
                    data1.ExplorerPosition = -1;
                }
                _battle.State.Data.Allies.Remove(unit);
            }
            if (unitId == -1)
            {
                return;
            }

            if (!_units.TryGetUnit(unitId, true, out var data))
            {
                _units.AddUnitShard(unitId, 100);
                _units.TryGetUnit(unitId, true, out data);
                _units.UpgradeNullRatity(data);
            }
            data.ExplorerPosition = slotId;
            _battle.State.Data.Allies[unitId] = _battleLogic.CreateBattleUnit(data, false);

        }

        [Command]
        public void AddMob(int mobId, int slotId)
        {
            if (_battle.State.Data == null)
            {
                return;
            }

            var mob = -1;

            foreach (var temp in _battle.State.Data.Enemies)
            {
                if (temp.Value.Position == slotId)
                {
                    mob = temp.Key;
                }
            }

            if (mob != -1)
            {
                _battle.State.Data.Enemies.Remove(mob);
                
            }
            if (mobId == -1)
            {
                return;
            }

            if (_battle.LiveEnemies.Count() < HardCodeIds.MaxBattleSlots)
            {
                _battle.State.Data.CurrentId++;
                _battle.State.Data.Enemies[_battle.State.Data.CurrentId] = _battleLogic.CreateBattleMob(mobId, slotId, false);
            }
        }

        [Command]
        public void BattleDeathUnit(int slot)
        {
            if (_battle.State.Data != null)
            {
                foreach (var temp in _battle.State.Data.Enemies)
                {
                    temp.Value.CurrentHp = 0;
                }
                _battle.State.Data.Status = BattleStatus.Win;
            }
        }

        [Command]
        public void SetItemValue(int itemId, int value)
        {
            _inventory.State.Items[itemId] = value;
        }

        [Command]
        public void AddAllEquipments()
        {
            foreach (var temp in _inventory.Static.Items)
            {
                _inventory.AddItem(temp.Key, 10);
            }
            foreach (var temp in _scorers.Static.MoneyTypes)
            {
                _scorers.State.Values.TryGetValue(temp.Value.ScorerId, out var value);
                _scorers.State.Values[temp.Value.ScorerId] = value + 10000000;
            }
        }

        [Command]
        public void FinishExplore()
        {
            _explorerLogic.FinishExplorer(true);
        }

        [Command]
        public void AddPlayerExp(int value)
        {
            _player.UpgradeLevel(value);
            var oldLevel = _player.State.Level;
            var newLevel = _player.UpgradeLevel();
            while (oldLevel != newLevel)
            {
                oldLevel++;
                _logic.ExecuteImpact(_player.GetImpact(oldLevel));
            }
        }

        [Command]
        public void AddUnitExp(int unitId, int value)
        {
            _units.UpgradeUnitLevel(unitId, value, _player.State.Level);
        }


        [Command]
        public void CheatExecuteImpact(int impactId)
        {
            _logic.ExecuteImpact((_settings.Settings.Impacts[impactId] as IImpactExecute).Impact);

        }

        [Command]
        public void AddUnitShards(int unitId, int shards)
        {
            _units.AddUnitShard(unitId, shards);
            var (unit, _) = _units.GetUnit(unitId);
            _drop.TryUpdateNullRarity(unit);
        }

        [Command]
        public void SetPerkStars(int unitId, int perkId, int value)
        {
            _units.GetUnit(unitId).data.PerkStars[perkId] = value;
        }

        [Command]
        public void DeadAllUnits()
        {
            _units.ExplorerUnits.ToList().ForEach(x => _units.GetUnit(x).data.CurrentHp = 0);
        }

        [Command]
        public void CompleteStageFull(int stageId)
        {
            var stage = _explorer.GetStage(stageId);
            foreach (var temp in HardCodeIds.ScorerStars)
            {
                var scorer = _scorers.GetScorer(temp);
                stage.Values[scorer.Id] = 1;
            }

        }

        [Command]
        public void  CheatStartExplorer(int stage)
        {
            for (var i = 1; i < 4; i++)
            {
                if (i <= _units.State.Units.Count)
                {
                    var data = _units.State.Units[i - 1];
                    data.ExplorerPosition = i;
                    data.Reserve = false;
                }
            }
            _explorerLogic.StartExplorer(stage);
        }

        [Command]
        public void CheatEndExplorer()
        {
            CompleteStageFull(_explorer.CurrentStage);
            var scorer = _scorers.GetScorer(HardCodeIds.CurrentStage);
            _scorers.State.Values[scorer.Id]++; 
            _battle.State.Data = null;
            LogicLog.SetExplorer(_explorer.CurrentStage, LogExplorerType.FinishImpact);
            _explorerLogic.FinishExplorer(true);
        }

        [Command]
        public void CheatEndBattle()
        {
            if (_battle.State.Data != null)
            {
                foreach (var temp in _battle.State.Data.Enemies)
                {
                    temp.Value.CurrentHp = 0;
                }

                _battle.State.Data.Status = BattleStatus.Win;
            }
        }

        [Command]
        public void SetStamina(int value)
        {
            _explorer.GetStage(_explorer.CurrentStage).Values[_scorers.StaminaId] = value;
        }

    }
}
