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
    internal class Internal_IAchievementData : IAchievementDataClient, IAchievementData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "achievementData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_RefreshNumber = new ReactiveProperty<Int32>(_RefreshNumber);
            Interface_FinishTime = new ReactiveProperty<Int64>(_FinishTime);
            Interface_Complete = new ReactiveProperty<Boolean>(_Complete);
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<Int32> Interface_RefreshNumber;
        IReadOnlyReactiveProperty<Int32> IAchievementDataClient.RefreshNumber => Interface_RefreshNumber;
        private ReactiveProperty<Int64> Interface_FinishTime;
        IReadOnlyReactiveProperty<Int64> IAchievementDataClient.FinishTime => Interface_FinishTime;
        private ReactiveProperty<Boolean> Interface_Complete;
        IReadOnlyReactiveProperty<Boolean> IAchievementDataClient.Complete => Interface_Complete;

        #endregion

        #region Internal

        [JsonName("refresh_number")]
        public Int32 _RefreshNumber;
        [JsonName("refresh_time")]
        public Int64 _FinishTime;
        [JsonName("complete")]
        public Boolean _Complete;

        #endregion

        #region Source

        Int32 IAchievementData.RefreshNumber
        {
            get => _RefreshNumber;
            set
            {
                if (_RefreshNumber == value)
                {
                    return;
                }
                _RefreshNumber = value;
                var dataId = DataId + $".refresh_number.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_RefreshNumber.Value = value; });
            }
        }
        Int64 IAchievementData.FinishTime
        {
            get => _FinishTime;
            set
            {
                if (_FinishTime == value)
                {
                    return;
                }
                _FinishTime = value;
                var dataId = DataId + $".refresh_time.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_FinishTime.Value = value; });
            }
        }
        Boolean IAchievementData.Complete
        {
            get => _Complete;
            set
            {
                if (_Complete == value)
                {
                    return;
                }
                _Complete = value;
                var dataId = DataId + $".complete.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Complete.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _RefreshNumber;
            result += _FinishTime;
            result += _Complete;
            return result;
        }

        #endregion

    }
}
