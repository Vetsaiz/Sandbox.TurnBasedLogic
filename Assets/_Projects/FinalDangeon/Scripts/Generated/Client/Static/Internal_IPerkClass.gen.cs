using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IPerkClass : IPerkClass 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 StateId => _StateId;

        public String UnityId => _UnityId;

        public IImpact Impact => _Impact;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("stage_id")]
        public Int32 _StateId;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("impact_init")]
        public Internal_IImpact _Impact;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
