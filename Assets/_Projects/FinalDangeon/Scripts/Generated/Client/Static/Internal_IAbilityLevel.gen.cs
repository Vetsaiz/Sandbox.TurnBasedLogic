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
    internal class Internal_IAbilityLevel : IAbilityLevel 
    {
        public void PostSerialize()
        {
            ROD_BaseAttackPrice = _BaseAttackPrice != null ? _BaseAttackPrice.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPrice;
            }
            ) : null;
            ROD_UpgradeAttackPrice = _UpgradeAttackPrice != null ? _UpgradeAttackPrice.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPrice;
            }
            ) : null;
            ROD_UltAttackPrice = _UltAttackPrice != null ? _UltAttackPrice.ToDictionary(
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

        public Int32 Level => _Level;

        public  IReadOnlyDictionary<Int32, IPrice> BaseAttackPrice => ROD_BaseAttackPrice;

        public  IReadOnlyDictionary<Int32, IPrice> UpgradeAttackPrice => ROD_UpgradeAttackPrice;

        public  IReadOnlyDictionary<Int32, IPrice> UltAttackPrice => ROD_UltAttackPrice;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("level")]
        public Int32 _Level;
        [JsonName("base_attack_price")]
        public Dictionary<String, Internal_IPrice> _BaseAttackPrice;
        private Dictionary<Int32, IPrice> ROD_BaseAttackPrice;
        [JsonName("alter_attack_price")]
        public Dictionary<String, Internal_IPrice> _UpgradeAttackPrice;
        private Dictionary<Int32, IPrice> ROD_UpgradeAttackPrice;
        [JsonName("ultimate_attack_price")]
        public Dictionary<String, Internal_IPrice> _UltAttackPrice;
        private Dictionary<Int32, IPrice> ROD_UltAttackPrice;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
