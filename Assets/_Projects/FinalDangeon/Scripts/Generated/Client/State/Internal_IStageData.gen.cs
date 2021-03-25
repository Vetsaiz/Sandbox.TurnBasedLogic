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
    internal class Internal_IStageData : IStageDataClient, IStageData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "stageData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_StageId = _StageId;
            Interface_IsUnlock = new ReactiveProperty<Boolean>(_IsUnlock);
            LD_Values?.Init($"{DataId}.scorers", storage, _Values);
            LD_ObjectAvailibility?.Init($"{DataId}.interactive_objects", storage, _ObjectAvailibility);
            LD_Rooms?.Init($"{DataId}.rooms", storage, _Rooms);
            Interface_DailyNumber = new ReactiveProperty<Int32>(_DailyNumber);
            Interface_RefreshNumber = new ReactiveProperty<Int32>(_RefreshNumber);
        }
        public void PreSave()
        {
            _Values = LD_Values.Source;
            _ObjectAvailibility = LD_ObjectAvailibility.Source;
            _Rooms = LD_Rooms.Source;
        }

        #region Interface

        private Int32 Interface_StageId;
        Int32 IStageDataClient.StageId => Interface_StageId;
        private ReactiveProperty<Boolean> Interface_IsUnlock;
        IReadOnlyReactiveProperty<Boolean> IStageDataClient.IsUnlock => Interface_IsUnlock;
        IReadOnlyReactiveDictionary<Int32, Int64> IStageDataClient.Values => LD_Values.Interface;
        public IReadOnlyReactiveProperty<Int64?> GetValuesProperty(Int32 key)
        {
            return LD_Values.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, InteractiveObjectData> IStageDataClient.ObjectAvailibility => LD_ObjectAvailibility.Interface;
        public IReadOnlyReactiveProperty<InteractiveObjectData> GetObjectAvailibilityProperty(Int32 key)
        {
            return LD_ObjectAvailibility.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int32> IStageDataClient.Rooms => LD_Rooms.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetRoomsProperty(Int32 key)
        {
            return LD_Rooms.GetProperty(key);
        }
        private ReactiveProperty<Int32> Interface_DailyNumber;
        IReadOnlyReactiveProperty<Int32> IStageDataClient.DailyNumber => Interface_DailyNumber;
        private ReactiveProperty<Int32> Interface_RefreshNumber;
        IReadOnlyReactiveProperty<Int32> IStageDataClient.RefreshNumber => Interface_RefreshNumber;

        #endregion

        #region Internal

        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("unlock")]
        public Boolean _IsUnlock;
        [JsonName("scorers")]
        public Dictionary<string, Int64> _Values = new Dictionary<string, Int64>();
        private StructLogicDictionary<Int32, Int64> LD_Values = new StructLogicDictionary<Int32, Int64>();
        [JsonName("interactive_objects")]
        public Dictionary<string, InteractiveObjectData> _ObjectAvailibility = new Dictionary<string, InteractiveObjectData>();
        private ReferenceLogicDictionary<Int32, InteractiveObjectData> LD_ObjectAvailibility = new ReferenceLogicDictionary<Int32, InteractiveObjectData>();
        [JsonName("rooms")]
        public Dictionary<string, Int32> _Rooms = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Rooms = new StructLogicDictionary<Int32, Int32>();
        [JsonName("daily_number")]
        public Int32 _DailyNumber;
        [JsonName("refresh_number")]
        public Int32 _RefreshNumber;

        #endregion

        #region Source

        Int32 IStageData.StageId
        {
            get => _StageId;
        }
        Boolean IStageData.IsUnlock
        {
            get => _IsUnlock;
            set
            {
                if (_IsUnlock == value)
                {
                    return;
                }
                _IsUnlock = value;
                var dataId = DataId + $".unlock.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_IsUnlock.Value = value; });
            }
        }
        ILogicDictionary<Int32, Int64> IStageData.Values
        {
            get => LD_Values;
        }
        ILogicDictionary<Int32, InteractiveObjectData> IStageData.ObjectAvailibility
        {
            get => LD_ObjectAvailibility;
        }
        ILogicDictionary<Int32, Int32> IStageData.Rooms
        {
            get => LD_Rooms;
        }
        Int32 IStageData.DailyNumber
        {
            get => _DailyNumber;
            set
            {
                if (_DailyNumber == value)
                {
                    return;
                }
                _DailyNumber = value;
                var dataId = DataId + $".daily_number.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_DailyNumber.Value = value; });
            }
        }
        Int32 IStageData.RefreshNumber
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

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _StageId;
            result += _IsUnlock;
            result += LD_Values.ToString();
            result += LD_ObjectAvailibility.ToString();
            result += LD_Rooms.ToString();
            result += _DailyNumber;
            result += _RefreshNumber;
            return result;
        }

        #endregion

    }
}
