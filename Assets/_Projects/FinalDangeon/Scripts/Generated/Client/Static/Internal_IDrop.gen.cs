using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IDrop : IDrop 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public DropType Type => _Type;

        public Int32 UnitId => _UnitId;

        public Int32 MoneyId => _MoneyId;

        public Int32 ItemId => _ItemId;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public DropType _Type;
        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("money_type_id")]
        public Int32 _MoneyId;
        [JsonName("item_id")]
        public Int32 _ItemId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
