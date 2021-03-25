using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class DropLogic {
        public ScorersAccessor _scorers;
        public InventoryAccessor _inventory;
        public UnitsAccessor _units;
        public ExplorerAccessor _explorer;

        public FormulaController _formula;
        public ImpactController _impact;

        public void Drop(IDropItem drop)
        {
            var value = (int)_formula.Calculate(drop.Value);
            switch (drop.Item.Type)
            {
                case DropType.Inventory:
                    _inventory.AddItem(drop.Item.ItemId, value);
                    break;
                case DropType.Money:
                    var data1 = _scorers.Static.MoneyTypes[drop.Item.MoneyId];
                    var dict = _scorers.State.Values;
                    dict.TryGetValue(data1.ScorerId, out var oldValue);
                    dict[data1.ScorerId] = oldValue + value;
                    if (data1.AchievScorerId != 0)
                    {
                        if (!dict.ContainsKey(data1.AchievScorerId))
                        {
                            dict[data1.AchievScorerId] = 0;
                        }
                        dict[data1.AchievScorerId] += value;
                    }
                    break;
                case DropType.Shard:
                    _units.AddUnitShard(drop.Item.UnitId, value);
                    var data = _units.State.Units.FirstOrDefault(x => x.Id == drop.Item.UnitId);
                    if (data != null)
                    {
                        TryUpdateNullRarity(data);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void UpdateUnitsDrop()
        {
            foreach (var temp in _units.State.Units)
            {
                TryUpdateNullRarity(temp);
            }
        }

        public void TryUpdateNullRarity(IUnitData temp)
        {
            if (temp.Stars == 0)
            {
                _units.UpgradeNullRatity(temp);
                if (temp.Stars > 0)
                {
                    var unit = _units.Static.Units[temp.Id];
                    _impact.ExecuteImpact(unit.ImpactInit);
                    _units.UpdateLastTeamSlots();
                }
            }
        }
    }
}
