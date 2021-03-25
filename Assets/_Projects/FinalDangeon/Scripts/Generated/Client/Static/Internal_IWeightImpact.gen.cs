using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IWeightImpact : IWeightImpact 
    {
        public void PostSerialize()
        {
            _Formula?.PostSerialize();
            _Impact?.PostSerialize();
        }

        #region Interface

        public IFormula Formula => _Formula;

        public IImpact Impact => _Impact;


        #endregion

        #region Internal

        [JsonName("weight")]
        public Internal_IFormula _Formula;
        [JsonName("impact")]
        public Internal_IImpact _Impact;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
