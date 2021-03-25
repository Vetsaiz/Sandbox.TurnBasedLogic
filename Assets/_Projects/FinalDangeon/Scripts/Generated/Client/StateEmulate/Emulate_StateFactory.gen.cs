using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IStateFactory : IStateFactory
    {
        private ChangeStorage _storage;
        private Internal_IStateFactory _factory;
        public Emulate_IStateFactory(Internal_IStateFactory factory, ChangeStorage storage)
        {
            _factory = factory;
            _storage = storage;
        }
        public IStageData CreateStage(Int32 stageId)
        {
            var data = new Emulate_IStageData();
            data.InitData(_factory.CreateStage(stageId), _storage);
            return data;
        }
        public IUnitData CreateUnit(Int32 id)
        {
            var data = new Emulate_IUnitData();
            data.InitData(_factory.CreateUnit(id), _storage);
            return data;
        }
        public IUnitData CreateUnit(Int32 id,Int32 shards,Int32 stars,Int32 exp,Int32 level,Int32 equipmentStars,Boolean familiarUnlock)
        {
            var data = new Emulate_IUnitData();
            data.InitData(_factory.CreateUnit(id,shards,stars,exp,level,equipmentStars,familiarUnlock), _storage);
            return data;
        }
        public IMemberBattleData CreateBattleMember(Int32 staticId,Int32 position,BattleParamData hpMax,BattleParamData strength,BattleParamData initiative,BattleMemberType memberType)
        {
            var data = new Emulate_IMemberBattleData();
            data.InitData(_factory.CreateBattleMember(staticId,position,hpMax,strength,initiative,memberType), _storage);
            return data;
        }
        public IMobWave CreateWave()
        {
            var data = new Emulate_IMobWave();
            data.InitData(_factory.CreateWave(), _storage);
            return data;
        }
        public IAbilityBattleData CreateAbilityData(Boolean spendMana)
        {
            var data = new Emulate_IAbilityBattleData();
            data.InitData(_factory.CreateAbilityData(spendMana), _storage);
            return data;
        }
        public IBattleStateData CreateBattleData(String formation,String description)
        {
            var data = new Emulate_IBattleStateData();
            data.InitData(_factory.CreateBattleData(formation,description), _storage);
            return data;
        }
        public IMobWaveData CreateMobWaveData(Int32 id,Int32 position)
        {
            var data = new Emulate_IMobWaveData();
            data.InitData(_factory.CreateMobWaveData(id,position), _storage);
            return data;
        }
        public IBuffBattleData CreateBuff(Int32 ownerId,Boolean neededRemove)
        {
            var data = new Emulate_IBuffBattleData();
            data.InitData(_factory.CreateBuff(ownerId,neededRemove), _storage);
            return data;
        }
        public IGoodSlotItem CreateSlot(Int32 goodId)
        {
            var data = new Emulate_IGoodSlotItem();
            data.InitData(_factory.CreateSlot(goodId), _storage);
            return data;
        }
        public IGoodGroupItem CreateGroup()
        {
            var data = new Emulate_IGoodGroupItem();
            data.InitData(_factory.CreateGroup(), _storage);
            return data;
        }
        public IGoodGroupSlotItem CreateGroupSlot(IGoodSlotItem[] value)
        {
            var data = new Emulate_IGoodGroupSlotItem();
            data.InitData(_factory.CreateGroupSlot(value), _storage);
            return data;
        }
        public IAchievementData CreateAchievement()
        {
            var data = new Emulate_IAchievementData();
            data.InitData(_factory.CreateAchievement(), _storage);
            return data;
        }
    }
}
