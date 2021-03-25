using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICutScene : ICutScene 
    {
        public void PostSerialize()
        {
            ROD_Frames = _Frames != null ? _Frames.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ICutSceneType;
            }
            ) : null;
        }

        #region Interface

        public String Name => _Name;

        public Int32 Id => _Id;

        public Boolean Skip => _Skip;

        public  IReadOnlyDictionary<Int32, ICutSceneType> Frames => ROD_Frames;


        #endregion

        #region Internal

        [JsonName("title")]
        public String _Name;
        [JsonName("id")]
        public Int32 _Id;
        [JsonName("skip")]
        public Boolean _Skip;
        [JsonName("frames")]
        public Dictionary<String, Internal_ICutSceneType> _Frames;
        private Dictionary<Int32, ICutSceneType> ROD_Frames;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
