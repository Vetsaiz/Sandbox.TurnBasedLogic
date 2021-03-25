using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class UnitsAccessor
    {
        [Query]
        public IUnitsStatic Static { get; set; }
        public IUnitsState State { get; set; }
        public IStateFactory Factory { get; set; }

        [Query]
        public IReadOnlyDictionary<int, IUnit> Units => Static.Units;

        [Query]
        public int[] ExplorerUnits 
        {
            get { return State.Units.Where(x => x.Level > 0 && x.ExplorerPosition > 0).Select(x => x.Id).ToArray(); }
        }

        [Query]
        public IPrice[] GetAbilityPrices(int countLevel, AbilityType type)
        {
            IEnumerable<IPrice> result = new List<IPrice>();
            var level = Static.AbilityLevels.Values.FirstOrDefault(x => x.Level == countLevel);
            if (level == null)
            {
                throw new Exception($"There is no data for the selected skill level. levelId = {countLevel}");
            }
            switch (type)
            {
                case AbilityType.BaseAttack:
                    if (level.BaseAttackPrice != null)
                    {
                        result = level.BaseAttackPrice.Values;
                    }
                    break;
                case AbilityType.UpgradeAttack:
                    if (level.UpgradeAttackPrice != null)
                    {
                        result = level.UpgradeAttackPrice.Values;
                    }
                    break;
                case AbilityType.Ultimate:
                    if (level.UltAttackPrice != null)
                    {
                        result = level.UltAttackPrice.Values;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(type.ToString());
            }
            return result.ToArray();
        }

        public bool IsExplorerUnit(int unitId)
        {
            var unit = State.Units.FirstOrDefault(x=> x.Id == unitId);
            if (unit == null)
            {
                return false;
            }
            return unit.ExplorerPosition > 0;
        }


        public void UpdateLastTeamSlots()
        {
            //var slots = new List<int> {1, 2, 3};

            var stateSlots = State.LastTeam.Select(x => x.Value);
            var lastTeam = State.LastTeam.Where(x => x.Value > 0).Select(x => x.Key).ToList();
            var slots = new Queue<int>(new List<int> { 1, 2, 3 }.Where(x => !stateSlots.Contains(x)));

            if (slots.Any())
            {
                foreach (var temp in State.Units.Where(x => x.Stars > 0 && x.Level > 0))
                {
                    if (!lastTeam.Contains(temp.Id))
                    {
                        State.LastTeam[temp.Id] = slots.Dequeue();
                        if (!slots.Any())
                        {
                            break;
                        }
                    }
                }
            }
        }


        public int? GetFreeSlot()
        {
            if (State.LastTeam.Count < 3)
            {
                var existSlots = State.LastTeam.Select(x => x.Value);
                for (var i = 1; i < 3; i++)
                {
                    if (!existSlots.Contains(i))
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        public void SetUnitReserve(int unitId, bool isDeath)
        {
            var unit = GetUnit(unitId).data;
            if (isDeath)
            {
                unit.CurrentHp = 0;
            }
            if (unit.ExplorerPosition <= 0)
            {
                throw new Exception($"An attempt to remove a unit already in reserve to the reserve. unit id = {unit} slotId = {unit.ExplorerPosition}");
            }
            unit.Reserve = true;
            //if (!unit.Assist)
            //{
                //var emptySlot = State.Units.Min(x => x.SlotExplorer);
                unit.ExplorerPosition = -unitId;
            //}
            //else
            //{
            //    unit.ExplorerPosition = -4;
            //}
        }

        public void SetUnitSlot(int unitId, int slotId)
        {
            var unit = GetUnit(unitId).data;
            unit.Reserve = false;
            if (unit.ExplorerPosition > 0)
            {
                throw new Exception($"An attempt to expose from the reserve a unit that is already in the team in a slot. unit id = {unit} new slot = {slotId} exist slot = {unit.ExplorerPosition}");
            }
            if (ExplorerUnits.Any(x => GetUnit(x).data.ExplorerPosition == unitId))
            {
                throw new Exception($"Attempt to put a unit in a slot occupied by a unit. new unit_id = {unit} slot = {slotId} exist unit_id = {ExplorerUnits.FirstOrDefault(x=> GetUnit(x).data.ExplorerPosition == slotId)}");
            }
            unit.ExplorerPosition = slotId;
        }

        public (IUnitData data, IUnit unit) GetUnit(int unitId)
        {
            IUnitData data;
            if (State.Assist != null && State.Assist.Id == unitId)
            {
                data = State.Assist;
            }
            else
            {
                data = State.Units.FirstOrDefault(x => x.Id == unitId);
                if (data == null || data.Level < 1)
                {
                    throw new Exception($"Unit id {unitId} missing");
                }
            }
            var unit = Static.Units[unitId];
            return (data, unit);
        }

        public int UpgradeUnitLevel(int unitId, int exp, int maxLevel)
        {
            var (data, unit) = GetUnit(unitId);
            if (data.Stars < 1)
            {
                return 0;
            }

            var levels = GetSortedLevels();
            if (data.Level == levels.Count)
            {
                return data.Level;
            }

            var newExp = data.Exp + exp;
            var max = levels.Last().ExpMin;
            if (newExp > max)
            {
                newExp = max;
            }

            while (data.Level < levels.Count)
            {
                if (data.Level == maxLevel)
                {
                    newExp = 0;
                    break;
                }

                var levelData = levels[data.Level];
                if (newExp >= levelData.ExpMin)
                {
                    data.Level += 1;
                    LogicLog.UpdateUnitLevel(unitId, data.Level, exp);
                }
                else
                {
                    break;
                }
            }
            data.Exp = newExp;
            return data.Level;
        }

        private IList<IUnitLevel> GetSortedLevels()
        {
            return Static.UnitLevels.Values.OrderBy(x => x.Level).ToList();
        }

        public void UpgradeNullRatity(IUnitData data)
        {
            if (data.Stars > 0)
            {
                return;
            }
            var countShards = GetShardsForUpgrage(data.Id, data.Stars);
            if (countShards > data.Shards)
            {
                return;
            }
            var allAbilities = Static.Abilities.Where(x => x.Value.Params.UnitId == data.Id);
            foreach (var temp in allAbilities)
            {
                data.Abilities[temp.Key] = 1;
            }
            var allPerks = Static.Perks.Where(x => x.Value.UnitId == data.Id);
            foreach (var temp in allPerks)
            {
                data.PerkStars[temp.Key] = 1;
            }
            data.EquipmentStars = 1;
            data.Stars = 1;
            data.Level = 1;
            data.Shards -= countShards;
            LogicLog.UpgradeRarityUnit(data.Id, data.Stars);
        }

        public void UpgradeRarity(int unitId)
        {
            var (data, unit) = GetUnit(unitId);
            if (Static.Units[unitId].Rarities.Count == data.Stars)
            {
                throw new Exception($"Maximum rarity level reached. unit_id = {unitId}");
            }
            var countShards = GetShardsForUpgrage(unitId, data.Stars);
            if (data.Shards < countShards)
            {
                throw new Exception($"Not enough shards to level up rarity. unit_id = {unitId} countStards = {countShards} neededStards = {data.Shards}");
            }
            data.Stars++;
            LogicLog.UpgradeRarityUnit(unitId, data.Stars);
            data.Shards -= countShards;
        }

        public IUnitLevel GetLevel(int level)
        {
            return Static.UnitLevels.Values.FirstOrDefault(x => x.Level == level);
        }

        [Query]
        public int GetShardsForUpgrage(int unitId, int countStars)
        {
            var currentRarity = Static.Units[unitId].Rarities.Values.FirstOrDefault(x => x.Stars == countStars + 1);
            if (currentRarity == null)
            {
                //throw new Exception($" Unit id = {unitId} no rarity for stars = {countStars}");
                return -1;
            }
            return currentRarity.Shards;
        }

        public void AddUnitShard(int unitId, int shards)
        {
            var data = State.Units.FirstOrDefault(x => x.Id == unitId);
            if (data == null)
            {
                data = Factory.CreateUnit(unitId);
                State.Units.Add(data);
            }
            var value = data.Shards + shards;
            if (value < 0)
            {
                value = 0;
            }
            data.Shards = value;
            if (data.Stars == 0 && data.Shards == 0)
            {
                State.Units.Remove(data);
            }
        }

        public bool IsFullEquipment(int unitId)
        {
            var (data, def) = GetUnit(unitId);
            var countSlots = def.Equipment.Values.Count(x => x.Stars == data.EquipmentStars);
            return data.Equipment.Count == countSlots;
        }

        public bool AddUnit(IUnitAdd impact)
        {
            var unit = CreateUnit(impact);
            if (State.Units.FirstOrDefault(x => x.ExplorerPosition == impact.SlotExplorer) != null)
            {
                unit.ExplorerPosition = -1;
            }

            var oldUnit = State.Units.FirstOrDefault(x => x.Id == impact.Id);
            if (oldUnit != null)
            {
                if (oldUnit.Stars > 0)
                {
                    return false;
                }
                unit.Shards += oldUnit.Shards;
                State.Units.Remove(oldUnit);
            }
            State.Units.Add(unit);
            return true;
        }

        public IUnitData CreateUnit(IUnitAdd impact)
        {
            var unit = Factory.CreateUnit(impact.Id, impact.Shards, impact.Stars, impact.Exp, impact.Level, impact.EquipmentRarity, impact.FamiliarUnlock);
            unit.ExplorerPosition = impact.SlotExplorer;
            foreach (var temp in impact.Equipment ?? new Dictionary<int, int>())
            {
                unit.Equipment[temp.Key] = temp.Value;
            }
            foreach (var temp in impact.PerkCharges ?? new Dictionary<int, int>())
            {
                unit.PerkCharges[temp.Key] = temp.Value;
            }

            var allPerks = Static.Perks.Where(x => x.Value.UnitId == impact.Id);
            foreach (var temp in allPerks)
            {
                unit.PerkStars[temp.Key] = 1;
            }
            var allAbilities = Static.Abilities.Where(x => x.Value.Params.UnitId == impact.Id);
            foreach (var temp in allAbilities)
            {
                unit.Abilities[temp.Key] = 1;
            }
            return unit;
        }

        [Query]
        public int CalculateMaxStamina(int unitId)
        {
            var maxStamina = 0;
            var (data, def) = GetUnit(unitId);
            var rarities = def.Rarities.Where(x => x.Value.Stars <= data.Stars);
            foreach (var rarity in rarities)
            {
                maxStamina += rarity.Value.Stamina;
            }
            return maxStamina;
        }

        [Query]
        public int CalculatePerkCharges(int unitId, int perkId)
        {
            var (data, def) = GetUnit(unitId);
            var perk = Static.Perks[perkId];
            if (perk.OnlyActive)
            {
                return -1;
            }
            var perkRarities = perk.Rarities.Where(x => x.Value.Stars <= data.PerkStars[perkId]);
            var charges = 0;
            foreach (var rarity in perkRarities)
            {
                charges += rarity.Value.Charges;
            }
            return charges;
        }

        public float CalculateEquipStrength(int unitId)
        {
            var sum = 0;
            var (data1, unit) = GetUnit(unitId);
            foreach (var temp in unit.EquipmentRarities.Values)
            {
                if (temp.Stars != data1.EquipmentStars)
                {
                    continue;
                }
                sum += temp.Strength;
            }
            if (unit.Equipment != null)
            {
                foreach (var temp in unit.Equipment.Values)
                {
                    if (temp.Stars != data1.EquipmentStars)
                    {
                        continue;
                    }
                    if (data1.Equipment.TryGetValue(temp.Slot, out var value) && value != 0)
                    {
                        sum += temp.Strength;
                    }
                }
            }
            return sum;
        }

        public float CalculateEquipHp(int unitId)
        {
            var sum = 0;
            var (data1, unit) = GetUnit(unitId);
            foreach (var temp in unit.EquipmentRarities.Values)
            {
                if (temp.Stars != data1.EquipmentStars)
                {
                    continue;
                }
                sum += temp.HpMax;
            }
            if (unit.Equipment != null)
            {
                foreach (var temp in unit.Equipment.Values)
                {
                    if (temp.Stars != data1.EquipmentStars)
                    {
                        continue;
                    }
                    if (data1.Equipment.TryGetValue(temp.Slot, out var value) && value != 0)
                    {
                        sum += temp.HpMax;
                    }
                }
            }
            return sum;
        }

        public float CalculateEquipInit(int unitId)
        {
            var sum = 0;
            var (data1, unit) = GetUnit(unitId);
            foreach (var temp in unit.EquipmentRarities.Values)
            {
                if (temp.Stars != data1.EquipmentStars)
                {
                    continue;
                }
                sum += temp.Initiative;
            }
            if (unit.Equipment != null)
            {
                foreach (var temp in unit.Equipment.Values)
                {
                    if (temp.Stars != data1.EquipmentStars)
                    {
                        continue;
                    }
                    if (data1.Equipment.TryGetValue(temp.Slot, out var value) && value != 0)
                    {
                        sum += temp.Initiative;
                    }
                }
            }
            return sum;
        }

        public BattleParamData CalculateMaxHp(IUnitData data, FormulaController formula)
        {
            var unit = Static.Units[data.Id];
            return new BattleParamData
            {
                Value = (int)formula.Calculate(unit.HpMax),
                Equip = CalculateEquipHp(data.Id),
                Base = unit.Rarities.Where(x => x.Value.Stars == data.Stars).Sum(x => x.Value.HpMax),
            };
        }
        
        public BattleParamData CalculateStrength(IUnitData data, FormulaController formula)
        {
            var unit = Static.Units[data.Id];
            return new BattleParamData
            {
                Value = (int)formula.Calculate(unit.Strength),
                Equip = CalculateEquipStrength(unit.Id),
                Base = unit.Rarities.Where(x => x.Value.Stars == data.Stars).Sum(x => x.Value.Strength),
            };
        }
        
        public BattleParamData CalculateInitiative(IUnitData data, FormulaController formula)
        {
            var unit = Static.Units[data.Id];
            return new BattleParamData
            {
                Value = (int)formula.Calculate(unit.Initiative),
                Equip = CalculateEquipInit(data.Id),
                Base = unit.Rarities.Where(x => x.Value.Stars == data.Stars).Sum(x => x.Value.Initiative),
            };
        }

        public bool TryGetUnit(int unitId, bool assist, out IUnitData data)
        {
            if (assist)
            {
                if (State.Assist != null && State.Assist.Id == unitId)
                {
                    data = State.Assist;
                    return true;
                }
            }
            data = State.Units.FirstOrDefault(x => x.Id == unitId);
            return data != null && data.Level > 0;
        }
    }
}
