using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class GachaModule
    {
        public ImpactController _impactLogic;

        public ScorersAccessor _scorers;
        public InventoryAccessor _resources;
        public UnitsAccessor _units;
        public ExplorerAccessor _explorer;
        public DropLogic _dropLogic;

        public ConditionController _condition;
        public FormulaLogic _formuls;

        [Command]
        public void Drop(int gachaId, GachaCountType count)
        {
            var (gachaItem, prices, countDrop) = _resources.GetGacha(gachaId, count, _condition);
            for (var i = 0; i < countDrop; i++)
            {
                _impactLogic.ExecuteImpact(gachaItem.Impact);
            }
            var gachaPrice = prices.Prices ?? new Dictionary<int, IPrice>();
            foreach (var price in gachaPrice.Values)
            {
                _scorers.Spend(price, _formuls);
            }
            _impactLogic.ExecuteImpact(prices.Impact);
            LogicLog.Gacha(gachaId, countDrop);
            UpdateDropItems();
        }

        [Command]
        public void UpdateGacha()
        {
            var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            foreach (var temp in _resources.State.Gacha.Select(x => x.Key).ToArray())
            {
                if (current > _resources.State.Gacha[temp])
                {
                    _resources.State.Gacha.Remove(temp);
                }
            }
        }

        [Command]
        public void UpdateDropItems()
        {
            _dropLogic.UpdateUnitsDrop();
        }
    }
}