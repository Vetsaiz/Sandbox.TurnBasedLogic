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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IBattleStateData : IBattleStateDataClient, IBattleStateData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "battleStateData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_Formation = _Formation;
            Interface_Description = _Description;
            LD_Enemies?.Init($"{DataId}.current_mobs", storage, _Enemies);
            LD_Allies?.Init($"{DataId}.current_units", storage, _Allies);
            LD_ReserveAllies?.Init($"{DataId}.researve_units", storage, _ReserveAllies);
            LD_StackMobs?.Init($"{DataId}.stack_mobs", storage, _StackMobs);
            Interface_Status = new ReactiveProperty<BattleStatus>(_Status);
            Interface_CurrentWave = new ReactiveProperty<Int32>(_CurrentWave);
            Interface_CurrentId = new ReactiveProperty<Int32>(_CurrentId);
        }
        public void PreSave()
        {
            foreach (var temp in LD_Enemies.Source)
            {
                temp.Value.PreSave();
            }
            _Enemies = LD_Enemies.Source;
            foreach (var temp in LD_Allies.Source)
            {
                temp.Value.PreSave();
            }
            _Allies = LD_Allies.Source;
            foreach (var temp in LD_ReserveAllies.Source)
            {
                temp.Value.PreSave();
            }
            _ReserveAllies = LD_ReserveAllies.Source;
            foreach (var temp in LD_StackMobs.Source)
            {
                temp.Value.PreSave();
            }
            _StackMobs = LD_StackMobs.Source;
        }

        #region Interface

        private String Interface_Formation;
        String IBattleStateDataClient.Formation => Interface_Formation;
        private String Interface_Description;
        String IBattleStateDataClient.Description => Interface_Description;
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> IBattleStateDataClient.Enemies => LD_Enemies.Interface;
        public IReadOnlyReactiveProperty<IMemberBattleDataClient> GetEnemiesProperty(Int32 key)
        {
            return LD_Enemies.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> IBattleStateDataClient.Allies => LD_Allies.Interface;
        public IReadOnlyReactiveProperty<IMemberBattleDataClient> GetAlliesProperty(Int32 key)
        {
            return LD_Allies.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, IMemberBattleDataClient> IBattleStateDataClient.ReserveAllies => LD_ReserveAllies.Interface;
        public IReadOnlyReactiveProperty<IMemberBattleDataClient> GetReserveAlliesProperty(Int32 key)
        {
            return LD_ReserveAllies.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, IMobWaveClient> IBattleStateDataClient.StackMobs => LD_StackMobs.Interface;
        public IReadOnlyReactiveProperty<IMobWaveClient> GetStackMobsProperty(Int32 key)
        {
            return LD_StackMobs.GetProperty(key);
        }
        private ReactiveProperty<BattleStatus> Interface_Status;
        IReadOnlyReactiveProperty<BattleStatus> IBattleStateDataClient.Status => Interface_Status;
        private ReactiveProperty<Int32> Interface_CurrentWave;
        IReadOnlyReactiveProperty<Int32> IBattleStateDataClient.CurrentWave => Interface_CurrentWave;
        private ReactiveProperty<Int32> Interface_CurrentId;
        IReadOnlyReactiveProperty<Int32> IBattleStateDataClient.CurrentId => Interface_CurrentId;

        #endregion

        #region Internal

        [JsonName("formation")]
        public String _Formation;
        [JsonName("description")]
        public String _Description;
        [JsonName("current_mobs")]
        public Dictionary<string, Internal_IMemberBattleData> _Enemies = new Dictionary<string, Internal_IMemberBattleData>();
        private InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient> LD_Enemies = new InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient>();
        [JsonName("current_units")]
        public Dictionary<string, Internal_IMemberBattleData> _Allies = new Dictionary<string, Internal_IMemberBattleData>();
        private InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient> LD_Allies = new InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient>();
        [JsonName("researve_units")]
        public Dictionary<string, Internal_IMemberBattleData> _ReserveAllies = new Dictionary<string, Internal_IMemberBattleData>();
        private InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient> LD_ReserveAllies = new InternalLogicDictionary<Int32, Internal_IMemberBattleData, IMemberBattleData, IMemberBattleDataClient>();
        [JsonName("stack_mobs")]
        public Dictionary<string, Internal_IMobWave> _StackMobs = new Dictionary<string, Internal_IMobWave>();
        private InternalLogicDictionary<Int32, Internal_IMobWave, IMobWave, IMobWaveClient> LD_StackMobs = new InternalLogicDictionary<Int32, Internal_IMobWave, IMobWave, IMobWaveClient>();
        [JsonName("is_victory")]
        public BattleStatus _Status;
        [JsonName("current_wave")]
        public Int32 _CurrentWave;
        [JsonName("current_id")]
        public Int32 _CurrentId;

        #endregion

        #region Source

        String IBattleStateData.Formation
        {
            get => _Formation;
        }
        String IBattleStateData.Description
        {
            get => _Description;
        }
        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.Enemies
        {
            get => LD_Enemies;
        }
        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.Allies
        {
            get => LD_Allies;
        }
        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.ReserveAllies
        {
            get => LD_ReserveAllies;
        }
        ILogicDictionary<Int32, IMobWave> IBattleStateData.StackMobs
        {
            get => LD_StackMobs;
        }
        BattleStatus IBattleStateData.Status
        {
            get => _Status;
            set
            {
                if (_Status == value)
                {
                    return;
                }
                _Status = value;
                var dataId = DataId + $".is_victory.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Status.Value = value; });
            }
        }
        Int32 IBattleStateData.CurrentWave
        {
            get => _CurrentWave;
            set
            {
                if (_CurrentWave == value)
                {
                    return;
                }
                _CurrentWave = value;
                var dataId = DataId + $".current_wave.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CurrentWave.Value = value; });
            }
        }
        Int32 IBattleStateData.CurrentId
        {
            get => _CurrentId;
            set
            {
                if (_CurrentId == value)
                {
                    return;
                }
                _CurrentId = value;
                var dataId = DataId + $".current_id.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CurrentId.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Formation;
            result += _Description;
            result += LD_Enemies.ToString();
            result += LD_Allies.ToString();
            result += LD_ReserveAllies.ToString();
            result += LD_StackMobs.ToString();
            result += _Status;
            result += _CurrentWave;
            result += _CurrentId;
            return result;
        }

        #endregion

    }
}
