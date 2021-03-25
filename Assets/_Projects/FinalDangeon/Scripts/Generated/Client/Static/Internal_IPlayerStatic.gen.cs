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
    internal class Internal_IPlayerStatic : IPlayerStatic 
    {
        public void PostSerialize()
        {
            ROD_Levels = _Levels != null ? _Levels.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPlayerLevel;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IPlayerLevel> Levels => ROD_Levels;


        #endregion

        #region Internal

        [JsonName("player_levels")]
        public Dictionary<String, Internal_IPlayerLevel> _Levels;
        private Dictionary<Int32, IPlayerLevel> ROD_Levels;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
