using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICutSceneType : ICutSceneType 
    {
        public void PostSerialize()
        {
            _Data?.PostSerialize();
        }

        #region Interface

        public ICutSceneFrame Data => _Data;


        #endregion

        #region Internal

        [JsonName("type")]
        public Internal_ICutSceneFrame _Data;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
