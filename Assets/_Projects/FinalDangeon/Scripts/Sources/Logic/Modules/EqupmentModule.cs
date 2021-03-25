using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class EquipmentModule
    {
        public InventoryAccessor _resources;
        public ScorersAccessor _scorers;
        public UnitsAccessor _units;

        public ImpactController _impact;
        public FormulaLogic _formula;

        [Command]
        public void SetUnitEquipment(int unitId, int slot)
        {
            var (data, defUnit) = _units.GetUnit(unitId);
            var currentEquipment = defUnit.Equipment.Values.FirstOrDefault(x => x.Slot == slot && x.Stars == data.EquipmentStars);
            if (currentEquipment == null)
            {
                throw new Exception($"Unit id ={unitId} no equipment id = {slot}");
            }
            if (!_resources.HasItem(currentEquipment.ItemId))
            {
                throw new Exception($"Unable to insert equipment for a unit. no required item in inventory. unit id = {unitId} slot = {slot} item_id = {currentEquipment.ItemId}");
            }
            data.Equipment[slot] = currentEquipment.ItemId;
            _resources.SpendItem(currentEquipment.ItemId, 1);
            LogicLog.SetEquip(unitId, currentEquipment.ItemId, slot, data.EquipmentStars);
        }

        [Command]
        public void UpgradeUnitEquipment(int unitId)
        {
            var (data, unit) = _units.GetUnit(unitId);

            if (!_units.IsFullEquipment(unitId))
            {
                throw new Exception($"The unit does not have all the equipment for pumping. id = {unitId}");
            }
            if (unit.EquipmentRarities.TryGetValue(data.EquipmentStars - 1, out var rarity))
            {
                foreach (var price in rarity.Prices)
                {
                    _scorers.Spend(price.Value, _formula);
                }
            }
            data.Equipment.Clear();
            data.EquipmentStars += 1;
            LogicLog.UpgradeEquipRarity(unitId, data.EquipmentStars);
            _impact.ExecuteContextImpact(unit.ImpactUpdrade, unitId);
        }
    }
}
