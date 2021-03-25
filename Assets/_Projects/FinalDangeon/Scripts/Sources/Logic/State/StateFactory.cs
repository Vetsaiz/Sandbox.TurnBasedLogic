using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateFactory]
    internal interface IStateFactory
    {
        IStageData CreateStage(int stageId);

        IUnitData CreateUnit(int id);
        IUnitData CreateUnit(int id, int shards, int stars, int exp, int level, int equipmentStars, bool familiarUnlock);
        IMemberBattleData CreateBattleMember(int staticId, int position, BattleParamData hpMax, BattleParamData strength, BattleParamData initiative, BattleMemberType memberType);
        IMobWave CreateWave();
        IAbilityBattleData CreateAbilityData(bool spendMana);
        
        IBattleStateData CreateBattleData(string formation, string description);
        IMobWaveData CreateMobWaveData(int id, int position);
        IBuffBattleData CreateBuff(int ownerId, bool neededRemove);
        IGoodSlotItem CreateSlot(int goodId);
        IGoodGroupItem CreateGroup();
        IGoodGroupSlotItem CreateGroupSlot(IGoodSlotItem[] value);
        IAchievementData CreateAchievement();
    }
}
