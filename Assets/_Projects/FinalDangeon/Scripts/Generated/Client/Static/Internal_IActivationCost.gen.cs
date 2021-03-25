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
    internal class Internal_IActivationCost : IActivationCost 
    {
        public void PostSerialize()
        {
            _ItemCount?.PostSerialize();
            _Stamina?.PostSerialize();
            ROD_Prices = _Prices != null ? _Prices.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPrice;
            }
            ) : null;
        }

        #region Interface

        public String BtnTitle => _BtnTitle;

        public Int32 ItemId => _ItemId;

        public IFormula ItemCount => _ItemCount;

        public IFormula Stamina => _Stamina;

        public  IReadOnlyDictionary<Int32, IPrice> Prices => ROD_Prices;


        #endregion

        #region Internal

        [JsonName("btn_title")]
        public String _BtnTitle;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("item_number")]
        public Internal_IFormula _ItemCount;
        [JsonName("stamina")]
        public Internal_IFormula _Stamina;
        [JsonName("price")]
        public Dictionary<String, Internal_IPrice> _Prices;
        private Dictionary<Int32, IPrice> ROD_Prices;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
