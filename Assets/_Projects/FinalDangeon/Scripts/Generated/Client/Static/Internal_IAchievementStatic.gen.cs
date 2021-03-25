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
    internal class Internal_IAchievementStatic : IAchievementStatic 
    {
        public void PostSerialize()
        {
            ROD_Achievements = _Achievements != null ? _Achievements.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IAchievement;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IAchievement> Achievements => ROD_Achievements;


        #endregion

        #region Internal

        [JsonName("achievements")]
        public Dictionary<String, Internal_IAchievement> _Achievements;
        private Dictionary<Int32, IAchievement> ROD_Achievements;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
