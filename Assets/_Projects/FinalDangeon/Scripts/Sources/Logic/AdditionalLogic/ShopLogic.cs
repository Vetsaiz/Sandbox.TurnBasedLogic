using System.Collections.Generic;
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
    internal partial class ShopLogic
    {
        public SettingsAccessor _settings;
        public ShopAccessor _shop;

        public FormulaController _formula;

        public void UpdateGroups(int groupId, long currentTime)
        {
            var group = _shop.GetGroup(groupId);
            if (group.Slots != null && group.Slots.Count > 0)
            {
                if (!_shop.State.Groups.TryGetValue(groupId, out var data))
                {
                    data = _shop.State.Groups[groupId] = _shop.Factory.CreateGroup();
                }
                data.FinishTime = currentTime;
                var list = new List<IGoodSlotItem>();

                foreach (var temp in group.Slots.OrderBy(x => x.Key))
                {
                    if (temp.Value.Goods == null)
                    {
                        Logger.Error($"groupId = {groupId} slot = {temp.Key} groups = null", this);
                        continue;
                    }
                    var dataWeight = new List<(int, int)>();
                    foreach (var temp1 in temp.Value.Goods)
                    {
                        var weight = (int)_formula.Calculate(temp1.Value.Weight);
                        dataWeight.Add((weight, temp1.Value.GoodId));
                    }
                    var goodId = _settings.GetWeightRandom(dataWeight).Item2;
                    list.Add(_shop.Factory.CreateSlot(goodId));
                }
                _shop.State.Groups[groupId].CurrentSlots = _shop.Factory.CreateGroupSlot(list.ToArray());
            }
        }
    }
}
