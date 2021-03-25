using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IPlayerLevel : IPlayerLevel 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
            _EnergyMax?.PostSerialize();
            ROD_RewardMoneyTypes = _RewardMoneyTypes != null ? _RewardMoneyTypes.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_RewardUnits = _RewardUnits != null ? _RewardUnits.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_RewardItems = _RewardItems != null ? _RewardItems.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 Level => _Level;

        public Int32 ExpMin => _ExpMin;

        public IImpact Impact => _Impact;

        public IFormula EnergyMax => _EnergyMax;

        public String Description => _Description;

        public  IReadOnlyDictionary<Int32, Int32> RewardMoneyTypes => ROD_RewardMoneyTypes;

        public  IReadOnlyDictionary<Int32, Int32> RewardUnits => ROD_RewardUnits;

        public  IReadOnlyDictionary<Int32, Int32> RewardItems => ROD_RewardItems;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("level")]
        public Int32 _Level;
        [JsonName("exp_min")]
        public Int32 _ExpMin;
        [JsonName("impact_init")]
        public Internal_IImpact _Impact;
        [JsonName("energy_max")]
        public Internal_IFormula _EnergyMax;
        [JsonName("description")]
        public String _Description;
        [JsonName("reward_money_types")]
        public Dictionary<String, Int32> _RewardMoneyTypes;
        private Dictionary<Int32, Int32> ROD_RewardMoneyTypes;
        [JsonName("reward_units")]
        public Dictionary<String, Int32> _RewardUnits;
        private Dictionary<Int32, Int32> ROD_RewardUnits;
        [JsonName("reward_items")]
        public Dictionary<String, Int32> _RewardItems;
        private Dictionary<Int32, Int32> ROD_RewardItems;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
