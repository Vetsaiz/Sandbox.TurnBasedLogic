using System;
using System.Collections.Generic;
using MetaLogic.Data;
namespace MetaLogic
{
    public interface ICommands
    {
        void Activation(ExplorerImpactType type, Int32 impactId, ExplorerPositionData position);
        void ActivationObject(Int32 id, Int32 index, PerkExecuteData data, ExplorerPositionData position);
        void ActivationTicker(Int32 ticker);
        void ActivationWindow(String windowId);
        void AddAllEquipments();
        void AddMob(Int32 mobId, Int32 slotId);
        void AddPlayerExp(Int32 value);
        void AddUnitExp(Int32 unitId, Int32 value);
        void AddUnitShards(Int32 unitId, Int32 shards);
        void BattleDeathUnit(Int32 slot);
        void Buy(Int32 groupId, Int32 slotId);
        void Buy(Int32 offerId);
        void CheatEndBattle();
        void CheatEndExplorer();
        void CheatExecuteImpact(Int32 impactId);
        void CheatStartExplorer(Int32 stage);
        void ClearLog();
        void ClearOldSession();
        void CompleteAchievement(Int32 achievementId);
        void CompleteStageFull(Int32 stageId);
        void DeadAllUnits();
        void Drop(Int32 gachaId, GachaCountType count);
        void EndExplorer(Int32[] inventoryIds, LogExplorerType result);
        void ExecuteMobAbility(Int32 mobId);
        void ExecuteUnitAbility(Int32 unitId, Int32 targetId, Int32 ablilityId);
        void FinishBattle();
        void FinishExplore();
        void MoveToExplorer(Int32 stage);
        void PerkUpgrateRarity(Int32 unitId, Int32 perkId);
        void PlayerLevelUp();
        void RefreshAllDaily();
        void RefreshAllShopGroups();
        void RefreshDaily(Int32 stageId);
        void RefreshGroup(Int32 groupId, Boolean force);
        void RefreshStamina();
        void RunCutSceneImpact(Int32 cutsceneId, Int32 index);
        void SellItem(Int32 itemId, Int32 count);
        void SetActiveUnit(Int32 unitId, Int32 slotId);
        void SetBattleUnit(Int32 unitId, Int32 slotId);
        void SetCutScene(Int32 tutorialId, LogTutorialType type, Int32 block);
        void SetHp(Int32 unitId, Boolean hp);
        void SetItemValue(Int32 itemId, Int32 value);
        void SetLocale(String locale);
        void SetNotificationStatus(Boolean status);
        void SetPerkStars(Int32 unitId, Int32 perkId, Int32 value);
        void SetReserveUnit(Int32 unitId);
        void SetRoom(Int32 roomId);
        void SetScorerValue(Int32 scorerId, Int32 value);
        void SetServer(ServerType type);
        void SetSession(LogSessionType type);
        void SetSettingsMusicOff(Boolean value);
        void SetSettingsSoundOff(Boolean value);
        void SetStamina(Int32 value);
        void SetTransactionProgress(String id);
        void SetUnitEquipment(Int32 unitId, Int32 slot);
        void SetUnitExplorer(Int32 unitId, Int32 slotExplorer);
        void StageAutowin(Int32 selectedStageId, Int32 tryCount);
        void StartBattle(ExplorerPositionData position);
        void StartExplorer(Int32 stage);
        void StartSession();
        void UnitUpgrateAbility(Int32 unitId, Int32 abilityId);
        void UnitUpgrateLevel(Int32 unitId);
        void UnitUpgrateRarity(Int32 unitId);
        void UpdateBuilds();
        void UpdateDropItems();
        void UpdateGacha();
        void UpdateTime(Int32 achievementId);
        void UpgradeUnitEquipment(Int32 unitId);
    }
}