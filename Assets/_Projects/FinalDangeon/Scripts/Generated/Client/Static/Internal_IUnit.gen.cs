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
    internal class Internal_IUnit : IUnit 
    {
        public void PostSerialize()
        {
            ROD_Rarities = _Rarities != null ? _Rarities.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IRarity;
            }
            ) : null;
            ROD_EquipmentRarities = _EquipmentRarities != null ? _EquipmentRarities.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IRarity;
            }
            ) : null;
            ROD_Equipment = _Equipment != null ? _Equipment.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IEquipment;
            }
            ) : null;
            ROD_Missions = _Missions != null ? _Missions.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IMission;
            }
            ) : null;
            _Strength?.PostSerialize();
            _HpMax?.PostSerialize();
            _Initiative?.PostSerialize();
            _ImpactInit?.PostSerialize();
            _ImpactUpdrade?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public Int32 WorldId => _WorldId;

        public Int32 ClassId => _ClassId;

        public String UnityId => _UnityId;

        public  IReadOnlyDictionary<Int32, IRarity> Rarities => ROD_Rarities;

        public  IReadOnlyDictionary<Int32, IRarity> EquipmentRarities => ROD_EquipmentRarities;

        public String FamiliarTitle => _FamiliarTitle;

        public String FamiliarDescription => _FamiliarDescription;

        public  IReadOnlyDictionary<Int32, IEquipment> Equipment => ROD_Equipment;

        public  IReadOnlyDictionary<Int32, IMission> Missions => ROD_Missions;

        public IFormula Strength => _Strength;

        public IFormula HpMax => _HpMax;

        public IFormula Initiative => _Initiative;

        public String Intro => _Intro;

        public Boolean HasFamiliar => _HasFamiliar;

        public IImpact ImpactInit => _ImpactInit;

        public IImpact ImpactUpdrade => _ImpactUpdrade;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("world_id")]
        public Int32 _WorldId;
        [JsonName("class_id")]
        public Int32 _ClassId;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("rarities")]
        public Dictionary<String, Internal_IRarity> _Rarities;
        private Dictionary<Int32, IRarity> ROD_Rarities;
        [JsonName("equipment_rarity")]
        public Dictionary<String, Internal_IRarity> _EquipmentRarities;
        private Dictionary<Int32, IRarity> ROD_EquipmentRarities;
        [JsonName("familiar_title")]
        public String _FamiliarTitle;
        [JsonName("familiar_description")]
        public String _FamiliarDescription;
        [JsonName("equipment")]
        public Dictionary<String, Internal_IEquipment> _Equipment;
        private Dictionary<Int32, IEquipment> ROD_Equipment;
        [JsonName("missions")]
        public Dictionary<String, Internal_IMission> _Missions;
        private Dictionary<Int32, IMission> ROD_Missions;
        [JsonName("strength")]
        public Internal_IFormula _Strength;
        [JsonName("hp_max")]
        public Internal_IFormula _HpMax;
        [JsonName("initiative")]
        public Internal_IFormula _Initiative;
        [JsonName("intro")]
        public String _Intro;
        [JsonName("has_familiar")]
        public Boolean _HasFamiliar;
        [JsonName("impact_init")]
        public Internal_IImpact _ImpactInit;
        [JsonName("impact_upgrade")]
        public Internal_IImpact _ImpactUpdrade;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
