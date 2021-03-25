using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IActivationSettings : IActivationSettings 
    {
        public void PostSerialize()
        {
            ROD_Triggers = _Triggers != null ? _Triggers.ToDictionary(
            x => Int32.Parse(x.Key),
            y => y.Value
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, ActivationTriggerType> Triggers => ROD_Triggers;

        public Boolean Auto => _Auto;

        public String AnumUnityId => _AnumUnityId;

        public String FxUnityId => _FxUnityId;


        #endregion

        #region Internal

        [JsonName("triggers")]
        public Dictionary<String, ActivationTriggerType> _Triggers;
        private Dictionary<Int32, ActivationTriggerType> ROD_Triggers;
        [JsonName("auto")]
        public Boolean _Auto;
        [JsonName("unity_id")]
        public String _AnumUnityId;
        [JsonName("fx_id")]
        public String _FxUnityId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
