using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface ISettingsStatic
    {
        [SerializableId("pushes")]
        IReadOnlyDictionary<int, IPush> Pushes { get; }

        [SerializableId("ui")]
        IReadOnlyDictionary<int, IUI> UiElements { get; }

        [SerializableId("emoji")]
        IReadOnlyDictionary<int, IEmoji> Emojies { get; }

        [SerializableId("buildings")]
        IReadOnlyDictionary<int, IBuilding> Buildings { get; }

        [SerializableId("ui_text")]
        IReadOnlyDictionary<int, IUIText> Texts { get; }

        [SerializableId("ui_locale")]
        IReadOnlyDictionary<int, ILocale> Locales { get; }

        [SerializableId("ui_windows")]
        IReadOnlyDictionary<int, IUIWindow> Windows { get; }

        [SerializableId("abl_action_info_types")]
        IReadOnlyDictionary<int, IAbilityActionInfo> AbilityActionInfo {get;}

        [SerializableId("settings")]
        IGameSettings GameSettings { get; }

        [SerializableId("player_settings")]
        IPlayerSettings PlayerSettings { get; }

        [SerializableId("embed_impacts")]
        IReadOnlyDictionary<int, IImpact> Impacts { get; }

        [SerializableId("builds")]
        IReadOnlyDictionary<int, IBuild> Builds { get; }
    }

    public interface IGameSettings
    {
        [SerializableId("ticker")]
        IImpact Ticker { get; }

        [SerializableId("android_client_version_min")]
        string AndroidClientVersion { get; }

        [SerializableId("android_client_version_current")]
        string AndroidClientVersionCurrent { get; }

        [SerializableId("default_lang")]
        string Languge { get; }

        [SerializableId("finish_battle_timeout")]
        int FinishBattleTimeout { get; }

        [SerializableId("timeout_user_save_success")]
        int TimeoutUserSaveSuccess { get; }

        [SerializableId("timeout_user_save_fail")]
        int TimeoutUserSaveFail { get; }

        [SerializableId("anim_special_min")]
        int AnimSpecialMin { get; }

        [SerializableId("anim_special_max")]
        int AnimSpecialMax { get; }

        [SerializableId("anim_run_speed")]
        int AnimRunSpeed { get; }

        [SerializableId("battle_zoom")]
        float BattleZoom { get; }

        [SerializableId("motion_screen_board")]
        float MotionScreenBoard { get; }

        [SerializableId("swipe_threshold")]
        float SwipeThreshold { get; }

        [SerializableId("time_for_change_snap_point")]
        float TimeForChangeSnapPoint { get; }

        [SerializableId("zoom_time")]
        float ZoomTime { get; }

        [SerializableId("zoom_step_time")]
        float ZoomStepTime { get; }

        [SerializableId("zoom_shift_transition")]
        float ZoomShiftTransition { get; }

        [SerializableId("bubble_show_time")]
        float BubbleShowTime { get; }

        [SerializableId("long_touch_time")]
        float LongTouchTime { get; }

        [SerializableId("wait_hide_familiar")]
        float WaitHideFamiliar { get; }

        [SerializableId("wait_time_when_mob_cant_move")]
        float WaitTimeWhenMobCantMove { get; }
        
        [SerializableId("wait_time_before_mob_move")]
        float WaitTimeBeforeMobMove { get; }

        [SerializableId("wait_time_autoreceive_drop")]
        float WaitTimeAutoreceiveDrop { get; }

        [SerializableId("wait_time_purchase_check_repeat")]
        float WaitTimePurchaseCheckRepeat { get; }

        [SerializableId("wait_getting_hit_digits")]
        float WaitGettingHitDigits { get; }
    }

    public interface IPlayerSettings
    {
        [SerializableId("daily_task_level")]
        float DailyTaskLevel { get; }

        [SerializableId("hp_crit")]
        float HpCrit { get; }

        [SerializableId("mana_ui_max")]
        float ManaUIMax { get; }

        [SerializableId("exp_max")]
        int ExpMax { get; }

        [SerializableId("unit_max")]
        int UnitMax { get; }

        [SerializableId("inventory_max")]
        int InventoryMax { get; }

        [SerializableId("mana_max")]
        int ManaMax { get; }

        [SerializableId("resources_head")]
        IReadOnlyDictionary<int, int> ResourcesHead { get; }

        [SerializableId("reserve_cost")]
        int ReserveCost { get; }

        [SerializableId("escape_cost")]
        int EscapeCost { get; }

        [SerializableId("unit_duplicate_cost")]
        int UnitDuplicateCost { get; }

        [SerializableId("shards_currency")]
        int ShardsCurrency { get; }

        [SerializableId("hp_segments")]
        IReadOnlyDictionary<int, IHpSegment> HpSegments { get; }

        [SerializableId("stage_refresh_cost")]
        IReadOnlyDictionary<int, IChangePrice> StageRefreshCost { get; }
        
        [SerializableId("stage_daily_number")]
        int StageDailyNumber { get; }

        [SerializableId("explore_stamina_cost")]
        IReadOnlyDictionary<int, IChangePrice> ExploreRefreshCost { get; }

        [SerializableId("explore_buy_stamina")]
        int BuyStamina { get; }

        [SerializableId("money_type_segments")]
        IReadOnlyDictionary<int, IMoneySegment> MoneySegments { get; }
    }

    public interface IHpSegment
    {
        [SerializableId("segments")]
        int Segments { get; }

        [SerializableId("Hp")]
        int Hp { get; }
    }

    public interface IMoneySegment
    {
        [SerializableId("icon")]
        int Icon { get; }

        [SerializableId("min_value")]
        int MinValue { get; }
    }
}
