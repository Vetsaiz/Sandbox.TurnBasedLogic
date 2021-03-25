using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IActivationEventTypes : IActivationEventTypes 
    {
        public void PostSerialize()
        {
            _Activation?.PostSerialize();
        }

        #region Interface

        public ITrigger Activation => _Activation;


        #endregion

        #region Internal

        [JsonName("type")]
        public Internal_ITrigger _Activation;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
