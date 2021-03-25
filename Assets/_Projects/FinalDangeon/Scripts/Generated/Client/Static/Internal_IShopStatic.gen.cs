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
    internal class Internal_IShopStatic : IShopStatic 
    {
        public void PostSerialize()
        {
            ROD_Goods = _Goods != null ? _Goods.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGood;
            }
            ) : null;
            ROD_GoodGroups = _GoodGroups != null ? _GoodGroups.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGoodGroup;
            }
            ) : null;
            ROD_RealPrices = _RealPrices != null ? _RealPrices.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IRealPrice;
            }
            ) : null;
            ROD_Offers = _Offers != null ? _Offers.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IOffer;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IGood> Goods => ROD_Goods;

        public  IReadOnlyDictionary<Int32, IGoodGroup> GoodGroups => ROD_GoodGroups;

        public  IReadOnlyDictionary<Int32, IRealPrice> RealPrices => ROD_RealPrices;

        public  IReadOnlyDictionary<Int32, IOffer> Offers => ROD_Offers;


        #endregion

        #region Internal

        [JsonName("goods")]
        public Dictionary<String, Internal_IGood> _Goods;
        private Dictionary<Int32, IGood> ROD_Goods;
        [JsonName("good_groups")]
        public Dictionary<String, Internal_IGoodGroup> _GoodGroups;
        private Dictionary<Int32, IGoodGroup> ROD_GoodGroups;
        [JsonName("real_prices")]
        public Dictionary<String, Internal_IRealPrice> _RealPrices;
        private Dictionary<Int32, IRealPrice> ROD_RealPrices;
        [JsonName("offers")]
        public Dictionary<String, Internal_IOffer> _Offers;
        private Dictionary<Int32, IOffer> ROD_Offers;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
