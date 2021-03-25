using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IHpSegment : IHpSegment 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Segments => _Segments;

        public Int32 Hp => _Hp;


        #endregion

        #region Internal

        [JsonName("segments")]
        public Int32 _Segments;
        [JsonName("Hp")]
        public Int32 _Hp;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
