using System;
using System.Collections.Generic;
using UniRx;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
namespace MetaLogic
{
    public interface IStateData
    {
        IAchievementStateClient AchievementState {get;}
        IBattleStateClient BattleState {get;}
        ICutSceneStateClient CutSceneState {get;}
        IExplorerStateClient ExplorerState {get;}
        IInventoryStateClient InventoryState {get;}
        ILogStateClient LogState {get;}
        IPlayerStateClient PlayerState {get;}
        IScorersStateClient ScorersState {get;}
        ISettingsStateClient SettingsState {get;}
        IShopStateClient ShopState {get;}
        IUnitsStateClient UnitsState {get;}
    }

    public interface IAbilityBattleDataClient
    {
        IReadOnlyReactiveProperty<Int32> CountBattle {get;}
        IReadOnlyReactiveProperty<Int32> CountTurn {get;}
        Boolean SpendMana {get;}
    }
    public interface IAchievementDataClient
    {
        IReadOnlyReactiveProperty<Int32> RefreshNumber {get;}
        IReadOnlyReactiveProperty<Int64> FinishTime {get;}
        IReadOnlyReactiveProperty<Boolean> Complete {get;}
    }
    public interface IAchievementStateClient
    {
        IReadOnlyReactiveProperty<IAchievementDataClient> GetAchievementsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IAchievementDataClient> Achievements {get;}
    }
    public interface IBattleStateClient
    {
        IReadOnlyReactiveProperty<IBattleStateDataClient> Data {get;}
        IBattleStatic StaticStatic {get;}
    }
    public interface IBattleStateDataClient
    {
        String Formation {get;}
        String Description {get;}
        IReadOnlyReactiveProperty<IMemberBattleDataClient> GetEnemiesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> Enemies {get;}
        IReadOnlyReactiveProperty<IMemberBattleDataClient> GetAlliesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> Allies {get;}
        IReadOnlyReactiveProperty<IMemberBattleDataClient> GetReserveAlliesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> ReserveAllies {get;}
        IReadOnlyReactiveProperty<IMobWaveClient> GetStackMobsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMobWaveClient> StackMobs {get;}
        IReadOnlyReactiveProperty<BattleStatus> Status {get;}
        IReadOnlyReactiveProperty<Int32> CurrentWave {get;}
        IReadOnlyReactiveProperty<Int32> CurrentId {get;}
    }
    public interface IBuffBattleDataClient
    {
        IReadOnlyReactiveProperty<Int32> CountStack {get;}
        IReadOnlyReactiveProperty<Boolean> NeededRemove {get;}
        Int32 OwnerId {get;}
    }
    public interface ICutSceneStateClient
    {
        IReadOnlyReactiveProperty<Boolean?> GetCompletedCutSceneProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Boolean> CompletedCutScene {get;}
        ICutScene GetCutScene(System.Int32 id);
        Boolean IsCompleteCutScene(System.Int32 id);
    }
    public interface IExplorerStateClient
    {
        IReadOnlyReactiveProperty<Int32> StageId {get;}
        IReadOnlyReactiveProperty<Int32> RoomId {get;}
        IReadOnlyReactiveProperty<IStageDataClient> GetStagesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IStageDataClient> Stages {get;}
        IReadOnlyReactiveProperty<Int32?> GetInventoryProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Inventory {get;}
        IReadOnlyReactiveProperty<ExplorerPositionData> Position {get;}
        IReadOnlyReactiveProperty<Int32> LastInteractiveId {get;}
        IReadOnlyReactiveProperty<Int32?> GetPlayerBuffsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> PlayerBuffs {get;}
        IReadOnlyReactiveProperty<Boolean> IsRun {get;}
        IReadOnlyReactiveProperty<Int32> RefreshNumber {get;}
        Int32 GetCountInteractive(System.Int32 stageId);
        IExplorerStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IInteractiveObject> ObjectsStatic {get;}
        IReadOnlyDictionary<Int32, IRoom> RoomsStatic {get;}
        IReadOnlyDictionary<Int32, IStage> StagesStatic {get;}
        IReadOnlyDictionary<Int32, IZone> ZonesStatic {get;}
    }
    public interface IGoodGroupItemClient
    {
        IReadOnlyReactiveProperty<IGoodGroupSlotItemClient> CurrentSlots {get;}
        IReadOnlyReactiveProperty<Int32> RefreshNumber {get;}
        IReadOnlyReactiveProperty<Int64> FinishTime {get;}
    }
    public interface IGoodGroupSlotItemClient
    {
        IGoodSlotItemClient[] Value {get;}
    }
    public interface IGoodSlotItemClient
    {
        Int32 GoodId {get;}
        IReadOnlyReactiveProperty<Boolean> IsBuy {get;}
        IReadOnlyReactiveProperty<Int64> WaitTime {get;}
    }
    public interface IInventoryStateClient
    {
        IReadOnlyReactiveProperty<Int32?> GetItemsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Items {get;}
        IReadOnlyReactiveProperty<Int64?> GetGachaProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int64> Gacha {get;}
        Int64 GetNextUpdate();
        IInventoryStatic StaticStatic {get;}
    }
    public interface ILogStateClient
    {
        IReadOnlyReactiveProperty<LogData> GetLogProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, LogData> Log {get;}
    }
    public interface IMemberBattleDataClient
    {
        Int32 StaticId {get;}
        Int32 Position {get;}
        IReadOnlyReactiveProperty<Single> CurrentHp {get;}
        IReadOnlyReactiveProperty<UnitBattleStatus> Status {get;}
        IReadOnlyReactiveCollection<InfluenceTargetType> TurnInfluence {get;}
        IReadOnlyReactiveCollection<Int32> TurnBuffTypes {get;}
        IReadOnlyReactiveCollection<Int32> TurnBuffs {get;}
        IReadOnlyReactiveProperty<Boolean> TurnFamiliarSummoned {get;}
        IReadOnlyReactiveProperty<IBuffBattleDataClient> GetBuffsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IBuffBattleDataClient> Buffs {get;}
        IReadOnlyReactiveProperty<IAbilityBattleDataClient> GetAbilitiesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IAbilityBattleDataClient> Abilities {get;}
        IReadOnlyReactiveProperty<BattleParamData> HpMax {get;}
        IReadOnlyReactiveProperty<BattleParamData> Strength {get;}
        IReadOnlyReactiveProperty<BattleParamData> Initiative {get;}
        IReadOnlyReactiveProperty<BattleMemberType> MemberType {get;}
        IReadOnlyReactiveProperty<Boolean> FamiliarSummoned {get;}
        IReadOnlyReactiveProperty<Boolean> Assist {get;}
    }
    public interface IMobWaveClient
    {
        IReadOnlyReactiveProperty<IMobWaveDataClient> GetMobDataProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMobWaveDataClient> MobData {get;}
    }
    public interface IMobWaveDataClient
    {
        Int32 Id {get;}
        Int32 Position {get;}
    }
    public interface IPlayerStateClient
    {
        IReadOnlyReactiveProperty<Int32> Level {get;}
        IReadOnlyReactiveProperty<Int32> Exp {get;}
        IReadOnlyReactiveProperty<String> RegisterTime {get;}
        IReadOnlyReactiveProperty<String> LastLoginTime {get;}
        IReadOnlyReactiveProperty<String> SyncTime {get;}
        IPlayerStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IPlayerLevel> LevelsStatic {get;}
    }
    public interface IScorersStateClient
    {
        IReadOnlyReactiveProperty<Int64?> GetValuesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int64> Values {get;}
        IReadOnlyReactiveProperty<Int64?> GetBattleValuesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int64> BattleValues {get;}
        IReadOnlyReactiveProperty<Int64?> GetImpactValuesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int64> ImpactValues {get;}
        IScorer GetScorer(System.String argKey);
        IScorerStatic StaticStatic {get;}
        Int32 StaminaIdStatic {get;}
        Int32 ManaIdStatic {get;}
    }
    public interface ISettingsStateClient
    {
        IReadOnlyReactiveProperty<Boolean> MusicOff {get;}
        IReadOnlyReactiveProperty<Boolean> SoundOff {get;}
        Int64 RegTime {get;}
        Int64 LoginTime {get;}
        Int64 SyncTime {get;}
        IReadOnlyReactiveProperty<String> Locale {get;}
        IReadOnlyReactiveProperty<ServerType> Server {get;}
        IReadOnlyReactiveProperty<String> CurrentVersion {get;}
        IReadOnlyReactiveProperty<Int32> Build {get;}
        IReadOnlyReactiveProperty<Int32> RandomState {get;}
        IReadOnlyReactiveProperty<Boolean> PushStatus {get;}
        Int32 GetSettingsMoneyIcon(System.Int32 delta);
        IPrice GetPriceRefresh(System.Int32 number);
        IPrice GetPriceStamina(System.Int32 number);
        Int32 GetIntVersion(System.String version);
        ISettingsStatic SettingsStatic {get;}
    }
    public interface IShopStateClient
    {
        IReadOnlyReactiveProperty<IGoodGroupItemClient> GetGroupsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IGoodGroupItemClient> Groups {get;}
        IReadOnlyReactiveProperty<IGoodSlotItemClient> GetOffersProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IGoodSlotItemClient> Offers {get;}
        IReadOnlyReactiveProperty<PaymentProgress?> GetTransactionsProperty(String key);
        IReadOnlyReactiveDictionary<String, PaymentProgress> Transactions {get;}
        IGoodSlotItemClient GetSlot(System.Int32 groupId, System.Int32 slotId);
        IPrice GetRefreshPrice(System.Int32 groupId);
        IShopStatic StaticStatic {get;}
    }
    public interface IStageDataClient
    {
        Int32 StageId {get;}
        IReadOnlyReactiveProperty<Boolean> IsUnlock {get;}
        IReadOnlyReactiveProperty<Int64?> GetValuesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int64> Values {get;}
        IReadOnlyReactiveProperty<InteractiveObjectData> GetObjectAvailibilityProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, InteractiveObjectData> ObjectAvailibility {get;}
        IReadOnlyReactiveProperty<Int32?> GetRoomsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Rooms {get;}
        IReadOnlyReactiveProperty<Int32> DailyNumber {get;}
        IReadOnlyReactiveProperty<Int32> RefreshNumber {get;}
    }
    public interface IUnitDataClient
    {
        Int32 Id {get;}
        IReadOnlyReactiveProperty<Int32> Shards {get;}
        IReadOnlyReactiveProperty<Int32> Stars {get;}
        IReadOnlyReactiveProperty<Int32> Exp {get;}
        IReadOnlyReactiveProperty<Int32> Level {get;}
        IReadOnlyReactiveProperty<Int32?> GetAbilitiesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Abilities {get;}
        IReadOnlyReactiveProperty<Int32?> GetPerkStarsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> PerkStars {get;}
        IReadOnlyReactiveProperty<Int32?> GetPerkChargesProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> PerkCharges {get;}
        IReadOnlyReactiveProperty<Int32?> GetEquipmentProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Equipment {get;}
        IReadOnlyReactiveProperty<Int32> EquipmentStars {get;}
        IReadOnlyReactiveProperty<Int32?> GetBuffsProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> Buffs {get;}
        IReadOnlyReactiveProperty<Int32> ExplorerPosition {get;}
        IReadOnlyReactiveProperty<Boolean> Reserve {get;}
        IReadOnlyReactiveProperty<Single> CurrentHp {get;}
        IReadOnlyReactiveProperty<Boolean> FamiliarUnlock {get;}
        IReadOnlyReactiveProperty<Int32> MissionCounter {get;}
    }
    public interface IUnitsStateClient
    {
        IReadOnlyReactiveCollection<IUnitDataClient> Units {get;}
        IReadOnlyReactiveProperty<IUnitDataClient> Assist {get;}
        IReadOnlyReactiveProperty<Int32?> GetLastTeamProperty(Int32 key);
        IReadOnlyReactiveDictionary<Int32, Int32> LastTeam {get;}
        IPrice[] GetAbilityPrices(System.Int32 countLevel, MetaLogic.Data.AbilityType type);
        Int32 GetShardsForUpgrage(System.Int32 unitId, System.Int32 countStars);
        Int32 CalculateMaxStamina(System.Int32 unitId);
        Int32 CalculatePerkCharges(System.Int32 unitId, System.Int32 perkId);
        IUnitsStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IUnit> UnitsStatic {get;}
        Int32[] ExplorerUnitsStatic {get;}
    }
}
