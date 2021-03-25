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
    internal class Internal_IGood : IGood 
    {
        public void PostSerialize()
        {
            ROD_Price = _Price != null ? _Price.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPrice;
            }
            ) : null;
            _EndTime?.PostSerialize();
            _Quantity?.PostSerialize();
            _Impact?.PostSerialize();
            _Visibility?.PostSerialize();
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

        public  IReadOnlyDictionary<Int32, IPrice> Price => ROD_Price;

        public Int32 RealPrice => _RealPrice;

        public IFormula EndTime => _EndTime;

        public IFormula Quantity => _Quantity;

        public IImpact Impact => _Impact;

        public ICondition Visibility => _Visibility;

        public  IReadOnlyDictionary<Int32, IDropItem> Items => ROD_Items;

        public GoodLabelType GoodType => _GoodType;


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
        [JsonName("price")]
        public Dictionary<String, Internal_IPrice> _Price;
        private Dictionary<Int32, IPrice> ROD_Price;
        [JsonName("price_real")]
        public Int32 _RealPrice;
        [JsonName("end_time")]
        public Internal_IFormula _EndTime;
        [JsonName("quantity")]
        public Internal_IFormula _Quantity;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("visibility")]
        public Internal_ICondition _Visibility;
        [JsonName("items")]
        public Dictionary<String, Internal_IDropItem> _Items;
        private Dictionary<Int32, IDropItem> ROD_Items;
        [JsonName("badge")]
        public GoodLabelType _GoodType;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
