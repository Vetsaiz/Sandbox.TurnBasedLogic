using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICutSceneContainer : ICutSceneContainer 
    {
        public void PostSerialize()
        {
            _Event?.PostSerialize();
        }

        #region Interface

        public ICutSceneEvent Event => _Event;


        #endregion

        #region Internal

        [JsonName("events")]
        public Internal_ICutSceneEvent _Event;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
