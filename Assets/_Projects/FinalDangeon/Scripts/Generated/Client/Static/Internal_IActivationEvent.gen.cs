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
    internal class Internal_IActivationEvent : IActivationEvent 
    {
        public void PostSerialize()
        {
            ROD_Events = _Events != null ? _Events.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IActivationEventTypes;
            }
            ) : null;
        }

        #region Interface

        public TargetActivationType Target => _Target;

        public  IReadOnlyDictionary<Int32, IActivationEventTypes> Events => ROD_Events;

        public TriggerType Type => _Type;


        #endregion

        #region Internal

        [JsonName("target")]
        public TargetActivationType _Target;
        [JsonName("events")]
        public Dictionary<String, Internal_IActivationEventTypes> _Events;
        private Dictionary<Int32, IActivationEventTypes> ROD_Events;
        [JsonName("template_id")]
        public TriggerType _Type;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
