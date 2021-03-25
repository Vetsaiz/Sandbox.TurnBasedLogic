using System;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using MetaLogic.Data;


namespace MetaLogic.Client.Internal.Containers
{
    internal class InternalCommands : BaseClientCommands, ICommands
    {
        private InternalModules _modules;

        public InternalCommands(InternalModules modules, ChangeStorage storage, LogicInitData data) : base(storage, data)
        {
            _modules = modules;
        }

        protected override void PreCommand()
        {
            base.PreCommand();
            _modules.StartSessionModule.SetAccessors();
        }

        protected override void PostCommand(string nameCommand, object[] args)
        {
            base.PostCommand(nameCommand, args);
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
                Logger.Exception(e, "Activation", new object[] {(object)(int)type, (object)impactId, (object)position} );
                return;
            }
            PostCommand("Activation", new object[] {(object)(int)type, (object)impactId, (object)position} );
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
                Logger.Exception(e, "ActivationObject", new object[] {(object)id, (object)index, (object)data, (object)position} );
                return;
            }
            PostCommand("ActivationObject", new object[] {(object)id, (object)index, (object)data, (object)position} );
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
                Logger.Exception(e, "ActivationTicker", new object[] {(object)ticker} );
                return;
            }
            PostCommand("ActivationTicker", new object[] {(object)ticker} );
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
                Logger.Exception(e, "ActivationWindow", new object[] {(object)windowId} );
                return;
            }
            PostCommand("ActivationWindow", new object[] {(object)windowId} );
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
                Logger.Exception(e, "AddAllEquipments", new object[] {} );
                return;
            }
            PostCommand("AddAllEquipments", new object[] {} );
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
                Logger.Exception(e, "AddMob", new object[] {(object)mobId, (object)slotId} );
                return;
            }
            PostCommand("AddMob", new object[] {(object)mobId, (object)slotId} );
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
                Logger.Exception(e, "AddPlayerExp", new object[] {(object)value} );
                return;
            }
            PostCommand("AddPlayerExp", new object[] {(object)value} );
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
                Logger.Exception(e, "AddUnitExp", new object[] {(object)unitId, (object)value} );
                return;
            }
            PostCommand("AddUnitExp", new object[] {(object)unitId, (object)value} );
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
                Logger.Exception(e, "AddUnitShards", new object[] {(object)unitId, (object)shards} );
                return;
            }
            PostCommand("AddUnitShards", new object[] {(object)unitId, (object)shards} );
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
                Logger.Exception(e, "BattleDeathUnit", new object[] {(object)slot} );
                return;
            }
            PostCommand("BattleDeathUnit", new object[] {(object)slot} );
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
                Logger.Exception(e, "Buy", new object[] {(object)groupId, (object)slotId} );
                return;
            }
            PostCommand("Buy", new object[] {(object)groupId, (object)slotId} );
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
                Logger.Exception(e, "Buy", new object[] {(object)offerId} );
                return;
            }
            PostCommand("Buy", new object[] {(object)offerId} );
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
                Logger.Exception(e, "CheatEndBattle", new object[] {} );
                return;
            }
            PostCommand("CheatEndBattle", new object[] {} );
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
                Logger.Exception(e, "CheatEndExplorer", new object[] {} );
                return;
            }
            PostCommand("CheatEndExplorer", new object[] {} );
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
                Logger.Exception(e, "CheatExecuteImpact", new object[] {(object)impactId} );
                return;
            }
            PostCommand("CheatExecuteImpact", new object[] {(object)impactId} );
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
                Logger.Exception(e, "CheatStartExplorer", new object[] {(object)stage} );
                return;
            }
            PostCommand("CheatStartExplorer", new object[] {(object)stage} );
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
                Logger.Exception(e, "ClearLog", new object[] {} );
                return;
            }
            PostCommand("ClearLog", new object[] {} );
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
                Logger.Exception(e, "ClearOldSession", new object[] {} );
                return;
            }
            PostCommand("ClearOldSession", new object[] {} );
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
                Logger.Exception(e, "CompleteAchievement", new object[] {(object)achievementId} );
                return;
            }
            PostCommand("CompleteAchievement", new object[] {(object)achievementId} );
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
                Logger.Exception(e, "CompleteStageFull", new object[] {(object)stageId} );
                return;
            }
            PostCommand("CompleteStageFull", new object[] {(object)stageId} );
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
                Logger.Exception(e, "DeadAllUnits", new object[] {} );
                return;
            }
            PostCommand("DeadAllUnits", new object[] {} );
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
                Logger.Exception(e, "Drop", new object[] {(object)gachaId, (object)(int)count} );
                return;
            }
            PostCommand("Drop", new object[] {(object)gachaId, (object)(int)count} );
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
                Logger.Exception(e, "EndExplorer", new object[] {(object)inventoryIds, (object)(int)result} );
                return;
            }
            PostCommand("EndExplorer", new object[] {(object)inventoryIds, (object)(int)result} );
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
                Logger.Exception(e, "ExecuteMobAbility", new object[] {(object)mobId} );
                return;
            }
            PostCommand("ExecuteMobAbility", new object[] {(object)mobId} );
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
                Logger.Exception(e, "ExecuteUnitAbility", new object[] {(object)unitId, (object)targetId, (object)ablilityId} );
                return;
            }
            PostCommand("ExecuteUnitAbility", new object[] {(object)unitId, (object)targetId, (object)ablilityId} );
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
                Logger.Exception(e, "FinishBattle", new object[] {} );
                return;
            }
            PostCommand("FinishBattle", new object[] {} );
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
                Logger.Exception(e, "FinishExplore", new object[] {} );
                return;
            }
            PostCommand("FinishExplore", new object[] {} );
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
                Logger.Exception(e, "MoveToExplorer", new object[] {(object)stage} );
                return;
            }
            PostCommand("MoveToExplorer", new object[] {(object)stage} );
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
                Logger.Exception(e, "PerkUpgrateRarity", new object[] {(object)unitId, (object)perkId} );
                return;
            }
            PostCommand("PerkUpgrateRarity", new object[] {(object)unitId, (object)perkId} );
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
                Logger.Exception(e, "PlayerLevelUp", new object[] {} );
                return;
            }
            PostCommand("PlayerLevelUp", new object[] {} );
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
                Logger.Exception(e, "RefreshAllDaily", new object[] {} );
                return;
            }
            PostCommand("RefreshAllDaily", new object[] {} );
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
                Logger.Exception(e, "RefreshAllShopGroups", new object[] {} );
                return;
            }
            PostCommand("RefreshAllShopGroups", new object[] {} );
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
                Logger.Exception(e, "RefreshDaily", new object[] {(object)stageId} );
                return;
            }
            PostCommand("RefreshDaily", new object[] {(object)stageId} );
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
                Logger.Exception(e, "RefreshGroup", new object[] {(object)groupId, (object)force} );
                return;
            }
            PostCommand("RefreshGroup", new object[] {(object)groupId, (object)force} );
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
                Logger.Exception(e, "RefreshStamina", new object[] {} );
                return;
            }
            PostCommand("RefreshStamina", new object[] {} );
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
                Logger.Exception(e, "RunCutSceneImpact", new object[] {(object)cutsceneId, (object)index} );
                return;
            }
            PostCommand("RunCutSceneImpact", new object[] {(object)cutsceneId, (object)index} );
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
                Logger.Exception(e, "SellItem", new object[] {(object)itemId, (object)count} );
                return;
            }
            PostCommand("SellItem", new object[] {(object)itemId, (object)count} );
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
                Logger.Exception(e, "SetActiveUnit", new object[] {(object)unitId, (object)slotId} );
                return;
            }
            PostCommand("SetActiveUnit", new object[] {(object)unitId, (object)slotId} );
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
                Logger.Exception(e, "SetBattleUnit", new object[] {(object)unitId, (object)slotId} );
                return;
            }
            PostCommand("SetBattleUnit", new object[] {(object)unitId, (object)slotId} );
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
                Logger.Exception(e, "SetCutScene", new object[] {(object)tutorialId, (object)(int)type, (object)block} );
                return;
            }
            PostCommand("SetCutScene", new object[] {(object)tutorialId, (object)(int)type, (object)block} );
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
                Logger.Exception(e, "SetHp", new object[] {(object)unitId, (object)hp} );
                return;
            }
            PostCommand("SetHp", new object[] {(object)unitId, (object)hp} );
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
                Logger.Exception(e, "SetItemValue", new object[] {(object)itemId, (object)value} );
                return;
            }
            PostCommand("SetItemValue", new object[] {(object)itemId, (object)value} );
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
                Logger.Exception(e, "SetLocale", new object[] {(object)locale} );
                return;
            }
            PostCommand("SetLocale", new object[] {(object)locale} );
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
                Logger.Exception(e, "SetNotificationStatus", new object[] {(object)status} );
                return;
            }
            PostCommand("SetNotificationStatus", new object[] {(object)status} );
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
                Logger.Exception(e, "SetPerkStars", new object[] {(object)unitId, (object)perkId, (object)value} );
                return;
            }
            PostCommand("SetPerkStars", new object[] {(object)unitId, (object)perkId, (object)value} );
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
                Logger.Exception(e, "SetReserveUnit", new object[] {(object)unitId} );
                return;
            }
            PostCommand("SetReserveUnit", new object[] {(object)unitId} );
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
                Logger.Exception(e, "SetRoom", new object[] {(object)roomId} );
                return;
            }
            PostCommand("SetRoom", new object[] {(object)roomId} );
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
                Logger.Exception(e, "SetScorerValue", new object[] {(object)scorerId, (object)value} );
                return;
            }
            PostCommand("SetScorerValue", new object[] {(object)scorerId, (object)value} );
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
                Logger.Exception(e, "SetServer", new object[] {(object)(int)type} );
                return;
            }
            PostCommand("SetServer", new object[] {(object)(int)type} );
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
                Logger.Exception(e, "SetSession", new object[] {(object)(int)type} );
                return;
            }
            PostCommand("SetSession", new object[] {(object)(int)type} );
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
                Logger.Exception(e, "SetSettingsMusicOff", new object[] {(object)value} );
                return;
            }
            PostCommand("SetSettingsMusicOff", new object[] {(object)value} );
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
                Logger.Exception(e, "SetSettingsSoundOff", new object[] {(object)value} );
                return;
            }
            PostCommand("SetSettingsSoundOff", new object[] {(object)value} );
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
                Logger.Exception(e, "SetStamina", new object[] {(object)value} );
                return;
            }
            PostCommand("SetStamina", new object[] {(object)value} );
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
                Logger.Exception(e, "SetTransactionProgress", new object[] {(object)id} );
                return;
            }
            PostCommand("SetTransactionProgress", new object[] {(object)id} );
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
                Logger.Exception(e, "SetUnitEquipment", new object[] {(object)unitId, (object)slot} );
                return;
            }
            PostCommand("SetUnitEquipment", new object[] {(object)unitId, (object)slot} );
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
                Logger.Exception(e, "SetUnitExplorer", new object[] {(object)unitId, (object)slotExplorer} );
                return;
            }
            PostCommand("SetUnitExplorer", new object[] {(object)unitId, (object)slotExplorer} );
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
                Logger.Exception(e, "StageAutowin", new object[] {(object)selectedStageId, (object)tryCount} );
                return;
            }
            PostCommand("StageAutowin", new object[] {(object)selectedStageId, (object)tryCount} );
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
                Logger.Exception(e, "StartBattle", new object[] {(object)position} );
                return;
            }
            PostCommand("StartBattle", new object[] {(object)position} );
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
                Logger.Exception(e, "StartExplorer", new object[] {(object)stage} );
                return;
            }
            PostCommand("StartExplorer", new object[] {(object)stage} );
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
                Logger.Exception(e, "StartSession", new object[] {} );
                return;
            }
            PostCommand("StartSession", new object[] {} );
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
                Logger.Exception(e, "UnitUpgrateAbility", new object[] {(object)unitId, (object)abilityId} );
                return;
            }
            PostCommand("UnitUpgrateAbility", new object[] {(object)unitId, (object)abilityId} );
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
                Logger.Exception(e, "UnitUpgrateLevel", new object[] {(object)unitId} );
                return;
            }
            PostCommand("UnitUpgrateLevel", new object[] {(object)unitId} );
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
                Logger.Exception(e, "UnitUpgrateRarity", new object[] {(object)unitId} );
                return;
            }
            PostCommand("UnitUpgrateRarity", new object[] {(object)unitId} );
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
                Logger.Exception(e, "UpdateBuilds", new object[] {} );
                return;
            }
            PostCommand("UpdateBuilds", new object[] {} );
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
                Logger.Exception(e, "UpdateDropItems", new object[] {} );
                return;
            }
            PostCommand("UpdateDropItems", new object[] {} );
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
                Logger.Exception(e, "UpdateGacha", new object[] {} );
                return;
            }
            PostCommand("UpdateGacha", new object[] {} );
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
                Logger.Exception(e, "UpdateTime", new object[] {(object)achievementId} );
                return;
            }
            PostCommand("UpdateTime", new object[] {(object)achievementId} );
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
                Logger.Exception(e, "UpgradeUnitEquipment", new object[] {(object)unitId} );
                return;
            }
            PostCommand("UpgradeUnitEquipment", new object[] {(object)unitId} );
        }

    }
}
