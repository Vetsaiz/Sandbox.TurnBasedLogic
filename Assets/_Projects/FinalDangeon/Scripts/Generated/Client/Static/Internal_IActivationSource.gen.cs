using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IActivationSource : IActivationSource 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 PerkClassId => _PerkClassId;

        public Int32 PerkLevel => _PerkLevel;

        public Int32 IconType => _IconType;

        public Int32 UnitId => _UnitId;


        #endregion

        #region Internal

        [JsonName("perk_class_id")]
        public Int32 _PerkClassId;
        [JsonName("perk_level")]
        public Int32 _PerkLevel;
        [JsonName("icon_type")]
        public Int32 _IconType;
        [JsonName("unit_id")]
        public Int32 _UnitId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
