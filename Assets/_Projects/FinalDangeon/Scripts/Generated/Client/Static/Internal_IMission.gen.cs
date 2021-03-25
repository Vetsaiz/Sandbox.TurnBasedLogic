using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IMission : IMission 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Number => _Number;

        public Int32 StageId => _StageId;

        public String Description => _Description;


        #endregion

        #region Internal

        [JsonName("number")]
        public Int32 _Number;
        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("description")]
        public String _Description;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
