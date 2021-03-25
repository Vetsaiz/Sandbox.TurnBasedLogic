using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class ShopModule
    {
        public ScorersAccessor _scorers;
        public ShopAccessor _shop;
        public FormulaLogic _formula;
        public ImpactController _impacts;
        public ShopLogic _shopLogic;
        public DropLogic _dropLogic;

        [Command]
        public void Buy(int groupId, int slotId)
        {
            var slot = _shop.GetSlot(groupId, slotId);
            var good = _shop.GetGood(slot.GoodId);
            var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (!_shop.State.Groups.TryGetValue(groupId, out var groupData))
            {
                Logger.Error($"no state group id = {groupId}", this);
                return;
            }
            if (groupData.FinishTime != 0)
            {
                if (slot.IsBuy)
                {
                    throw new Exception($"Allready buy group id = {groupId} slot id = {slotId}");
                }
                slot.IsBuy = true;
            }

            foreach (var price in good.Price?.Values ?? new IPrice[0])
            {
                _scorers.Spend(price, _formula);
            }
            _impacts.ExecuteImpact(good.Impact);
            foreach (var temp in good.Items)
            {
                _dropLogic.Drop(temp.Value);
            }

            LogicLog.BuyGood(slot.GoodId);
        }

        [Command]
        public void Buy(int offerId)
        {
            var offer = _shop.Static.Offers[offerId];
            var good = _shop.GetGood(offer.GoodId);
            //var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            //if (current < slot.WaitTime)
            //{
            //    throw new Exception($"wait time = ");
            //}
            //slot.WaitTime = current;
            if (good.RealPrice != 0)
            {
                //var price = _shop.Static.RealPrices[good.RealPrice];
                //if (_shop.State.Transactions[price.StoreId] != PaymentProgress.Complete)
                //{
                //    throw new Exception("transactions no complete");
                //}
                //else
                //{
                //    _shop.State.Transactions.Remove(price.StoreId);
                //}
            }
            else
            {
                foreach (var price in good.Price?.Values ?? new IPrice[0])
                {
                    _scorers.Spend(price, _formula);
                }
            }
            _impacts.ExecuteImpact(good.Impact);
            foreach (var temp in good.Items)
            {
                _dropLogic.Drop(temp.Value);
            }
            LogicLog.BuyOffer(offerId);
        }

        [Command]
        public void RefreshGroup(int groupId, bool force)
        {
            var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (!_shop.State.Groups.TryGetValue(groupId, out var groupData))
            {
                Logger.Error($"no state group id = {groupId}", this);
            }

            if (_shop.Static.GoodGroups.TryGetValue(groupId, out var group))
            {
                Logger.Error($"no static group id = {groupId}",this);
            }
            //var groupData = _shop.State.Groups[groupId];

            //var group = _shop.GetGroup(groupId);c
            if (!force && current < groupData.FinishTime)
            {
                throw new Exception("no time for refresh");
            }
            if (force)
            {
                var price = group.RechargePrices.Values.FirstOrDefault(x => x.Numbler == groupData.RefreshNumber).Price;
                _scorers.Spend(price, _formula);
                if (groupData.RefreshNumber < group.RechargePrices.Count)
                {
                    groupData.RefreshNumber++;
                }
            }
            _shopLogic.UpdateGroups(groupId, current + group.Period);
        }

        [Command]
        public void RefreshAllShopGroups()
        {
            var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            foreach (var temp in _shop.State.Groups)
            {
                var group = _shop.GetGroup(temp.Key);
                var price = group.RechargePrices.Values.FirstOrDefault(x => x.Numbler == temp.Value.RefreshNumber)?.Price;
                if (price != null)
                {
                    temp.Value.RefreshNumber = 1;
                    _shopLogic.UpdateGroups(temp.Key, current + group.Period);
                }
            }
        }

        [Command]
        public void SetTransactionProgress(string id)
        {
            _shop.State.Transactions[id] = PaymentProgress.Complete;
        }
    }
}
