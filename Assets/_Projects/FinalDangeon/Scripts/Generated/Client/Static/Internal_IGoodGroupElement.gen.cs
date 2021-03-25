using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IGoodGroupElement : IGoodGroupElement 
    {
        public void PostSerialize()
        {
            _Weight?.PostSerialize();
        }

        #region Interface

        public Int32 GoodId => _GoodId;

        public IFormula Weight => _Weight;


        #endregion

        #region Internal

        [JsonName("good_id")]
        public Int32 _GoodId;
        [JsonName("weight")]
        public Internal_IFormula _Weight;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
