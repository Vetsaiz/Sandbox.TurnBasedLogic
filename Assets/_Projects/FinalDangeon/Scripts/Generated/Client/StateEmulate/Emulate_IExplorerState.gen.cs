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
    internal class Emulate_IExplorerState : IExplorerStateEmulate, IExplorerState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private ExplorerAccessor _accessor;
        public void InitData(IExplorerStateClient client, ExplorerAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.StageId.Subscribe(x => _StageId = x).AddTo(_disposables);
            client.RoomId.Subscribe(x => _RoomId = x).AddTo(_disposables);
            LD_Stages.Init(client.Stages, storage);
            LD_Inventory.Init(client.Inventory, storage);
            client.Position.Subscribe(x => _Position = x).AddTo(_disposables);
            client.LastInteractiveId.Subscribe(x => _LastInteractiveId = x).AddTo(_disposables);
            LD_PlayerBuffs.Init(client.PlayerBuffs, storage);
            client.IsRun.Subscribe(x => _IsRun = x).AddTo(_disposables);
            client.RefreshNumber.Subscribe(x => _RefreshNumber = x).AddTo(_disposables);
        }


        #region Queries

        public Int32 GetCountInteractive(System.Int32 stageId)
        {
            return _accessor.GetCountInteractive(stageId);
        }
        public IExplorerStatic StaticStatic => _accessor.Static;
        public IReadOnlyDictionary<Int32, IInteractiveObject> ObjectsStatic => _accessor.Objects;
        public IReadOnlyDictionary<Int32, IRoom> RoomsStatic => _accessor.Rooms;
        public IReadOnlyDictionary<Int32, IStage> StagesStatic => _accessor.Stages;
        public IReadOnlyDictionary<Int32, IZone> ZonesStatic => _accessor.Zones;

        #endregion

        #region Common

        private Int32 _StageId;
        public Int32  StageId
        {
            get => _StageId;
               set
            {
                 var backValue = _StageId;
                _storage.AddBackAction(() => _StageId = backValue);
                _StageId = value;
            }
        }
        private Int32 _RoomId;
        public Int32  RoomId
        {
            get => _RoomId;
               set
            {
                 var backValue = _RoomId;
                _storage.AddBackAction(() => _RoomId = backValue);
                _RoomId = value;
            }
        }
        private ExplorerPositionData _Position;
        public ExplorerPositionData  Position
        {
            get => _Position;
               set
            {
                 var backValue = _Position;
                _storage.AddBackAction(() => _Position = backValue);
                _Position = value;
            }
        }
        private Int32 _LastInteractiveId;
        public Int32  LastInteractiveId
        {
            get => _LastInteractiveId;
               set
            {
                 var backValue = _LastInteractiveId;
                _storage.AddBackAction(() => _LastInteractiveId = backValue);
                _LastInteractiveId = value;
            }
        }
        private Boolean _IsRun;
        public Boolean  IsRun
        {
            get => _IsRun;
               set
            {
                 var backValue = _IsRun;
                _storage.AddBackAction(() => _IsRun = backValue);
                _IsRun = value;
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

        IEmulateClientDictionary<Int32, IStageDataEmulate> IExplorerStateEmulate.Stages => LD_Stages;
        IEmulateClientDictionary<Int32, Int32> IExplorerStateEmulate.Inventory => LD_Inventory;
        IEmulateClientDictionary<Int32, Int32> IExplorerStateEmulate.PlayerBuffs => LD_PlayerBuffs;

        #endregion

        #region Internal

        ILogicDictionary<Int32, IStageData> IExplorerState.Stages => LD_Stages;
        ILogicDictionary<Int32, Int32> IExplorerState.Inventory => LD_Inventory;
        ILogicDictionary<Int32, Int32> IExplorerState.PlayerBuffs => LD_PlayerBuffs;

        #endregion

        #region Source

        public InternalEmulateDictionary<Int32,Emulate_IStageData, IStageData, IStageDataEmulate> LD_Stages { get; } = new InternalEmulateDictionary<Int32,Emulate_IStageData, IStageData, IStageDataEmulate>();
        public ValueEmulateDictionary<Int32, Int32> LD_Inventory { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int32> LD_PlayerBuffs { get; } = new ValueEmulateDictionary<Int32, Int32>();

        #endregion

    }
}
