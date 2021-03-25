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
    internal class Internal_IAbility : IAbility 
    {
        public void PostSerialize()
        {
            _Activation?.PostSerialize();
            _Impact?.PostSerialize();
            _Mana?.PostSerialize();
            ROD_Influence = _Influence != null ? _Influence.ToDictionary(
            x => Int32.Parse(x.Key),
            y => y.Value
            ) : null;
            _Params?.PostSerialize();
            ROD_Actions = _Actions != null ? _Actions.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IAbilityAction;
            }
            ) : null;
            _Actable?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public String UnityId => _UnityId;

        public IActivationEvent Activation => _Activation;

        public IImpact Impact => _Impact;

        public IFormula Mana => _Mana;

        public Int32 LimitBattle => _LimitBattle;

        public Int32 LimitTurn => _LimitTurn;

        public  IReadOnlyDictionary<Int32, InfluenceType> Influence => ROD_Influence;

        public IAbilityParam Params => _Params;

        public  IReadOnlyDictionary<Int32, IAbilityAction> Actions => ROD_Actions;

        public Boolean IsHidden => _IsHidden;

        public Boolean HasFamiliar => _HasFamiliar;

        public Boolean LockFamiliar => _LockFamiliar;

        public ICondition Actable => _Actable;

        public Boolean HideBar => _HideBar;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("activation")]
        public Internal_IActivationEvent _Activation;
        [JsonName("impact_unit")]
        public Internal_IImpact _Impact;
        [JsonName("mana")]
        public Internal_IFormula _Mana;
        [JsonName("limit_battle")]
        public Int32 _LimitBattle;
        [JsonName("limit_turn")]
        public Int32 _LimitTurn;
        [JsonName("influence_type")]
        public Dictionary<String, InfluenceType> _Influence;
        private Dictionary<Int32, InfluenceType> ROD_Influence;
        [JsonName("params")]
        public Internal_IAbilityParam _Params;
        [JsonName("action_info")]
        public Dictionary<String, Internal_IAbilityAction> _Actions;
        private Dictionary<Int32, IAbilityAction> ROD_Actions;
        [JsonName("hidden")]
        public Boolean _IsHidden;
        [JsonName("has_familiar")]
        public Boolean _HasFamiliar;
        [JsonName("lock_familiar")]
        public Boolean _LockFamiliar;
        [JsonName("actable")]
        public Internal_ICondition _Actable;
        [JsonName("hide_bar")]
        public Boolean _HideBar;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
