using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IChangePrice : IChangePrice 
    {
        public void PostSerialize()
        {
            _Price?.PostSerialize();
        }

        #region Interface

        public Int32 Numbler => _Numbler;

        public IPrice Price => _Price;


        #endregion

        #region Internal

        [JsonName("number")]
        public Int32 _Numbler;
        [JsonName("price")]
        public Internal_IPrice _Price;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
