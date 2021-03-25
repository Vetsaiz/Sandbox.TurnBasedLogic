using System;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IStateFactory : IStateFactory
    {
        public IStageData CreateStage(Int32 stageId)
        {
            var data = new Internal_IStageData();
            data._StageId = stageId;
            return data;
        }
        public IUnitData CreateUnit(Int32 id)
        {
            var data = new Internal_IUnitData();
            data._Id = id;
            return data;
        }
        public IUnitData CreateUnit(Int32 id,Int32 shards,Int32 stars,Int32 exp,Int32 level,Int32 equipmentStars,Boolean familiarUnlock)
        {
            var data = new Internal_IUnitData();
            data._Id = id;
            data._Shards = shards;
            data._Stars = stars;
            data._Exp = exp;
            data._Level = level;
            data._EquipmentStars = equipmentStars;
            data._FamiliarUnlock = familiarUnlock;
            return data;
        }
        public IMemberBattleData CreateBattleMember(Int32 staticId,Int32 position,BattleParamData hpMax,BattleParamData strength,BattleParamData initiative,BattleMemberType memberType)
        {
            var data = new Internal_IMemberBattleData();
            data._StaticId = staticId;
            data._Position = position;
            data._HpMax = hpMax;
            data._Strength = strength;
            data._Initiative = initiative;
            data._MemberType = memberType;
            return data;
        }
        public IMobWave CreateWave()
        {
            var data = new Internal_IMobWave();
            return data;
        }
        public IAbilityBattleData CreateAbilityData(Boolean spendMana)
        {
            var data = new Internal_IAbilityBattleData();
            data._SpendMana = spendMana;
            return data;
        }
        public IBattleStateData CreateBattleData(String formation,String description)
        {
            var data = new Internal_IBattleStateData();
            data._Formation = formation;
            data._Description = description;
            return data;
        }
        public IMobWaveData CreateMobWaveData(Int32 id,Int32 position)
        {
            var data = new Internal_IMobWaveData();
            data._Id = id;
            data._Position = position;
            return data;
        }
        public IBuffBattleData CreateBuff(Int32 ownerId,Boolean neededRemove)
        {
            var data = new Internal_IBuffBattleData();
            data._OwnerId = ownerId;
            data._NeededRemove = neededRemove;
            return data;
        }
        public IGoodSlotItem CreateSlot(Int32 goodId)
        {
            var data = new Internal_IGoodSlotItem();
            data._GoodId = goodId;
            return data;
        }
        public IGoodGroupItem CreateGroup()
        {
            var data = new Internal_IGoodGroupItem();
            return data;
        }
        public IGoodGroupSlotItem CreateGroupSlot(IGoodSlotItem[] value)
        {
            var data = new Internal_IGoodGroupSlotItem();
            data._Value = value.Select(x=> x as Internal_IGoodSlotItem).ToArray();
            return data;
        }
        public IAchievementData CreateAchievement()
        {
            var data = new Internal_IAchievementData();
            return data;
        }
    }
}
