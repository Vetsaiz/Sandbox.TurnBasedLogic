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
    internal class Internal_IGoodSlotItem : IGoodSlotItemClient, IGoodSlotItem 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "goodSlotItem";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_GoodId = _GoodId;
            Interface_IsBuy = new ReactiveProperty<Boolean>(_IsBuy);
            Interface_WaitTime = new ReactiveProperty<Int64>(_WaitTime);
        }
        public void PreSave()
        {
        }

        #region Interface

        private Int32 Interface_GoodId;
        Int32 IGoodSlotItemClient.GoodId => Interface_GoodId;
        private ReactiveProperty<Boolean> Interface_IsBuy;
        IReadOnlyReactiveProperty<Boolean> IGoodSlotItemClient.IsBuy => Interface_IsBuy;
        private ReactiveProperty<Int64> Interface_WaitTime;
        IReadOnlyReactiveProperty<Int64> IGoodSlotItemClient.WaitTime => Interface_WaitTime;

        #endregion

        #region Internal

        [JsonName("good_id")]
        public Int32 _GoodId;
        [JsonName("buy")]
        public Boolean _IsBuy;
        [JsonName("refresh_time")]
        public Int64 _WaitTime;

        #endregion

        #region Source

        Int32 IGoodSlotItem.GoodId
        {
            get => _GoodId;
        }
        Boolean IGoodSlotItem.IsBuy
        {
            get => _IsBuy;
            set
            {
                if (_IsBuy == value)
                {
                    return;
                }
                _IsBuy = value;
                var dataId = DataId + $".buy.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_IsBuy.Value = value; });
            }
        }
        Int64 IGoodSlotItem.WaitTime
        {
            get => _WaitTime;
            set
            {
                if (_WaitTime == value)
                {
                    return;
                }
                _WaitTime = value;
                var dataId = DataId + $".refresh_time.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_WaitTime.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _GoodId;
            result += _IsBuy;
            result += _WaitTime;
            return result;
        }

        #endregion

    }
}
