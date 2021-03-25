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
    internal class Internal_IBattleState : IBattleStateClient, IBattleState 
    {
        private ChangeStorage _storage;
        private string DataId = "battleState";
        private BattleAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, BattleAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _Data?.InitData(DataId, storage);
            Interface_Data = new ReactiveProperty<IBattleStateDataClient>(_Data);
        }
        public void PreSave()
        {
            _Data?.PreSave();
        }

        #region Queries

        public IBattleStatic StaticStatic => _accessor.Static;

        #endregion

        #region Interface

        private ReactiveProperty<IBattleStateDataClient> Interface_Data;
        IReadOnlyReactiveProperty<IBattleStateDataClient> IBattleStateClient.Data => Interface_Data;

        #endregion

        #region Internal

        [JsonName("data")]
        public Internal_IBattleStateData _Data;

        #endregion

        #region Source

        IBattleStateData IBattleState.Data
        {
            get => _Data;
            set
            {
                var castValue = (Internal_IBattleStateData) value;
                if (_storage != null)
                {
                    castValue?.PreSave();
                    castValue?.InitData(DataId, _storage);
                }
                _Data = castValue;
                _storage?.AddChange(this, DataId + $".data.{castValue?.ToString()}", () => Interface_Data.Value = castValue);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Data?.ToString();
            return result;
        }

        #endregion

    }
}
