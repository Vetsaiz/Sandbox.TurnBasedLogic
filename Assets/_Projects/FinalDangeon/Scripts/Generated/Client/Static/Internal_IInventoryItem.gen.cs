using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IInventoryItem : IInventoryItem 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
        }

        #region Interface

        public String Title => _Title;

        public String Description => _Description;

        public String IconUnityId => _IconUnityId;

        public String BackUnityId => _BackUnityId;

        public String Stack => _Stack;

        public IImpact Impact => _Impact;

        public String ItemType => _ItemType;


        #endregion

        #region Internal

        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unity_id")]
        public String _IconUnityId;
        [JsonName("back_unity_id")]
        public String _BackUnityId;
        [JsonName("stack")]
        public String _Stack;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("type")]
        public String _ItemType;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
