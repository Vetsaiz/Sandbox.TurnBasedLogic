using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IUIWindow : IUIWindow 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
            ROD_Resources = _Resources != null ? _Resources.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public IImpact Impact => _Impact;

        public  IReadOnlyDictionary<Int32, Int32> Resources => ROD_Resources;

        public String Title => _Title;

        public String UnityId => _UnityId;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("resources")]
        public Dictionary<String, Int32> _Resources;
        private Dictionary<Int32, Int32> ROD_Resources;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("unity_id")]
        public String _UnityId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
