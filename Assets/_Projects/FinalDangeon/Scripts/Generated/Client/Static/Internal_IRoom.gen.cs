using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IRoom : IRoom 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 StageId => _StageId;

        public String UnityId => _UnityId;

        public IImpact Impact => _Impact;

        public String Title => _Title;

        public String Description => _Description;

        public Boolean Hidden => _Hidden;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("impact_init")]
        public Internal_IImpact _Impact;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("hidden")]
        public Boolean _Hidden;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
