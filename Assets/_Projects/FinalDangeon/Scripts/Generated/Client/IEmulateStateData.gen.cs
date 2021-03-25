using System;
using System.Collections.Generic;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
using VetsEngine.MetaLogic.Contracts;

namespace MetaLogic
{
    public interface IEmulateStateData
    {
        IAchievementStateEmulate AchievementState {get;}
        IBattleStateEmulate BattleState {get;}
        ICutSceneStateEmulate CutSceneState {get;}
        IExplorerStateEmulate ExplorerState {get;}
        IInventoryStateEmulate InventoryState {get;}
        ILogStateEmulate LogState {get;}
        IPlayerStateEmulate PlayerState {get;}
        IScorersStateEmulate ScorersState {get;}
        ISettingsStateEmulate SettingsState {get;}
        IShopStateEmulate ShopState {get;}
        IUnitsStateEmulate UnitsState {get;}
    }

    public interface IAbilityBattleDataEmulate
    {
        Int32 CountBattle {get; set;}
        Int32 CountTurn {get; set;}
        Boolean SpendMana {get;}
    }
    public interface IAchievementDataEmulate
    {
        Int32 RefreshNumber {get; set;}
        Int64 FinishTime {get; set;}
        Boolean Complete {get; set;}
    }
    public interface IAchievementStateEmulate
    {
        IEmulateClientDictionary<Int32, IAchievementDataEmulate> Achievements {get;}
    }
    public interface IBattleStateEmulate
    {
        IBattleStateDataEmulate Data {get;}
        IBattleStatic StaticStatic {get;}
    }
    public interface IBattleStateDataEmulate
    {
        String Formation {get;}
        String Description {get;}
        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> Enemies {get;}
        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> Allies {get;}
        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> ReserveAllies {get;}
        IEmulateClientDictionary<Int32, IMobWaveEmulate> StackMobs {get;}
        BattleStatus Status {get; set;}
        Int32 CurrentWave {get; set;}
        Int32 CurrentId {get; set;}
    }
    public interface IBuffBattleDataEmulate
    {
        Int32 CountStack {get; set;}
        Boolean NeededRemove {get; set;}
        Int32 OwnerId {get;}
    }
    public interface ICutSceneStateEmulate
    {
        IEmulateClientDictionary<Int32, Boolean> CompletedCutScene {get;}
        ICutScene GetCutScene(System.Int32 id);
        Boolean IsCompleteCutScene(System.Int32 id);
    }
    public interface IExplorerStateEmulate
    {
        Int32 StageId {get; set;}
        Int32 RoomId {get; set;}
        IEmulateClientDictionary<Int32, IStageDataEmulate> Stages {get;}
        IEmulateClientDictionary<Int32, Int32> Inventory {get;}
        ExplorerPositionData Position {get; set;}
        Int32 LastInteractiveId {get; set;}
        IEmulateClientDictionary<Int32, Int32> PlayerBuffs {get;}
        Boolean IsRun {get; set;}
        Int32 RefreshNumber {get; set;}
        Int32 GetCountInteractive(System.Int32 stageId);
        IExplorerStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IInteractiveObject> ObjectsStatic {get;}
        IReadOnlyDictionary<Int32, IRoom> RoomsStatic {get;}
        IReadOnlyDictionary<Int32, IStage> StagesStatic {get;}
        IReadOnlyDictionary<Int32, IZone> ZonesStatic {get;}
    }
    public interface IGoodGroupItemEmulate
    {
        IGoodGroupSlotItemEmulate CurrentSlots {get;}
        Int32 RefreshNumber {get; set;}
        Int64 FinishTime {get; set;}
    }
    public interface IGoodGroupSlotItemEmulate
    {
        IGoodSlotItemEmulate[] Value {get;}
    }
    public interface IGoodSlotItemEmulate
    {
        Int32 GoodId {get;}
        Boolean IsBuy {get; set;}
        Int64 WaitTime {get; set;}
    }
    public interface IInventoryStateEmulate
    {
        IEmulateClientDictionary<Int32, Int32> Items {get;}
        IEmulateClientDictionary<Int32, Int64> Gacha {get;}
        Int64 GetNextUpdate();
        IInventoryStatic StaticStatic {get;}
    }
    public interface ILogStateEmulate
    {
        IEmulateClientDictionary<Int32, LogData> Log {get;}
    }
    public interface IMemberBattleDataEmulate
    {
        Int32 StaticId {get;}
        Int32 Position {get;}
        Single CurrentHp {get; set;}
        UnitBattleStatus Status {get; set;}
        IEmulateClientList<InfluenceTargetType> TurnInfluence {get;}
        IEmulateClientList<Int32> TurnBuffTypes {get;}
        IEmulateClientList<Int32> TurnBuffs {get;}
        Boolean TurnFamiliarSummoned {get; set;}
        IEmulateClientDictionary<Int32, IBuffBattleDataEmulate> Buffs {get;}
        IEmulateClientDictionary<Int32, IAbilityBattleDataEmulate> Abilities {get;}
        BattleParamData HpMax {get; set;}
        BattleParamData Strength {get; set;}
        BattleParamData Initiative {get; set;}
        BattleMemberType MemberType {get; set;}
        Boolean FamiliarSummoned {get; set;}
        Boolean Assist {get; set;}
    }
    public interface IMobWaveEmulate
    {
        IEmulateClientDictionary<Int32, IMobWaveDataEmulate> MobData {get;}
    }
    public interface IMobWaveDataEmulate
    {
        Int32 Id {get;}
        Int32 Position {get;}
    }
    public interface IPlayerStateEmulate
    {
        Int32 Level {get; set;}
        Int32 Exp {get; set;}
        String RegisterTime {get; set;}
        String LastLoginTime {get; set;}
        String SyncTime {get; set;}
        IPlayerStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IPlayerLevel> LevelsStatic {get;}
    }
    public interface IScorersStateEmulate
    {
        IEmulateClientDictionary<Int32, Int64> Values {get;}
        IEmulateClientDictionary<Int32, Int64> BattleValues {get;}
        IEmulateClientDictionary<Int32, Int64> ImpactValues {get;}
        IScorer GetScorer(System.String argKey);
        IScorerStatic StaticStatic {get;}
        Int32 StaminaIdStatic {get;}
        Int32 ManaIdStatic {get;}
    }
    public interface ISettingsStateEmulate
    {
        Boolean MusicOff {get; set;}
        Boolean SoundOff {get; set;}
        Int64 RegTime {get;}
        Int64 LoginTime {get;}
        Int64 SyncTime {get;}
        String Locale {get; set;}
        ServerType Server {get; set;}
        String CurrentVersion {get; set;}
        Int32 Build {get; set;}
        Int32 RandomState {get; set;}
        Boolean PushStatus {get; set;}
        Int32 GetSettingsMoneyIcon(System.Int32 delta);
        IPrice GetPriceRefresh(System.Int32 number);
        IPrice GetPriceStamina(System.Int32 number);
        Int32 GetIntVersion(System.String version);
        ISettingsStatic SettingsStatic {get;}
    }
    public interface IShopStateEmulate
    {
        IEmulateClientDictionary<Int32, IGoodGroupItemEmulate> Groups {get;}
        IEmulateClientDictionary<Int32, IGoodSlotItemEmulate> Offers {get;}
        IEmulateClientDictionary<String, PaymentProgress> Transactions {get;}
        IGoodSlotItemClient GetSlot(System.Int32 groupId, System.Int32 slotId);
        IPrice GetRefreshPrice(System.Int32 groupId);
        IShopStatic StaticStatic {get;}
    }
    public interface IStageDataEmulate
    {
        Int32 StageId {get;}
        Boolean IsUnlock {get; set;}
        IEmulateClientDictionary<Int32, Int64> Values {get;}
        IEmulateClientDictionary<Int32, InteractiveObjectData> ObjectAvailibility {get;}
        IEmulateClientDictionary<Int32, Int32> Rooms {get;}
        Int32 DailyNumber {get; set;}
        Int32 RefreshNumber {get; set;}
    }
    public interface IUnitDataEmulate
    {
        Int32 Id {get;}
        Int32 Shards {get; set;}
        Int32 Stars {get; set;}
        Int32 Exp {get; set;}
        Int32 Level {get; set;}
        IEmulateClientDictionary<Int32, Int32> Abilities {get;}
        IEmulateClientDictionary<Int32, Int32> PerkStars {get;}
        IEmulateClientDictionary<Int32, Int32> PerkCharges {get;}
        IEmulateClientDictionary<Int32, Int32> Equipment {get;}
        Int32 EquipmentStars {get; set;}
        IEmulateClientDictionary<Int32, Int32> Buffs {get;}
        Int32 ExplorerPosition {get; set;}
        Boolean Reserve {get; set;}
        Single CurrentHp {get; set;}
        Boolean FamiliarUnlock {get; set;}
        Int32 MissionCounter {get; set;}
    }
    public interface IUnitsStateEmulate
    {
        IEmulateClientList<IUnitDataEmulate> Units {get;}
        IUnitDataEmulate Assist {get;}
        IEmulateClientDictionary<Int32, Int32> LastTeam {get;}
        IPrice[] GetAbilityPrices(System.Int32 countLevel, MetaLogic.Data.AbilityType type);
        Int32 GetShardsForUpgrage(System.Int32 unitId, System.Int32 countStars);
        Int32 CalculateMaxStamina(System.Int32 unitId);
        Int32 CalculatePerkCharges(System.Int32 unitId, System.Int32 perkId);
        IUnitsStatic StaticStatic {get;}
        IReadOnlyDictionary<Int32, IUnit> UnitsStatic {get;}
        Int32[] ExplorerUnitsStatic {get;}
    }
}
