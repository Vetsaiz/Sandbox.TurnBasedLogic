using System;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;

namespace MetaLogic.Logic.AdditionalLogic
{
    public class LogicLog
    {
        private static LogAccessor _inst;
        private static SettingsAccessor _settings;

        public static bool IsClear;

        internal static void SetAccessor(LogAccessor inst, SettingsAccessor settings)
        {
            _inst = inst;
            _settings = settings;
        }

        public static void SetSession(LogSessionType type)
        {
            _inst.AddLog(Create(UserLogType.LogSession, new Dictionary<string, object>
            {
                {"type", (int)type}
            }));
        }

        public static void SetTutorial(int tutorialId, LogTutorialType type, int block)
        {
            _inst.AddLog(Create(UserLogType.LogTutorial, new Dictionary<string, object>
            {
                {"type", (int)type},
                {"cutscene_id", tutorialId},
                {"block", block}
            }));
        }

        #region CoreGame

        public static void SetBattle(LogBattleType type, int interactiveObject, int roomId, int stageId)
        {
            _inst.AddLog(Create(UserLogType.LogBattle, new Dictionary<string, object>
            {
                {"type", (int)type},
                {"room_id", roomId },
                {"stage_id", stageId },
                {"interactive_object_id", interactiveObject}
            }));
        }

        public static void SetExplorer(int stateId, LogExplorerType type)
        {
            _inst.AddLog(Create(UserLogType.LogEndExplore, new Dictionary<string, object>
            {
                {"type", (int)type},
                {"stage_id", stateId}
            }));
        }

        public static void DeathUnit(int unitId)
        {
            _inst.AddLog(Create(UserLogType.LogUnitDeath, new Dictionary<string, object>
            {
                {"unit_id", unitId}
            }));
        }


        public static void MobDeath(int mobId, int wave, int position)
        {
            _inst.AddLog(Create(UserLogType.LogMobDeath, new Dictionary<string, object>
            {
                {"mob_id", mobId},
                {"wave", wave},
                {"position", position},
            }));
        }

        public static void ExecuteAbility(int perkId)
        {
            _inst.AddLog(Create(UserLogType.LogAbilities, new Dictionary<string, object>
            {
                {"ability_id", perkId},
            }));
        }

        public static void ChangePerkCharge(int perkId, int value)
        {
            _inst.AddLog(Create(UserLogType.LogPerk, new Dictionary<string, object>
            {
                {"perk_id", perkId},
                {"value", value},
            }));
        }

        public static void ChangeReserve(int fromUnitId, int toUnitId, bool battle)
        {
            _inst.AddLog(Create(UserLogType.LogReseive, new Dictionary<string, object>
            {
                {"from_unit_id", fromUnitId},
                {"to_unit_id", toUnitId},
                {"value", battle},
            }));
        }

        #endregion

        public static void UpdatePlayerLevel(int level, int exp)
        {
            _inst.AddLog(Create(UserLogType.LogUserLevel, new Dictionary<string, object>
            {
                {"level", level},
                {"exp", exp }
            }));
        }

        public static void StageAccess(int stateId, AccessType dataAccess)
        {
            _inst.AddLog(Create(UserLogType.LogStageAccess, new Dictionary<string, object>
            {
                {"stage_id", stateId},
                {"access",  (int)dataAccess}
            }));
        }

        public static void Activate(int objectId, int activationId)
        {
            _inst.AddLog(Create(UserLogType.LogIntObject, new Dictionary<string, object>
            {
                {"activation_id", activationId},
                {"int_object_id", objectId},
            }));
        }

        public static void SetEquip(int unitId, int itemId, int slot, int equipmentLevel)
        {
            _inst.AddLog(Create(UserLogType.LogEquip, new Dictionary<string, object>
            {
                {"item_id", itemId},
                {"slot", slot},
                {"unit_id", unitId},
                {"equipment_level", equipmentLevel},
            }));
        }

        public static void ChangeItemValue(int itemId, int value)
        {
            _inst.AddLog(Create(UserLogType.LogItems, new Dictionary<string, object>
            {
                {"item_id", itemId},
                {"value", value},
            }));
        }

        public static void AddUnitShard(int userId, int value)
        {
            _inst.AddLog(Create(UserLogType.LogShards, new Dictionary<string, object>
            {
                {"unit_id", userId},
                {"value", value}
            }));
        }

        public static void UpdateUnitLevel(int userId, int level, int exp)
        {
            _inst.AddLog(Create(UserLogType.LogUnitLevel, new Dictionary<string, object>
            {
                {"unit_id", userId},
                {"level", level},
                {"exp", exp }
            }));
        }

        public static void UnlockFamiliar(int unitId)
        {
            _inst.AddLog(Create(UserLogType.LogFamiliarUnlock, new Dictionary<string, object>
            {
                {"unit_id", unitId},
            }));
        }

        public static void UpgradePerkLevel(int unitId, int perkId, int stars)
        {
            _inst.AddLog(Create(UserLogType.LogPerkUp, new Dictionary<string, object>
            {
                {"perk_id", perkId},
                {"stars", stars},
                {"unit_id", unitId},
            }));
        }

        public static void UpgradeRarityUnit(int unitId, int stars)
        {
            _inst.AddLog(Create(UserLogType.LogUnitStarsUp, new Dictionary<string, object>
            {
                {"stars", stars},
                {"unit_id", unitId},
            }));
        }

        public static void UpgradeAbilityLevel(int unitId, int abilityId, int level)
        {
            _inst.AddLog(Create(UserLogType.LogAbilityUp, new Dictionary<string, object>
            {
                {"ability_id", abilityId},
                {"level",  level},
                {"unit_id", unitId},
            }));
        }

        public static void UpgradeEquipRarity(int unitId, int level)
        {
            _inst.AddLog(Create(UserLogType.LogEquipmentUp, new Dictionary<string, object>
            {
                {"equipment_level", level},
                {"unit_id", unitId},
            }));
        }

        public static void UnitAdd(int unitId, bool assist)
        {
            _inst.AddLog(Create(UserLogType.LogUnitAdd, new Dictionary<string, object>
            {
                {"assist", assist},
                {"unit_id", unitId},
            }));
        }

        public static void SoundSettings(bool sound, bool music)
        {
            _inst.AddLog(Create(UserLogType.LogSoundSettings, new Dictionary<string, object>
            {
                {"sound", sound},
                {"music", music},
            }));
        }

        public static void ChangeScorer(int parameter, OperationType operatorType, long value, int stageId)
        {
            var dict = new Dictionary<string, object>
            {
                {"parameter", parameter},
                {"operator", (int) operatorType},
                {"value", value},
            };
            if (stageId > 0)
            {
                dict.Add("stage_id", stageId);
            }
            _inst.AddLog(Create(UserLogType.LogChangeData, dict));
        }

        public static void AssistUnsummon(int unitId)
        {
            _inst.AddLog(Create(UserLogType.LogAssistUnsummon, new Dictionary<string, object>
            {
                {"unit_id", unitId}
            }));
        }

        public static void Warn(int unitId)
        {
            _inst.AddLog(Create(UserLogType.LogWarn, new Dictionary<string, object>
            {
                {"unit_id", unitId}
            }));
        }

        public static void ExploreRenew(int stageId, int tryNumber)
        {
            _inst.AddLog(Create(UserLogType.LogExploreRenew, new Dictionary<string, object>
            {
                {"stage_id", stageId},
                {"try", tryNumber},
            }));
        }

        public static void Gacha(int gachaId, int num)
        {
            _inst.AddLog(Create(UserLogType.LogGacha, new Dictionary<string, object>
            {
                {"gacha_id", gachaId},
                {"num", num},
            }));
        }


        public static void BuyGood(int goodId)
        {
            _inst.AddLog(Create(UserLogType.LogBuyGood, new Dictionary<string, object>
            {
                {"good_id", goodId},
            }));
        }


        public static void BuyOffer(int offerId)
        {
            _inst.AddLog(Create(UserLogType.LogBuyOffer, new Dictionary<string, object>
            {
                {"offer_id", offerId},
            }));
        }


        public static void ChangeMoneyType(int moneyTypeId, OperationType operatorType, int value)
        {
            _inst.AddLog(Create(UserLogType.LogChangeMoneyType, new Dictionary<string, object>
            {
                {"operator", (int)operatorType},
                {"money_type_id", moneyTypeId},
                {"value", value},
            }));
        }

        public static void Event(int eventId, int value)
        {
            _inst.AddLog(Create(UserLogType.LogEvent, new Dictionary<string, object>
            {
                {"event_id", eventId},
                {"event_value", value},
            }));
        }

        public static void CompleteAchievement(int achievementId)
        {
            _inst.AddLog(Create(UserLogType.LogAchievement, new Dictionary<string, object>
            {
                {"achievement_id", achievementId}
            }));
        }

        private static LogData Create(UserLogType template, Dictionary<string, object> param)
        {
            param.Add("template_id", (int)template);
            
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return new LogData
            {
                Time = time,
                Params = param
            };
        }
    }
}
