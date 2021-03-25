using System;
using System.Collections;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using UnityEngine;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Module)]
    internal partial class StartSessionModule
    {
        public UnitsAccessor _units;
        public ScorersAccessor _scorers;
        public BattleAccessor _battle;
        public InventoryAccessor _inventory;
        public PlayerAccessor _player;
        public ExplorerAccessor _explorer;
        public LogAccessor _accessor;
        public SettingsAccessor _settings;
        public ShopAccessor _shop;
        public LogAccessor _log;
        public AchievementAccessor _achievement;

        public BattleLogic _battleLogic;
        public ShopLogic _shopLogic;
        public ExplorerLogic _explorerLogic;

        public FormulaController _formula;
        public ImpactController _logic;

        [Command]
        public void StartSession()
        {
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            LogicLog.SetAccessor(_accessor, _settings);
            if (_player.State.Level == 0)
            {
                FirstSession(currentTime);
            }
            _player.State.LastLoginTime = currentTime.ToString();
        }

        private void FirstSession(long currentTime)
        {
            _player.State.RegisterTime = currentTime.ToString();
            _explorer.State.IsRun = false;
            _explorer.State.StageId = -1;
            _player.UpgradeLevel(0);
            foreach (var temp in _shop.Static.GoodGroups)
            {
                var group = _shop.GetGroup(temp.Key);
                if (group.Period == 0)
                {
                    _shopLogic.UpdateGroups(temp.Key, 0);
                }
                else
                {
                    _shopLogic.UpdateGroups(temp.Key, currentTime + group.Period);
                }
                if (_shop.State.Groups.TryGetValue(temp.Value.Id, out var data)){
                    data.RefreshNumber = 1;
                }
            }
            foreach (var temp in _achievement.Static.Achievements)
            {
                var data = _achievement.CreateAchievementData(temp.Key);
                var duration = (int) _formula.Calculate(temp.Value.Time);
                if (duration > 0)
                {
                    data.FinishTime = currentTime + duration;
                }
            }

            LogicLog.SetSession(LogSessionType.OpenGame);
            _settings.State.CurrentVersion = Application.version;
            _settings.State.Build = _settings.Settings.Builds.FirstOrDefault(x => x.Value.Version == Application.version).Key;
        }

        [PreExecuteCommand]
        public void SetAccessors()
        {
            LogicLog.SetAccessor(_accessor, _settings);
        }

        [Command]
        public void UpdateBuilds()
        {
            if (_settings.UpdateBuilds(out var builds)){
                foreach (var temp in builds)
                {
                    _logic.ExecuteImpact(temp.Impact);
                }
                foreach (var temp in _shop.State.Groups.Select(x=> x.Key).ToArray())
                {
                    if (!_shop.Static.GoodGroups.ContainsKey(temp))
                    {
                        _shop.State.Groups.Remove(temp);
                    }
                }
                foreach (var temp in _achievement.State.Achievements.Select(x => x.Key).ToArray()) 
                {
                    if (!_achievement.Static.Achievements.ContainsKey(temp))
                    {
                        _achievement.State.Achievements.Remove(temp);
                    }
                }
                foreach (var temp in _achievement.Static.Achievements.Select(x => x.Key).ToArray())
                {
                    if (!_achievement.State.Achievements.ContainsKey(temp))
                    {
                        _achievement.CreateAchievementData(temp);
                    }
                }
            }
        }




        [Command]
        public void ClearOldSession()
        {
            _battle.State.Data = null;
            if (_explorer.State.StageId != -1)
            {
                _explorer.State.IsRun = true;
                _explorerLogic.FinishExplorer(false);
                //_explorer.State.IsRun = true;
            }
        }


        [Command]
        public void PlayerLevelUp()
        {
            var oldLevel = _player.State.Level;
            var newLevel = _player.UpgradeLevel();
            if (oldLevel == newLevel)
            {
                return;
            }
            while (oldLevel != newLevel)
            {
                oldLevel++;
                _logic.ExecuteImpact(_player.GetImpact(oldLevel));
            }
            PlayerLevelUp();
        }

        [Command]
        public void ClearLog()
        {
            _log.ClearLog();
        }


        [Command]
        public void SetSession(LogSessionType type)
        {
            LogicLog.SetSession(type);
        }

        [Command]
        public void SetCutScene(int tutorialId, LogTutorialType type, int block)
        {
            LogicLog.SetTutorial(tutorialId, type, block);
        }

        [Command]
        public void SetServer(ServerType type)
        {
            _settings.State.Server = type;
        }
    }
}
