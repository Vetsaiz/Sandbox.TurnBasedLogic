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
    internal class Internal_IInventoryStatic : IInventoryStatic 
    {
        public void PostSerialize()
        {
            ROD_Items = _Items != null ? _Items.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IInventoryItem;
            }
            ) : null;
            ROD_GachaItems = _GachaItems != null ? _GachaItems.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGacha;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IInventoryItem> Items => ROD_Items;

        public  IReadOnlyDictionary<Int32, IGacha> GachaItems => ROD_GachaItems;


        #endregion

        #region Internal

        [JsonName("items")]
        public Dictionary<String, Internal_IInventoryItem> _Items;
        private Dictionary<Int32, IInventoryItem> ROD_Items;
        [JsonName("gacha")]
        public Dictionary<String, Internal_IGacha> _GachaItems;
        private Dictionary<Int32, IGacha> ROD_GachaItems;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
