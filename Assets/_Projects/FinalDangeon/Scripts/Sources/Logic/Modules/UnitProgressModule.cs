using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class UnitProgressModule
    {
        public UnitsAccessor _units;
        public ScorersAccessor _scorers;
        public BattleAccessor _battle;

        public FormulaLogic _formuls;
        public PlayerAccessor _player;

        public ImpactController _impact;

        [Command]
        public void UnitUpgrateRarity(int unitId)
        {
            _units.UpgradeRarity(unitId);
            var unit = _units.Static.Units[unitId];
            _impact.ExecuteContextImpact(unit.ImpactUpdrade, unitId);
        }

        [Command]
        public void UnitUpgrateLevel(int unitId)
        {
            var (data, unit) = _units.GetUnit(unitId);
            var playerLevel = _player.State.Level;
            if (data.Level >= playerLevel)
            {
                throw new Exception($"Unable to level up unit. Unit id = {unitId} unit level = {data.Level} current player level = {playerLevel}");
            }
            var prices = _units.GetLevel(data.Level + 1)?.Prices;
            if (prices != null)
            {
                foreach (var price in prices)
                {
                    _scorers.Spend(price.Value, _formuls);
                }
            }
            data.Exp = 0;
            data.Level++;
            _impact.ExecuteContextImpact(unit.ImpactUpdrade, unitId);

        }

        [Command]
        public void UnitUpgrateAbility(int unitId, int abilityId)
        {
            var (data, unit) = _units.GetUnit(unitId);
            if (!data.Abilities.ContainsKey(abilityId))
            {
                throw new Exception($"Ability missing. Unit id = {unitId} ability id =  {abilityId}");
            }
            var currentLevel = data.Abilities[abilityId];
            if (currentLevel >= data.Level)
            {
                throw new Exception($"Impossible to upgrade the ability. Unit id = {unitId} current level = {data.Level}");
            }

            var abilityType = _units.Static.Abilities[abilityId].Params.Mode;
            var prices = _units.GetAbilityPrices(currentLevel, abilityType);
            foreach (var price in prices) {
                _scorers.Spend(price, _formuls);
            }
            data.Abilities[abilityId]++;
            LogicLog.UpgradeAbilityLevel(unitId, abilityId, data.Abilities[abilityId]);
            _impact.ExecuteContextImpact(unit.ImpactUpdrade, unitId);
        }

        [Command]
        public void PerkUpgrateRarity(int unitId, int perkId)
        {
            var (data, unit) = _units.GetUnit(unitId);
            var perk = _units.Static.Perks[perkId];
            if (!data.PerkStars.ContainsKey(perkId))
            {
                throw new Exception($"Perk missing. Unit id = {unitId} perk id =  {perkId}");
            }
            var rarity = perk.Rarities.Values.FirstOrDefault(x=> x.Stars == data.PerkStars[perkId]);
            foreach (var price in rarity.Prices?.Values ?? new IPrice[0])
            {
                _scorers.Spend(price, _formuls);
            }
            data.PerkStars[perkId]++;
            LogicLog.UpgradePerkLevel(unitId, perkId, data.PerkStars[perkId]);
            _impact.ExecuteContextImpact(unit.ImpactUpdrade, unitId);
        }
    }
}
