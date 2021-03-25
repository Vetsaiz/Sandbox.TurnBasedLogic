using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;
using UnityEngine;
using Logger = VetsEngine.MetaLogic.Core.Logger;

//using UnityEngine;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class BattleLogic
    {
        public ApplyChangeLogic _manager;
        public ContextLogic _context;
        public ConditionLogic _condition;
        public FormulaController _formula;

        public BattleAccessor _battle;
        public ScorersAccessor _scorers;
        public UnitsAccessor _units;
        public ExplorerAccessor _explorer;
        public SettingsAccessor _settings;

        public void StartBattle()
        {
            _manager.SetMode(ApplyMode.Manual);
            _battle.State.Data.Status = BattleStatus.Running;
            _scorers.State.Values[_scorers.ManaId] = 0;
            _scorers.State.BattleValues.Clear();
        }

        public void BatchEventBattle()
        {
            _manager.BatchBattle();
            _manager.SetMode(ApplyMode.Auto);
        }

        public void GenerateBattleState(IReadOnlyDictionary<int, IImpactMobData> dataMobs, string formation, string description)
        {
            _context.MobImpacts.Clear();
            _battle.State.Data = _battle.Factory.CreateBattleData(formation, description);

            int currentWave = 0;
            int currentMob = 0;

            foreach (var mob in dataMobs.OrderBy(x => x.Value.Wave))
            {
                if (currentWave != mob.Value.Wave)
                {
                    currentWave = mob.Value.Wave;
                    _battle.State.Data.StackMobs[currentWave] = _battle.Factory.CreateWave();
                }
                _context.MobImpacts[currentMob] = mob.Value.Impact;
                _battle.State.Data.StackMobs[currentWave].MobData[currentMob++] = _battle.Factory.CreateMobWaveData(mob.Value.MobId, mob.Value.Position);
            }
            _battle.State.Data.CurrentId = currentMob;
            _battle.State.Data.CurrentWave = _battle.State.Data.StackMobs.Min(x => x.Key) - 1;
            GenerateNewWave();

            foreach (var unit in _units.State.Units)
            {
                if (unit.ExplorerPosition <= 0)
                {
                    continue;
                }

                if (unit.Level < 1)
                {
                    continue;
                }

                var data = CreateBattleUnit(unit, false);
                if (unit.ExplorerPosition > 0)
                {
                    _battle.State.Data.Allies[unit.Id] = data;
                }
                else
                {
                    _battle.State.Data.ReserveAllies[unit.Id] = data;
                }
            }
            if (_units.State.Assist != null)
            {
                _battle.State.Data.Allies[_units.State.Assist.Id] = CreateBattleUnit(_units.State.Assist, true);
            }
        }

        public bool HasExecuteAbility(int id, int abilityId)
        {
            var data = _battle.GetMember(id);
            var staticData = _units.Static.Abilities[abilityId];
            if (!_condition.CheckUnit(staticData.Actable, id))
            {
                return false;
            }

            //if (staticData.Params.Mode != AbilityType.Passive && data.CurrentHp <= 0)
            //{
            //    return false;
            //}

            var abilityData = data.Abilities[abilityId];
            if (staticData.LimitTurn > 0)
            {
                if (abilityData.CountTurn >= staticData.LimitTurn)
                {
                    return false;
                }
            }
            if (staticData.LimitBattle > 0)
            {
                if (abilityData.CountBattle >= staticData.LimitBattle)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<IAbility> GetAbilities(int memberId)
        {
            var member = _battle.GetMember(memberId);
            return member.Abilities.Select(x => _units.Static.Abilities[x.Key]);
        }

        public void UpdateAbility(int owner, int abilityId)
        {
            var data = _battle.GetMember(owner);
            var abilityData = data.Abilities[abilityId];
            var abilityStatic = _units.Static.Abilities[abilityId];
            _context.SetContextFormula(owner);
            var value = (int) _formula.Calculate(abilityStatic.Mana);
            _context.SetContextFormula(null);
            if (value != 0)
            {
                SpendManaAction(value);
            }
            abilityData.CountTurn += 1;
            abilityData.CountBattle += 1;

            //if (_manager._mainTarget == null)
            //{
            //    Logger.Error($"No main target ownerId = {owner} ability Id = {abilityId}", this);
            //    if (_battle.State.Data.Enemies.ContainsKey(owner))
            //    {
            //        _manager.SetAbilityTarget(_battle.State.Data.Allies.FirstOrDefault().Key);
            //    }
            //    else
            //    {
            //        _manager.SetAbilityTarget(_battle.State.Data.Enemies.FirstOrDefault().Key);
            //    }
            //}

            _manager.BatchBattleAbility(owner, abilityId);
        }

        public void SpendManaAction(int value)
        {
            var stage = _explorer.GetStage(_explorer.CurrentStage);
            stage.Values.TryGetValue(_scorers.ManaId, out var scorer);
            value = Mathf.Min((int)scorer + value, _settings.Settings.PlayerSettings.ManaMax);
            if (value < 0)
            {
                throw new Exception($"Unable to summon the ability. Not enough mana. present value = {scorer} value for calling an ability = {value}");
            }
            stage.Values[_scorers.ManaId] = value;
        }

        public IMemberBattleData StartTurn(int mobId, int? targetId, bool isEnemy)
        {
            var unit = _battle.GetMember(mobId);
            _manager.SetMode(ApplyMode.Manual);
            if (targetId != null)
            {
                _manager.SetAbilityTarget(targetId.Value);
            }
            if (!isEnemy)
            {
                _manager.BatchBattle();
            }
            return unit;
        }

        public void FinishTurn()
        {
            _manager.BatchBattle();
            _manager.SetMode(ApplyMode.Auto);
        }

        public bool UpdateMobs()
        {
            bool isGenerate = false;
            if (UpdateStatus(_battle.State.Data.Allies,false))
            {
                _battle.State.Data.Status = BattleStatus.Lose;
            }
            else if (UpdateStatus(_battle.State.Data.Enemies, true))
            {
                if (!GenerateNewWave())
                {
                    _battle.State.Data.Status = BattleStatus.Win;
                }
                else
                {
                    isGenerate = true;
                    //return true;
                }
            }
            return isGenerate;

            bool UpdateStatus(ILogicDictionary<int, IMemberBattleData> members, bool isEnemy)
            {
                foreach (var unit in members)
                {
                    if (unit.Value.Status == UnitBattleStatus.Dead)
                    {
                        continue;
                    }
                    unit.Value.TurnBuffs.Clear();
                    unit.Value.TurnBuffTypes.Clear();
                    unit.Value.TurnInfluence.Clear();
                    unit.Value.TurnFamiliarSummoned = false;
                    foreach (var temp in unit.Value.Abilities)
                    {
                        temp.Value.CountTurn = 0;
                    }

                    if (unit.Value.Status == UnitBattleStatus.DeadInTern)
                    {
                        unit.Value.Status = UnitBattleStatus.Dead;
                    }
                }

                var isLose = true;
                foreach (var member in members)
                {
                    if (member.Value.Status == UnitBattleStatus.Live)
                    {
                        isLose = false;
                        break;
                    }
                }

                return isLose;
            }
        }

        public void ClearBattle()
        {
            foreach (var temp in _battle.State.Data.Allies)
            {
                if (_units.State.Units.FirstOrDefault(x=>x.Id == temp.Value.StaticId) == null && temp.Value.Assist)
                {
                    continue;
                }
                var unit = _units.GetUnit(temp.Value.StaticId);
                unit.data.CurrentHp = temp.Value.CurrentHp;
                foreach (var buff in temp.Value.Buffs)
                {
                    unit.data.Buffs[buff.Key] = buff.Value.CountStack;
                }
            }

            _battle.State.Data = null;
        }

        private bool GenerateNewWave()
        {
            if (_battle.State.Data.CurrentWave == _battle.State.Data.StackMobs.Count)
            {
                return false;
            }

            _battle.State.Data.Enemies.Clear();
            foreach (var temp in _battle.State.Data.StackMobs[_battle.State.Data.CurrentWave + 1].MobData)
            {
                _battle.State.Data.Enemies[temp.Key] = CreateBattleMob(temp.Value.Id, temp.Value.Position);
            }

            _battle.State.Data.CurrentWave++;
            return true;
        }

        public IImpact GetMobImpact(int mobId)
        {
            var mob = _battle.GetMember(mobId);
            return _explorer.Static.Mobs[mob.StaticId].Impact;
        }

        public IMemberBattleData CreateBattleUnit(IUnitData unit, bool assist)
        {
            _context.NeedExploreParam = true;
            _context.SetContextFormula(unit.Id);
            var data = _battle.Factory.CreateBattleMember(
                unit.Id,
                unit.ExplorerPosition,
                _units.CalculateMaxHp(unit, _formula),
                _units.CalculateStrength(unit, _formula),
                _units.CalculateInitiative(unit, _formula),
                BattleMemberType.Unit
            );
            _context.SetContextFormula(null);
            _context.NeedExploreParam = false;
            data.Assist = assist;
            data.CurrentHp = unit.CurrentHp;
            var abilities = _units.Static.Abilities.Values.Where(x => x.Params.UnitId == unit.Id).ToArray();
            UpdateParams(data, abilities);

            return data;
        }

        public IMemberBattleData CreateBattleMob(int mobId, int position, bool isAssist = false)
        {
            var data = _battle.Factory.CreateBattleMember(
                mobId,
                position,
                _explorer.CalculateMaxHp(mobId, _formula),
                _explorer.CalculateStreath(mobId, _formula),
                _explorer.CalculateInitiative(mobId, _formula),
                BattleMemberType.Mob
            );
            data.CurrentHp = (float)data.HpMax.Value;
            var abilities = _units.Static.Abilities.Values.Where(x => x.Params.MobId == mobId).ToArray();
            UpdateParams(data, abilities);
            return data;
        }

        private void UpdateParams(IMemberBattleData data, IAbility[] abilities)
        {
            foreach (var ability in abilities)
            {
                data.Abilities[ability.Id] = _battle.Factory.CreateAbilityData(false);
            }
        }

        public void SetSlotUnit(int unitId, int slotId)
        {
            var unitReserve = _battle.State.Data.ReserveAllies[unitId];
            _battle.State.Data.ReserveAllies.Remove(unitId);
            _battle.State.Data.Allies[unitId] = unitReserve;
            _units.SetUnitSlot(unitId, slotId);
        }

        public void SetReserveUnit(int unitId)
        {
            var unit = _battle.State.Data.Allies[unitId];
            _battle.State.Data.Allies.Remove(unitId);
            _battle.State.Data.ReserveAllies[unitId] = unit;
            _units.SetUnitReserve(unitId, false);
        }
    }
}
