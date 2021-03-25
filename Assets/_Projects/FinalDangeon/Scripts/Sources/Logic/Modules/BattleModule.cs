using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class BattleModule
    {
        public BattleAccessor _battle;
        public ExplorerAccessor _explorer;
        public UnitsAccessor _units;

        public ContextLogic _contextLogic;
        public ImpactController _impactLogic;
        public TriggerLogic _triggerLogic;
        public BattleLogic _battleLogic;
        public BuffLogic _buffLogic;

        [Command]
        public void StartBattle(ExplorerPositionData position)
        {
            _contextLogic.TurnType = BattleTurnResultType.StartTurn;
            _battleLogic.StartBattle();
            _contextLogic.SetAbilityContext(-1, -1, false);
            _impactLogic.ExecuteImpact(_contextLogic.ImpactInit);
            _battleLogic.BatchEventBattle();
            _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
            foreach (var temp in _battle.LiveAllies)
            {
                _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                ExecuteStartAbility(temp, false);
            }
            foreach (var temp in _battle.LiveEnemies)
            {
                _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                ExecuteStartAbility(temp, true);
                if (_contextLogic.MobImpacts.TryGetValue(temp, out var impact))
                {
                    _contextLogic.SetAbilityContext(temp, null, true);
                    _impactLogic.ExecuteImpact(impact);
                }

            }
            _contextLogic.TurnType = BattleTurnResultType.EndTurn;
            _explorer.State.Position = position;
            _battleLogic.UpdateMobs();
            _battleLogic.BatchEventBattle();
            LogicLog.SetBattle(LogBattleType.Start, _explorer.State.LastInteractiveId, _explorer.State.RoomId, _explorer.CurrentStage);
        }

        [Command]
        public void FinishBattle()
        {
            if (_battle.State.Data.Status == BattleStatus.Running)
            {
                _battle.State.Data.Status = BattleStatus.Leave;
                LogicLog.SetBattle(LogBattleType.Leave, _explorer.State.LastInteractiveId, _explorer.State.RoomId, _explorer.CurrentStage);
            }
            var status = _battle.State.Data.Status;
            _battleLogic.ClearBattle();
            if (status == BattleStatus.Win)
            {
                _impactLogic.ExecuteImpact(_contextLogic.ImpactWin);
                LogicLog.SetBattle(LogBattleType.Win, _explorer.State.LastInteractiveId, _explorer.State.RoomId, _explorer.CurrentStage);
            }
            else
            {
                _impactLogic.ExecuteImpact(_contextLogic.ImpactLose);
                LogicLog.SetBattle(LogBattleType.Lose, _explorer.State.LastInteractiveId, _explorer.State.RoomId, _explorer.CurrentStage);
            }
        }

        [Command]
        public void ExecuteUnitAbility(int unitId, int targetId, int ablilityId)
        {
            var allies = new List<int>(_battle.LiveAllies);
            var enemies = new List<int>(_battle.LiveEnemies);

            if (!allies.Contains(unitId))
            {
                Logger.Error($"unit id = {unitId} dead.", this);
                return;
            }

            int? interfaceTargetId = null;
            if (targetId != -1)
            {
                interfaceTargetId = targetId;
            }
            if (!_battleLogic.HasExecuteAbility(unitId, ablilityId))
            {
                throw new Exception($"No actable ability unitId = {unitId} ablilityId = {ablilityId}");
            }
            _contextLogic.TurnType = BattleTurnResultType.StartTurn;
            _battleLogic.StartTurn(unitId, interfaceTargetId, false);
            if (!_battle.HasStan(unitId))
            {
                _contextLogic.TurnType = BattleTurnResultType.ActiveAbility;
                var ability = _units.Static.Abilities[ablilityId];
                Logger.Trace(() => $"----------------------------------- start execute impact unit active ability unitId = {unitId} abilityId = {ablilityId}");
                ExecuteAbility(unitId, interfaceTargetId, ability.Impact, ablilityId, false);
                Logger.Trace(() => $"----------------------------------- finish execute impact unit active ability");
            }
            else
            {
                _contextLogic.SetAbilityContext(unitId, interfaceTargetId, false);
            }
            _contextLogic.TurnType = BattleTurnResultType.Buff;
            UpdateBuffs(false);
            _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
            ExecutePassiveAbility(ActivationType.Events);
            _contextLogic.TurnType = BattleTurnResultType.EndTurn;

            _battleLogic.UpdateMobs();
            var members = new List<int>(_battle.LiveEnemies);
            members.RemoveAll(x => enemies.Contains(x));
            foreach (var enemy in members)
            {
                if (_contextLogic.MobImpacts.TryGetValue(enemy, out var impact))
                {
                    _contextLogic.SetAbilityContext(enemy, null, true);
                    _impactLogic.ExecuteImpact(impact);
                }
            }
            _battleLogic.FinishTurn();

            if (_battle.State.Data.Status == BattleStatus.Running)
            {
                var newAllies = new List<int>(_battle.LiveAllies);
                newAllies.RemoveAll(x => allies.Contains(x));
                foreach (var ally in newAllies)
                {
                    _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                    ExecuteStartAbility(ally, false);
                }
                foreach (var enemy in members)
                {
                    _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                    ExecuteStartAbility(enemy, true);
                }
            }
            LogicLog.ExecuteAbility(ablilityId);
        }

        [Command]
        public void ExecuteMobAbility(int mobId)
        {
            var allies = new List<int>(_battle.LiveAllies);
            var enemies = new List<int>(_battle.LiveEnemies);

            if (!enemies.Contains(mobId))
            {
                Logger.Error($"mob id = {mobId} dead.", this);
                return;
            }
            _contextLogic.TurnType = BattleTurnResultType.StartTurn;
            _battleLogic.StartTurn(mobId, null, true);
            if (!_battle.HasStan(mobId))
            {
                Logger.Trace(() => $"----------------------------------- start execute impact mob mobId = {mobId}");
                _contextLogic.SetAbilityContext(mobId, null, true);
                _impactLogic.ExecuteImpact(_battleLogic.GetMobImpact(mobId));
                Logger.Trace(() => $"----------------------------------- finish execute impact mob");
                UpdateDrop();
                if (_contextLogic.InternalAbility != 0)
                {
                    _battleLogic.UpdateAbility(mobId, _contextLogic.InternalAbility);
                    _contextLogic.InternalAbility = 0;
                }
                else
                {
                    _battleLogic._manager.BatchBattle();
                }
            }
            else
            {
                _contextLogic.SetAbilityContext(mobId, null, true);
            }

            _contextLogic.TurnType = BattleTurnResultType.Buff;
            UpdateBuffs(true);
            _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
            ExecutePassiveAbility(ActivationType.Events);
            _contextLogic.TurnType = BattleTurnResultType.EndTurn;
            _battleLogic.UpdateMobs();
            var members = new List<int>(_battle.LiveEnemies);
            members.RemoveAll(x => enemies.Contains(x));
            foreach (var enemy in members)
            {
                if (_contextLogic.MobImpacts.TryGetValue(enemy, out var impact))
                {
                    _contextLogic.SetAbilityContext(enemy, null, true);
                    _impactLogic.ExecuteImpact(impact);
                }
            }
            _battleLogic.FinishTurn();

            if (_battle.State.Data.Status == BattleStatus.Running)
            {
                var newAllies = new List<int>(_battle.LiveAllies);
                newAllies.RemoveAll(x => allies.Contains(x));
                foreach (var ally in newAllies)
                {
                    _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                    ExecuteStartAbility(ally, false);
                }
                foreach (var enemy in members)
                {
                    _contextLogic.TurnType = BattleTurnResultType.PassiveAbility;
                    ExecuteStartAbility(enemy, true);
                }
            }
        }

        [Command]
        public void SetActiveUnit(int unitId, int slotId)
        {
            _battleLogic.SetSlotUnit(unitId, slotId);
        }

        [Command]
        public void SetReserveUnit(int unitId)
        {
            _battleLogic.SetReserveUnit(unitId);
        }

        private void UpdateBuffs(bool isEnemy)
        {
            var owner = _battle.GetMember(_contextLogic.ContextTurn.OwnerId);
            foreach (var temp in owner.Buffs)
            {
                var buffStatic = _battle.Static.Buffs[temp.Key];
                if (buffStatic.Impact != null)
                {
                    _contextLogic.SetContextImpact(temp.Value.OwnerId, _contextLogic.ContextTurn.OwnerId, isEnemy);
                    _impactLogic.ExecuteImpact(buffStatic.Impact);
                }
            }
            var list = _buffLogic.UpdateBuff();
            foreach (var temp in list)
            {
                _impactLogic.ExecuteImpact(_battle.Static.Buffs[temp].ImpactTakeOff);
            }
        }

        private void ExecuteStartAbility(int unit, bool isEnemy)
        {
            var data = new TriggerUnitData {OwnerId = unit, TargetId = unit};
            foreach (var temp in _battleLogic.GetAbilities(unit))
            {
                if (!_triggerLogic.CheckTrigger(data, temp.Activation, ActivationType.StartBattle))
                {
                    continue;
                }
                if (!_battleLogic.HasExecuteAbility(data.TargetId, temp.Id))
                {
                    continue;
                }
                Logger.Trace(() => $"----------------------------------- start execute impact passive ability memberId = {data.TargetId} abilityId = {temp.Id}");
                ExecuteAbility(data.OwnerId, null, temp.Impact, temp.Id, isEnemy);
                Logger.Trace(() => $"----------------------------------- finish execute impact ability");
            }
        }

        private void ExecutePassiveAbility(ActivationType eventTrigger, bool isOnlyEnemies = false)
        {
            bool isExecuteAblility = true;

            HashSet<int> lastUnitIds = new HashSet<int>();

            //var ownerId = _contextLogic.ContextTurn?.OwnerId ?? -1;

            while (isExecuteAblility)
            {
                isExecuteAblility = false;
                UpdatePassiveAbilities();

                void UpdatePassiveAbilities()
                {
                    var updateAllies = new List<int>(_battle.LiveAllies);
                    updateAllies.RemoveAll(x => lastUnitIds.Contains(x));
                    var updateEnemies = new List<int>(_battle.State.Data.Enemies.Where(x=> x.Value.Status != UnitBattleStatus.Dead).Select(x=> x.Key));
                    updateEnemies.RemoveAll(x => lastUnitIds.Contains(x));
                    lastUnitIds.Clear();

                    foreach (var id in updateEnemies)
                    {
                        if (lastUnitIds.Contains(id))
                        {
                            continue;
                        }
                        var data = new TriggerUnitData { OwnerId = id, TargetId = id};
                        UpdateAbilities(data, _battleLogic.GetAbilities(id), true);
                    }
                    if (!isOnlyEnemies)
                    {
                        foreach (var unit in updateAllies)
                        {
                            if (lastUnitIds.Contains(unit))
                            {
                                continue;
                            }
                            var data = new TriggerUnitData {OwnerId = unit, TargetId = unit};
                            UpdateAbilities(data, _battleLogic.GetAbilities(unit), false);
                        }
                    }
                }

                void UpdateAbilities(TriggerUnitData data, IEnumerable<IAbility> abilities, bool isEnemy)
                {
                    foreach (var temp in abilities)
                    {
                        if (_triggerLogic.CheckTrigger(data, temp.Activation, eventTrigger))
                        {
                            if (_battleLogic.HasExecuteAbility(data.TargetId, temp.Id))
                            {
                                Logger.Trace(() => $"----------------------------------- start execute impact passive ability memberId = {data.TargetId} abilityId = {temp.Id}");
                                ExecuteAbility(data.OwnerId, null, temp.Impact, temp.Id, isEnemy);
                                Logger.Trace(() => $"----------------------------------- finish execute impact ability");
                                isExecuteAblility = eventTrigger != ActivationType.StartBattle;
                                lastUnitIds.Add(data.OwnerId);
                            }
                        }
                    }
                }
            }
        }

        void ExecuteAbility(int ownerId, int? target, IImpact impact, int abilityId, bool isEnemy)
        {
            _contextLogic.SetAbilityContext(ownerId, target, isEnemy);
            _contextLogic.CurrentAbility = abilityId;
            _impactLogic.ExecuteImpact(impact);
            _contextLogic.CurrentAbility = 0;
            UpdateDrop();
            _battleLogic.UpdateAbility(ownerId, abilityId);
        }

        private void UpdateDrop()
        {
            foreach (var temp in _battle.State.Data.Enemies.ToArray())
            {
                if (temp.Value.Status == UnitBattleStatus.DeadInTernNoDropped)
                {
                    _contextLogic.SetContextImpact(-1, -1, false);
                    _impactLogic.ExecuteImpact(_explorer.GetMob(temp.Value.StaticId).ImpactWin);
                    temp.Value.Status = UnitBattleStatus.DeadInTern;
                    foreach (var buffData in temp.Value.Buffs)
                    {
                        var buff = _battle.Static.Buffs[buffData.Key];
                        _impactLogic.ExecuteImpact(buff.ImpactDie);
                    }
                    //var position = _battle.State.Data.StackMobs[_battle.State.Data.CurrentWave].MobData[temp.Key].Position;
                    LogicLog.MobDeath(temp.Value.StaticId, _battle.State.Data.CurrentWave, 0);
                }
            }

            foreach (var temp in _battle.State.Data.Allies)
            {
                if (temp.Value.Status == UnitBattleStatus.DeadInTernNoDropped)
                {
                    temp.Value.Status = UnitBattleStatus.DeadInTern;
                    foreach (var buffData in temp.Value.Buffs)
                    {
                        var buff = _battle.Static.Buffs[buffData.Key];
                        _impactLogic.ExecuteImpact(buff.ImpactDie);
                    }
                    LogicLog.DeathUnit(temp.Value.StaticId);
                }
            }
        }
    }
}
