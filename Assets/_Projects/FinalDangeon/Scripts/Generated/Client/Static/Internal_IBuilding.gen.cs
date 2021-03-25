using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IBuilding : IBuilding 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public String Title => _Title;

        public Int32 UnlockLevel => _UnlockLevel;

        public String Description => _Description;

        public Int32 Resource => _Resource;

        public Boolean Hide => _Hide;


        #endregion

        #region Internal

        [JsonName("ui_title")]
        public String _Title;
        [JsonName("unlock_level")]
        public Int32 _UnlockLevel;
        [JsonName("description")]
        public String _Description;
        [JsonName("resource")]
        public Int32 _Resource;
        [JsonName("hide")]
        public Boolean _Hide;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
