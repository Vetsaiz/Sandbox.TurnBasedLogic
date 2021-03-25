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
    internal class Internal_IGoodGroupSlot : IGoodGroupSlot 
    {
        public void PostSerialize()
        {
            ROD_Goods = _Goods != null ? _Goods.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGoodGroupElement;
            }
            ) : null;
        }

        #region Interface

        public Int32 Slot => _Slot;

        public  IReadOnlyDictionary<Int32, IGoodGroupElement> Goods => ROD_Goods;


        #endregion

        #region Internal

        [JsonName("slot")]
        public Int32 _Slot;
        [JsonName("elements")]
        public Dictionary<String, Internal_IGoodGroupElement> _Goods;
        private Dictionary<Int32, IGoodGroupElement> ROD_Goods;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
