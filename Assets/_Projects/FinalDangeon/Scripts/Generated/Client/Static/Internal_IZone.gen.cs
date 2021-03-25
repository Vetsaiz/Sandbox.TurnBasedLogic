using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IZone : IZone 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public String TitleFull => _TitleFull;

        public Int32 WorldId => _WorldId;

        public Int32 Number => _Number;

        public Boolean Portal => _Portal;

        public String UnityId => _UnityId;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("ui_title_full")]
        public String _TitleFull;
        [JsonName("world_id")]
        public Int32 _WorldId;
        [JsonName("zone_numbler")]
        public Int32 _Number;
        [JsonName("portal")]
        public Boolean _Portal;
        [JsonName("unity_id")]
        public String _UnityId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
