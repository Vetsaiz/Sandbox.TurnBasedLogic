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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IBattleStateData : IBattleStateDataEmulate, IBattleStateData 
    , IInitStateData<IBattleStateDataClient>, IInitStateData<IBattleStateData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IBattleStateDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            Formation = client.Formation;
            Description = client.Description;
            LD_Enemies.Init(client.Enemies, storage);
            LD_Allies.Init(client.Allies, storage);
            LD_ReserveAllies.Init(client.ReserveAllies, storage);
            LD_StackMobs.Init(client.StackMobs, storage);
            client.Status.Subscribe(x => _Status = x).AddTo(_disposables);
            client.CurrentWave.Subscribe(x => _CurrentWave = x).AddTo(_disposables);
            client.CurrentId.Subscribe(x => _CurrentId = x).AddTo(_disposables);
        }

        public void InitData(IBattleStateData data, ChangeStorage storage)
        {
            _storage = storage;
            Formation = data.Formation;
            Description = data.Description;
            LD_Enemies.Init(data.Enemies, storage);
            LD_Allies.Init(data.Allies, storage);
            LD_ReserveAllies.Init(data.ReserveAllies, storage);
            LD_StackMobs.Init(data.StackMobs, storage);
            Status = data.Status;
            CurrentWave = data.CurrentWave;
            CurrentId = data.CurrentId;
        }

        #region Common

        public String Formation { get; private set; }
        public String Description { get; private set; }
        private BattleStatus _Status;
        public BattleStatus  Status
        {
            get => _Status;
               set
            {
                 var backValue = _Status;
                _storage.AddBackAction(() => _Status = backValue);
                _Status = value;
            }
        }
        private Int32 _CurrentWave;
        public Int32  CurrentWave
        {
            get => _CurrentWave;
               set
            {
                 var backValue = _CurrentWave;
                _storage.AddBackAction(() => _CurrentWave = backValue);
                _CurrentWave = value;
            }
        }
        private Int32 _CurrentId;
        public Int32  CurrentId
        {
            get => _CurrentId;
               set
            {
                 var backValue = _CurrentId;
                _storage.AddBackAction(() => _CurrentId = backValue);
                _CurrentId = value;
            }
        }

        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> IBattleStateDataEmulate.Enemies => LD_Enemies;
        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> IBattleStateDataEmulate.Allies => LD_Allies;
        IEmulateClientDictionary<Int32, IMemberBattleDataEmulate> IBattleStateDataEmulate.ReserveAllies => LD_ReserveAllies;
        IEmulateClientDictionary<Int32, IMobWaveEmulate> IBattleStateDataEmulate.StackMobs => LD_StackMobs;

        #endregion

        #region Internal

        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.Enemies => LD_Enemies;
        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.Allies => LD_Allies;
        ILogicDictionary<Int32, IMemberBattleData> IBattleStateData.ReserveAllies => LD_ReserveAllies;
        ILogicDictionary<Int32, IMobWave> IBattleStateData.StackMobs => LD_StackMobs;

        #endregion

        #region Source

        public InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate> LD_Enemies { get; } = new InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate>();
        public InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate> LD_Allies { get; } = new InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate>();
        public InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate> LD_ReserveAllies { get; } = new InternalEmulateDictionary<Int32,Emulate_IMemberBattleData, IMemberBattleData, IMemberBattleDataEmulate>();
        public InternalEmulateDictionary<Int32,Emulate_IMobWave, IMobWave, IMobWaveEmulate> LD_StackMobs { get; } = new InternalEmulateDictionary<Int32,Emulate_IMobWave, IMobWave, IMobWaveEmulate>();

        #endregion

    }
}
