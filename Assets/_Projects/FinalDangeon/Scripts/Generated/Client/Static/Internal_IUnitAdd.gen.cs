using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IUnitAdd : IUnitAdd 
    {
        public void PostSerialize()
        {
            ROD_PerkCharges = _PerkCharges != null ? _PerkCharges.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_Equipment = _Equipment != null ? _Equipment.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 Shards => _Shards;

        public Int32 Stars => _Stars;

        public Int32 Exp => _Exp;

        public Int32 Level => _Level;

        public  IReadOnlyDictionary<Int32, Int32> PerkCharges => ROD_PerkCharges;

        public  IReadOnlyDictionary<Int32, Int32> Equipment => ROD_Equipment;

        public Int32 EquipmentRarity => _EquipmentRarity;

        public Boolean FamiliarUnlock => _FamiliarUnlock;

        public Boolean Assist => _Assist;

        public Boolean Reserve => _Reserve;

        public Int32 SlotExplorer => _SlotExplorer;


        #endregion

        #region Internal

        [JsonName("unit_id")]
        public Int32 _Id;
        [JsonName("shards")]
        public Int32 _Shards;
        [JsonName("stars")]
        public Int32 _Stars;
        [JsonName("exp")]
        public Int32 _Exp;
        [JsonName("level")]
        public Int32 _Level;
        [JsonName("perk_charges")]
        public Dictionary<String, Int32> _PerkCharges;
        private Dictionary<Int32, Int32> ROD_PerkCharges;
        [JsonName("equipment")]
        public Dictionary<String, Int32> _Equipment;
        private Dictionary<Int32, Int32> ROD_Equipment;
        [JsonName("equipment_level")]
        public Int32 _EquipmentRarity;
        [JsonName("has_familiar")]
        public Boolean _FamiliarUnlock;
        [JsonName("assist")]
        public Boolean _Assist;
        [JsonName("reserve")]
        public Boolean _Reserve;
        [JsonName("position")]
        public Int32 _SlotExplorer;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
