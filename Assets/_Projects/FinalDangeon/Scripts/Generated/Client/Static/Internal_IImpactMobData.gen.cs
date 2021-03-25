using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IImpactMobData : IImpactMobData 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
        }

        #region Interface

        public Int32 MobId => _MobId;

        public Int32 Wave => _Wave;

        public Int32 Position => _Position;

        public IImpact Impact => _Impact;


        #endregion

        #region Internal

        [JsonName("mob_id")]
        public Int32 _MobId;
        [JsonName("wave")]
        public Int32 _Wave;
        [JsonName("position")]
        public Int32 _Position;
        [JsonName("impact_init")]
        public Internal_IImpact _Impact;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
