using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IAchievementState : IAchievementStateClient, IAchievementState 
    {
        private ChangeStorage _storage;
        private string DataId = "achievementState";
        private AchievementAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, AchievementAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_Achievements?.Init($"{DataId}.achievements", storage, _Achievements);
        }
        public void PreSave()
        {
            foreach (var temp in LD_Achievements.Source)
            {
                temp.Value.PreSave();
            }
            _Achievements = LD_Achievements.Source;
        }

        #region Queries


        #endregion

        #region Interface

        IReadOnlyReactiveDictionary<Int32, IAchievementDataClient> IAchievementStateClient.Achievements => LD_Achievements.Interface;
        public IReadOnlyReactiveProperty<IAchievementDataClient> GetAchievementsProperty(Int32 key)
        {
            return LD_Achievements.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("achievements")]
        public Dictionary<string, Internal_IAchievementData> _Achievements = new Dictionary<string, Internal_IAchievementData>();
        private InternalLogicDictionary<Int32, Internal_IAchievementData, IAchievementData, IAchievementDataClient> LD_Achievements = new InternalLogicDictionary<Int32, Internal_IAchievementData, IAchievementData, IAchievementDataClient>();

        #endregion

        #region Source

        ILogicDictionary<Int32, IAchievementData> IAchievementState.Achievements
        {
            get => LD_Achievements;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_Achievements.ToString();
            return result;
        }

        #endregion

    }
}
