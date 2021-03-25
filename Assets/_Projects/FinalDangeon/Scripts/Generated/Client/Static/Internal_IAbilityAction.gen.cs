using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IAbilityAction : IAbilityAction 
    {
        public void PostSerialize()
        {
            _Block?.PostSerialize();
            _Condition?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public IAblityActionBlock Block => _Block;

        public ICondition Condition => _Condition;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("block")]
        public Internal_IAblityActionBlock _Block;
        [JsonName("condition")]
        public Internal_ICondition _Condition;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
