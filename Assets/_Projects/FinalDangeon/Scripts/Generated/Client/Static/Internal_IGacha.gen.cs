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
    internal class Internal_IGacha : IGacha 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
            _BonusQuantity?.PostSerialize();
            _EndTime?.PostSerialize();
            _Visibility?.PostSerialize();
            _StartFreeTime?.PostSerialize();
            ROD_Items = _Items != null ? _Items.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGachaItem;
            }
            ) : null;
            ROD_Prices1 = _Prices1 != null ? _Prices1.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUniversalPrice;
            }
            ) : null;
            ROD_Prices10 = _Prices10 != null ? _Prices10.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUniversalPrice;
            }
            ) : null;
            ROD_Resources = _Resources != null ? _Resources.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public String UnityId => _UnityId;

        public Boolean DefaultView => _DefaultView;

        public IImpact Impact => _Impact;

        public GachaType GachaType => _GachaType;

        public Int32 BonusUnitId => _BonusUnitId;

        public IFormula BonusQuantity => _BonusQuantity;

        public IFormula EndTime => _EndTime;

        public ICondition Visibility => _Visibility;

        public IFormula StartFreeTime => _StartFreeTime;

        public  IReadOnlyDictionary<Int32, IGachaItem> Items => ROD_Items;

        public Boolean IsPromo => _IsPromo;

        public  IReadOnlyDictionary<Int32, IUniversalPrice> Prices1 => ROD_Prices1;

        public  IReadOnlyDictionary<Int32, IUniversalPrice> Prices10 => ROD_Prices10;

        public  IReadOnlyDictionary<Int32, Int32> Resources => ROD_Resources;


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
        [JsonName("default_item")]
        public Boolean _DefaultView;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("type")]
        public GachaType _GachaType;
        [JsonName("bonus_unit_id")]
        public Int32 _BonusUnitId;
        [JsonName("bonus_quantity")]
        public Internal_IFormula _BonusQuantity;
        [JsonName("end_time")]
        public Internal_IFormula _EndTime;
        [JsonName("availability")]
        public Internal_ICondition _Visibility;
        [JsonName("start_free_time")]
        public Internal_IFormula _StartFreeTime;
        [JsonName("items")]
        public Dictionary<String, Internal_IGachaItem> _Items;
        private Dictionary<Int32, IGachaItem> ROD_Items;
        [JsonName("promo")]
        public Boolean _IsPromo;
        [JsonName("prices1")]
        public Dictionary<String, Internal_IUniversalPrice> _Prices1;
        private Dictionary<Int32, IUniversalPrice> ROD_Prices1;
        [JsonName("prices10")]
        public Dictionary<String, Internal_IUniversalPrice> _Prices10;
        private Dictionary<Int32, IUniversalPrice> ROD_Prices10;
        [JsonName("resources")]
        public Dictionary<String, Int32> _Resources;
        private Dictionary<Int32, Int32> ROD_Resources;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
