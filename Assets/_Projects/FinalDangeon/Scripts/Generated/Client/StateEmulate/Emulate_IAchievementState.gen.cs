using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
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
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IAchievementState : IAchievementStateEmulate, IAchievementState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private AchievementAccessor _accessor;
        public void InitData(IAchievementStateClient client, AchievementAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_Achievements.Init(client.Achievements, storage);
        }


        #region Queries


        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, IAchievementDataEmulate> IAchievementStateEmulate.Achievements => LD_Achievements;

        #endregion

        #region Internal

        ILogicDictionary<Int32, IAchievementData> IAchievementState.Achievements => LD_Achievements;

        #endregion

        #region Source

        public InternalEmulateDictionary<Int32,Emulate_IAchievementData, IAchievementData, IAchievementDataEmulate> LD_Achievements { get; } = new InternalEmulateDictionary<Int32,Emulate_IAchievementData, IAchievementData, IAchievementDataEmulate>();

        #endregion

    }
}
