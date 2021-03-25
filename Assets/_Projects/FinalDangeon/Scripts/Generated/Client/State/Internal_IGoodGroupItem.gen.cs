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
    internal class Internal_IGoodGroupItem : IGoodGroupItemClient, IGoodGroupItem 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "goodGroupItem";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _CurrentSlots?.InitData(DataId, storage);
            Interface_CurrentSlots = new ReactiveProperty<IGoodGroupSlotItemClient>(_CurrentSlots);
            Interface_RefreshNumber = new ReactiveProperty<Int32>(_RefreshNumber);
            Interface_FinishTime = new ReactiveProperty<Int64>(_FinishTime);
        }
        public void PreSave()
        {
            _CurrentSlots?.PreSave();
        }

        #region Interface

        private ReactiveProperty<IGoodGroupSlotItemClient> Interface_CurrentSlots;
        IReadOnlyReactiveProperty<IGoodGroupSlotItemClient> IGoodGroupItemClient.CurrentSlots => Interface_CurrentSlots;
        private ReactiveProperty<Int32> Interface_RefreshNumber;
        IReadOnlyReactiveProperty<Int32> IGoodGroupItemClient.RefreshNumber => Interface_RefreshNumber;
        private ReactiveProperty<Int64> Interface_FinishTime;
        IReadOnlyReactiveProperty<Int64> IGoodGroupItemClient.FinishTime => Interface_FinishTime;

        #endregion

        #region Internal

        [JsonName("slots")]
        public Internal_IGoodGroupSlotItem _CurrentSlots;
        [JsonName("refresh_number")]
        public Int32 _RefreshNumber;
        [JsonName("refresh_time")]
        public Int64 _FinishTime;

        #endregion

        #region Source

        IGoodGroupSlotItem IGoodGroupItem.CurrentSlots
        {
            get => _CurrentSlots;
            set
            {
                var castValue = (Internal_IGoodGroupSlotItem) value;
                if (_storage != null)
                {
                    castValue?.PreSave();
                    castValue?.InitData(DataId, _storage);
                }
                _CurrentSlots = castValue;
                _storage?.AddChange(this, DataId + $".slots.{castValue?.ToString()}", () => Interface_CurrentSlots.Value = castValue);
            }
        }
        Int32 IGoodGroupItem.RefreshNumber
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
        Int64 IGoodGroupItem.FinishTime
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

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _CurrentSlots?.ToString();
            result += _RefreshNumber;
            result += _FinishTime;
            return result;
        }

        #endregion

    }
}
