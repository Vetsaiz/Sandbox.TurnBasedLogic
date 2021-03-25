using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IMoneySegment : IMoneySegment 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Icon => _Icon;

        public Int32 MinValue => _MinValue;


        #endregion

        #region Internal

        [JsonName("icon")]
        public Int32 _Icon;
        [JsonName("min_value")]
        public Int32 _MinValue;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
