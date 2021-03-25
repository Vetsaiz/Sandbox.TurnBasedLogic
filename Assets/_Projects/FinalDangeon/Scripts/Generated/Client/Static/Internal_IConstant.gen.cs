using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IConstant : IConstant 
    {
        public void PostSerialize()
        {
            _Formula?.PostSerialize();
        }

        #region Interface

        public String Title => _Title;

        public IFormula Formula => _Formula;


        #endregion

        #region Internal

        [JsonName("title")]
        public String _Title;
        [JsonName("value")]
        public Internal_IFormula _Formula;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
