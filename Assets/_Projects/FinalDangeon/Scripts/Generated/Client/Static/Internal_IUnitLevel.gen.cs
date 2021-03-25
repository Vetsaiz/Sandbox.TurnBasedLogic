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
    internal class Internal_IUnitLevel : IUnitLevel 
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
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 Level => _Level;

        public Int32 ExpMin => _ExpMin;

        public  IReadOnlyDictionary<Int32, IPrice> Prices => ROD_Prices;

        public IImpact Impact => _Impact;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("level")]
        public Int32 _Level;
        [JsonName("exp_min")]
        public Int32 _ExpMin;
        [JsonName("price")]
        public Dictionary<String, Internal_IPrice> _Prices;
        private Dictionary<Int32, IPrice> ROD_Prices;
        [JsonName("impact_init")]
        public Internal_IImpact _Impact;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
