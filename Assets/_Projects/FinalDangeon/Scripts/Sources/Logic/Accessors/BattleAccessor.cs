using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class BattleAccessor
    {
        public IBattleState State { get; set; }
        public IStateFactory Factory { get; set; }

        [Query]
        public IBattleStatic Static { get; set; }

        public IEnumerable<int> LiveEnemies
        {
            get
            {
                return State.Data.Enemies?.Where(x => x.Value?.Status == UnitBattleStatus.Live).Select(x => x.Key);
            }
        }

        public IEnumerable<int> LiveAllies => State.Data.Allies.Where(x => x.Value.Status == UnitBattleStatus.Live).Select(x => x.Key);

        public IMemberBattleData GetMember(int id)
        {
            if (!State.Data.Enemies.TryGetValue(id, out IMemberBattleData data))
            {
                if (State.Data.Allies.TryGetValue(id, out IMemberBattleData data1))
                    return data1;

                return null;
            }
            return data;
        }

        public IMemberBattleData FindMemberInStaticId(int id)
        {
            var data = State.Data.Enemies.Select(x=> x.Value).FirstOrDefault(x => x.StaticId == id);
            if (data == null)
            {
                if (State.Data.Allies.TryGetValue(id, out IMemberBattleData data1))
                    return data1;

                return null;
            }
            return data;
        }

        public bool IsTarget(TriggerUnitData data, TargetActivationType target)
        {
            switch (target)
            {
                case TargetActivationType.Owner:
                    if (data.OwnerId != data.TargetId)
                    {
                        return false;
                    }
                    break;
                case TargetActivationType.Ally:
                    if (LiveEnemies.Contains(data.TargetId) && !LiveAllies.Contains(data.OwnerId))
                    {
                        return false;
                    }
                    break;
                case TargetActivationType.Enemy:
                    if (LiveEnemies.Contains(data.TargetId) && LiveAllies.Contains(data.OwnerId))
                    {
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(target), target, null);
            }
            return true;
        }
        
        public void AddInfluence(int ownerId, InfluenceTargetType influence)
        {
            GetMember(ownerId).TurnInfluence.Add(influence);
        }

        public bool HasStan(int ownerId)
        {
            var member = GetMember(ownerId);
            if (member != null)
            {
                foreach (var buff in member.Buffs)
                {
                    foreach (var id in Static.Buffs[buff.Key].BuffType.Values)
                    {
                        if ((BuffType) id == BuffType.Stun)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
