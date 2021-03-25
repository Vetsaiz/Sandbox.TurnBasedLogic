using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IBattleParam : IBattleParam 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Label => _Label;

        public OwnerType Owner => _Owner;

        public String Description => _Description;

        public String UnityId => _UnityId;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("label")]
        public String _Label;
        [JsonName("owner")]
        public OwnerType _Owner;
        [JsonName("description")]
        public String _Description;
        [JsonName("icon_unity_id")]
        public String _UnityId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
