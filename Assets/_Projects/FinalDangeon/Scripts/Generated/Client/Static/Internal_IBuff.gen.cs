using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IBuff : IBuff 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
            _ImpactTakeOff?.PostSerialize();
            ROD_Mods = _Mods != null ? _Mods.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBuffModifier;
            }
            ) : null;
            ROD_FxStatuses = _FxStatuses != null ? _FxStatuses.ToDictionary(
            x => Int32.Parse(x.Key),
            y => y.Value
            ) : null;
            ROD_BuffType = _BuffType != null ? _BuffType.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            _Condition?.PostSerialize();
            _ImpactInit?.PostSerialize();
            _ImpactDie?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public Boolean Indelible => _Indelible;

        public Int32 LimitCharges => _LimitCharges;

        public IImpact Impact => _Impact;

        public IImpact ImpactTakeOff => _ImpactTakeOff;

        public  IReadOnlyDictionary<Int32, IBuffModifier> Mods => ROD_Mods;

        public Int32 WithdrawTurn => _WithdrawTurn;

        public Int32 WithdrawDeath => _WithdrawDeath;

        public Int32 WithdrawFinish => _WithdrawFinish;

        public String Title => _Title;

        public String Description => _Description;

        public String UnityId => _UnityId;

        public  IReadOnlyDictionary<Int32, FxStatusType> FxStatuses => ROD_FxStatuses;

        public  IReadOnlyDictionary<Int32, Int32> BuffType => ROD_BuffType;

        public ICondition Condition => _Condition;

        public Boolean Hidden => _Hidden;

        public Boolean AnimLoop => _AnimLoop;

        public Boolean HiddenNumber => _HiddenNumber;

        public InfluenceBuffType Influence => _Influence;

        public IImpact ImpactInit => _ImpactInit;

        public IImpact ImpactDie => _ImpactDie;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("indelible")]
        public Boolean _Indelible;
        [JsonName("limit_charges")]
        public Int32 _LimitCharges;
        [JsonName("impact_unit")]
        public Internal_IImpact _Impact;
        [JsonName("impact_takeoff")]
        public Internal_IImpact _ImpactTakeOff;
        [JsonName("mods")]
        public Dictionary<String, Internal_IBuffModifier> _Mods;
        private Dictionary<Int32, IBuffModifier> ROD_Mods;
        [JsonName("withdraw_turn")]
        public Int32 _WithdrawTurn;
        [JsonName("withdraw_death")]
        public Int32 _WithdrawDeath;
        [JsonName("withdraw_finish")]
        public Int32 _WithdrawFinish;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("unity_fx_status")]
        public Dictionary<String, FxStatusType> _FxStatuses;
        private Dictionary<Int32, FxStatusType> ROD_FxStatuses;
        [JsonName("buff_type_id")]
        public Dictionary<String, Int32> _BuffType;
        private Dictionary<Int32, Int32> ROD_BuffType;
        [JsonName("cond_buff")]
        public Internal_ICondition _Condition;
        [JsonName("hidden")]
        public Boolean _Hidden;
        [JsonName("anim_loop")]
        public Boolean _AnimLoop;
        [JsonName("hidden_number")]
        public Boolean _HiddenNumber;
        [JsonName("influence_type")]
        public InfluenceBuffType _Influence;
        [JsonName("impact_init")]
        public Internal_IImpact _ImpactInit;
        [JsonName("impact_die")]
        public Internal_IImpact _ImpactDie;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
