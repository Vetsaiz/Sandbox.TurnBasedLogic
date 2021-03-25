using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IMoneyType : IMoneyType 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Description => _Description;

        public String IconId => _IconId;

        public Int32 Limit => _Limit;

        public Int32 ScorerId => _ScorerId;

        public Int32 AchievScorerId => _AchievScorerId;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("description")]
        public String _Description;
        [JsonName("unity_id")]
        public String _IconId;
        [JsonName("limit")]
        public Int32 _Limit;
        [JsonName("scorer_id")]
        public Int32 _ScorerId;
        [JsonName("achiev_scorer_id")]
        public Int32 _AchievScorerId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
