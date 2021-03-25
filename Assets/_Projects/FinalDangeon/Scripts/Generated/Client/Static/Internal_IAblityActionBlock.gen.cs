using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IAblityActionBlock : IAblityActionBlock 
    {
        public void PostSerialize()
        {
            _Value?.PostSerialize();
        }

        #region Interface

        public AbilityActionType Template => _Template;

        public Int32 BuffId => _BuffId;

        public Int32 ActionInfoId => _ActionInfoId;

        public IFormula Value => _Value;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public AbilityActionType _Template;
        [JsonName("buff_id")]
        public Int32 _BuffId;
        [JsonName("type")]
        public Int32 _ActionInfoId;
        [JsonName("value")]
        public Internal_IFormula _Value;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
