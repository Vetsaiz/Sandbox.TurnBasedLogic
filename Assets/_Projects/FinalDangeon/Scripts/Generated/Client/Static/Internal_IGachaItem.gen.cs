using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IGachaItem : IGachaItem 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 UnitId => _UnitId;

        public Int32 ItemId => _ItemId;

        public Int32 MoneyTypeId => _MoneyTypeId;

        public Int32 Chance => _Chance;

        public Int32 Number => _Number;

        public Boolean IsPromo => _IsPromo;

        public Int32 Count => _Count;


        #endregion

        #region Internal

        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("money_type_id")]
        public Int32 _MoneyTypeId;
        [JsonName("chance")]
        public Int32 _Chance;
        [JsonName("number")]
        public Int32 _Number;
        [JsonName("promo")]
        public Boolean _IsPromo;
        [JsonName("count")]
        public Int32 _Count;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
