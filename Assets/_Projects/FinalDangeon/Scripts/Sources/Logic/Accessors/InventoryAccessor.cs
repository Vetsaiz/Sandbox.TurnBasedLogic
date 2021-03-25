using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class InventoryAccessor
    {
        [Query]
        public IInventoryStatic Static { get; set; }
        public IInventoryState State { get; set; }

        public (int, IEquipment) GetEquipment(int itemId)
        {
            return (State.Items[itemId], null);
        }

        public void AddItem(int itemId, int count)
        {
            if (!State.Items.ContainsKey(itemId))
            {
                State.Items[itemId] = count;
            }
            else
            {
                State.Items[itemId] += count;
            }
        }

        public void SetItem(int itemId, int count)
        {
            State.Items[itemId] = count;
        }

        public void SpendItem(int itemId, int count)
        {
            State.Items[itemId] -= count;
        }

        public bool HasItem(int currentEquipmentItemId)
        {
            State.Items.TryGetValue(currentEquipmentItemId, out var value);
            return value > 0;
        }

        [Query]
        public long GetNextUpdate()
        {
            if (State.Gacha.Count == 0)
            {
                return 0;
            }
            var min = State.Gacha.Min(x => x.Value);
            return min;
        }

        //public long GetOffset(int gachaItemId)
        //{
        //    var item = Static.GachaItems[gachaItemId];
        //    int count = 0;
        //    switch (item.RollsQuantity)
        //    {
        //        case TimeQuantityType.Hour:
        //            count = 60 * 60;
        //            break;
        //        case TimeQuantityType.Hour6:
        //            count = 6 * 60 * 60;
        //            break;
        //            case TimeQuantityType.Hour12:
        //            count = 6 * 60 * 60;
        //            break;
        //        case TimeQuantityType.Day:
        //            count = 24 * 60 * 60;
        //            break;
        //        case TimeQuantityType.Weak:
        //            count = 7 * 24 * 60 * 60;
        //            break;
        //    }
        //    return Static.GachaItems[gachaItemId].RollsPeriod * count;
        //}

        public (IGacha, IUniversalPrice, int) GetGacha(int gachaId, GachaCountType count, ConditionController condition)
        {
            var gachaItem = Static.GachaItems[gachaId];
            IReadOnlyDictionary<int, IUniversalPrice> prices = null;
            int countDrop = 0;
            switch (count)
            {
                case GachaCountType.One:
                    prices = gachaItem.Prices1;
                    countDrop = 1;
                    break;
                case GachaCountType.Ten:
                    prices = gachaItem.Prices10;
                    countDrop = 10;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(count), count, null);
            }

            IUniversalPrice price = null;
            foreach (var ordered in prices.Keys.OrderBy(x=> x))
            {
                if (condition.Check(prices[ordered].Condition))
                {
                    price = prices[ordered];
                    break;
                }
            }
            return (gachaItem, price, countDrop);
        }
    }
}
