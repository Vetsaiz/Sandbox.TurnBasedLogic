using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IDropItem : IDropItem 
    {
        public void PostSerialize()
        {
            _Item?.PostSerialize();
            _Value?.PostSerialize();
        }

        #region Interface

        public IDrop Item => _Item;

        public IFormula Value => _Value;


        #endregion

        #region Internal

        [JsonName("item")]
        public Internal_IDrop _Item;
        [JsonName("value")]
        public Internal_IFormula _Value;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
