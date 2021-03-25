using System;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactItemDataExecutor : ImpactExecutor<IImpactItemData>
    {
        private InventoryAccessor _inventory;
        private ExplorerAccessor _explorer;
        private FormulaLogic _logic;

        public ImpactItemDataExecutor(FormulaLogic logic, InventoryAccessor inventory, ExplorerAccessor explorer) {
            _inventory = inventory;
            _explorer = explorer;
            _logic = logic;
        }

        public override void Execute(IImpactItemData data)
        {
            var value = (int)_logic.Calculate(data.Value);
            ILogicDictionary<int, int> dict;
            if (!data.IsExplorer)
            {
                if (!_inventory.State.Items.ContainsKey(data.ItemId))
                {
                    _inventory.State.Items[data.ItemId] = 0;
                }
                dict = _inventory.State.Items;
            }
            else
            {
                if (!_explorer.State.Inventory.ContainsKey(data.ItemId))
                {
                    _explorer.State.Inventory[data.ItemId] = 0;
                }
                dict = _explorer.State.Inventory;
            }
            switch (data.Operator)
            {
                case OperationType.Add:
                    dict[data.ItemId] += value;
                    break;
                case OperationType.Set:
                    dict[data.ItemId] = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (dict[data.ItemId] <= 0)
            {
                dict.Remove(data.ItemId);
            }
            LogicLog.ChangeItemValue(data.ItemId, value);
        }

        public override ImpactType Id => ImpactType.ImpChangeItem;
    }
}
