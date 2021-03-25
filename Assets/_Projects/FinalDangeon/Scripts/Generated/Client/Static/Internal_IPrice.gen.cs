using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IPrice : IPrice 
    {
        public void PostSerialize()
        {
            _Value?.PostSerialize();
        }

        #region Interface

        public IFormula Value => _Value;

        public Int32 MoneyType => _MoneyType;


        #endregion

        #region Internal

        [JsonName("value")]
        public Internal_IFormula _Value;
        [JsonName("money_type")]
        public Int32 _MoneyType;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
