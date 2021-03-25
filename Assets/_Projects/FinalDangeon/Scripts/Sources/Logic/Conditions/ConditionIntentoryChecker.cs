using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionIntentoryChecker : ConditionChecker<IConditionAvailability> {
        private readonly InventoryAccessor _inventory;
        private FormulaLogic _logic;

        public ConditionIntentoryChecker(FormulaLogic logic, InventoryAccessor inventory) {
            _inventory = inventory;
            _logic = logic;
        }

        public override bool Check(IConditionAvailability restictionData)
        {
            _inventory.State.Items.TryGetValue(restictionData.ItemId, out var currentValue);
            var value = (int)_logic.Calculate(restictionData.Value);
            return restictionData.Operator.Check(currentValue, value);
        }

        public override ConditionType Id => ConditionType.CondItemAvailability;
    }
}
