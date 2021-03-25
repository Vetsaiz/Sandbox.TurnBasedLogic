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

namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_ICutSceneState : ICutSceneStateEmulate, ICutSceneState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private CutSceneAccessor _accessor;
        public void InitData(ICutSceneStateClient client, CutSceneAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_CompletedCutScene.Init(client.CompletedCutScene, storage);
        }


        #region Queries

        public ICutScene GetCutScene(System.Int32 id)
        {
            return _accessor.GetCutScene(id);
        }
        public Boolean IsCompleteCutScene(System.Int32 id)
        {
            return _accessor.IsCompleteCutScene(id);
        }

        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, Boolean> ICutSceneStateEmulate.CompletedCutScene => LD_CompletedCutScene;

        #endregion

        #region Internal

        ILogicDictionary<Int32, Boolean> ICutSceneState.CompletedCutScene => LD_CompletedCutScene;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, Boolean> LD_CompletedCutScene { get; } = new ValueEmulateDictionary<Int32, Boolean>();

        #endregion

    }
}
