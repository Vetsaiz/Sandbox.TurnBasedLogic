using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IAbilityParam : IAbilityParam 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 UnitId => _UnitId;

        public Int32 MobId => _MobId;

        public AbilityType Mode => _Mode;


        #endregion

        #region Internal

        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("mob_id")]
        public Int32 _MobId;
        [JsonName("mode")]
        public AbilityType _Mode;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
