using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;

using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using VetsEngine.MetaLogic.Contracts;


namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IStageData : IStageDataEmulate, IStageData 
    , IInitStateData<IStageDataClient>, IInitStateData<IStageData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IStageDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            StageId = client.StageId;
            client.IsUnlock.Subscribe(x => _IsUnlock = x).AddTo(_disposables);
            LD_Values.Init(client.Values, storage);
            LD_ObjectAvailibility.Init(client.ObjectAvailibility, storage);
            LD_Rooms.Init(client.Rooms, storage);
            client.DailyNumber.Subscribe(x => _DailyNumber = x).AddTo(_disposables);
            client.RefreshNumber.Subscribe(x => _RefreshNumber = x).AddTo(_disposables);
        }

        public void InitData(IStageData data, ChangeStorage storage)
        {
            _storage = storage;
            StageId = data.StageId;
            IsUnlock = data.IsUnlock;
            LD_Values.Init(data.Values, storage);
            LD_ObjectAvailibility.Init(data.ObjectAvailibility, storage);
            LD_Rooms.Init(data.Rooms, storage);
            DailyNumber = data.DailyNumber;
            RefreshNumber = data.RefreshNumber;
        }

        #region Common

        public Int32 StageId { get; private set; }
        private Boolean _IsUnlock;
        public Boolean  IsUnlock
        {
            get => _IsUnlock;
               set
            {
                 var backValue = _IsUnlock;
                _storage.AddBackAction(() => _IsUnlock = backValue);
                _IsUnlock = value;
            }
        }
        private Int32 _DailyNumber;
        public Int32  DailyNumber
        {
            get => _DailyNumber;
               set
            {
                 var backValue = _DailyNumber;
                _storage.AddBackAction(() => _DailyNumber = backValue);
                _DailyNumber = value;
            }
        }
        private Int32 _RefreshNumber;
        public Int32  RefreshNumber
        {
            get => _RefreshNumber;
               set
            {
                 var backValue = _RefreshNumber;
                _storage.AddBackAction(() => _RefreshNumber = backValue);
                _RefreshNumber = value;
            }
        }

        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, Int64> IStageDataEmulate.Values => LD_Values;
        IEmulateClientDictionary<Int32, InteractiveObjectData> IStageDataEmulate.ObjectAvailibility => LD_ObjectAvailibility;
        IEmulateClientDictionary<Int32, Int32> IStageDataEmulate.Rooms => LD_Rooms;

        #endregion

        #region Internal

        ILogicDictionary<Int32, Int64> IStageData.Values => LD_Values;
        ILogicDictionary<Int32, InteractiveObjectData> IStageData.ObjectAvailibility => LD_ObjectAvailibility;
        ILogicDictionary<Int32, Int32> IStageData.Rooms => LD_Rooms;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, Int64> LD_Values { get; } = new ValueEmulateDictionary<Int32, Int64>();
        public ValueEmulateDictionary<Int32, InteractiveObjectData> LD_ObjectAvailibility { get; } = new ValueEmulateDictionary<Int32, InteractiveObjectData>();
        public ValueEmulateDictionary<Int32, Int32> LD_Rooms { get; } = new ValueEmulateDictionary<Int32, Int32>();

        #endregion

    }
}
