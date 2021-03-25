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
    internal class Internal_IBattleStatic : IBattleStatic 
    {
        public void PostSerialize()
        {
            ROD_Buffs = _Buffs != null ? _Buffs.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBuff;
            }
            ) : null;
            ROD_BuffType = _BuffType != null ? _BuffType.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBuffType;
            }
            ) : null;
            ROD_Modifiers = _Modifiers != null ? _Modifiers.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IModifier;
            }
            ) : null;
            ROD_BattleParams = _BattleParams != null ? _BattleParams.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBattleParam;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IBuff> Buffs => ROD_Buffs;

        public  IReadOnlyDictionary<Int32, IBuffType> BuffType => ROD_BuffType;

        public  IReadOnlyDictionary<Int32, IModifier> Modifiers => ROD_Modifiers;

        public  IReadOnlyDictionary<Int32, IBattleParam> BattleParams => ROD_BattleParams;


        #endregion

        #region Internal

        [JsonName("buffs")]
        public Dictionary<String, Internal_IBuff> _Buffs;
        private Dictionary<Int32, IBuff> ROD_Buffs;
        [JsonName("buff_types")]
        public Dictionary<String, Internal_IBuffType> _BuffType;
        private Dictionary<Int32, IBuffType> ROD_BuffType;
        [JsonName("mods")]
        public Dictionary<String, Internal_IModifier> _Modifiers;
        private Dictionary<Int32, IModifier> ROD_Modifiers;
        [JsonName("params")]
        public Dictionary<String, Internal_IBattleParam> _BattleParams;
        private Dictionary<Int32, IBattleParam> ROD_BattleParams;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
