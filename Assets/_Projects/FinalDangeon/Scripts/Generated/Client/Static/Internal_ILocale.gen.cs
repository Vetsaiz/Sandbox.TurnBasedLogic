using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ILocale : ILocale 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Locale => _Locale;

        public Int32 Title => _Title;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("locale")]
        public String _Locale;
        [JsonName("ui_title")]
        public Int32 _Title;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
