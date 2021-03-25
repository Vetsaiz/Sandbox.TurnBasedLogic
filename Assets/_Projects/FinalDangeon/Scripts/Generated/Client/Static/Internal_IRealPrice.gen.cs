using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IRealPrice : IRealPrice 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String StoreId => _StoreId;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("product_id")]
        public String _StoreId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
