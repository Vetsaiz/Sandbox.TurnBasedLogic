using System;

namespace MetaLogic.Data
{
    public class HardCodeIds
    {
        public const string Stamina = "stamina";
        public const string Mana = "mana";
        public const string CurrentStage = "plot_stage";
        public const string TutorialZone = "zone_Temples";
        public const string EndBattleLabel = "battle_popup_quit_title";
        public const string EndBattleLabelTitle = "battle_popup_quit_text";
        public const string ExpIcon = "exp_icon";

        public const string SpecialGoalEndtime = "special_goal_endtime";
        public const string SpecialGoalComplete = "special_goal_complete";
        //public const string SpecialGoalActive = "special_goal_active";

        public const string TimeMinSec = "timeout_m_s";
        public const string TimeHourMin = "timeout_h_m";
        public const string TimeDayHourMin = "timeout_d_h_m";

        public const int EmptyEmoji = 0;
        public const int BattleAssistSlot = 4;
        public const int MaxBattleSlots = 4;

        public static string[] ScorerStars = {
            "goal",
            "star_1_goal",
            "star_2_goal",
            "star_3_goal"
        };

        public const string PurchaseTitle = "info_wait_purchase_title";
        public const string PurchaseDesc = "info_wait_purchase_desc";

        public const string PushRequestTitle = "info_wait_push_title";
        public const string PushRequestDesc = "info_wait_push_desc";

        public const string AutoWinWarningTitle = "info_lock_autowin_title";
        public const string AutoWinWarningDesc = "info_lock_autowin_desc";

        public static string GetTextId(AbilityType type)
        {
            switch (type)
            {
                //case AbilityType.BaseAttack:
                //    return "profile_popup_ability_base_attack";
                //case AbilityType.UpgradeAttack:
                //    return "profile_popup_ability_ulta_attack";
                //case AbilityType.Ultimate:
                //    return "profile_popup_ability_ulta_attack";
                case AbilityType.Passive:
                    return "profile_popup_ability_passive_attack";
                default:
                    return "profile_popup_ability_title";
            }
        }

        public static UpgradeType GetAbilityType(AbilityType type)
        {
            switch (type)
            {
                case AbilityType.BaseAttack:
                    return UpgradeType.AbilityAttackLevel;
                case AbilityType.UpgradeAttack:
                    return UpgradeType.AbilitySpecLevel;
                case AbilityType.Ultimate:
                    return UpgradeType.AbilityUltLevel;
                case AbilityType.Passive:
                    return UpgradeType.AbilityAttackLevel;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
