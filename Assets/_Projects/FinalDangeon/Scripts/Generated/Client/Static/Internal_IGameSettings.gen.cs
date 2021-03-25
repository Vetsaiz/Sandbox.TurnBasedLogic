using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IGameSettings : IGameSettings 
    {
        public void PostSerialize()
        {
            _Ticker?.PostSerialize();
        }

        #region Interface

        public IImpact Ticker => _Ticker;

        public String AndroidClientVersion => _AndroidClientVersion;

        public String AndroidClientVersionCurrent => _AndroidClientVersionCurrent;

        public String Languge => _Languge;

        public Int32 FinishBattleTimeout => _FinishBattleTimeout;

        public Int32 TimeoutUserSaveSuccess => _TimeoutUserSaveSuccess;

        public Int32 TimeoutUserSaveFail => _TimeoutUserSaveFail;

        public Int32 AnimSpecialMin => _AnimSpecialMin;

        public Int32 AnimSpecialMax => _AnimSpecialMax;

        public Int32 AnimRunSpeed => _AnimRunSpeed;

        public Single BattleZoom => _BattleZoom;

        public Single MotionScreenBoard => _MotionScreenBoard;

        public Single SwipeThreshold => _SwipeThreshold;

        public Single TimeForChangeSnapPoint => _TimeForChangeSnapPoint;

        public Single ZoomTime => _ZoomTime;

        public Single ZoomStepTime => _ZoomStepTime;

        public Single ZoomShiftTransition => _ZoomShiftTransition;

        public Single BubbleShowTime => _BubbleShowTime;

        public Single LongTouchTime => _LongTouchTime;

        public Single WaitHideFamiliar => _WaitHideFamiliar;

        public Single WaitTimeWhenMobCantMove => _WaitTimeWhenMobCantMove;

        public Single WaitTimeBeforeMobMove => _WaitTimeBeforeMobMove;

        public Single WaitTimeAutoreceiveDrop => _WaitTimeAutoreceiveDrop;

        public Single WaitTimePurchaseCheckRepeat => _WaitTimePurchaseCheckRepeat;

        public Single WaitGettingHitDigits => _WaitGettingHitDigits;


        #endregion

        #region Internal

        [JsonName("ticker")]
        public Internal_IImpact _Ticker;
        [JsonName("android_client_version_min")]
        public String _AndroidClientVersion;
        [JsonName("android_client_version_current")]
        public String _AndroidClientVersionCurrent;
        [JsonName("default_lang")]
        public String _Languge;
        [JsonName("finish_battle_timeout")]
        public Int32 _FinishBattleTimeout;
        [JsonName("timeout_user_save_success")]
        public Int32 _TimeoutUserSaveSuccess;
        [JsonName("timeout_user_save_fail")]
        public Int32 _TimeoutUserSaveFail;
        [JsonName("anim_special_min")]
        public Int32 _AnimSpecialMin;
        [JsonName("anim_special_max")]
        public Int32 _AnimSpecialMax;
        [JsonName("anim_run_speed")]
        public Int32 _AnimRunSpeed;
        [JsonName("battle_zoom")]
        public Single _BattleZoom;
        [JsonName("motion_screen_board")]
        public Single _MotionScreenBoard;
        [JsonName("swipe_threshold")]
        public Single _SwipeThreshold;
        [JsonName("time_for_change_snap_point")]
        public Single _TimeForChangeSnapPoint;
        [JsonName("zoom_time")]
        public Single _ZoomTime;
        [JsonName("zoom_step_time")]
        public Single _ZoomStepTime;
        [JsonName("zoom_shift_transition")]
        public Single _ZoomShiftTransition;
        [JsonName("bubble_show_time")]
        public Single _BubbleShowTime;
        [JsonName("long_touch_time")]
        public Single _LongTouchTime;
        [JsonName("wait_hide_familiar")]
        public Single _WaitHideFamiliar;
        [JsonName("wait_time_when_mob_cant_move")]
        public Single _WaitTimeWhenMobCantMove;
        [JsonName("wait_time_before_mob_move")]
        public Single _WaitTimeBeforeMobMove;
        [JsonName("wait_time_autoreceive_drop")]
        public Single _WaitTimeAutoreceiveDrop;
        [JsonName("wait_time_purchase_check_repeat")]
        public Single _WaitTimePurchaseCheckRepeat;
        [JsonName("wait_getting_hit_digits")]
        public Single _WaitGettingHitDigits;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
