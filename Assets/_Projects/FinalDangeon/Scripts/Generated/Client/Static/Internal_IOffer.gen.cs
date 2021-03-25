using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IOffer : IOffer 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public String UnityId => _UnityId;

        public Int32 GoodId => _GoodId;

        public Boolean IsLobby => _IsLobby;

        public Boolean IsCommon => _IsCommon;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("good_id")]
        public Int32 _GoodId;
        [JsonName("promo")]
        public Boolean _IsLobby;
        [JsonName("common")]
        public Boolean _IsCommon;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
