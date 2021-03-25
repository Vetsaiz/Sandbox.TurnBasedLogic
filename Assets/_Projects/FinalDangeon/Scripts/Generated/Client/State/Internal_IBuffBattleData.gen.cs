using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IBuffBattleData : IBuffBattleDataClient, IBuffBattleData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "buffBattleData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_CountStack = new ReactiveProperty<Int32>(_CountStack);
            Interface_NeededRemove = new ReactiveProperty<Boolean>(_NeededRemove);
            Interface_OwnerId = _OwnerId;
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<Int32> Interface_CountStack;
        IReadOnlyReactiveProperty<Int32> IBuffBattleDataClient.CountStack => Interface_CountStack;
        private ReactiveProperty<Boolean> Interface_NeededRemove;
        IReadOnlyReactiveProperty<Boolean> IBuffBattleDataClient.NeededRemove => Interface_NeededRemove;
        private Int32 Interface_OwnerId;
        Int32 IBuffBattleDataClient.OwnerId => Interface_OwnerId;

        #endregion

        #region Internal

        [JsonName("count_stack")]
        public Int32 _CountStack;
        [JsonName("needed_remove")]
        public Boolean _NeededRemove;
        [JsonName("owner_id")]
        public Int32 _OwnerId;

        #endregion

        #region Source

        Int32 IBuffBattleData.CountStack
        {
            get => _CountStack;
            set
            {
                if (_CountStack == value)
                {
                    return;
                }
                _CountStack = value;
                var dataId = DataId + $".count_stack.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CountStack.Value = value; });
            }
        }
        Boolean IBuffBattleData.NeededRemove
        {
            get => _NeededRemove;
            set
            {
                if (_NeededRemove == value)
                {
                    return;
                }
                _NeededRemove = value;
                var dataId = DataId + $".needed_remove.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_NeededRemove.Value = value; });
            }
        }
        Int32 IBuffBattleData.OwnerId
        {
            get => _OwnerId;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _CountStack;
            result += _NeededRemove;
            result += _OwnerId;
            return result;
        }

        #endregion

    }
}
