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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IExplorerState : IExplorerStateClient, IExplorerState 
    {
        private ChangeStorage _storage;
        private string DataId = "explorerState";
        private ExplorerAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, ExplorerAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            Interface_StageId = new ReactiveProperty<Int32>(_StageId);
            Interface_RoomId = new ReactiveProperty<Int32>(_RoomId);
            LD_Stages?.Init($"{DataId}.stages", storage, _Stages);
            LD_Inventory?.Init($"{DataId}.inventory", storage, _Inventory);
            Interface_Position = new ReactiveProperty<ExplorerPositionData>(_Position);
            Interface_LastInteractiveId = new ReactiveProperty<Int32>(_LastInteractiveId);
            LD_PlayerBuffs?.Init($"{DataId}.player_buffs", storage, _PlayerBuffs);
            Interface_IsRun = new ReactiveProperty<Boolean>(_IsRun);
            Interface_RefreshNumber = new ReactiveProperty<Int32>(_RefreshNumber);
        }
        public void PreSave()
        {
            foreach (var temp in LD_Stages.Source)
            {
                temp.Value.PreSave();
            }
            _Stages = LD_Stages.Source;
            _Inventory = LD_Inventory.Source;
            _PlayerBuffs = LD_PlayerBuffs.Source;
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

        #region Interface

        private ReactiveProperty<Int32> Interface_StageId;
        IReadOnlyReactiveProperty<Int32> IExplorerStateClient.StageId => Interface_StageId;
        private ReactiveProperty<Int32> Interface_RoomId;
        IReadOnlyReactiveProperty<Int32> IExplorerStateClient.RoomId => Interface_RoomId;
        IReadOnlyReactiveDictionary<Int32, IStageDataClient> IExplorerStateClient.Stages => LD_Stages.Interface;
        public IReadOnlyReactiveProperty<IStageDataClient> GetStagesProperty(Int32 key)
        {
            return LD_Stages.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int32> IExplorerStateClient.Inventory => LD_Inventory.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetInventoryProperty(Int32 key)
        {
            return LD_Inventory.GetProperty(key);
        }
        private ReactiveProperty<ExplorerPositionData> Interface_Position;
        IReadOnlyReactiveProperty<ExplorerPositionData> IExplorerStateClient.Position => Interface_Position;
        private ReactiveProperty<Int32> Interface_LastInteractiveId;
        IReadOnlyReactiveProperty<Int32> IExplorerStateClient.LastInteractiveId => Interface_LastInteractiveId;
        IReadOnlyReactiveDictionary<Int32, Int32> IExplorerStateClient.PlayerBuffs => LD_PlayerBuffs.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetPlayerBuffsProperty(Int32 key)
        {
            return LD_PlayerBuffs.GetProperty(key);
        }
        private ReactiveProperty<Boolean> Interface_IsRun;
        IReadOnlyReactiveProperty<Boolean> IExplorerStateClient.IsRun => Interface_IsRun;
        private ReactiveProperty<Int32> Interface_RefreshNumber;
        IReadOnlyReactiveProperty<Int32> IExplorerStateClient.RefreshNumber => Interface_RefreshNumber;

        #endregion

        #region Internal

        [JsonName("current_stage_id")]
        public Int32 _StageId;
        [JsonName("current_room_id")]
        public Int32 _RoomId;
        [JsonName("stages")]
        public Dictionary<string, Internal_IStageData> _Stages = new Dictionary<string, Internal_IStageData>();
        private InternalLogicDictionary<Int32, Internal_IStageData, IStageData, IStageDataClient> LD_Stages = new InternalLogicDictionary<Int32, Internal_IStageData, IStageData, IStageDataClient>();
        [JsonName("inventory")]
        public Dictionary<string, Int32> _Inventory = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Inventory = new StructLogicDictionary<Int32, Int32>();
        [JsonName("position")]
        public ExplorerPositionData _Position;
        [JsonName("last_interactive_id")]
        public Int32 _LastInteractiveId;
        [JsonName("player_buffs")]
        public Dictionary<string, Int32> _PlayerBuffs = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_PlayerBuffs = new StructLogicDictionary<Int32, Int32>();
        [JsonName("isRun")]
        public Boolean _IsRun;
        [JsonName("refresh_number")]
        public Int32 _RefreshNumber;

        #endregion

        #region Source

        Int32 IExplorerState.StageId
        {
            get => _StageId;
            set
            {
                if (_StageId == value)
                {
                    return;
                }
                _StageId = value;
                var dataId = DataId + $".current_stage_id.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_StageId.Value = value; });
            }
        }
        Int32 IExplorerState.RoomId
        {
            get => _RoomId;
            set
            {
                if (_RoomId == value)
                {
                    return;
                }
                _RoomId = value;
                var dataId = DataId + $".current_room_id.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_RoomId.Value = value; });
            }
        }
        ILogicDictionary<Int32, IStageData> IExplorerState.Stages
        {
            get => LD_Stages;
        }
        ILogicDictionary<Int32, Int32> IExplorerState.Inventory
        {
            get => LD_Inventory;
        }
        ExplorerPositionData IExplorerState.Position
        {
            get => _Position;
            set
            {
                if (_Position == value)
                {
                    return;
                }
                _Position = value;
                var dataId = DataId + $".position.{value?.ToString()}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Position.Value = value; });
            }
        }
        Int32 IExplorerState.LastInteractiveId
        {
            get => _LastInteractiveId;
            set
            {
                if (_LastInteractiveId == value)
                {
                    return;
                }
                _LastInteractiveId = value;
                var dataId = DataId + $".last_interactive_id.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_LastInteractiveId.Value = value; });
            }
        }
        ILogicDictionary<Int32, Int32> IExplorerState.PlayerBuffs
        {
            get => LD_PlayerBuffs;
        }
        Boolean IExplorerState.IsRun
        {
            get => _IsRun;
            set
            {
                if (_IsRun == value)
                {
                    return;
                }
                _IsRun = value;
                var dataId = DataId + $".isRun.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_IsRun.Value = value; });
            }
        }
        Int32 IExplorerState.RefreshNumber
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
            result += _RoomId;
            result += LD_Stages.ToString();
            result += LD_Inventory.ToString();
            result += _Position?.ToString();
            result += _LastInteractiveId;
            result += LD_PlayerBuffs.ToString();
            result += _IsRun;
            result += _RefreshNumber;
            return result;
        }

        #endregion

    }
}
