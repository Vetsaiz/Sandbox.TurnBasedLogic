using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;
using Pathfinding.Serialization.JsonFx;

namespace MetaLogic.Logic.State
{
    [JsonIgnore]
    [StateData]
    internal interface IBattleState
    {
        IBattleStateData Data { get; set; }
    }

    internal interface IBattleStateData
    {
        [SerializableId("formation")]
        string Formation { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("current_mobs")]
        ILogicDictionary<int, IMemberBattleData> Enemies { get; }

        [SerializableId("current_units")]
        ILogicDictionary<int, IMemberBattleData> Allies { get; }

        [SerializableId("researve_units")]
        ILogicDictionary<int, IMemberBattleData> ReserveAllies { get; }

        [SerializableId("stack_mobs")]
        ILogicDictionary<int, IMobWave> StackMobs { get; }

        [SerializableId("is_victory")]
        BattleStatus Status { get; set; }

        [SerializableId("current_wave")]
        int CurrentWave { get; set; }

        [SerializableId("current_id")]
        int CurrentId { get; set; }
    }

    internal interface IMemberBattleData
    {
        [SerializableId("id")]
        int StaticId { get; }

        [SerializableId("position")]
        int Position { get; }

        [SerializableId("current_hp")]
        [ForceEventState]
        float CurrentHp { get; set; }

        [SerializableId("status")]
        UnitBattleStatus Status { get; set; }

        [SerializableId("turn_influence")]
        ILogicList<InfluenceTargetType> TurnInfluence { get; }
        
        [SerializableId("turn_buff_types")]
        ILogicList<int> TurnBuffTypes { get; }

        [SerializableId("turn_buffs")]
        ILogicList<int> TurnBuffs { get; }

        [SerializableId("familiar_summoned")]
        bool TurnFamiliarSummoned { get; set; }

        [SerializableId("buffs")]
        ILogicDictionary<int, IBuffBattleData> Buffs { get; }

        [SerializableId("abilities")]
        ILogicDictionary<int,IAbilityBattleData> Abilities { get; }

        [SerializableId("max_hp")]
        BattleParamData HpMax { get; set; }

        [SerializableId("strength")]
        BattleParamData Strength { get; set; }

        [SerializableId("initiative")]
        BattleParamData Initiative { get; set; }

        [SerializableId("member_type")]
        BattleMemberType MemberType { get; set; }

        [SerializableId("familiar_summoned")]
        bool FamiliarSummoned { get; set; }

        [SerializableId("assist")]
        bool Assist { get; set; }
    }

    internal interface IBuffBattleData
    {
        [SerializableId("count_stack")]
        int CountStack { get; set; }

        [SerializableId("needed_remove")]
        bool NeededRemove { get; set; }

        [SerializableId("owner_id")]
        int OwnerId { get; }
    }

    internal interface IAbilityBattleData
    {
        int CountBattle { get; set; }

        int CountTurn { get; set; }

        bool SpendMana { get; }
    }

    internal interface IMobWave
    {
        [SerializableId("mobs")]
        ILogicDictionary<int, IMobWaveData> MobData { get; }
    }

    internal interface IMobWaveData
    {
        int Id { get; }
        int Position { get; }
    }
}
