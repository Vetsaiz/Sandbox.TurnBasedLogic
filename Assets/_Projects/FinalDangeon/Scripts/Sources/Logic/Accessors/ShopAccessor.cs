using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class ShopAccessor
    {
        public IShopState State { get; set; }

        [Query]
        public IShopStatic Static { get; set; }

        public IStateFactory Factory { get; set; }

        [Query]
        public IGoodSlotItem GetSlot(int groupId, int slotId)
        {
            return State.Groups[groupId].CurrentSlots.Value[slotId];
        }

        public IGoodGroup GetGroup(int groupId)
        {
            return Static.GoodGroups[groupId];
        }

        public IGood GetGood(int goodId)
        {
            return Static.Goods[goodId];
        }


        [Query]
        public IPrice GetRefreshPrice(int groupId)
        {
            var data = State.Groups[groupId];
            var group = GetGroup(groupId);

            var price = group.RechargePrices.Values.FirstOrDefault(x => x.Numbler == data.RefreshNumber);
            if (price == null)
            {
                throw new Exception("No price in number = ");
            }
            return price.Price;
        }
    }
}
