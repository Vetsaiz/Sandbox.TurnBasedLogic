using System;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using MetaLogic.Data;
namespace MetaLogic.Client.Internal.Containers
{
    internal class EmulateCommands: BaseEmulateCommands, ICommands
    {
        private InternalModules _modules;

         public EmulateCommands(InternalModules modules, LogicInitData data) : base(data)
        {
            _modules = modules;
        }

        protected override void PreCommand()
        {
            base.PreCommand();
            _modules.StartSessionModule.SetAccessors();
        }

        protected override void PostCommand()
        {
            base.PostCommand();
        }

        public void Activation(ExplorerImpactType type, Int32 impactId, ExplorerPositionData position)
        {
            PreCommand();
            try
            {
                _modules.ActivationModule.Activation(type, impactId, position);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ActivationObject(Int32 id, Int32 index, PerkExecuteData data, ExplorerPositionData position)
        {
            PreCommand();
            try
            {
                _modules.ActivationModule.ActivationObject(id, index, data, position);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ActivationTicker(Int32 ticker)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.ActivationTicker(ticker);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ActivationWindow(String windowId)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.ActivationWindow(windowId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void AddAllEquipments()
        {
            PreCommand();
            try
            {
                _modules.CheatModule.AddAllEquipments();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void AddMob(Int32 mobId, Int32 slotId)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.AddMob(mobId, slotId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void AddPlayerExp(Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.AddPlayerExp(value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void AddUnitExp(Int32 unitId, Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.AddUnitExp(unitId, value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void AddUnitShards(Int32 unitId, Int32 shards)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.AddUnitShards(unitId, shards);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void BattleDeathUnit(Int32 slot)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.BattleDeathUnit(slot);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void Buy(Int32 groupId, Int32 slotId)
        {
            PreCommand();
            try
            {
                _modules.ShopModule.Buy(groupId, slotId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void Buy(Int32 offerId)
        {
            PreCommand();
            try
            {
                _modules.ShopModule.Buy(offerId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CheatEndBattle()
        {
            PreCommand();
            try
            {
                _modules.CheatModule.CheatEndBattle();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CheatEndExplorer()
        {
            PreCommand();
            try
            {
                _modules.CheatModule.CheatEndExplorer();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CheatExecuteImpact(Int32 impactId)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.CheatExecuteImpact(impactId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CheatStartExplorer(Int32 stage)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.CheatStartExplorer(stage);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ClearLog()
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.ClearLog();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ClearOldSession()
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.ClearOldSession();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CompleteAchievement(Int32 achievementId)
        {
            PreCommand();
            try
            {
                _modules.AchievementModule.CompleteAchievement(achievementId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void CompleteStageFull(Int32 stageId)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.CompleteStageFull(stageId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void DeadAllUnits()
        {
            PreCommand();
            try
            {
                _modules.CheatModule.DeadAllUnits();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void Drop(Int32 gachaId, GachaCountType count)
        {
            PreCommand();
            try
            {
                _modules.GachaModule.Drop(gachaId, count);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void EndExplorer(Int32[] inventoryIds, LogExplorerType result)
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.EndExplorer(inventoryIds, result);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ExecuteMobAbility(Int32 mobId)
        {
            PreCommand();
            try
            {
                _modules.BattleModule.ExecuteMobAbility(mobId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void ExecuteUnitAbility(Int32 unitId, Int32 targetId, Int32 ablilityId)
        {
            PreCommand();
            try
            {
                _modules.BattleModule.ExecuteUnitAbility(unitId, targetId, ablilityId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void FinishBattle()
        {
            PreCommand();
            try
            {
                _modules.BattleModule.FinishBattle();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void FinishExplore()
        {
            PreCommand();
            try
            {
                _modules.CheatModule.FinishExplore();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void MoveToExplorer(Int32 stage)
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.MoveToExplorer(stage);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void PerkUpgrateRarity(Int32 unitId, Int32 perkId)
        {
            PreCommand();
            try
            {
                _modules.UnitProgressModule.PerkUpgrateRarity(unitId, perkId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void PlayerLevelUp()
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.PlayerLevelUp();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RefreshAllDaily()
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.RefreshAllDaily();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RefreshAllShopGroups()
        {
            PreCommand();
            try
            {
                _modules.ShopModule.RefreshAllShopGroups();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RefreshDaily(Int32 stageId)
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.RefreshDaily(stageId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RefreshGroup(Int32 groupId, Boolean force)
        {
            PreCommand();
            try
            {
                _modules.ShopModule.RefreshGroup(groupId, force);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RefreshStamina()
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.RefreshStamina();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void RunCutSceneImpact(Int32 cutsceneId, Int32 index)
        {
            PreCommand();
            try
            {
                _modules.CutSceneModule.RunCutSceneImpact(cutsceneId, index);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SellItem(Int32 itemId, Int32 count)
        {
            PreCommand();
            try
            {
                _modules.StorageModule.SellItem(itemId, count);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetActiveUnit(Int32 unitId, Int32 slotId)
        {
            PreCommand();
            try
            {
                _modules.BattleModule.SetActiveUnit(unitId, slotId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetBattleUnit(Int32 unitId, Int32 slotId)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetBattleUnit(unitId, slotId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetCutScene(Int32 tutorialId, LogTutorialType type, Int32 block)
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.SetCutScene(tutorialId, type, block);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetHp(Int32 unitId, Boolean hp)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetHp(unitId, hp);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetItemValue(Int32 itemId, Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetItemValue(itemId, value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetLocale(String locale)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.SetLocale(locale);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetNotificationStatus(Boolean status)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.SetNotificationStatus(status);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetPerkStars(Int32 unitId, Int32 perkId, Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetPerkStars(unitId, perkId, value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetReserveUnit(Int32 unitId)
        {
            PreCommand();
            try
            {
                _modules.BattleModule.SetReserveUnit(unitId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetRoom(Int32 roomId)
        {
            PreCommand();
            try
            {
                _modules.ActivationModule.SetRoom(roomId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetScorerValue(Int32 scorerId, Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetScorerValue(scorerId, value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetServer(ServerType type)
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.SetServer(type);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetSession(LogSessionType type)
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.SetSession(type);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetSettingsMusicOff(Boolean value)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.SetSettingsMusicOff(value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetSettingsSoundOff(Boolean value)
        {
            PreCommand();
            try
            {
                _modules.SettingsModule.SetSettingsSoundOff(value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetStamina(Int32 value)
        {
            PreCommand();
            try
            {
                _modules.CheatModule.SetStamina(value);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetTransactionProgress(String id)
        {
            PreCommand();
            try
            {
                _modules.ShopModule.SetTransactionProgress(id);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetUnitEquipment(Int32 unitId, Int32 slot)
        {
            PreCommand();
            try
            {
                _modules.EquipmentModule.SetUnitEquipment(unitId, slot);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void SetUnitExplorer(Int32 unitId, Int32 slotExplorer)
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.SetUnitExplorer(unitId, slotExplorer);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void StageAutowin(Int32 selectedStageId, Int32 tryCount)
        {
            PreCommand();
            try
            {
                _modules.AutowinModule.StageAutowin(selectedStageId, tryCount);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void StartBattle(ExplorerPositionData position)
        {
            PreCommand();
            try
            {
                _modules.BattleModule.StartBattle(position);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void StartExplorer(Int32 stage)
        {
            PreCommand();
            try
            {
                _modules.ExplorerProgressModule.StartExplorer(stage);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void StartSession()
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.StartSession();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UnitUpgrateAbility(Int32 unitId, Int32 abilityId)
        {
            PreCommand();
            try
            {
                _modules.UnitProgressModule.UnitUpgrateAbility(unitId, abilityId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UnitUpgrateLevel(Int32 unitId)
        {
            PreCommand();
            try
            {
                _modules.UnitProgressModule.UnitUpgrateLevel(unitId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UnitUpgrateRarity(Int32 unitId)
        {
            PreCommand();
            try
            {
                _modules.UnitProgressModule.UnitUpgrateRarity(unitId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UpdateBuilds()
        {
            PreCommand();
            try
            {
                _modules.StartSessionModule.UpdateBuilds();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UpdateDropItems()
        {
            PreCommand();
            try
            {
                _modules.GachaModule.UpdateDropItems();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UpdateGacha()
        {
            PreCommand();
            try
            {
                _modules.GachaModule.UpdateGacha();
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UpdateTime(Int32 achievementId)
        {
            PreCommand();
            try
            {
                _modules.AchievementModule.UpdateTime(achievementId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

        public void UpgradeUnitEquipment(Int32 unitId)
        {
            PreCommand();
            try
            {
                _modules.EquipmentModule.UpgradeUnitEquipment(unitId);
            }
            catch (Exception e)
            {
                Logger.ErrorEmulate(e);
                return;
            }
            PostCommand();
        }

    }
}
