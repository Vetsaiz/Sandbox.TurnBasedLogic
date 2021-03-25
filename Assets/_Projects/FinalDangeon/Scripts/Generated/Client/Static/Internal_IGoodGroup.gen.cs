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
    internal class Internal_IGoodGroup : IGoodGroup 
    {
        public void PostSerialize()
        {
            ROD_Slots = _Slots != null ? _Slots.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IGoodGroupSlot;
            }
            ) : null;
            ROD_RechargePrices = _RechargePrices != null ? _RechargePrices.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IChangePrice;
            }
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String UnityId => _UnityId;

        public Int32 Period => _Period;

        public Boolean WideSlots => _WideSlots;

        public  IReadOnlyDictionary<Int32, IGoodGroupSlot> Slots => ROD_Slots;

        public  IReadOnlyDictionary<Int32, IChangePrice> RechargePrices => ROD_RechargePrices;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("period")]
        public Int32 _Period;
        [JsonName("wide_slots")]
        public Boolean _WideSlots;
        [JsonName("slots")]
        public Dictionary<String, Internal_IGoodGroupSlot> _Slots;
        private Dictionary<Int32, IGoodGroupSlot> ROD_Slots;
        [JsonName("recharge_prices")]
        public Dictionary<String, Internal_IChangePrice> _RechargePrices;
        private Dictionary<Int32, IChangePrice> ROD_RechargePrices;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
