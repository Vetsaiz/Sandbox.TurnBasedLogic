using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.State;
using UnityEngine;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class BuffLogic
    {
        public BattleAccessor _accessor;

        public ContextLogic _contextLogic;
        public ApplyChangeLogic _logic;

        public List<int> UpdateBuff()
        {
            var list = new List<int>();
            var data = _accessor.GetMember(_contextLogic.ContextTurn.OwnerId);
            foreach (var temp in data.Buffs.Select(x=> x.Key).ToArray())
            {
                var buffState = data.Buffs[temp];
                var staticData = _accessor.Static.Buffs[temp];
                if (buffState.NeededRemove)
                {
                    buffState.NeededRemove = false;
                    continue;
                }

                var targetData = _accessor.GetMember(buffState.OwnerId);

                if (targetData != null && targetData.Status == UnitBattleStatus.DeadInTern)
                {
                    buffState.CountStack -= staticData.WithdrawDeath;
                }

                if (buffState.CountStack <= staticData.WithdrawTurn)
                {
                    data.Buffs.Remove(temp);
                    list.Add(temp);
                }
                else
                {
                    buffState.CountStack -= staticData.WithdrawTurn;
                }
            }
            _logic.BatchBattle();
            return list;
        }

        public bool ChangeBuff(IMemberBattleData member, IBuffBattleData buffData, int buffId, int value)
        {
            var buff = _accessor.Static.Buffs[buffId];
            var oldStack = buffData.CountStack;

            var newValue = buffData.CountStack + value;
            if (value > 0)
            {
                buffData.CountStack = newValue;
                member.TurnBuffs.Add(buffId);
                foreach (var buffType in buff.BuffType.Values)
                {
                    member.TurnBuffTypes.Add(buffType);
                }
            }
            else if (value < 0)
            {
                if (newValue > 0)
                {
                    buffData.CountStack = newValue;
                }
                else
                {
                    member.Buffs.Remove(buffId);
                    return false;
                }
            }
            return true;
        }
    }
}
