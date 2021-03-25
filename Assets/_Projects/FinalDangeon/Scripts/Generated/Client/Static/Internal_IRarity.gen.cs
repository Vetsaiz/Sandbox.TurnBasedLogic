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
    internal class Internal_IRarity : IRarity 
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
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 Stars => _Stars;

        public Int32 Shards => _Shards;

        public  IReadOnlyDictionary<Int32, IPrice> Prices => ROD_Prices;

        public Int32 Charges => _Charges;

        public Int32 UpgradeRestriction => _UpgradeRestriction;

        public Int32 Stamina => _Stamina;

        public Int32 Strength => _Strength;

        public Int32 HpMax => _HpMax;

        public Int32 Initiative => _Initiative;

        public String Description => _Description;

        public String ChangesDescription => _ChangesDescription;

        public String Color => _Color;

        public String Title => _Title;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("stars")]
        public Int32 _Stars;
        [JsonName("shards")]
        public Int32 _Shards;
        [JsonName("price")]
        public Dictionary<String, Internal_IPrice> _Prices;
        private Dictionary<Int32, IPrice> ROD_Prices;
        [JsonName("charges")]
        public Int32 _Charges;
        [JsonName("upgrade_condition")]
        public Int32 _UpgradeRestriction;
        [JsonName("stamina")]
        public Int32 _Stamina;
        [JsonName("strength")]
        public Int32 _Strength;
        [JsonName("hp_max")]
        public Int32 _HpMax;
        [JsonName("initiative")]
        public Int32 _Initiative;
        [JsonName("description")]
        public String _Description;
        [JsonName("prev_diff_description")]
        public String _ChangesDescription;
        [JsonName("color")]
        public String _Color;
        [JsonName("title")]
        public String _Title;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
