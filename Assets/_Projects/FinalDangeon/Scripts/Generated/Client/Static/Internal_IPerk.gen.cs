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
    internal class Internal_IPerk : IPerk 
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
            _Actable?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public Int32 UnitId => _UnitId;

        public String UnityId => _UnityId;

        public Int32 ClassId => _ClassId;

        public  IReadOnlyDictionary<Int32, IRarity> Rarities => ROD_Rarities;

        public String Owner => _Owner;

        public Boolean OnlyActive => _OnlyActive;

        public ICondition Actable => _Actable;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("class_id")]
        public Int32 _ClassId;
        [JsonName("rarity")]
        public Dictionary<String, Internal_IRarity> _Rarities;
        private Dictionary<Int32, IRarity> ROD_Rarities;
        [JsonName("owner")]
        public String _Owner;
        [JsonName("endless")]
        public Boolean _OnlyActive;
        [JsonName("actable")]
        public Internal_ICondition _Actable;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
