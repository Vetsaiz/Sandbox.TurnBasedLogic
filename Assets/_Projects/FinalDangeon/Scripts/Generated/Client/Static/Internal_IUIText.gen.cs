using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IUIText : IUIText 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Label => _Label;

        public Int32 UnlockLevel => _UnlockLevel;

        public String Text => _Text;

        public String Font => _Font;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("label")]
        public String _Label;
        [JsonName("ui")]
        public Int32 _UnlockLevel;
        [JsonName("text")]
        public String _Text;
        [JsonName("font")]
        public String _Font;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
