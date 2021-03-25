using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ILogStatic : ILogStatic 
    {
        public void PostSerialize()
        {
            ROD_Events = _Events != null ? _Events.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ILogEvent;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, ILogEvent> Events => ROD_Events;


        #endregion

        #region Internal

        [JsonName("events")]
        public Dictionary<String, Internal_ILogEvent> _Events;
        private Dictionary<Int32, ILogEvent> ROD_Events;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
