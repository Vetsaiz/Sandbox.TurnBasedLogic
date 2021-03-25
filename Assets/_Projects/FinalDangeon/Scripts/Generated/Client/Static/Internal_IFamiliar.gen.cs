using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IFamiliar : IFamiliar 
    {
        public void PostSerialize()
        {
            ROD_BaseStrength = _BaseStrength != null ? _BaseStrength.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public String PipupUnityId => _PipupUnityId;

        public  IReadOnlyDictionary<Int32, Int32> BaseStrength => ROD_BaseStrength;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("pipup_unity_id")]
        public String _PipupUnityId;
        [JsonName("base_strength")]
        public Dictionary<String, Int32> _BaseStrength;
        private Dictionary<Int32, Int32> ROD_BaseStrength;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
