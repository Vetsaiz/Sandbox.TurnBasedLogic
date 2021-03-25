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
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_ICutSceneState : ICutSceneStateClient, ICutSceneState 
    {
        private ChangeStorage _storage;
        private string DataId = "cutSceneState";
        private CutSceneAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, CutSceneAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_CompletedCutScene?.Init($"{DataId}.completedCutScene", storage, _CompletedCutScene);
        }
        public void PreSave()
        {
            _CompletedCutScene = LD_CompletedCutScene.Source;
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

        #region Interface

        IReadOnlyReactiveDictionary<Int32, Boolean> ICutSceneStateClient.CompletedCutScene => LD_CompletedCutScene.Interface;
        public IReadOnlyReactiveProperty<Boolean?> GetCompletedCutSceneProperty(Int32 key)
        {
            return LD_CompletedCutScene.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("completedCutScene")]
        public Dictionary<string, Boolean> _CompletedCutScene = new Dictionary<string, Boolean>();
        private StructLogicDictionary<Int32, Boolean> LD_CompletedCutScene = new StructLogicDictionary<Int32, Boolean>();

        #endregion

        #region Source

        ILogicDictionary<Int32, Boolean> ICutSceneState.CompletedCutScene
        {
            get => LD_CompletedCutScene;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_CompletedCutScene.ToString();
            return result;
        }

        #endregion

    }
}
