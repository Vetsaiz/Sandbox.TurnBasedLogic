using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IEquipment : IEquipment 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Stars => _Stars;

        public Int32 Slot => _Slot;

        public Int32 ItemId => _ItemId;

        public Int32 Strength => _Strength;

        public Int32 HpMax => _HpMax;

        public Int32 Initiative => _Initiative;


        #endregion

        #region Internal

        [JsonName("stars")]
        public Int32 _Stars;
        [JsonName("slot")]
        public Int32 _Slot;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("strength")]
        public Int32 _Strength;
        [JsonName("hp_max")]
        public Int32 _HpMax;
        [JsonName("initiative")]
        public Int32 _Initiative;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
