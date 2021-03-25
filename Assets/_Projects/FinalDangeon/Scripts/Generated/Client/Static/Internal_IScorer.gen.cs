using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IScorer : IScorer 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String Label => _Label;

        public Boolean Temporary => _Temporary;

        public ScorerType Domain => _Domain;

        public Boolean Log => _Log;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("title")]
        public String _Title;
        [JsonName("label")]
        public String _Label;
        [JsonName("temporary")]
        public Boolean _Temporary;
        [JsonName("domain")]
        public ScorerType _Domain;
        [JsonName("log")]
        public Boolean _Log;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
