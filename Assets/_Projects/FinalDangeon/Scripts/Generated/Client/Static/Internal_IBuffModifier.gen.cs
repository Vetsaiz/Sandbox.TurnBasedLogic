using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IBuffModifier : IBuffModifier 
    {
        public void PostSerialize()
        {
            _Value?.PostSerialize();
        }

        #region Interface

        public Int32 ModId => _ModId;

        public IFormula Value => _Value;


        #endregion

        #region Internal

        [JsonName("mod")]
        public Int32 _ModId;
        [JsonName("value")]
        public Internal_IFormula _Value;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
