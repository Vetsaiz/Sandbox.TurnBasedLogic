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
    internal class Internal_ICutScenesStatic : ICutScenesStatic 
    {
        public void PostSerialize()
        {
            ROD_CutScenes = _CutScenes != null ? _CutScenes.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ICutScene;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, ICutScene> CutScenes => ROD_CutScenes;


        #endregion

        #region Internal

        [JsonName("cutscenes")]
        public Dictionary<String, Internal_ICutScene> _CutScenes;
        private Dictionary<Int32, ICutScene> ROD_CutScenes;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
