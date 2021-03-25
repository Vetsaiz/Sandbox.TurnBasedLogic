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
    internal class Internal_IAchievement : IAchievement 
    {
        public void PostSerialize()
        {
            _Avaibility?.PostSerialize();
            _Time?.PostSerialize();
            _Value?.PostSerialize();
            _Impact?.PostSerialize();
            ROD_Items = _Items != null ? _Items.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IDropItem;
            }
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String UnityId => _UnityId;

        public String Description => _Description;

        public ICondition Avaibility => _Avaibility;

        public AchievementType Type => _Type;

        public IFormula Time => _Time;

        public IFormula Value => _Value;

        public Int32 ScorerId => _ScorerId;

        public IImpact Impact => _Impact;

        public  IReadOnlyDictionary<Int32, IDropItem> Items => ROD_Items;

        public String WindowId => _WindowId;

        public Int32 NotificationPrepare => _NotificationPrepare;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("description")]
        public String _Description;
        [JsonName("availibility")]
        public Internal_ICondition _Avaibility;
        [JsonName("type")]
        public AchievementType _Type;
        [JsonName("end_time")]
        public Internal_IFormula _Time;
        [JsonName("scorer_limit")]
        public Internal_IFormula _Value;
        [JsonName("scorer_id")]
        public Int32 _ScorerId;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("items")]
        public Dictionary<String, Internal_IDropItem> _Items;
        private Dictionary<Int32, IDropItem> ROD_Items;
        [JsonName("window_id")]
        public String _WindowId;
        [JsonName("notif_prepare")]
        public Int32 _NotificationPrepare;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
