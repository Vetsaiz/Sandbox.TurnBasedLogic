using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IActivationDescription : IActivationDescription 
    {
        public void PostSerialize()
        {
            _ItemCount?.PostSerialize();
        }

        #region Interface

        public String Description => _Description;

        public Int32 ItemId => _ItemId;

        public IFormula ItemCount => _ItemCount;

        public Boolean UnknownItem => _UnknownItem;


        #endregion

        #region Internal

        [JsonName("description")]
        public String _Description;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("item_number")]
        public Internal_IFormula _ItemCount;
        [JsonName("unknown_item")]
        public Boolean _UnknownItem;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
