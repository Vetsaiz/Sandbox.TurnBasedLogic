using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ILogEvent : ILogEvent 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public String FacebookId => _FacebookId;

        public String FirebaseId => _FirebaseId;

        public String AppmetricaId => _AppmetricaId;

        public String AppsFlyerId => _AppsFlyerId;


        #endregion

        #region Internal

        [JsonName("facebook_id")]
        public String _FacebookId;
        [JsonName("firebase_id")]
        public String _FirebaseId;
        [JsonName("appmetrica_id")]
        public String _AppmetricaId;
        [JsonName("appsflyer_id")]
        public String _AppsFlyerId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
