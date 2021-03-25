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
    internal class Internal_IUniversalPrice : IUniversalPrice 
    {
        public void PostSerialize()
        {
            ROD_Prices = _Prices != null ? _Prices.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPrice;
            }
            ) : null;
            _Impact?.PostSerialize();
            _Condition?.PostSerialize();
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IPrice> Prices => ROD_Prices;

        public IImpact Impact => _Impact;

        public ICondition Condition => _Condition;


        #endregion

        #region Internal

        [JsonName("price")]
        public Dictionary<String, Internal_IPrice> _Prices;
        private Dictionary<Int32, IPrice> ROD_Prices;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("availability")]
        public Internal_ICondition _Condition;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
